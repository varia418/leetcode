from typing import List

class Solution:
    def maxProduct(self, nums: List[int]) -> int:
        result = max(nums)
        
        dp = [[]] * len(nums)

        if nums[0] < 0:
            dp[0].append(0)
            dp[0].append(nums[0])
        elif nums[0] > 0:
            dp[0].append(nums[0])
            dp[0].append(0)
        else:
            dp[0].append(0)
            dp[0].append(0)
        
        for i in range(1, len(nums)):
            dp[i] = []
            first = nums[i] * dp[i - 1][0]
            second = nums[i] * dp[i - 1][1]
            dp[i].append(max(0, nums[i], first, second))

            neg = [0]
            nums[i] < 0 and neg.append(nums[i])
            first < 0 and neg.append(first)
            second < 0 and neg.append(second)
            
            dp[i].append(min(neg))
            
            result = max(result, max(dp[i]))
                        
        return result
    
    
print(Solution().maxProduct([2,3,-2,4]))