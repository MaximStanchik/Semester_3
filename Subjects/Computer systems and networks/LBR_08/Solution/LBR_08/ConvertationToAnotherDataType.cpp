#include "stdafx.h"

unsigned long CharToLong(char* ip_)
{
	unsigned long out = 0;//число дл€ IP-адреса
	char* buff;
	buff = new char[3];
	//буфер дл€ хранени€ одного октета
	for (int i = 0, j = 0, k = 0; ip_[i] != '\0'; i++, j++)
	{
		if (ip_[i] != '.') //если не точка
			buff[j] = ip_[i]; // записать символ в буфер
		if (ip_[i] == '.' || ip_[i + 1] == '\0')
		{
			// если следующий октет или последний
			out <<= 8; //сдвинуть число на 8 бит
			if (atoi(buff) > 255)
				return NULL;
			// еcли октет больше 255 Ц ошибка
			out += (unsigned long)atoi(buff);
			//преобразовать и добавить
			//к числу IP-адреса
			k++;
			j = -1;
			delete[]buff;
			buff = new char[3];
		}
	}
	return out;
}