#include <stdio.h>
#include <ctype.h>

int isNumber(char number[])
{
    if (number[0] == '-' || number[0] == '0')
        return  0;
    for (int i = 0; number[i] != 0; i++)
    {
        if (!isdigit(number[i]))
            return 0;
    }
    return 1;
}

int main(int argc, char *argv[])
{	
	if(!isNumber(argv[1])){
		printf("ƒGƒ‰[I\n", argv[1]);
	} else {
		int numb = atoi(argv[1]);
		int counter;
		for(int i=1; i <= numb; i++){
			counter = 0;
			for(int j = 1; j < i; j++){
				if(i % j == 0) {
					counter++;
				}
			}
			if(counter < 2) printf("%d ", i);
		}

	}
	return 0;
}