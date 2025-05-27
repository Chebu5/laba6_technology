using System.Collections.Generic;
using System.Drawing;

namespace laba6_technology
{
    public class Emitter
    {
        private List<Particle> particles = new List<Particle>();
        public List<Point> gravityPoints = new List<Point>();
        
        public float GravitationX = 0;
        public float GravitationY = 1;
        public PointF ParticleSpawnPoint { get; set; }

        public Teleporter Teleporter { get; set; }


        public void UpdateState()
        {
            foreach (var particle in particles)
            {
                particle.Life -= 1;
                if (particle.Life < 0)
                {
                    particle.Life = 20 + Particle.rand.Next(100);
                    particle.X = ParticleSpawnPoint.X;
                    particle.Y = ParticleSpawnPoint.Y;
                    double angle =11* Math.PI/6 + (Particle.rand.NextDouble() * 2 - 1);
                    float speed = (float)Particle.rand.NextDouble();
                    particle.SpeedX = (float)(Math.Cos(angle) * speed);
                    particle.SpeedY = (float)(Math.Sin(angle) * speed);

                    particle.IsTeleported = false;

                    particle.Radius = 2 + Particle.rand.Next(10);
                }
                else
                {
                    if (!particle.IsTeleported)
                    {
                        float gX = Teleporter.Entry.X - particle.X;
                        float gY = Teleporter.Entry.Y - particle.Y;

                        float distanceSquared = gX * gX + gY * gY;

                        if (distanceSquared > 1)
                        {
                            float gravityStrength = 10f;
                            particle.SpeedX += gX * gravityStrength / distanceSquared;
                            particle.SpeedY += gY * gravityStrength / distanceSquared;
                        }
                    }

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;

                    if (Teleporter.CheckCollision(particle))
                    {
                        particle.X = Teleporter.Exit.X;
                        particle.Y = Teleporter.Exit.Y;

                        particle.IsTeleported = true;
                    }
                }
            }

            for (var i = 0; i < 20; ++i)
            {
                if (particles.Count < 100)
                {
                    var particle = new ParticleColorful
                    {
                        FromColor = Color.OrangeRed,
                        ToColor = Color.FromArgb(0, Color.Magenta),
                        X = Teleporter.Entry.X + 20,
                        Y = Teleporter.Entry.Y + 20
                    };
                    //double baseAngle = 10 * Math.PI / 3;
                    //double spread = 100 * Math.PI / 180;
                    double angle =11*Math.PI/6;
                    float speed = 0.1f + (float)Particle.rand.NextDouble() * 1.0f;
                    particle.SpeedX = (float)(Math.Cos(angle) * speed);
                    particle.SpeedY = (float)(Math.Sin(angle) * speed);
                    particles.Add(particle);
                }
                else
                {
                    break;
                }
            }
        }


        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            foreach (var point in gravityPoints)
            {
                g.FillEllipse(
                    new SolidBrush(Color.Red),
                    point.X - 5,
                    point.Y - 5,
                    10,
                    10
                );
            }
                g.DrawEllipse(
                    Pens.Blue,
                    Teleporter.Entry.X - Teleporter.Radius,
                    Teleporter.Entry.Y - Teleporter.Radius,
                    Teleporter.Radius * 2,
                    Teleporter.Radius * 2);
                g.DrawEllipse(Pens.Green,
                    Teleporter.Exit.X - Teleporter.Radius,
                    Teleporter.Exit.Y - Teleporter.Radius,
                    Teleporter.Radius * 2,
                    Teleporter.Radius * 2);
            
        }
    }
}
