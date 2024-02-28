#include "stdafx.h"

int main() {
    setlocale(LC_ALL, "Rus");

    Graph graph;

    graph.toAddEdges();

    cout << "����������� ������� ��������� �����, ��������������� � ������������ ������ #5:" << endl;
    vector<vector<float>> adjacencyMatrix = toBuildAnOriginalGraphAdjacencyMatrix();
    toPrintMatrix(adjacencyMatrix);

    cout << "����������� �������� ������, ���������� � ������� ��������� ��������:\n";
    vector<pair<string, string>> KruskalMinimumSpanningTree = graph.toGetPrimMinimumSpanningTree();
    graph.toPrintPrimMinimumSpanningTree(KruskalMinimumSpanningTree);

    cout << "����������� �������� ������, ���������� � ������� ��������� �����:\n";
    vector<pair<string, string>> PrimMinimumSpanningTree = graph.toGetPrimMinimumSpanningTree();
    graph.toPrintPrimMinimumSpanningTree(PrimMinimumSpanningTree);

    system("pause");
    return 0;
}