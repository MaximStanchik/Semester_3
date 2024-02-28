#include "stdafx.h"

void SerealizeData(const string& serializedData, int needToCleanTheFile)
{
    ofstream serializationFile("LiteralInfo.bin", ofstream::app);
    if (!serializationFile)
    {
        cout << "Ошибка открытия файла." << endl;
        return;
    }

    if (needToCleanTheFile == 1) {
        serializationFile.close();
        serializationFile.open("LiteralInfo.bin", ofstream::out | ofstream::trunc);
    }

    cout << "Содержимое файла LiteralInfo.bin успешно изменено" << endl;

    serializationFile << serializedData;

    int number = 0;

    serializationFile.close();
}
    









