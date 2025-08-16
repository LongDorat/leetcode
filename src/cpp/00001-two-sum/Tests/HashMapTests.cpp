#include <gtest/gtest.h>
#include "../Solutions.hpp"

TEST(TwoSum_HashMap, BasicCase) {
    std::vector<int> nums = {2, 7, 11, 15};
    int target = 9;
    std::vector<int> result = HashMap(nums, target);
    std::vector<int> expected = {0, 1};
    EXPECT_EQ(result, expected);
}

TEST(TwoSum_HashMap, TargetAtEnd) {
    std::vector<int> nums = {3, 2, 4};
    int target = 6;
    std::vector<int> result = HashMap(nums, target);
    std::vector<int> expected = {1, 2};
    EXPECT_EQ(result, expected);
}

TEST(TwoSum_HashMap, SameNumberTwice) {
    std::vector<int> nums = {3, 3};
    int target = 6;
    std::vector<int> result = HashMap(nums, target);
    std::vector<int> expected = {0, 1};
    EXPECT_EQ(result, expected);
}

TEST(TwoSum_HashMap, NegativeNumbers) {
    std::vector<int> nums = {-1, -2, -3, -4, -5};
    int target = -8;
    std::vector<int> result = HashMap(nums, target);
    std::vector<int> expected = {2, 4};
    EXPECT_EQ(result, expected);
}

TEST(TwoSum_HashMap, MixedNumbers) {
    std::vector<int> nums = {-3, 4, 3, 90};
    int target = 0;
    std::vector<int> result = HashMap(nums, target);
    std::vector<int> expected = {0, 2};
    EXPECT_EQ(result, expected);
}

TEST(TwoSum_HashMap, EmptyArray) {
    std::vector<int> nums = {};
    int target = 0;
    std::vector<int> result = HashMap(nums, target);
    std::vector<int> expected = {};
    EXPECT_EQ(result, expected);
}

TEST(TwoSum_HashMap, SingleElement) {
    std::vector<int> nums = {5};
    int target = 5;
    std::vector<int> result = HashMap(nums, target);
    std::vector<int> expected = {};
    EXPECT_EQ(result, expected);
}

TEST(TwoSum_HashMap, NoSolution) {
    std::vector<int> nums = {1, 2, 3, 4};
    int target = 10;
    std::vector<int> result = HashMap(nums, target);
    std::vector<int> expected = {};
    EXPECT_EQ(result, expected);
}

TEST(TwoSum_HashMap, LargeNumbers) {
    std::vector<int> nums = {1000000, 2000000, 3000000};
    int target = 5000000;
    std::vector<int> result = HashMap(nums, target);
    std::vector<int> expected = {1, 2};
    EXPECT_EQ(result, expected);
}