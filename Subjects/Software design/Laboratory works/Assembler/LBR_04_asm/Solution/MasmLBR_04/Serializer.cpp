#include "stdafx.h"

void SerealizeData(const string& serializedData, int needToCleanTheFile)
{
    ofstream serializationFile("LiteralInfo.bin", ofstream::app);
    if (!serializationFile)
    {
        cout << "������ �������� �����." << endl;
        return;
    }

    if (needToCleanTheFile == 1) {
        serializationFile.close();
        serializationFile.open("LiteralInfo.bin", ofstream::out | ofstream::trunc);
    }

    cout << "���������� ����� LiteralInfo.bin ������� ��������" << endl;

    serializationFile << serializedData;

    int number = 0;

    serializationFile.close();
}
    









