#include "stdafx.h"
#include "ImplementationOfTheHuffmanAlgorithm.h"

int main()
{
    setlocale(LC_ALL, "Russian");

    cout << "Здравствуйте!" << endl;
    cout << "Введите текст:" << endl;

    string originalString;
    getline(cin, originalString);

    if (originalString.empty()) {
        cout << "Строка пустая. Автоматический выход из программы" << endl;
    }
    else {
        cout << "Вывод таблицы встречаемости символов в тексте: " << endl;
        printCharacterOccurrences(originalString);

        set<Node*, ComparatorForNodes> nodes = buildHuffmanTree(originalString);

        cout << "\n\n";
        cout << "Вывод таблицы соответствия символа и кодовой последовательности: " << endl;
        createAndDisplayAListOfSymbolOccurrences(**nodes.begin(), "");

        cout << "\n\n";
        cout << "Вывод выходной последовательности символов: " << endl;
        createAndOutputAnOutputSequence(originalString, **nodes.begin());

        cout << "\n\n";
    }

    return 0;
}