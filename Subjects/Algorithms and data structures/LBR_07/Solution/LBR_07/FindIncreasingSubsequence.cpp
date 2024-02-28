#include "stdafx.h"

int findLongestIncreasingSubsequence(const vector<double>& sequenceElements) {
    int n = sequenceElements.size();
    vector<int> increasingSubsequences(n, 1); // Инициализируем вектор dp с длинами подпоследовательностей, начиная с 1

    for (int i = 1; i < n; i++) {
        for (int j = 0; j < i; j++) {
            if (sequenceElements[i] > sequenceElements[j]) {
                increasingSubsequences[i] = max(increasingSubsequences[i], increasingSubsequences[j] + 1);
            }
        }
    }

    int  maximumSubsequenceLength{};
    for (int i = 0; i < n; i++) {
        maximumSubsequenceLength = max(maximumSubsequenceLength, increasingSubsequences[i]);
    }

    return  maximumSubsequenceLength;
}

vector<double> findMaxIncreasingSubsequence(const vector<double>& sequenceElements) {
    int numberOfElementsOfTheOriginalSequence = sequenceElements.size();
    vector<int> dp(numberOfElementsOfTheOriginalSequence, 1); // Инициализируем вектор dp с длинами подпоследовательностей, начиная с 1
    vector<int> next(numberOfElementsOfTheOriginalSequence, -1); // Инициализируем вектор next для отслеживания индексов элементов подпоследовательности

    int maxLengthIndex = 0;
    for (int i = 1; i < numberOfElementsOfTheOriginalSequence; i++) {
        for (int j = 0; j < i; j++) {
            if (sequenceElements[i] > sequenceElements[j] && dp[i] < dp[j] + 1) {
                dp[i] = dp[j] + 1;
                next[i] = j;
            }
        }
        if (dp[i] > dp[maxLengthIndex]) {
            maxLengthIndex = i;
        }
    }

    vector<double> maxIncreasingSubsequence;
    while (maxLengthIndex != -1) {
        maxIncreasingSubsequence.insert(maxIncreasingSubsequence.begin(), sequenceElements[maxLengthIndex]);
        maxLengthIndex = next[maxLengthIndex];
    }

    return maxIncreasingSubsequence;
}

void printTheMaximumIncreasingSubsequence(const vector<double>& maxIncreasingSubsequence) {
    for (size_t i = 0; i < maxIncreasingSubsequence.size(); i++) {
        cout << maxIncreasingSubsequence[i] << " ";
    }
}