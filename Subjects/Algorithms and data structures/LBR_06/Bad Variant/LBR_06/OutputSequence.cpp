#include "stdafx.h"

namespace implementationOfTheHuffmanAlgorithm {

    std::string OutputSequence::createOutputSequence(const std::string& inputText, treeNode* root) {
        std::unordered_map<char, std::string> huffmanCodes;
        HuffmanAlgorithm::toAssignHuffmanCodes(root, "", huffmanCodes);

        std::string outputSequence = "";
        for (char ch : inputText) {
            outputSequence += huffmanCodes[ch];
        }

        return outputSequence;
    }

    void OutputSequence::printOutputSequence(const std::string& outputSequence) {
        std::cout << outputSequence << std::endl;
    }

}
