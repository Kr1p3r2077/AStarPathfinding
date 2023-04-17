public class AStarPathfinding
{
    public List<PathfindingCell> open = new List<PathfindingCell>();
    public List<PathfindingCell> closed = new List<PathfindingCell>();

    Vec2Int from;
    Vec2Int to;

    public PathfindingCell Find(Vec2Int from, Vec2Int to)
    {
        this.to = to;
        this.from = from;

        var start = new PathfindingCell(from);
        start.UpdateCostToDestination(to);
        start.gCost = 0;
        open.Add(start);

        PathfindingCell current = null;
        int c = 0;
        while (true)
        {
            c++;
            if (c == 10000) return null;

            current = open[0];

            foreach (var v in open)
            {
                if (v.fCost < current.fCost)
                    current = v;
            }

            open.Remove(current);
            closed.Add(current);

            if (current.pos.x == to.x && current.pos.y == to.y) break;

            PrepNeighbours(current);
        }

        return current;
    }

    private void PrepNeighbours(PathfindingCell cell)
    {
        List<PathfindingCell> neighbours = new List<PathfindingCell>();
        PrepareNeighbour(cell, neighbours, 1, 0, 10);
        PrepareNeighbour(cell, neighbours, -1, 0, 10);
        PrepareNeighbour(cell, neighbours, 1, 1, 14);
        PrepareNeighbour(cell, neighbours, -1, 1, 14);
        PrepareNeighbour(cell, neighbours, 1, -1, 14);
        PrepareNeighbour(cell, neighbours, -1, -1, 14);
        PrepareNeighbour(cell, neighbours, 0, 1, 10);
        PrepareNeighbour(cell, neighbours, 0, -1, 10);
    }

    private void PrepareNeighbour(PathfindingCell cell, List<PathfindingCell> neighbours, int x, int y, int step)
    {
        var c = GetCell(cell.pos.x + x, cell.pos.y + y);
        if (c != null)
        {
            if (c.parent != null)
            {
                if (c.gCost > c.parent.gCost + step || !open.Contains(c))
                {
                    c.parent = cell;
                    c.gCost = c.parent.gCost + step;
                    if (!open.Contains(c))
                        open.Add(c);
                }
            }
            else
            {
                c.parent = cell;
                c.gCost = c.parent.gCost + step;
                if (!open.Contains(c))
                    open.Add(c);
            }

            c.UpdateCostToDestination(to);
            neighbours.Add(c);
        }
    }

    private PathfindingCell GetCell(int x, int y)
    {
        if (closed.Any(el => el.pos.x == x && el.pos.y == y)) return null;

        for (int i = 0; i < open.Count; i++)
        {
            if (open[i].pos == new Vec2Int(x, y))
            {
                return open[i];
            }
        }

        var cell = new PathfindingCell(new Vec2Int(x, y));
        return cell;
    }
}
