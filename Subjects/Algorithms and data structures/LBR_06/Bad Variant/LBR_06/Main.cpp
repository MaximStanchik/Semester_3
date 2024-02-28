#include "stdafx.h"
#include "FrequencyTable.h"

void toCallFunctions(string userEnteredText); 

int main() {
    setlocale(LC_ALL, "Russian");

    int choiceInput{};
    string fullNameOfStudent = "Станчик Максим Андреевич";
    string userEnteredText{};

    cout << "Здравствуйте!" << endl;
    cout << "1--Начать выполнение программы" << endl;
    cout << "2--Выход из программы" << endl;
    cout << "Ввод: ";
    cin >> choiceInput;
    switch (choiceInput) {
    case 1:
        cout << "1--Ввести текст произвольной длины " << endl;
        cout << "2--Протестировать строку '" << fullNameOfStudent << "'" << endl;
        cout << "3--Выход из программы" << endl;
        cout << "Ввод: ";
        cin >> choiceInput;
        switch (choiceInput) {
        case 1: {
            cout << "Введите текст: ";
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
            cout << "Введено неверное значение" << endl;
            cout << "Автоматический выход из программы" << endl;
            break;
        }
        break;
    case 2:
        cout << "Программа закончила свое выполнение" << endl;
        break;
    default:
        cout << "Введено неверное значение" << endl;
        cout << "Автоматический выход из программы" << endl;
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
    cout << "Таблица встречаемости символов в тексте: " << endl;
    FrequencyTableObject.printFrequencyTable(createdFrequencyTable);

    unordered_map<char, string> huffmanCodes;
    HuffmanAlgorithmObject.toAssignHuffmanCodes(HuffmanAlgorithmObject.toBuildHuffmanTree(userEnteredText), "", huffmanCodes);

    cout << "Выходная последовательность:" << endl;
    std::string generatedOutputSequence = OutputSequenceObject.createOutputSequence(userEnteredText, HuffmanAlgorithmObject.toBuildHuffmanTree(userEnteredText));

    OutputSequenceObject.printOutputSequence(generatedOutputSequence);

    cout << "Таблица соответствия символа и кодовой последовательности" << endl;
    // HuffmanAlgorithmObject.printCodeTable(huffmanCodes);

    std::string encodedText = HuffmanAlgorithmObject.toEncodeText(HuffmanAlgorithmObject.toBuildHuffmanTree(userEnteredText), userEnteredText);
    std::cout << "Encoded Text: " << encodedText << "\n\n";

    HuffmanAlgorithmObject.printCodeTable(huffmanCodes);
}