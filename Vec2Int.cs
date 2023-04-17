public class Vec2Int
{
    public int x, y;
    public Vec2Int(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString()
    {
        return x + " " + y;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Vec2Int) throw new Exception("Nothing can be compared except the 'Vec2Int' type");
        return (Vec2Int)obj == this;
    }
}
