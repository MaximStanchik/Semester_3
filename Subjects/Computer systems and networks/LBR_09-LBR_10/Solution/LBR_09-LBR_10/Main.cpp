#include "Stdafx.h"
#include "CheckingIPandMask.h"

struct NetworkSettings {
	string OriginalIPAddress;
	string OriginalMACAddress;
	string DNSname;
	unsigned long IPAddressValue;
	unsigned long SubnetMaskValue;
};

int main() {
	WSADATA WsaData;
	struct hostent* dns;
	struct hostent* netbios;
	char* host = new char[16];
	int i = 0;
	bool flag = true;
	bool is_ip = true;
	in_addr addr;
	if (WSAStartup(0x0202, &WsaData) == NULL)
		cout << "WSA done!" << endl;
	NetworkSettings network;
	cout << "Выберите действие: " << endl;
	cout << "1 -- Ввести IP-адрес и определить MAC-адрес" << endl;
	cout << "2 -- Ввести MAC-адрес и определить IP-адрес" << endl;
	cout << "0 -- Выход из программы" << endl;
	int choiseOfInput{};
	cin >> choiseOfInput;
	switch (choiseOfInput) {
	case 0: {
		cout << "Выход из программы" << endl;
		return 0;
		break;
	}
	case 1: {
enteringTheIPAddressValue:
		cout << "Введите IP-адрес:" << endl;
		cin >> network.OriginalIPAddress;
		if (CheckAddress(network.OriginalIPAddress.c_str()) == true) {
			network.IPAddressValue = stoul(network.OriginalIPAddress);
		}
		else if (!flag && CheckAddress(network.OriginalIPAddress.c_str()) == false) {
			cout << "Вы ввели неверное значение для IP-адреса." << endl;
			cout << "1--Ввести значение для IP-адреса заново." << endl;
			cout << "2--Выход из программы" << endl;
			int selectingTheIPAddressValueEntry{};
			cin >> selectingTheIPAddressValueEntry;
			switch (selectingTheIPAddressValueEntry) {
			case 1: {
				goto enteringTheIPAddressValue;
			}
			case 2: {
				cout << "Выход из программы" << endl;
				return 0;
			}
			default: {
				cout << "Введено неверное значение. Автоматический выход из программы." << endl;
				return 0;
			}
			}
		}
		break;
	}
	case 2: {
		cout << "Введите MAC-адрес:" << endl;
		cin >> network.OriginalMACAddress;
		break;
	}
	default: {
		cout << "Введено неверное значение." << endl;
		cout << "Автоматический выход из программы." << endl;
		return 0;
		break;
	}
	}
	cout << "Введите DNS-имя:" << endl;
	system("pause");
	return 0;
}