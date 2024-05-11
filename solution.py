from typing import List


class Solution:
    def findMaxK(self, nums: List[int]) -> int:
        numsMap = {}

        for i in range(0, len(nums)):
            num = abs(nums[i])
            
            if (numsMap.get(num) is None):
                if (nums[i] > 0):
                    numsMap[num] = 1
                else:
                    numsMap[num] = -1
            else:
                if (nums[i] > 0 and numsMap[num] < 0):
                    numsMap[num] = numsMap[num] + 1
                if (nums[i] < 0 and numsMap[num] > 0):
                    numsMap[num] = numsMap[num] - 1
        
        for key in reversed(sorted(numsMap.keys())):
            if (numsMap.get(key) == 0):
                return key
            
        return -1
    
input = [-30,34,1,32,26,-9,-30,22,-49,29,48,47,38,4,43,12,-1,-8,11,-37,32,40,9,15,-34,-34,-16,-5,26,-44,-36,-13,-16,10,39,-17,-22,17,-16]
print(Solution().findMaxK(input))