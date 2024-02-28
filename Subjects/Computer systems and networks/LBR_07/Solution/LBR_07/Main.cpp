#include "stdafx.h"

#include "IPOptionInfo.h"
#include "SendingEchoRequests.h"
#include "ReceivedEchoReplies.h"

void Ping(const char* cHost, unsigned int Timeout, unsigned int RequestCount) {
    HANDLE hIP = IcmpCreateFile();
    if (hIP == INVALID_HANDLE_VALUE) {
        WSACleanup();
        return;
    }

    char SendData[32] = "Data for ping"; // ����� ��� ��������
    int LostPacketsCount = 0; // ���-�� ���������� �������
    unsigned int MaxMS = 0; // ������������ ����� ������ (��)
    int MinMS = -1; // ����������� ����� ������ (��)

    IP_OPTION_INFORMATION option = { 255, 255, 240, 0, 0 }; // ����� IP

    // �������� ������ ��� ����� � ����� ������
    PICMP_ECHO_REPLY pIpe = (PICMP_ECHO_REPLY)GlobalAlloc(GHND, sizeof(ICMP_ECHO_REPLY) + sizeof(SendData));
    if (pIpe == 0) {
        IcmpCloseHandle(hIP);
        WSACleanup();
        return;
    }
    pIpe->Data = SendData;
    pIpe->DataSize = sizeof(SendData);
    unsigned long ipaddr = inet_addr(cHost);

    for (unsigned int c = 0; c < RequestCount; c++) {
        int dwStatus = IcmpSendEcho(hIP, ipaddr, SendData, sizeof(SendData), &option, pIpe, sizeof(ICMP_ECHO_REPLY) + sizeof(SendData), Timeout);
        if (dwStatus > 0) {
            for (int i = 0; i < dwStatus; i++) {
                unsigned char* pIpPtr = (unsigned char*)&pIpe->Address;
                cout << "����� �� " << (int)*(pIpPtr)
                    << "." << (int)*(pIpPtr + 1)
                    << "." << (int)*(pIpPtr + 2)
                    << "." << (int)*(pIpPtr + 3)
                    << ": ����� ���� = " << pIpe->DataSize
                    << " ����� = " << pIpe->RoundTripTime
                    << "�� TTL = " << (int)pIpe->Options.Ttl;
                MaxMS = (MaxMS > pIpe->RoundTripTime) ? MaxMS : pIpe->RoundTripTime;
                MinMS = (MinMS < (int)pIpe->RoundTripTime && MinMS >= 0) ? MinMS : pIpe->RoundTripTime;
                cout << endl;
            }
        }
        else {
            if (pIpe->Status) {
                LostPacketsCount++;
                switch (pIpe->Status) {
                case IP_DEST_NET_UNREACHABLE:
                case IP_DEST_HOST_UNREACHABLE:
                case IP_DEST_PROT_UNREACHABLE:
                case IP_DEST_PORT_UNREACHABLE:
                    cout << "Remote host may be down." << endl;
                    break;
                case IP_REQ_TIMED_OUT:
                    cout << "Request timed out." << endl;
                    break;
                case IP_TTL_EXPIRED_TRANSIT:
                    cout << "TTL expired in transit." << endl;
                    break;
                default:
                    cout << "Error code: " << pIpe->Status << endl;
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
        << ", �������� = " << RequestCount - LostPacketsCount
        << ", �������� = " << LostPacketsCount
        << " <" << (int)(100 / (float)RequestCount) * LostPacketsCount
        << " % ������>, " << endl;
    cout << "��������������� ����� ������-��������:"
        << endl << "����������� = " << MinMS
        << "��, ������������ = " << MaxMS
        << "��, ������� = " << (MaxMS + MinMS) / 2 << "��" << endl;
}

int main(int argc, char* argv[]) {
    if (argc < 3) {
        cout << "�������������: ping <�����> <����� ��������> [���������� �������]" << endl;
        return 1;
    }

    const char* host = argv[1];
    unsigned int timeout = atoi(argv[2]);
    unsigned int requestCount = (argc >= 4) ? atoi(argv[3]) : 4;

    Ping(host, timeout, requestCount);

    return 0;
}