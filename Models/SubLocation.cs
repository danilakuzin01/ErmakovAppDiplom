namespace ErmakovAppDiplom.Models
{
    public class SubLocation
    {
        public long Id { get; set; }
        public Location Location { get; set; }
        public string Name { get; set; }
        public Floor Floor { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
