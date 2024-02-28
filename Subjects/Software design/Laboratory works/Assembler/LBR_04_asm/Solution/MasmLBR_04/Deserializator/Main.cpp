#include "stdafx.h"
#include "ReadingDataFromFile.h"
#include "Deserializer.h"
int main() {
    setlocale(LC_ALL, "Rus");

    cout << "Идет выполнение чтения данных из файла..." << endl << endl;

    string filename = "D:\\User\\Desktop\\EverythingForBSTU\\Narkevich\\КПО\\2-ой курс 3-ий семестр\\LaboratoryWorks\\Assembler\\LBR_04_asm\\Solution\\MasmLBR_04\\LiteralInfo.bin";
    string fileContents = readDataFromFile(filename);

    cout << "Содержимое файла: " << endl;
    cout << fileContents << endl << endl;

    cout << "Идет выполнение десериализации изначальных данных, полученных при просмотре содержимого файла..." << endl << endl;

    vector<string> splitLines = splitString(fileContents);
    int count{};
    cout << "Десериализованные переменные:" << endl << endl;
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
            cdataType = "неизвестный тип данных";
        }

        cout << "Переменная         : " << line << endl;
        cout << "Тип данных         : " << dataType << endl;
        cout << "Размер типа данных : " << sizeValue << endl;
        cout << "Значение           : " << numericValue << endl;
        cout << "Тип данных в с++   : " << cdataType << endl << endl;

        if (dataType == '0' || dataType == '1' && sizeValue == '4') {
            writeToAssemblyFile("output.asm", "variable" + to_string(count), numericValue);
            count++;
        }
    }

    system("pause");
    return 0;
}












    