#include "stdafx.h"

void Graph::toAddEdges() {
    toAddEachEdge("V1", "V2", 2);
    toAddEachEdge("V2", "V3", 3);
    toAddEachEdge("V1", "V4", 8);
    toAddEachEdge("V4", "V5", 14);
    toAddEachEdge("V1", "V5", 2);
    toAddEachEdge("V4", "V2", 10);
    toAddEachEdge("V2", "V5", 5);
    toAddEachEdge("V5", "V3", 12);
    toAddEachEdge("V5", "V8", 8);
    toAddEachEdge("V3", "V8", 7);
    toAddEachEdge("V5", "V7", 4);
    toAddEachEdge("V7", "V8", 9);
    toAddEachEdge("V4", "V7", 1);
    toAddEachEdge("V6", "V5", 11);
    toAddEachEdge("V4", "V6", 3);
    toAddEachEdge("V6", "V7", 6);
}

void Graph::toAddEachEdge(const std::string& startVertex, const std::string& finalVertex, int weight) {
    adjacencyList[startVertex].push_back({ finalVertex, weight, startVertex });
    adjacencyList[finalVertex].push_back({ startVertex, weight, finalVertex });
}

void Graph::toAddEdgesToVector(std::vector<Edge>& edges) const {
    for (const auto& entry : adjacencyList) {
        std::string source = entry.first;
        for (const auto& edge : entry.second) {
            std::string destination = edge.finalVertex;
            int weight = edge.weight;
            edges.push_back({ destination, weight, source });
        }
    }
}