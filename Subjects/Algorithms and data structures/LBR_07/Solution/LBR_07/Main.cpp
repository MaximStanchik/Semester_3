#include "stdafx.h"

#include "NumberCheck.h"
#include "FindIncreasingSubsequence.h"

int main() {
    setlocale(LC_ALL, "Russian");

    string numberOfSequenceElements{};
    cout << "������� ����� ��������� ������������������: ";

enteringAValue:
    cin >> numberOfSequenceElements;

    if (!checkNumber(numberOfSequenceElements)) {
        cout << "�� ����� �������� ��������. �������, ����������, �����." << std::endl;
        goto enteringAValue;
    }
    else {
        int convertedStringToNumber = std::stoi(numberOfSequenceElements);
        vector<double> sequenceElements(convertedStringToNumber); 

        for (int serialNumber = 0; serialNumber < convertedStringToNumber; serialNumber++) {
            cout << "������� " << serialNumber + 1 << "-�� �������: ";
            cin >> sequenceElements[serialNumber];
        }

        int maximumSubsequenceLength = findLongestIncreasingSubsequence(sequenceElements);
        vector<double> maxIncreasingSubsequence = findMaxIncreasingSubsequence(sequenceElements);

        cout << "����� ������������ ���������������������: " << maximumSubsequenceLength << endl;

        cout << "������������ ������������ ���������������������: ";
        printTheMaximumIncreasingSubsequence(maxIncreasingSubsequence);
        cout << endl;
    }

    system("pause");
    return 0;
}