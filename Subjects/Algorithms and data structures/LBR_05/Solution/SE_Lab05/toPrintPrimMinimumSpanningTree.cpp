#include "stdafx.h"

void Graph::toPrintPrimMinimumSpanningTree(const vector<pair<string, string>>& minimumSpanningTree) const {
    for (const auto& edge : minimumSpanningTree) {
        cout << edge.first << " - " << edge.second << "\n";
    }
}