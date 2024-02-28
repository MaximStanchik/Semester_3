#include "stdafx.h"
#include "ImplementationOfTheHuffmanAlgorithm.h"

int main()
{
    setlocale(LC_ALL, "Russian");

    cout << "������������!" << endl;
    cout << "������� �����:" << endl;

    string originalString;
    getline(cin, originalString);

    if (originalString.empty()) {
        cout << "������ ������. �������������� ����� �� ���������" << endl;
    }
    else {
        cout << "����� ������� ������������� �������� � ������: " << endl;
        printCharacterOccurrences(originalString);

        set<Node*, ComparatorForNodes> nodes = buildHuffmanTree(originalString);

        cout << "\n\n";
        cout << "����� ������� ������������ ������� � ������� ������������������: " << endl;
        createAndDisplayAListOfSymbolOccurrences(**nodes.begin(), "");

        cout << "\n\n";
        cout << "����� �������� ������������������ ��������: " << endl;
        createAndOutputAnOutputSequence(originalString, **nodes.begin());

        cout << "\n\n";
    }

    return 0;
}