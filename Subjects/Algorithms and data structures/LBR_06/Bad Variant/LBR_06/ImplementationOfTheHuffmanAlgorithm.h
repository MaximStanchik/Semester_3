#ifndef IMPLEMENTATIONOFTHEHUFFMANALGORITHM_H
#define IMPLEMENTATIONOFTHEHUFFMANALGORITHM_H

#include "stdafx.h"

namespace implementationOfTheHuffmanAlgorithm {
    struct treeNode {
        char symbol;
        int symbolFrequency;
        treeNode* left;
        treeNode* right;

        treeNode(char s, int freq) : symbol(s), symbolFrequency(freq), left(nullptr), right(nullptr) {}
    };

    class HuffmanAlgorithm {
    public:
        static std::unordered_map<char, int> toDivideTextIntoLetters(const std::string& inputText);
        static std::vector<std::pair<char, int>> toSortAscending(std::unordered_map<char, int>& letterCounts);
        static treeNode* toCreateHuffmanNode(char symbol, int symbolFrequency);
        static treeNode* toBuildHuffmanTree(const std::string& inputText);
        static void toAssignHuffmanCodes(treeNode* root, std::string code, std::unordered_map<char, std::string>& huffmanCodes);
        std::string toEncodeText(treeNode* root, const std::string& inputText);
        void printCodeTable(const std::unordered_map<char, std::string>& huffmanCodes);
    };

} 

#endif 