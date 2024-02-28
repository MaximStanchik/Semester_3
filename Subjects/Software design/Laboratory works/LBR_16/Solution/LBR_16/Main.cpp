#include "FST.h"

using namespace std;

int _tmain(int argc, TCHAR* argv[])
{
	setlocale(LC_ALL, "rus");

	char originalChain_1[] = "ak dmzil";
	char originalChain_2[] = "a   b dmz   il";
	char originalChain_3[] = "a bcbcbbb dmz il";
	char originalChain_4[] = "a bccc dmzil";
	char originalChain_5[] = "a bbbc  dmz  il";
	char originalChain_6[] = "a  bcccccc     dmz  il";
	char originalChain_7[] = "a   bbcccb dmzil";
	char originalChain_8[] = "abcdcf";
	char originalChain_9[] = "abcddbf";

	char* severalOiginalChains[] = { originalChain_1, originalChain_2, originalChain_3, originalChain_4, originalChain_5, originalChain_6, originalChain_7, originalChain_8, originalChain_9 };

	for (int i = 0; i < sizeof(severalOiginalChains) / sizeof(char*); i++)
	{
		FST::FST disassembledChain(severalOiginalChains[i], 9,
			FST::NODE(1, FST::RELATION('a', 1)),
			FST::NODE(4, FST::RELATION(' ', 1), FST::RELATION('k', 3), FST::RELATION('c', 2), FST::RELATION('b', 2)),
			FST::NODE(3, FST::RELATION('b', 2), FST::RELATION('c', 2), FST::RELATION(' ', 3)),
			FST::NODE(2, FST::RELATION(' ', 3), FST::RELATION('d', 4)),
			FST::NODE(1, FST::RELATION('m', 5)),
			FST::NODE(1, FST::RELATION('z', 6)),
			FST::NODE(2, FST::RELATION('i', 7), FST::RELATION(' ', 6)),
			FST::NODE(1, FST::RELATION('l', 8)),
			FST::NODE()
		);

		if (FST::execute(disassembledChain)) {
			cout << "Цепочка " << disassembledChain.string << " распознана" << endl;
		}	
		else {
			cout << "Цепочка " << disassembledChain.string << " не распознана" << endl;
		}
	};

	system("pause");
	return 0;
}