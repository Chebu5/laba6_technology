using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6_technology
{
    class Teleporter
    {
        public Point Entry { get; set; }
        public Point Exit { get; set; }   
        public int Radius { get; set; } = 50;

        public Teleporter(Point entry, Point exit)
        {
            Entry = entry;
            Exit = exit;
        }

        public bool CheckParticle(Particle particle)
        {
           
            float dx = particle.X - Entry.X;
            float dy = particle.Y - Entry.Y;
            float distanceSquared = dx * dx + dy * dy;

            return distanceSquared <= Radius * Radius;
        }

        public void TeleportParticle(Particle particle)
        {
            
            particle.X = Exit.X;
            particle.Y = Exit.Y;

            
            particle.X += Particle.rand.Next(-10, 10);
            particle.Y += Particle.rand.Next(-10, 10);
        }

        public void Render(Graphics g)
        {
          
            g.DrawEllipse(new Pen(Color.Blue, 2),
                Entry.X - Radius, Entry.Y - Radius,
                Radius * 2, Radius * 2);
            g.FillEllipse(Brushes.Blue,
                Entry.X - 5, Entry.Y - 5, 10, 10);

           
            g.DrawEllipse(new Pen(Color.Green, 2),
                Exit.X - Radius, Exit.Y - Radius,
                Radius * 2, Radius * 2);
            g.FillEllipse(Brushes.Green,
                Exit.X - 5, Exit.Y - 5, 10, 10);
        }
    }
}
