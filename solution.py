from typing import List


class Solution:
    def markIsland(self, grid: List[List[str]], row: int, col: int) -> None:
        grid[row][col] = "2"
        if row > 0 and grid[row - 1][col] == "1":
            self.markIsland(grid, row - 1, col)
        if row < len(grid) - 1 and grid[row + 1][col] == "1":
            self.markIsland(grid, row + 1, col)
        if col > 0 and grid[row][col - 1] == "1":
            self.markIsland(grid, row, col - 1)
        if col < len(grid[0]) - 1 and grid[row][col + 1] == "1":
            self.markIsland(grid, row, col + 1)

    def numIslands(self, grid: List[List[str]]) -> int:

        count = 0
        for row in range(len(grid)):
            for col in range(len(grid[0])):
                if grid[row][col] == "1":
                    count += 1
                    self.markIsland(grid, row, col)

        return count


print(Solution().numIslands([["1", "1", "0", "0", "0"], [
      "1", "1", "0", "0", "0"], ["0", "0", "1", "0", "0"], ["0", "0", "0", "1", "1"]]))
