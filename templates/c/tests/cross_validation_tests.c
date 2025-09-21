#include <unity.h>

// Declaration of the function to be tested
extern int example_function(int a, int b);

void test_example_function_cross_validation(void) {
    TEST_ASSERT_EQUAL(5, example_function(2, 3));
    TEST_ASSERT_EQUAL(-1, example_function(2, -3));
    TEST_ASSERT_EQUAL(0, example_function(0, 0));
}