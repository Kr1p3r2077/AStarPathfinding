public class PathfindingCell
{
    public Vec2Int pos;
    public PathfindingCell parent;

    public float gCost = float.MaxValue, hCost = float.MaxValue;
    public float fCost => hCost + gCost;

    public PathfindingCell(Vec2Int pos, PathfindingCell parent = null)
    {
        this.pos = pos;
        this.parent = parent;
    }

    public void UpdateCostToDestination(Vec2Int pos)
    {
        hCost = Math.Abs(this.pos.x - pos.x) + Math.Abs(this.pos.y - pos.y);
        hCost *= 10;
    }
}
