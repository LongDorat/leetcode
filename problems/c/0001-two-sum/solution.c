#include <stdio.h>
#include <stdlib.h>

/**
 * @brief Finds two numbers in the array that add up to the target
 * @param nums The input array of integers
 * @param numsSize The size of the input array
 * @param target The target sum
 * @param returnSize Pointer to store the size of the returned array
 * @returns Array containing the indices of the two numbers that sum to target
 * @note Time Complexity: O(n^2), Space Complexity: O(1)
 */
int *two_sum_brute_force(int *nums, int numsSize, int target, int *returnSize)
{
    *returnSize = 2;
    int *result = (int *)malloc(2 * sizeof(int));

    for (int i = 0; i < numsSize - 1; i++)
    {
        for (int j = i + 1; j < numsSize; j++)
        {
            if (nums[i] + nums[j] == target)
            {
                result[0] = i;
                result[1] = j;
            }
        }
    }

    return result;
}

typedef struct
{
    int value;
    int index;
} NumIndex;

int compare(const void *a, const void *b) {
    return ((NumIndex*)a)->value - ((NumIndex*)b)->value;
}

/**
 * @brief Finds two numbers in the array that add up to the target using two pointers approach
 * @param nums The input array of integers
 * @param numsSize The size of the input array
 * @param target The target sum
 * @param returnSize Pointer to store the size of the returned array
 * @returns Array containing the indices of the two numbers that sum to target
 * @note Time Complexity: O(n log n), Space Complexity: O(n)
 */
int *two_sum_two_pointers(int *nums, int numsSize, int target, int *returnSize)
{
    *returnSize = 2;
    int *result = (int *)malloc(2 * sizeof(int));

    NumIndex* pairs = (NumIndex*)malloc(numsSize * sizeof(NumIndex));
    for (int i = 0; i < numsSize; i++)
    {
        pairs[i].value = nums[i];
        pairs[i].index = i;
    }

    qsort(pairs, numsSize, sizeof(NumIndex), compare);

    int left = 0;
    int right = numsSize - 1;
    while (left < right)
    {
        int sum = pairs[left].value + pairs[right].value;

        if (sum == target)
        {
            result[0] = pairs[left].index;
            result[1] = pairs[right].index;
            free(pairs);
            return result;
        }

        if (sum < target)
        {
            left++;
        }
        else
        {
            right--;
        }
    }

    free(result);
    free(pairs);
    return NULL;
}