#include "stdafx.h"

unsigned long CharToLong(char* ip_)
{
	unsigned long out = 0;//����� ��� IP-������
	char* buff;
	buff = new char[3];
	//����� ��� �������� ������ ������
	for (int i = 0, j = 0, k = 0; ip_[i] != '\0'; i++, j++)
	{
		if (ip_[i] != '.') //���� �� �����
			buff[j] = ip_[i]; // �������� ������ � �����
		if (ip_[i] == '.' || ip_[i + 1] == '\0')
		{
			// ���� ��������� ����� ��� ���������
			out <<= 8; //�������� ����� �� 8 ���
			if (atoi(buff) > 255)
				return NULL;
			// �c�� ����� ������ 255 � ������
			out += (unsigned long)atoi(buff);
			//������������� � ��������
			//� ����� IP-������
			k++;
			j = -1;
			delete[]buff;
			buff = new char[3];
		}
	}
	return out;
}