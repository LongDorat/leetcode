#include <unity.h>
#include <stdlib.h>

// Declaration of the function to be tested
extern int *two_sum_two_pointers(int *nums, int numsSize, int target, int *returnSize);

void test_two_sum_two_pointers_basic_case(void) {
    int nums[] = {2, 7, 11, 15};
    int numsSize = 4;
    int target = 9;
    int returnSize;
    
    int *result = two_sum_two_pointers(nums, numsSize, target, &returnSize);
    
    TEST_ASSERT_NOT_NULL(result);
    TEST_ASSERT_EQUAL(2, returnSize);
    // The function returns indices, and they should be in sorted order
    // For input [2, 7, 11, 15] with target 9, indices should be [0, 1]
    int expected_indices[2] = {0, 1};
    TEST_ASSERT_TRUE((result[0] == expected_indices[0] && result[1] == expected_indices[1]) ||
                     (result[0] == expected_indices[1] && result[1] == expected_indices[0]));
    
    free(result);
}

void test_two_sum_two_pointers_negative_numbers(void) {
    int nums[] = {-1, -2, -3, -4, -5};
    int numsSize = 5;
    int target = -8;
    int returnSize;
    
    int *result = two_sum_two_pointers(nums, numsSize, target, &returnSize);
    
    TEST_ASSERT_NOT_NULL(result);
    TEST_ASSERT_EQUAL(2, returnSize);
    // For input [-1, -2, -3, -4, -5] with target -8, we need -3 and -5
    // Original indices are 2 and 4
    int expected_indices[2] = {2, 4};
    TEST_ASSERT_TRUE((result[0] == expected_indices[0] && result[1] == expected_indices[1]) ||
                     (result[0] == expected_indices[1] && result[1] == expected_indices[0]));
    
    free(result);
}

void test_two_sum_two_pointers_mixed_numbers(void) {
    int nums[] = {-3, 4, 3, 90};
    int numsSize = 4;
    int target = 0;
    int returnSize;
    
    int *result = two_sum_two_pointers(nums, numsSize, target, &returnSize);
    
    TEST_ASSERT_NOT_NULL(result);
    TEST_ASSERT_EQUAL(2, returnSize);
    // For input [-3, 4, 3, 90] with target 0, we need -3 and 3
    // Original indices are 0 and 2
    int expected_indices[2] = {0, 2};
    TEST_ASSERT_TRUE((result[0] == expected_indices[0] && result[1] == expected_indices[1]) ||
                     (result[0] == expected_indices[1] && result[1] == expected_indices[0]));
    
    free(result);
}

void test_two_sum_two_pointers_duplicate_numbers(void) {
    int nums[] = {3, 3};
    int numsSize = 2;
    int target = 6;
    int returnSize;
    
    int *result = two_sum_two_pointers(nums, numsSize, target, &returnSize);
    
    TEST_ASSERT_NOT_NULL(result);
    TEST_ASSERT_EQUAL(2, returnSize);
    // For input [3, 3] with target 6, indices should be [0, 1]
    int expected_indices[2] = {0, 1};
    TEST_ASSERT_TRUE((result[0] == expected_indices[0] && result[1] == expected_indices[1]) ||
                     (result[0] == expected_indices[1] && result[1] == expected_indices[0]));
    
    free(result);
}

void test_two_sum_two_pointers_large_numbers(void) {
    int nums[] = {1000000, 999999, 1};
    int numsSize = 3;
    int target = 1999999;
    int returnSize;
    
    int *result = two_sum_two_pointers(nums, numsSize, target, &returnSize);
    
    TEST_ASSERT_NOT_NULL(result);
    TEST_ASSERT_EQUAL(2, returnSize);
    // For input [1000000, 999999, 1] with target 1999999, indices should be [0, 1]
    int expected_indices[2] = {0, 1};
    TEST_ASSERT_TRUE((result[0] == expected_indices[0] && result[1] == expected_indices[1]) ||
                     (result[0] == expected_indices[1] && result[1] == expected_indices[0]));
    
    free(result);
}

void test_two_sum_two_pointers_no_solution(void) {
    int nums[] = {1, 2, 3, 4};
    int numsSize = 4;
    int target = 10;
    int returnSize;
    
    int *result = two_sum_two_pointers(nums, numsSize, target, &returnSize);
    
    // Should return NULL when no solution exists
    TEST_ASSERT_NULL(result);
}