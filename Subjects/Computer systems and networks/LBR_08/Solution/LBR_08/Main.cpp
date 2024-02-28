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
	cout << "Введите, пожалуйста, IP-адрес:" << endl;
	cin >> IPAddress;
	if (CheckAddress(IPAddress.c_str()) == true) {
		IPAddressValue = std::stoul(IPAddress);
	}
	else {
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

enteringTheSubnetMaskValue:
	cout << "Введите, пожалуйста, маску подсети:" << endl;
	cin >> SubnetMask;
	if (CheckAddress(SubnetMask.c_str()) == true) {
		SubnetMaskValue = std::stoul(SubnetMask);
	}
	else {
		cout << "Вы ввели неверное значение для маски подсети." << endl;
		cout << "1--Ввести значение для маски подсети заново." << endl;
		cout << "2--Выход из программы" << endl;
		int selectingTheIPAddressValueEntry{};
		cin >> selectingTheIPAddressValueEntry;
		switch (selectingTheIPAddressValueEntry) {
		case 1: {
			goto enteringTheSubnetMaskValue;
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

	cout << "Проверка маски подсети на непрерывность единиц:" << endl;

	if (checkSubnetMask(SubnetMask)) {
		cout << "Маска подсети является непрерывной." << endl;
	}
	else {
		cout << "Маска подсети не является непрерывной." << endl;
	}


	cout << "Полученный ID подсети: " << getSubnetID(IPAddressValue, SubnetMaskValue) << endl;
	cout << "Полученный ID хоста: " << getHostID(IPAddressValue, SubnetMaskValue) << endl;
	cout << "Полученный Broadcast адрес: " << getBroadcastAdress(IPAddressValue, SubnetMaskValue) << endl;

	system("pause");
	return 0;
}