#include "stdafx.h"

vector<string> splitString(const string& inputString) {
    vector<string> lines;

    stringstream ss(inputString);
    string line;

    while (getline(ss, line, ';')) {
        line += ';';
        lines.push_back(line);
    }

    return lines;
}

tuple<char, char, string> processString(const string& input) {
    if (input.empty()) {
        throw invalid_argument("Входная строка пустая");
    }

    char firstChar = input[0];
    char secondChar = input[1];
    string thirdElement;

    size_t semicolonPos = input.find(';');
    if (semicolonPos != string::npos) {
        size_t startPos = 2; 
        size_t length = semicolonPos - startPos;
        thirdElement = input.substr(startPos, length);
    }
    else {
        throw invalid_argument("Входная строка не содержит точку с запятой");
    }

    return make_tuple(firstChar, secondChar, thirdElement);
}

void writeToAssemblyFile(const string& fileName, const string& variableName, const string& value)
{
    ifstream inputFile(fileName);
    stringstream outputFileContents;
    string line;

    while (getline(inputFile, line))
    {
        if (line.find(".DATA") != string::npos)
        {
            outputFileContents << line << endl;
            outputFileContents << variableName << " DWORD " << value << endl;
        }
        else
        {
            outputFileContents << line << endl;
        }
    }
    inputFile.close();

    ofstream outputFile(fileName);
    if (outputFile.is_open())
    {
        outputFile << outputFileContents.str();
        outputFile.close();
        cout << "Запись в файл успешно выполнена." << endl << endl;
    }
    else
    {
        cout << "Не удалось открыть файл для записи." << endl << endl;
    }
}
