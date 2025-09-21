#include <unity.h>

// Declaration of the function to be tested
extern int example_function(int a, int b);

void setUp(void) {
    // This is run before EACH TEST
}

void tearDown(void) {
    // This is run after EACH TEST
}

void test_example_function_basic(void) {
    TEST_ASSERT_EQUAL(5, example_function(2, 3));
    TEST_ASSERT_EQUAL(-1, example_function(2, -3));
    TEST_ASSERT_EQUAL(0, example_function(0, 0));
}

int main(void) {
    UNITY_BEGIN();
    RUN_TEST(test_example_function_basic);
    return UNITY_END();
}