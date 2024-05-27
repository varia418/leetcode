from typing import Optional
from collections import deque


class Node:
    def __init__(self, val=0, neighbors=None):
        self.val = val
        self.neighbors = neighbors if neighbors is not None else []


class Solution:
    def buildGraph(self, edges) -> Optional['Node']:
        nodes = []
        for i in range(len(edges)):
            nodes.append(Node(i + 1))

        for i in range(len(edges)):
            for edge in edges[i]:
                nodes[i].neighbors.append(nodes[edge - 1])

        return nodes[0]

    def cloneGraph(self, node: Optional['Node']) -> Optional['Node']:
        if node is None:
            return None

        queue = deque()
        node_dict = {}
        neighbor_dict = {}

        # init nodes
        queue.append(node)
        while len(queue) > 0:
            current = queue.popleft()
            node_dict[current.val] = Node(current.val)
            neighbor_dict[current.val] = []

            for neighbor in current.neighbors:
                neighbor_dict[current.val].append(neighbor.val)
                if neighbor.val not in node_dict and neighbor not in queue:
                    queue.append(neighbor)

        # set neighbors
        for key in neighbor_dict:
            for neighbor in neighbor_dict[key]:
                node_dict[key].neighbors.append(node_dict[neighbor])

        return node_dict[1]


node = Solution().buildGraph([[2, 4], [1, 3], [2, 4], [1, 3]])
Solution().cloneGraph(node)
