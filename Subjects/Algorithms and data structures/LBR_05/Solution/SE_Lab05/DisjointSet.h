#pragma once
#include <string>
#include <unordered_map>

class DisjointSet {
private:
    std::unordered_map<std::string, std::string> parent;
    std::unordered_map<std::string, int> rank;

public:
    void makeSet(std::string vertex);
    std::string findSet(std::string vertex);
    void unionSets(std::string vertex1, std::string vertex2);
};