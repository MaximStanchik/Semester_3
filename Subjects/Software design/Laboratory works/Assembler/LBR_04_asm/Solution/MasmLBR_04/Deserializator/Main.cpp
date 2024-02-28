#include "stdafx.h"
#include "ReadingDataFromFile.h"
#include "Deserializer.h"
int main() {
    setlocale(LC_ALL, "Rus");

    cout << "���� ���������� ������ ������ �� �����..." << endl << endl;

    string filename = "D:\\User\\Desktop\\EverythingForBSTU\\Narkevich\\���\\2-�� ���� 3-�� �������\\LaboratoryWorks\\Assembler\\LBR_04_asm\\Solution\\MasmLBR_04\\LiteralInfo.bin";
    string fileContents = readDataFromFile(filename);

    cout << "���������� �����: " << endl;
    cout << fileContents << endl << endl;

    cout << "���� ���������� �������������� ����������� ������, ���������� ��� ��������� ����������� �����..." << endl << endl;

    vector<string> splitLines = splitString(fileContents);
    int count{};
    cout << "����������������� ����������:" << endl << endl;
    for (const auto& line : splitLines) {
        tuple<char, char, string> result = processString(line);
        char dataType = get<0>(result);
        char sizeValue = get<1>(result);
        string numericValue = get<2>(result);
        string cdataType{};

        if (dataType == '0' && sizeValue == '4') {
            cdataType = "unsigned int";
        }
        else if (dataType == '1' && sizeValue == '4') {
            cdataType = "int";
        }
        else {
            cdataType = "����������� ��� ������";
        }

        cout << "����������         : " << line << endl;
        cout << "��� ������         : " << dataType << endl;
        cout << "������ ���� ������ : " << sizeValue << endl;
        cout << "��������           : " << numericValue << endl;
        cout << "��� ������ � �++   : " << cdataType << endl << endl;

        if (dataType == '0' || dataType == '1' && sizeValue == '4') {
            writeToAssemblyFile("output.asm", "variable" + to_string(count), numericValue);
            count++;
        }
    }

    system("pause");
    return 0;
}












    