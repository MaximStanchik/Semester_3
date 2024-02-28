#include "stdafx.h"

vector<pair<string, string>> Graph::toGetPrimMinimumSpanningTree() const {
    unordered_set<string> visited;
    visited.insert(adjacencyList.begin()->first);

    vector<pair<string, string>> minimumSpanningTree;
    vector<Edge> edges;

    toAddEdgesToVector(edges);

    while (visited.size() < adjacencyList.size()) {
        int minWeight = INT_MAX;
        string minSource, minDestination;

        for (const auto& entry : adjacencyList) {
            string source = entry.first;

            if (visited.find(source) == visited.end()) {
                continue;
            }

            for (const auto& edge : entry.second) {
                string destination = edge.finalVertex;
                int weight = edge.weight;

                if (visited.find(destination) == visited.end() && weight < minWeight) {
                    minWeight = weight;
                    minSource = source;
                    minDestination = destination;
                }
            }
        }
        visited.insert(minDestination);
        minimumSpanningTree.push_back({ minSource, minDestination });
    }

    return minimumSpanningTree;
}


