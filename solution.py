class Solution:
    def numDecodings(self, s: str) -> int:
        dp = [1] * (len(s) + 1)
        if s[0] == "0":
            dp[1] = 0
        
        for i in range(2, len(dp)):
            if s[i - 2] == "0":
                if (s[i - 1]) == "0":
                    return 0
                
                dp[i] = dp[i - 1]
                continue
            
            num = int(s[i - 1])
            
            if num == 0:
                if int(s[i - 2]) > 2:
                    return 0
                val = dp[i - 1] if dp[i - 1] == dp[i - 2] else dp[i - 1] - 1
                if val == 0:
                    return 0
                else:
                    dp[i] = val
            elif int(s[i - 2:i]) <= 26:
                dp[i] = dp[i - 1] + dp[i - 2]
            else:
                dp[i] = dp[i - 1]
            
        return dp[-1]
     
       
result = Solution().numDecodings("12120") # expect: 3
print(result)