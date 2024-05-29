from typing import List
from collections import namedtuple


class Solution:
    def orangesRotting(self, grid: List[List[int]]) -> int:
        Coordinate = namedtuple('Coordinate', ['row', 'column'])

        fresh_orange_count = 0
        fresh_oranges = []
        rows, cols = len(grid), len(grid[0])

        for i in range(rows):
            for j in range(cols):
                if grid[i][j] == 1:
                    fresh_oranges.append(Coordinate(i, j))

        fresh_orange_count = len(fresh_oranges)
        if fresh_orange_count == 0:
            return 0

        time = 0
        while fresh_orange_count > 0:
            prev_fresh_orange_count = fresh_orange_count
            current_fresh_oranges = []
            just_rotted_oranges = []
            time += 1
            for coor in fresh_oranges:
                if coor.row > 0 and grid[coor.row - 1][coor.column] == 2:
                    just_rotted_oranges.append(coor)
                    grid[coor.row][coor.column] = 3
                    fresh_orange_count -= 1
                    continue
                if coor.row < rows - 1 and grid[coor.row + 1][coor.column] == 2:
                    just_rotted_oranges.append(coor)
                    grid[coor.row][coor.column] = 3
                    fresh_orange_count -= 1
                    continue
                if coor.column > 0 and grid[coor.row][coor.column - 1] == 2:
                    just_rotted_oranges.append(coor)
                    grid[coor.row][coor.column] = 3
                    fresh_orange_count -= 1
                    continue
                if coor.column < cols - 1 and grid[coor.row][coor.column + 1] == 2:
                    just_rotted_oranges.append(coor)
                    grid[coor.row][coor.column] = 3
                    fresh_orange_count -= 1
                    continue

                current_fresh_oranges.append(coor)

            if prev_fresh_orange_count == fresh_orange_count:
                return -1

            fresh_oranges = current_fresh_oranges
            for coor in just_rotted_oranges:
                grid[coor.row][coor.column] = 2

        return time


print(Solution().orangesRotting([[2, 1, 1], [1, 1, 0], [0, 1, 1]]))
