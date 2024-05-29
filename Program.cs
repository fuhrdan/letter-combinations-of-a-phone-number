/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
char** letterCombinations(char* digits, int* returnSize) {
    if (!digits || strlen(digits) == 0)
	{
		*returnSize = 0;
		return NULL;
	}

	char* mapping[] = {"abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};

	int total = 1;
	for (int i = 0; i < strlen(digits); i++)
	{
		total *= strlen(mapping[digits[i] - '2']);
	}

	*returnSize = total;
	char** result = (char**)malloc(total * sizeof(char*));

	for (int i = 0; i < total; i++)
	{
		result[i] = (char*)malloc((strlen(digits) + 1) * sizeof(char));
		int temp = 1;
		for (int j = 0; j < strlen(digits); j++)
		{
			int len = strlen(mapping[digits[j] - '2']);
			result[i][j] = mapping[digits[j] - '2'][(i / temp) % len];
			temp *= len;
		}
		result[i][strlen(digits)] = '\0';
	}

	return result;
}