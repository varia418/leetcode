from typing import List
from collections import namedtuple
import sys


class Solution:
    def lengthOfLIS(self, nums: List[int]) -> int:
        n = len(nums)
        Pair = namedtuple("Pair", ["num", "count"])
        dp = [Pair(sys.maxsize, 0)] * (n + 1)
        maxLen = 0

        for i in range(n - 1, -1, -1):
            currMaxCount = 0
            for j in range(i + 1, len(dp)):
                if nums[i] < dp[j].num:
                    currMaxCount = max(currMaxCount, dp[j].count)

            dp[i] = Pair(nums[i], currMaxCount + 1)
            maxLen = max(maxLen, dp[i].count)

        return maxLen


print(Solution().lengthOfLIS([4, 10, 4, 3, 8, 9]))
