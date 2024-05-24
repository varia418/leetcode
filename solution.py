from typing import List


class Solution:
    def canPartition(self, nums: List[int]) -> bool:
        s = sum(nums)

        if s % 2 == 1:
            return False

        half = s / 2
        dp = {nums[-1]}

        for i in range(len(nums) - 2, -1, -1):
            if nums[i] > half:
                return False
            elif nums[i] == half:
                return True
            else:
                curr_dp = dp.copy()
                for prev_sum in dp:
                    curr_sum = nums[i] + prev_sum

                    if curr_sum == half:
                        return True

                    curr_dp.add(curr_sum)
                curr_dp.add(nums[i])
                dp = curr_dp

        return False


print(Solution().canPartition([1, 2, 5]))
