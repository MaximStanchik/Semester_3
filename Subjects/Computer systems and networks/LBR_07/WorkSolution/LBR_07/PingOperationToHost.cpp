#include "stdafx.h"

IP_OPTION_INFORMATION option = { 255, 255, 240, 0, 0 };

void Ping(const char* cHost, //����� �����, ������� ����� �����������
    unsigned int Timeout, //����� �������� ������ (� ��) ����� �������
    unsigned int RequestCount) //���������� ���������� ��������
{
    // ������� ���� �������
    HANDLE hIP = IcmpCreateFile();
    if (hIP == INVALID_HANDLE_VALUE)
    {
        WSACleanup();
        return;
    }

    char SendData[32] = "������ ��� �����";    //����� ��� ��������
    int LostPacketsCount = 0;               // ���-�� ���������� �������
    unsigned int MaxMS = 0;                 // ������������ ����� ������ (��)
    int MinMS = -1;                         // ����������� ����� ������ (��)

    // �������� ������ ��� ����� � ����� ������
    PICMP_ECHO_REPLY pIpe =
        (PICMP_ECHO_REPLY)GlobalAlloc(GHND, sizeof(ICMP_ECHO_REPLY) + sizeof(SendData));

    if (pIpe == 0)
    {
        IcmpCloseHandle(hIP);
        WSACleanup();
        return;
    }
    pIpe->Data = SendData;
    pIpe->DataSize = sizeof(SendData);
    unsigned long ipaddr = inet_addr(cHost);

    for (unsigned int c = 0; c < RequestCount; c++)
    {
        int dwStatus = IcmpSendEcho(hIP,
            ipaddr,
            SendData,
            sizeof(SendData),
            &option,
            pIpe,
            sizeof(ICMP_ECHO_REPLY) + sizeof(SendData),
            Timeout);
        if (dwStatus > 0)
        {
            for (int i = 0; i < dwStatus; i++)
            {
                unsigned char* pIpPtr =
                    (unsigned char*)&pIpe->Address;
                cout << "����� �� " << (int)*(pIpPtr)
                    << "." << (int)*(pIpPtr + 1)
                    << "." << (int)*(pIpPtr + 2)
                    << "." << (int)*(pIpPtr + 3)
                    << ": ����� ���� = " << pIpe->DataSize
                    << " ����� = " << pIpe->RoundTripTime
                    << "�� TTL = " << (int)pIpe->Options.Ttl;
                MaxMS = (MaxMS > pIpe->RoundTripTime) ?
                    MaxMS : pIpe->RoundTripTime;
                MinMS = (MinMS < (int)pIpe->RoundTripTime
                    && MinMS >= 0) ?
                    MinMS : pIpe->RoundTripTime;
                cout << endl;
            }
        }
        else
        {
            if (pIpe->Status)
            {
                LostPacketsCount++;
                switch (pIpe->Status)
                {
                case IP_DEST_NET_UNREACHABLE:
                case IP_DEST_HOST_UNREACHABLE:
                case IP_DEST_PROT_UNREACHABLE:
                case IP_DEST_PORT_UNREACHABLE:
                    cout << "��������, ��������� ���� �� ��������." << endl;
                    break;
                case IP_REQ_TIMED_OUT:
                    cout << "������� ����� �������." << endl;
                    break;
                case IP_TTL_EXPIRED_TRANSIT:
                    cout << "TTL ����� � ����." << endl;
                    break;
                default:
                    cout << "������ ����: %ld"
                        << pIpe->Status << endl;
                    break;
                }
            }
        }
    }

    IcmpCloseHandle(hIP);
    WSACleanup();

    if (MinMS < 0) MinMS = 0;
    unsigned char* pByte = (unsigned char*)&pIpe->Address;
    cout << "���������� Ping "
        << (int)*(pByte)
        << "." << (int)*(pByte + 1)
        << "." << (int)*(pByte + 2)
        << "." << (int)*(pByte + 3) << endl;
    cout << "\t�������: ���������� = " << RequestCount
        << ", ������� = "
        << RequestCount - LostPacketsCount
        << ", �������� = " << LostPacketsCount
        << "<" << (int)(100 / (float)RequestCount) *
        LostPacketsCount
        << " % ������>, " << endl;
    cout << "��������������� ����� ������-��������:"
        << endl << "����������� = " << MinMS
        << "��, ������������ = " << MaxMS
        << "��, ������� = " << (MaxMS + MinMS) / 2
        << "��" << endl;
}