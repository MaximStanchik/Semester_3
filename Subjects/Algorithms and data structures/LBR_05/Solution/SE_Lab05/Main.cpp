#include "stdafx.h"

int main() {
    setlocale(LC_ALL, "Rus");

    Graph graph;

    graph.toAddEdges();

    cout << "Изначальная матрица смежности графа, представленного в лабораторной работе #5:" << endl;
    vector<vector<float>> adjacencyMatrix = toBuildAnOriginalGraphAdjacencyMatrix();
    toPrintMatrix(adjacencyMatrix);

    cout << "Минимальное остовное дерево, полученное с помощью алгоритма Краскала:\n";
    vector<pair<string, string>> KruskalMinimumSpanningTree = graph.toGetPrimMinimumSpanningTree();
    graph.toPrintPrimMinimumSpanningTree(KruskalMinimumSpanningTree);

    cout << "Минимальное остовное дерево, полученное с помощью алгоритма Прима:\n";
    vector<pair<string, string>> PrimMinimumSpanningTree = graph.toGetPrimMinimumSpanningTree();
    graph.toPrintPrimMinimumSpanningTree(PrimMinimumSpanningTree);

    system("pause");
    return 0;
}