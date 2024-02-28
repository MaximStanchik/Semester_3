#include "stdafx.h"
#include "PingOperationToHost.h"

int main(int argc, char** argv)
{
    setlocale(LC_ALL, "RUS");
    const char* par0 = argv[1];
    int par1 = atoi(argv[2]);
    int par2 = atoi(argv[3]);
    Ping(par0, par1, par2);
    //Ping("8.8.8.8", 60, 10);
    system("pause");
    return 0;
}