#pragma once

#include <unordered_map>

namespace implementationOfTheHuffmanAlgorithm {

    class FrequencyTable {
    public:
        static void printFrequencyTable(const std::unordered_map<char, int>& letterCounts);
    };

}