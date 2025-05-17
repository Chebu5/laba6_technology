using System.Drawing;

namespace laba6_technology
{
    public class Teleporter
    {
        public Point Entry { get; set; }
        public Point Exit { get; set; }
        public int Radius { get; set; } = 30;

        public Teleporter(Point entry, Point exit)
        {
            Entry = entry;
            Exit = exit;
        }
        public bool CheckCollision(Particle particle)
        {
            float dx = particle.X - Entry.X;
            float dy = particle.Y - Entry.Y;
            return dx * dx + dy * dy <= Radius * Radius;
        }
    }
}
