#include "stdafx.h"
#include "Serializer.h"
#include "GettingDataAboutLiteral.h"

int main() {
    setlocale(LC_ALL, "Rus");

    int needToCleanTheFile{};
    int choiceOfAction{};
    unsigned int numberOfunsignedIntTypeEnteredByUser{};
    int numberOfIntTypeEnteredByUser{};

    cout << "������� ������������� ����� �����: ";
    cin >> numberOfunsignedIntTypeEnteredByUser;
    cout << "������� ����� �����: ";
    cin >> numberOfIntTypeEnteredByUser;
    cout << endl;
    cout << "unsigned int -- 0" << endl;
    cout << "int          -- 1" << endl << endl;
    string serializedDataOfUnsignedIntLiteral = getDataAboutAFundamentalTypeLiteral(numberOfunsignedIntTypeEnteredByUser);
    string serializedDataOfIntLiteral = getDataAboutAFundamentalTypeLiteral(numberOfIntTypeEnteredByUser);
enteringValue:
    cout << "����� �������� ����, ���������� ����������?" << endl;
    cout << "1--�������� ���� ����� ����������� ������������" << endl;
    cout << "2--�� ������� ���� ����� ����������� ������������" << endl;
    cin >> choiceOfAction;
    if (choiceOfAction == 1) {
        cout << "����, ���������� ����������, ����� ������ ����� ����������� ������������" << endl;
        SerealizeData(serializedDataOfUnsignedIntLiteral, 1);
        SerealizeData(serializedDataOfIntLiteral, 0);
    }
    else if (choiceOfAction == 2) {
        cout << "����, ���������� ����������, �� ����� ������ ����� ����������� ������������" << endl;
        SerealizeData(serializedDataOfUnsignedIntLiteral, 0);
        SerealizeData(serializedDataOfIntLiteral, 0);
    }
    else {
        cout << "������� �������� ��������. ������� ��� ��� ���." << endl;
        goto enteringValue;
    }

    system("pause");
    return 0;
}