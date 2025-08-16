#ifndef SOLUTIONS_HPP
#define SOLUTIONS_HPP

#include "IncludeLib.hpp"

/**
 * @brief Solves Two Sum problem using brute force approach.
 *        Checks every pair of numbers to find two that sum to target.
 * @param nums Vector of integers to search through
 * @param target The target sum to find
 * @return Vector containing indices of two numbers that add up to target
 * @note Time Complexity: O(n²) | Space Complexity: O(1)
 */
std::vector<int> BruteForce(std::vector<int> nums, int target);

/**
 * @brief Solves Two Sum problem using hash map approach (optimal solution).
 *        Uses hash map to store seen numbers and find complement in O(1) time.
 * @param nums Vector of integers to search through
 * @param target The target sum to find
 * @return Vector containing indices of two numbers that add up to target
 * @note Time Complexity: O(n) | Space Complexity: O(n)
 */
std::vector<int> HashMap(std::vector<int> nums, int target);

#endif // SOLUTIONS_HPP