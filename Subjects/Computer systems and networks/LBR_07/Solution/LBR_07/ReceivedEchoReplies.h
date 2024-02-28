#pragma once
#include "stdafx.h"

typedef struct icmp_echo_reply {
	IPAddr Address; // ����� ����������� ����
	ULONG Status; // ������ ������
	ULONG RoundTripTime; // ����� ����������� ������� � ��
	USHORT DataSize; // ������ ������ ������
	USHORT Reserved; // ���������������
	PVOID Data; // ��������� �� ������ ������
	IP_OPTION_INFORMATION Options;
} ICMP_ECHO_REPLY, * PICMP_ECHO_REPLY;