#include "Stdafx.h"

bool CheckDNSName(char* dns_name)
{
    for (int i = 0; dns_name[i] != '\0'; i++)
    {
        if (!(dns_name[i] >= 'A' && dns_name[i] <= 'Z' ||
            dns_name[i] >= 'a' && dns_name[i] <= 'z' ||
            dns_name[i] >= '0' && dns_name[i] <= '9' ||
            dns_name[i] == '.' ||
            dns_name[i] == '-'))
        {
            return false;
        }
    }

    return true;
}