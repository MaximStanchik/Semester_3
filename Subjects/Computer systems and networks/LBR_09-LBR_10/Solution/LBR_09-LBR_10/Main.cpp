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
	cout << "�������� ��������: " << endl;
	cout << "1 -- ������ IP-����� � ���������� MAC-�����" << endl;
	cout << "2 -- ������ MAC-����� � ���������� IP-�����" << endl;
	cout << "0 -- ����� �� ���������" << endl;
	int choiseOfInput{};
	cin >> choiseOfInput;
	switch (choiseOfInput) {
	case 0: {
		cout << "����� �� ���������" << endl;
		return 0;
		break;
	}
	case 1: {
enteringTheIPAddressValue:
		cout << "������� IP-�����:" << endl;
		cin >> network.OriginalIPAddress;
		if (CheckAddress(network.OriginalIPAddress.c_str()) == true) {
			network.IPAddressValue = stoul(network.OriginalIPAddress);
		}
		else if (!flag && CheckAddress(network.OriginalIPAddress.c_str()) == false) {
			cout << "�� ����� �������� �������� ��� IP-������." << endl;
			cout << "1--������ �������� ��� IP-������ ������." << endl;
			cout << "2--����� �� ���������" << endl;
			int selectingTheIPAddressValueEntry{};
			cin >> selectingTheIPAddressValueEntry;
			switch (selectingTheIPAddressValueEntry) {
			case 1: {
				goto enteringTheIPAddressValue;
			}
			case 2: {
				cout << "����� �� ���������" << endl;
				return 0;
			}
			default: {
				cout << "������� �������� ��������. �������������� ����� �� ���������." << endl;
				return 0;
			}
			}
		}
		break;
	}
	case 2: {
		cout << "������� MAC-�����:" << endl;
		cin >> network.OriginalMACAddress;
		break;
	}
	default: {
		cout << "������� �������� ��������." << endl;
		cout << "�������������� ����� �� ���������." << endl;
		return 0;
		break;
	}
	}
	cout << "������� DNS-���:" << endl;
	system("pause");
	return 0;
}