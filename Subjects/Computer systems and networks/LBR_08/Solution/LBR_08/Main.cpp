#include "stdafx.h"
#include "GettingIPAdresses.h"
#include "CheckingAddress.h"
#include "ConvertationToAnotherDataType.h"
#include "CheckingSubnetMask.h"

int main() {
	setlocale(LC_ALL, "Rus");

	string IPAddress{};
	string SubnetMask{};

	unsigned long IPAddressValue = 0;
	unsigned long SubnetMaskValue = 0;

	string SubnetID{};
	string HostID{};

	unsigned long BroadcastAdress{};
enteringTheIPAddressValue:
	cout << "�������, ����������, IP-�����:" << endl;
	cin >> IPAddress;
	if (CheckAddress(IPAddress.c_str()) == true) {
		IPAddressValue = std::stoul(IPAddress);
	}
	else {
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

enteringTheSubnetMaskValue:
	cout << "�������, ����������, ����� �������:" << endl;
	cin >> SubnetMask;
	if (CheckAddress(SubnetMask.c_str()) == true) {
		SubnetMaskValue = std::stoul(SubnetMask);
	}
	else {
		cout << "�� ����� �������� �������� ��� ����� �������." << endl;
		cout << "1--������ �������� ��� ����� ������� ������." << endl;
		cout << "2--����� �� ���������" << endl;
		int selectingTheIPAddressValueEntry{};
		cin >> selectingTheIPAddressValueEntry;
		switch (selectingTheIPAddressValueEntry) {
		case 1: {
			goto enteringTheSubnetMaskValue;
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

	cout << "�������� ����� ������� �� ������������� ������:" << endl;

	if (checkSubnetMask(SubnetMask)) {
		cout << "����� ������� �������� �����������." << endl;
	}
	else {
		cout << "����� ������� �� �������� �����������." << endl;
	}


	cout << "���������� ID �������: " << getSubnetID(IPAddressValue, SubnetMaskValue) << endl;
	cout << "���������� ID �����: " << getHostID(IPAddressValue, SubnetMaskValue) << endl;
	cout << "���������� Broadcast �����: " << getBroadcastAdress(IPAddressValue, SubnetMaskValue) << endl;

	system("pause");
	return 0;
}