from typing import List


class Solution:
    def __init__(self):
        self.dp = {}

    def wordBreak(
        self,
        s: str,
        word_dict: List[str],
        s_index: int = 0,
    ) -> bool:
        if s_index == len(s):
            return True

        word_dict.sort(key=len, reverse=True)

        result = False
        curr = s[s_index:]
        if curr in self.dp:
            return False

        for word in word_dict:
            if curr.startswith(word):
                result = self.wordBreak(
                    s, word_dict, s_index + len(word)
                )

                if result is True:
                    break

        if not result:
            self.dp[curr] = False

        return result


s = "aaaaaaa"
word_dict = ["aaaa", "aaa"]
print(Solution().wordBreak(s, word_dict))
