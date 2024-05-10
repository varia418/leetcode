from typing import List


class Solution:
    def rob(self, nums: List[int]) -> int:
        n = len(nums)
        if (n == 1):
            return nums[0]
        if (n == 2):
            return max(nums[0], nums[1])
        
        nums.insert(0, 0)
        
        for i in range(2, n + 1):
            nums[i] = max(nums[i - 1], nums[i] + nums[i - 2])

        return nums[n]
    

print(Solution().rob([2,1,1,2]))