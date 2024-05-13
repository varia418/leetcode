class Solution:
    def longestPalindrome(self, s: str) -> str:
        n = len(s)
        result = ""
        resLength = 0

        for i in range(0, n):
            # odd length
            l, r = i, i
            while (l >= 0 and r < n and s[l] == s[r]):
                if (resLength < r - l + 1):
                    result = s[l:r + 1]
                    resLength = r - l + 1
                    
                l -= 1
                r += 1
                
            # even length
            l, r = i, i + 1
            while (l >= 0 and r < n and s[l] == s[r]):
                if (resLength < r - l + 1):
                    result = s[l:r + 1]
                    resLength = r - l + 1
                    
                l -= 1
                r += 1
                
        return result

print(Solution().longestPalindrome("abb"))