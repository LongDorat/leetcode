#include <unity.h>

// Brute force test declarations
extern void test_two_sum_brute_force_basic_case(void);
extern void test_two_sum_brute_force_negative_numbers(void);
extern void test_two_sum_brute_force_mixed_numbers(void);
extern void test_two_sum_brute_force_duplicate_numbers(void);
extern void test_two_sum_brute_force_large_numbers(void);

// Hash table test declarations
extern void test_two_sum_two_pointers_basic_case(void);
extern void test_two_sum_two_pointers_negative_numbers(void);
extern void test_two_sum_two_pointers_mixed_numbers(void);
extern void test_two_sum_two_pointers_duplicate_numbers(void);
extern void test_two_sum_two_pointers_large_numbers(void);
extern void test_two_sum_two_pointers_no_solution(void);

// Cross validation test declarations
extern void test_cross_validation_basic_case(void);
extern void test_cross_validation_negative_numbers(void);
extern void test_cross_validation_mixed_numbers(void);
extern void test_cross_validation_duplicate_numbers(void);
extern void test_cross_validation_no_solution(void);

void setUp(void) {
    // This is run before EACH TEST
}

void tearDown(void) {
    // This is run after EACH TEST
}

int main(void) {
    UNITY_BEGIN();
    
    // Brute force tests
    RUN_TEST(test_two_sum_brute_force_basic_case);
    RUN_TEST(test_two_sum_brute_force_negative_numbers);
    RUN_TEST(test_two_sum_brute_force_mixed_numbers);
    RUN_TEST(test_two_sum_brute_force_duplicate_numbers);
    RUN_TEST(test_two_sum_brute_force_large_numbers);
    
    // Hash table tests
    RUN_TEST(test_two_sum_two_pointers_basic_case);
    RUN_TEST(test_two_sum_two_pointers_negative_numbers);
    RUN_TEST(test_two_sum_two_pointers_mixed_numbers);
    RUN_TEST(test_two_sum_two_pointers_duplicate_numbers);
    RUN_TEST(test_two_sum_two_pointers_large_numbers);
    RUN_TEST(test_two_sum_two_pointers_no_solution);
    
    // Cross validation tests
    RUN_TEST(test_cross_validation_basic_case);
    RUN_TEST(test_cross_validation_negative_numbers);
    RUN_TEST(test_cross_validation_mixed_numbers);
    RUN_TEST(test_cross_validation_duplicate_numbers);
    RUN_TEST(test_cross_validation_no_solution);
    
    return UNITY_END();
}