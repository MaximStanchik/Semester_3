#include "stdafx.h"
#include "FrequencyTable.h"

void toCallFunctions(string userEnteredText); 

int main() {
    setlocale(LC_ALL, "Russian");

    int choiceInput{};
    string fullNameOfStudent = "������� ������ ���������";
    string userEnteredText{};

    cout << "������������!" << endl;
    cout << "1--������ ���������� ���������" << endl;
    cout << "2--����� �� ���������" << endl;
    cout << "����: ";
    cin >> choiceInput;
    switch (choiceInput) {
    case 1:
        cout << "1--������ ����� ������������ ����� " << endl;
        cout << "2--�������������� ������ '" << fullNameOfStudent << "'" << endl;
        cout << "3--����� �� ���������" << endl;
        cout << "����: ";
        cin >> choiceInput;
        switch (choiceInput) {
        case 1: {
            cout << "������� �����: ";
            cin >> userEnteredText;
            toCallFunctions(userEnteredText);
            break;
        }
        case 2: {
            toCallFunctions(fullNameOfStudent);
            break;
        }
        case 3:
            break;
        default:
            cout << "������� �������� ��������" << endl;
            cout << "�������������� ����� �� ���������" << endl;
            break;
        }
        break;
    case 2:
        cout << "��������� ��������� ���� ����������" << endl;
        break;
    default:
        cout << "������� �������� ��������" << endl;
        cout << "�������������� ����� �� ���������" << endl;
        break;
    }

    system("pause");
    return 0;
}

void toCallFunctions(string userEnteredText) {
    implementationOfTheHuffmanAlgorithm::HuffmanAlgorithm HuffmanAlgorithmObject;
    implementationOfTheHuffmanAlgorithm::FrequencyTable FrequencyTableObject;
    implementationOfTheHuffmanAlgorithm::OutputSequence OutputSequenceObject;
    unordered_map<char, int> createdFrequencyTable = HuffmanAlgorithmObject.toDivideTextIntoLetters(userEnteredText);
    cout << "������� ������������� �������� � ������: " << endl;
    FrequencyTableObject.printFrequencyTable(createdFrequencyTable);

    unordered_map<char, string> huffmanCodes;
    HuffmanAlgorithmObject.toAssignHuffmanCodes(HuffmanAlgorithmObject.toBuildHuffmanTree(userEnteredText), "", huffmanCodes);

    cout << "�������� ������������������:" << endl;
    std::string generatedOutputSequence = OutputSequenceObject.createOutputSequence(userEnteredText, HuffmanAlgorithmObject.toBuildHuffmanTree(userEnteredText));

    OutputSequenceObject.printOutputSequence(generatedOutputSequence);

    cout << "������� ������������ ������� � ������� ������������������" << endl;
    // HuffmanAlgorithmObject.printCodeTable(huffmanCodes);

    std::string encodedText = HuffmanAlgorithmObject.toEncodeText(HuffmanAlgorithmObject.toBuildHuffmanTree(userEnteredText), userEnteredText);
    std::cout << "Encoded Text: " << encodedText << "\n\n";

    HuffmanAlgorithmObject.printCodeTable(huffmanCodes);
}