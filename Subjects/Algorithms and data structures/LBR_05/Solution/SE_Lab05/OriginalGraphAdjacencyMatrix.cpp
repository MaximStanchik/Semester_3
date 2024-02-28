#include "stdafx.h"

    vector<vector<float>> toBuildAnOriginalGraphAdjacencyMatrix() {
        std::vector<std::vector<float>> OriginalGraphAdjacencyMatrix = {
            {0, 2,  0,  8,  2,  0,  0, 0},
            {2, 0,  3,  0,  5,  0,  0, 0},
            {0, 3,  0,  0,  12, 0,  0, 7},
            {8, 10, 0,  0,  14, 3,  1, 0},
            {2, 5,  12, 14, 0,  11, 4, 8},
            {0, 0,  0,  3,  11, 0,  6, 0},
            {0, 0,  0,  1,  4,  6,  0, 9},
            {0, 0,  7,  0,  8,  0,  9, 0}
        };
        return OriginalGraphAdjacencyMatrix;
    }

    void toPrintMatrix(const vector<vector<float>>& matrix) {
        for (const auto& row : matrix) {
            for (const auto& value : row) {
                cout << value << " ";
            }
            cout << endl;
        }
    }

