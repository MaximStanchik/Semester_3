.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO: DWORD
MessageBoxA PROTO: DWORD, : DWORD, : DWORD, : DWORD

.STACK 4096

.CONST

.DATA

myBytes   BYTE  10h, 20h, 30h, 40h
myWords   WORD  8Ah, 3Bh, 44h, 5Fh, 99h
myDoubles DWORD 0,   2,   3,   4,   5,   6
myPointer DWORD myDoubles
MB_OK     EQU   0
HW DD ?
TITLEOFWINDOW DB "Станчик Максим Андреевич, 2-ой курс, ПОИТ 4", 0
RESULT_1 DB "Нулевой элемент присутствует", 0
RESULT_2 DB "Нулевой элемент отсутствует", 0

FIRSTARRAY  BYTE 1, 0, 6, 7, 9, 1, 5

FIRSTARRAYSIZE = ($ - FIRSTARRAY ) / 1
FIRSTARRAYSUM DWORD ?

.CODE

main PROC
START:

mov esi, OFFSET myBytes
mov ah, [esi + 1]
mov al, [esi + 3]

xor eax, eax
xor esi, esi
mov ecx, FIRSTARRAYSIZE
mov esi, OFFSET FIRSTARRAY   

SUM_LOOP:
  add al, [esi]
  inc esi
  loop SUM_LOOP

mov FIRSTARRAYSUM, eax

xor ebx, ebx
mov ecx, -1
CYCLE:
  add ecx, 1
  cmp [FIRSTARRAY + ECX], 0
  je TRUE
  jne FALSE

TRUE:
  add EBX, 0
  cmp ecx, 7
  je ENDOFCYCLE
  jne CYCLE
  
FALSE:
  add EBX, 1 
  cmp ecx, 7
  je ENDOFCYCLE
  jne CYCLE


ENDOFCYCLE:

   ISTHEREANELEMENT:
     cmp ebx, 7
     je PRESENCE
     jne ABSENCE

   PRESENCE:
     INVOKE MessageBoxA, HW, OFFSET RESULT_1, OFFSET TITLEOFWINDOW, MB_OK
     jmp ENDOFPROGRAM

   ABSENCE:
     INVOKE MessageBoxA, HW, OFFSET RESULT_2, OFFSET TITLEOFWINDOW, MB_OK

   ENDOFPROGRAM:
     push 0
     call ExitProcess

main ENDP
end main




