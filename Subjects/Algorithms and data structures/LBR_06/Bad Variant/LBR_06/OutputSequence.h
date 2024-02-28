#ifndef OUTPUTSEQUENCE_H
#define OUTPUTSEQUENCE_H

#include "stdafx.h"

namespace implementationOfTheHuffmanAlgorithm {

    struct treeNode;

    class OutputSequence {
    public:
        static std::string createOutputSequence(const std::string& inputText, treeNode* root);
        static void printOutputSequence(const std::string& outputSequence);
    };

}

#endif