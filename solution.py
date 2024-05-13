from typing import List

class Solution:
    def rob(self, nums: List[int]) -> int:
        if len(nums) <= 3:
            return max(nums)

        n = len(nums)
        numsWithoutFirstHouse = nums.copy()
        # numsWithoutFirstHouse[0] = 0
        del numsWithoutFirstHouse[0]
        numsWithoutLastHouse = nums.copy()
        # numsWithoutLastHouse[-1] = 0
        del numsWithoutLastHouse[-1]
        
        numsWithoutFirstHouse.insert(0, 0)
        numsWithoutLastHouse.insert(0, 0)
        
        for i in range(2, n):
            numsWithoutFirstHouse[i] = max(numsWithoutFirstHouse[i - 1], numsWithoutFirstHouse[i] + numsWithoutFirstHouse[i - 2])
            numsWithoutLastHouse[i] = max(numsWithoutLastHouse[i - 1], numsWithoutLastHouse[i] + numsWithoutLastHouse[i - 2])
            
        return max(numsWithoutFirstHouse[-1], numsWithoutLastHouse[-1])

print(Solution().rob([4,1,2,7,5,3,1]))