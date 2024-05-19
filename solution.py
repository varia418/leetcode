from typing import List


class Solution:
    def coinChange(self, coins: List[int], amount: int) -> int:
        if (amount == 0):
            return 0
        
        coins.sort(reverse = True)
        dp = {0: 0}

        for coin in coins:
            dp[coin] = 1
            
        i = 0
        while True:
            i += 1
            filtered_dict = {k:v for (k,v) in dp.items() if v == i}
            i = i
            for curr, count in sorted(filtered_dict.items(), reverse = True):
                if curr == -1:
                    continue
                
                if amount - curr in dp:
                    dp[amount] = count + dp[amount - curr]
                    return dp[amount]
                
                for coin in coins:
                    next = curr + coin
                    if next in dp or next > amount:
                        continue
                    
                    dp[next] = count + 1

                if curr + coins[-1] not in dp:
                    dp[curr] = -1
                 
            if len(filtered_dict) == 0:
                return -1
        
result = Solution().coinChange([474,83,404,3], 264)
print(result)