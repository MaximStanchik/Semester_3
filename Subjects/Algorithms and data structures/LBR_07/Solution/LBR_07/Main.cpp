#include "stdafx.h"

#include "NumberCheck.h"
#include "FindIncreasingSubsequence.h"

int main() {
    setlocale(LC_ALL, "Russian");

    string numberOfSequenceElements{};
    cout << "Введите число элементов последовательности: ";

enteringAValue:
    cin >> numberOfSequenceElements;

    if (!checkNumber(numberOfSequenceElements)) {
        cout << "Вы ввели неверное значение. Введите, пожалуйста, снова." << std::endl;
        goto enteringAValue;
    }
    else {
        int convertedStringToNumber = std::stoi(numberOfSequenceElements);
        vector<double> sequenceElements(convertedStringToNumber); 

        for (int serialNumber = 0; serialNumber < convertedStringToNumber; serialNumber++) {
            cout << "Введите " << serialNumber + 1 << "-ый элемент: ";
            cin >> sequenceElements[serialNumber];
        }

        int maximumSubsequenceLength = findLongestIncreasingSubsequence(sequenceElements);
        vector<double> maxIncreasingSubsequence = findMaxIncreasingSubsequence(sequenceElements);

        cout << "Длина максимальной подпоследовательности: " << maximumSubsequenceLength << endl;

        cout << "Максимальная возрастающая подпоследовательность: ";
        printTheMaximumIncreasingSubsequence(maxIncreasingSubsequence);
        cout << endl;
    }

    system("pause");
    return 0;
}