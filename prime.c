#include <stdio.h>
#include <ctype.h>

int isNumber(char number[])
{
    int i = 0;

    //checking for negative numbers
    if (number[0] == '-')
        i = 1;
    for (; number[i] != 0; i++)
    {
        //if (number[i] > '9' || number[i] < '0')
        if (!isdigit(number[i]))
            return 0;
    }
    return 1;
}

int main(int argc, char *argv[])
{	
	if(!isNumber(argv[1])){
		printf("エラー！%sは数字じゃありません。\n", argv[1]);
	} else {
		int numb = atoi(argv[1]);
	
		for(int i=1; i < numb; i++){
			if(i%2 != 0) {
				printf("%d ", i);
			}
		}

	}
	return 0;
}