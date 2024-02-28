#pragma once
#include "stdafx.h"

struct Edge {
    std::string finalVertex;
    int weight;
    std::string startVertex;
};

class Graph {
private:
    std::unordered_map<std::string, std::vector<Edge>> adjacencyList;
public:
    void toAddEachEdge(const std::string& startVertex, const std::string& finalVertex, int weight);
    std::vector<std::pair<std::string, std::string>> toGetPrimMinimumSpanningTree() const;
    std::vector<std::pair<std::string, std::string>> toGetKruskalMinimumSpanningTree() const;
    void toPrintPrimMinimumSpanningTree(const std::vector<std::pair<std::string, std::string>>& minimumSpanningTree) const;
    void toAddEdges();
    void toAddEdgesToVector(std::vector<Edge>& edges) const;
};
