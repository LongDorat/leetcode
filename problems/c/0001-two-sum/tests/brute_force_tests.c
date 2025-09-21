#include <unity.h>
#include <stdlib.h>

// Declaration of the function to be tested
extern int *two_sum_brute_force(int *nums, int numsSize, int target, int *returnSize);

void test_two_sum_brute_force_basic_case(void) {
    int nums[] = {2, 7, 11, 15};
    int numsSize = 4;
    int target = 9;
    int returnSize;
    
    int *result = two_sum_brute_force(nums, numsSize, target, &returnSize);
    
    TEST_ASSERT_NOT_NULL(result);
    TEST_ASSERT_EQUAL(2, returnSize);
    // The function should return indices, not values
    TEST_ASSERT_EQUAL(0, result[0]);
    TEST_ASSERT_EQUAL(1, result[1]);
    // Verify the indices point to correct values that sum to target
    TEST_ASSERT_EQUAL(target, nums[result[0]] + nums[result[1]]);
    
    free(result);
}

void test_two_sum_brute_force_negative_numbers(void) {
    int nums[] = {-1, -2, -3, -4, -5};
    int numsSize = 5;
    int target = -8;
    int returnSize;
    
    int *result = two_sum_brute_force(nums, numsSize, target, &returnSize);
    
    TEST_ASSERT_NOT_NULL(result);
    TEST_ASSERT_EQUAL(2, returnSize);
    // Should return indices 2 and 4 (values -3 and -5)
    TEST_ASSERT_EQUAL(2, result[0]);
    TEST_ASSERT_EQUAL(4, result[1]);
    // Verify the indices point to correct values that sum to target
    TEST_ASSERT_EQUAL(target, nums[result[0]] + nums[result[1]]);
    
    free(result);
}

void test_two_sum_brute_force_mixed_numbers(void) {
    int nums[] = {-3, 4, 3, 90};
    int numsSize = 4;
    int target = 0;
    int returnSize;
    
    int *result = two_sum_brute_force(nums, numsSize, target, &returnSize);
    
    TEST_ASSERT_NOT_NULL(result);
    TEST_ASSERT_EQUAL(2, returnSize);
    // Should return indices 0 and 2 (values -3 and 3)
    TEST_ASSERT_EQUAL(0, result[0]);
    TEST_ASSERT_EQUAL(2, result[1]);
    // Verify the indices point to correct values that sum to target
    TEST_ASSERT_EQUAL(target, nums[result[0]] + nums[result[1]]);
    
    free(result);
}

void test_two_sum_brute_force_duplicate_numbers(void) {
    int nums[] = {3, 3};
    int numsSize = 2;
    int target = 6;
    int returnSize;
    
    int *result = two_sum_brute_force(nums, numsSize, target, &returnSize);
    
    TEST_ASSERT_NOT_NULL(result);
    TEST_ASSERT_EQUAL(2, returnSize);
    // Should return indices 0 and 1 (both values are 3)
    TEST_ASSERT_EQUAL(0, result[0]);
    TEST_ASSERT_EQUAL(1, result[1]);
    // Verify the indices point to correct values that sum to target
    TEST_ASSERT_EQUAL(target, nums[result[0]] + nums[result[1]]);
    
    free(result);
}

void test_two_sum_brute_force_large_numbers(void) {
    int nums[] = {1000000, 999999, 1};
    int numsSize = 3;
    int target = 1999999;
    int returnSize;
    
    int *result = two_sum_brute_force(nums, numsSize, target, &returnSize);
    
    TEST_ASSERT_NOT_NULL(result);
    TEST_ASSERT_EQUAL(2, returnSize);
    // Should return indices 0 and 1 (values 1000000 and 999999)
    TEST_ASSERT_EQUAL(0, result[0]);
    TEST_ASSERT_EQUAL(1, result[1]);
    // Verify the indices point to correct values that sum to target
    TEST_ASSERT_EQUAL(target, nums[result[0]] + nums[result[1]]);
    
    free(result);
}