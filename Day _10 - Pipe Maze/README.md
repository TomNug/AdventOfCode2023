# Day 10
## Key Skills: 

- 2D arrays
- Queues
- breadth-first search for traversing a grid
- flood-fill algorithm
  
## --- Day 9 ---

It's been a long day

### My Approach
Used the symbol to determine the two adjacent pipe sections.
From the start point, explored both directions of the pipe simultaneously.
Stopped when one route was exploring a node from the other route.

## --- Part Two ---

Long day

### My Approach
Came up with the idea to flood the grid to see what's connected.
Converted each character to a 3x3 grid to represent what corners were open to which other adjacent nodes.

E.g.
```J``` becomes:
```
.X.
XX.
...
```

```LJ``` becomes:
```
.X..X.
.XXXX.
......
```

Then explored the grid in a breadth-first search.
