namespace OnymojiAuto.Code.Model
{
    public class PointColor
    {
        public string id { get; }
        public int x { get; }
        public int y { get; }
        public decimal color { get; }

        public PointColor(string id, int x, int y, decimal color)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.color = color;
        }
    }
}