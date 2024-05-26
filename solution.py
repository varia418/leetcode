from typing import List


class Solution:
    def markIsland(self, grid: List[List[int]], row: int, col: int) -> int:
        grid[row][col] = 2
        area = 1
        if row > 0 and grid[row - 1][col] == 1:
            area += self.markIsland(grid, row - 1, col)
        if row < len(grid) - 1 and grid[row + 1][col] == 1:
            area += self.markIsland(grid, row + 1, col)
        if col > 0 and grid[row][col - 1] == 1:
            area += self.markIsland(grid, row, col - 1)
        if col < len(grid[0]) - 1 and grid[row][col + 1] == 1:
            area += self.markIsland(grid, row, col + 1)

        return area

    def maxAreaOfIsland(self, grid: List[List[int]]) -> int:
        maxArea = 0
        for row in range(len(grid)):
            for col in range(len(grid[0])):
                if grid[row][col] == 1:
                    maxArea = max(maxArea, self.markIsland(grid, row, col))

        return maxArea


print(Solution().maxAreaOfIsland([[0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0], [0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0], [0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0], [
      0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0], [0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0]]))
