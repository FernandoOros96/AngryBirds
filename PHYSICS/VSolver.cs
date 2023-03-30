using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using PHYSICS;

namespace PHYSICS
{
    public class VSolver
    {
        VPoint p1, p2;
        public float life = 100;
        Vec2 axis, normal, res;
        float dis, dif;
        List<VPoint> pts;
        public VSolver(List<VPoint> pts)
        {
            this.pts = pts;
        }

        public int Update(Graphics g, int Width, int Height, Point mouse, bool isMouseDown)
        {
            int id;

            id = -1;

            for (int s = 0; s < pts.Count; s++)
            {
                for (int p = s; p < pts.Count; p++)
                {
                    p1 = pts[s];
                    p2 = pts[p];

                    if (p1.Id == p2.Id)// BY ID
                        continue;

                    if (p1.IsPinned && p2.IsPinned)
                        continue;

                    axis = p1.Pos - p2.Pos;//vector de direccion
                    dis = axis.Length(); // magnitud

                    if (dis < (p1.Radius + p2.Radius))//COLLISION DETECTED
                    {

                        if (p2.isPig)
                        {

                            if (p1.vel.X > life || p1.vel.Y > life)
                                p2.hits = true;

                            else
                            {
                                life -= p1.vel.Y / 2;
                                life -= p1.vel.X / 2;
                                
                                p2.setImage(birds.hurt_pig);
                            }
                        }

                        if (p1.isPig)
                        {

                            if (p2.vel.X > life || p2.vel.Y > life)
                                p1.hits = true;

                            else
                            {
                                life -= p2.vel.Y / 2;
                                life -= p2.vel.X/2;
                                p1.setImage(birds.hurt_pig);
                            }
                        }

                        dif = (dis - (p1.Radius + p2.Radius)) * .5f;// dividir la fuerza para repatar entre ambas colisiones
                        normal = axis / dis; // normalizar la direccion para tener el vector unitario
                        res = dif * normal;// vector resultante

                        if (!p1.IsPinned)
                            if (p2.IsPinned)
                                p1.Pos -= res * 2;
                            else
                                p1.Pos -= res;

                        if (!p2.IsPinned)
                            if (p1.IsPinned)
                                p2.Pos += res * 2;
                            else
                                p2.Pos += res;
                        
                    }
                }

                if (isMouseDown)// para seleccionar el punto de masa a mover escogiendo su ID 
                    if (Math.Abs((p1.X - mouse.X) * (p1.X - mouse.X) + (p1.Y - mouse.Y) * (p1.Y - mouse.Y)) <= ((p1.Radius) * (p1.Radius)))
                        id = p1.Id;

                p1.Render(g, Width, Height);
            }

            return id;
        }
    }
}
