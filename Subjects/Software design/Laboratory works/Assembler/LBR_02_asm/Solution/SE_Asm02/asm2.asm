.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO: DWORD
MessageBoxA PROTO: DWORD, : DWORD, : DWORD, : DWORD

.STACK 4096

.CONST

.DATA
MB_OK EQU 0
ACTION DB "��������:", 0
ORIGNUMBERS DB "������� ����� 3 � 5", 0
COMPLETITION DB "���������:", 0
RESULT DB "�������� ", 0
HW DD ?

.CODE

main PROC
START:
    ; ����� ���� � STR1
    INVOKE MessageBoxA, HW, OFFSET ORIGNUMBERS, OFFSET ACTION, MB_OK

    ; ���������� �������� ��������
    MOV eax, 3
    ADD eax, 5

    ; ����������� ����� � ������

    ADD eax, 30h
    mov [RESULT + 9], al
    ; ����� ���� � RESULT � ����������� ��������
    INVOKE MessageBoxA, HW, OFFSET RESULT, OFFSET COMPLETITION, MB_OK

    push 0
    call ExitProcess
main ENDP
end main