#include "stdafx.h"

vector<pair<string, string>> Graph::toGetKruskalMinimumSpanningTree() const {
    DisjointSet disjointSet;

    for (const auto& entry : adjacencyList) {
        string vertex = entry.first;
        disjointSet.makeSet(vertex);
    }

    vector<Edge> edges;
    toAddEdgesToVector(edges);  

    sort(edges.begin(), edges.end(), [](const Edge& a, const Edge& b) {
        return a.weight < b.weight;
        });

    vector<pair<string, string>> minimumSpanningTree;

    for (const auto& edge : edges) {
        string source = edge.startVertex;
        string destination = edge.finalVertex;

        if (disjointSet.findSet(source) != disjointSet.findSet(destination)) {
            disjointSet.unionSets(source, destination);
            minimumSpanningTree.push_back({ source, destination });
        }

        if (minimumSpanningTree.size() == adjacencyList.size() - 1)
            break;
    }

    return minimumSpanningTree;
}