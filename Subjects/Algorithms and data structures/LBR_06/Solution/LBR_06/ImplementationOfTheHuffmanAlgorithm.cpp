#include "stdafx.h"
#include "ImplementationOfTheHuffmanAlgorithm.h"

void printCharacterOccurrences(const string& str)
{
    unordered_map<char, int> table;

    for (char ch : str) {
        table[ch]++;
    }

    for (const pair<const char, int>& p : table) {
        cout << p.first << ": " << p.second << endl;
    }
}

set<Node*, ComparatorForNodes> buildHuffmanTree(const string& originalString)
{
    unordered_map<char, int> table;

    for (auto ch : originalString) {
        table[ch]++;
    }

    set<Node*, ComparatorForNodes> nodes;

    for (const pair<const char, int>& p : table) {
        nodes.insert(new Node{ p.second, string(1, p.first), nullptr, nullptr });
    }

    while (nodes.size() != 1) {
        set<Node*, ComparatorForNodes>::iterator first = nodes.begin();
        set<Node*, ComparatorForNodes>::iterator second = ++nodes.begin();

        Node* newnode = new Node{
            (*first)->weight + (*second)->weight,
            (*first)->originalString + (*second)->originalString,
            *first, *second,
        };


        nodes.erase(nodes.begin());
        nodes.erase(nodes.begin());
        nodes.insert(newnode);
    }

    return nodes;
}

void createAndDisplayAListOfSymbolOccurrences(const Node& nodes, string originalString)
{
    if (!nodes.left) {
        cout << nodes.originalString << ": " << originalString << endl;
        return;
    }

    createAndDisplayAListOfSymbolOccurrences(*nodes.left, originalString + "0");
    createAndDisplayAListOfSymbolOccurrences(*nodes.right, originalString + "1");
}

void createAndOutputAnOutputSequence(const string& str, const Node& start)
{
    for (char ch : str) { 
        const Node* ptr = &start;
        string output;

        while (ptr->left) {
            if (ptr->left->originalString.find(ch) != string::npos) {
                ptr = ptr->left;
                output += "0";
                continue;
            }
            ptr = ptr->right;
            output += "1";
        }

        cout << output << " ";
    }
}

