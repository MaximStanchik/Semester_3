#include "stdafx.h"

bool CheckAddress(const char* ip_) {
	int points{};
	int numbers{};
	char* buff = new char[4];
	for (int i = 0; ip_[i] != '\0'; i++) {
		if (ip_[i] <= '9' && ip_[i] >= '0') {
			if (numbers > 3) {
				delete[] buff;
				return false;
			}
			buff[numbers++] = ip_[i];
		}
		else if (ip_[i] == '.') {
			if (stoi(buff) > 255) {
				delete[] buff;
				return false;
			}
			if (numbers == 0) {
				delete[] buff;
				return false;
			}
			numbers = 0;
			points++;
		}
		else {
			delete[] buff;
			return false;
		}
	}

	delete[] buff;

	if (points != 3)
		return false;
	if (numbers == 0 || numbers > 3)
		return false;

	string ip(ip_);
	if (ip.find('/') != string::npos) {
		int subnetLength = stoi(ip.substr(ip.find('/') + 1));
		if (subnetLength > 32)
			return false;
	}

	return true;
}