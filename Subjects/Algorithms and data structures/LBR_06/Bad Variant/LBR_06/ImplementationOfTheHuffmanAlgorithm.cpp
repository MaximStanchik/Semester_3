#include "stdafx.h"

namespace implementationOfTheHuffmanAlgorithm {

    std::unordered_map<char, int> HuffmanAlgorithm::toDivideTextIntoLetters(const std::string& inputText) {
        std::unordered_map<char, int> letterCounts;
        for (char everyLetter : inputText) {
            letterCounts[everyLetter]++;
        }
        return letterCounts;
    }

    std::vector<std::pair<char, int>> HuffmanAlgorithm::toSortAscending(std::unordered_map<char, int>& letterCounts) {
        std::vector<std::pair<char, int>> sortedElements(letterCounts.begin(), letterCounts.end());
        std::sort(sortedElements.begin(), sortedElements.end(),
            [](const std::pair<char, int>& a, const std::pair<char, int>& b) {
                return a.second < b.second;
            });
        return sortedElements;
    }

    treeNode* HuffmanAlgorithm::toCreateHuffmanNode(char symbol, int symbolFrequency) {
        return new treeNode(symbol, symbolFrequency);
    }

    treeNode* HuffmanAlgorithm::toBuildHuffmanTree(const std::string& inputText) {
        std::unordered_map<char, int> letterCounts = toDivideTextIntoLetters(inputText);

        std::vector<std::pair<char, int>> sortedElements = toSortAscending(letterCounts);

        while (sortedElements.size() > 1) {
            treeNode* leftChild = toCreateHuffmanNode(sortedElements[0].first, sortedElements[0].second);
            treeNode* rightChild = toCreateHuffmanNode(sortedElements[1].first, sortedElements[1].second);

            int parentFrequency = leftChild->symbolFrequency + rightChild->symbolFrequency;
            treeNode* parent = toCreateHuffmanNode('\0', parentFrequency);
            parent->left = leftChild;
            parent->right = rightChild;

            sortedElements.push_back(std::make_pair('\0', parentFrequency));

            sortedElements.erase(sortedElements.begin(), sortedElements.begin() + 2);

            std::sort(sortedElements.begin(), sortedElements.end(),
                [](const std::pair<char, int>& a, const std::pair<char, int>& b) {
                    return a.second < b.second;
                });
        }

        return toCreateHuffmanNode(sortedElements[0].first, sortedElements[0].second);
    }

    void HuffmanAlgorithm::toAssignHuffmanCodes(treeNode* root, std::string code, std::unordered_map<char, std::string>& huffmanCodes) {
        if (root == nullptr) {
            return;
        }

        if (root->left == nullptr && root->right == nullptr) {
            huffmanCodes[root->symbol] = code;
            return;
        }

        toAssignHuffmanCodes(root->left, code + "0", huffmanCodes);
        toAssignHuffmanCodes(root->right, code + "1", huffmanCodes);
    }

    std::string HuffmanAlgorithm::toEncodeText(treeNode* root, const std::string& inputText) {
        std::unordered_map<char, std::string> huffmanCodes;
        HuffmanAlgorithm::toAssignHuffmanCodes(root, "", huffmanCodes);

        std::string encodedText;
        for (char symbol : inputText) {
            encodedText += huffmanCodes[symbol];
        }
        return encodedText;
    }

    void HuffmanAlgorithm::printCodeTable(const std::unordered_map<char, std::string>& huffmanCodes) {
        std::cout << "Symbol\tCode\n";
        for (const auto& pair : huffmanCodes) {
            std::cout << pair.first << "\t" << pair.second << "\n";
        }
    }
}

