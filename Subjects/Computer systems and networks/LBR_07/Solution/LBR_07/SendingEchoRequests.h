#include "stdafx.h"

DWORD IcmpSendEcho
(
	__in HANDLE IcmpHandle, //���������� ���������� �������� IcmpCreateFile
	__in IPAddr DestinationAddress, //IP ����� �������
	__in LPVOID RequestData, //��������� �� ����� ���-�������
	__in WORD RequestSize, //������ ������ ���-�������
	__in PIP_OPTION_INFORMATION RequestOptions, //��������� �� ��������� � ������� �������
	__inout LPVOID ReplyBuffer, //��������� �� ����� ���-������
	__in DWORD ReplySize, //������ ������ ���-������
	__in DWORD Timeout //������� � �������������
);