#include "Solutions.hpp"

std::vector<int> BruteForce(std::vector<int> nums, int target)
{
    if (nums.size() < 2)
        return {};

    for (int i = 0; i < nums.size() - 1; i++)
    {
        for (int j = i + 1; j < nums.size(); j++)
        {
            if (nums[i] + nums[j] == target)
            {
                return {i, j};
            }
        }
    }
    return {};
}

std::vector<int> HashMap(std::vector<int> nums, int target)
{
    if (nums.size() < 2)
        return {};

    std::unordered_map<int, int> map;

    for (int i = 0; i < nums.size(); i++)
    {
        if (map.find(target - nums[i]) != map.end())
            return {map[target - nums[i]], i};

        map[nums[i]] = i;
    }
    return {};
}
