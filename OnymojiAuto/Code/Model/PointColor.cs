namespace OnymojiAuto.Code.Model
{
    public class PointColor
    {
        public string id { get; }
        public decimal x { get; }
        public decimal y { get; }
        public decimal color { get; }

        public PointColor(string id)
        {
            this.id = id;
        }

        public PointColor(string id, decimal x, decimal y, decimal color)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.color = color;
        }
    }
}