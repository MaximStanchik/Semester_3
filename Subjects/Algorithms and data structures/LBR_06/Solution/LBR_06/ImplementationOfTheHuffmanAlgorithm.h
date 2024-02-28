#pragma once
#include "stdafx.h"

struct Node {

    int weight;

    const string originalString;

    Node* left;     
    Node* right;    

    ~Node()
    {
        delete left;
        delete right;
    }
};

struct ComparatorForNodes {
    bool operator()(const Node* lhs, const Node* rhs) const {
        if (lhs->weight == rhs->weight)
            return lhs->originalString < rhs->originalString;
        return lhs->weight < rhs->weight;
    }
};

void printCharacterOccurrences(const string& str);
void createAndDisplayAListOfSymbolOccurrences(const Node& nodes, string str);
void createAndOutputAnOutputSequence (const string& str, const Node& start);
set<Node*, ComparatorForNodes> buildHuffmanTree(const string& str);
