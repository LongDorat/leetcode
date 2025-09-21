#include <unity.h>

// Declaration of the test function
extern void test_example_function_basic(void);
extern void test_example_function_cross(void);

void setUp(void) {
    // This is run before EACH TEST
}

void tearDown(void) {
    // This is run after EACH TEST
}

int main(void) {
    UNITY_BEGIN();
    RUN_TEST(test_example_function_basic);
    RUN_TEST(test_example_function_cross);
    return UNITY_END();
}