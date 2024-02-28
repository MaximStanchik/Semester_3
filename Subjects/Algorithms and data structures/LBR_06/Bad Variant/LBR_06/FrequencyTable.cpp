#include "stdafx.h"
#include "FrequencyTable.h"
#include <iostream>

namespace implementationOfTheHuffmanAlgorithm {

    void FrequencyTable::printFrequencyTable(const std::unordered_map<char, int>& letterCounts) {
        int totalCharacters = 0;
        for (const auto& pair : letterCounts) {
            totalCharacters += pair.second;
        }

        for (const auto& pair : letterCounts) {
            char character = pair.first;
            int frequency = pair.second;
            float percentage = (static_cast<float>(frequency) / totalCharacters) * 100;
            std::cout << character << ": " << frequency << " (" << percentage << "%)" << std::endl;
        }
    }

}