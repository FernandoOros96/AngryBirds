using PHYSICS;
using System.Collections.Generic;
using System.Drawing;
using System;

public class Hbox
{
    int id;
    bool self;
    List<Vec2> xp2 = new List<Vec2>();//-------------
    float minX, maxX, minY, maxY,endurance;
    Vec2 pos;
    int width, height;
    PointF[] pts;
    Color color, c1;
    SolidBrush brush;
    Pen pe;
    Pen alarm = new Pen(Color.Red, 10);
    static Random rand = new Random();
    public VPoint a, b, c, d, e, f, g, h, i, j, k, l, m, n;
    VPole p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21;
    VPole p22, p23, p24, p25, p26, p27, p28, p29, p30, p31, p32, p33;

    List<PointF> dPts;
    public bool disposed, col, destroyed = false;
    int numfig;

    public Hbox(int x, int y, int width, int height, int id,float endurance)
    {
        this.width = width;
        this.height = height;
        this.endurance = endurance;

        this.id = id;
        pos = new Vec2(x, y);

        a = new VPoint(x - ((width / 6) * 3), y - (height / 2), id);
        b = new VPoint(x - ((width / 6) * 2), y - (height / 2), id + 1);
        c = new VPoint(x - (width / 6), y - (height / 2), id + 2);
        d = new VPoint(x, y - (height / 2), id + 3);
        e = new VPoint(x + (width / 6), y - (height / 2), id + 4);
        f = new VPoint(x + ((width / 6) * 2), y - (height / 2), id + 5);
        g = new VPoint(x + (width / 6) * 3, y - (height / 2), id + 6);

        h = new VPoint(x - (width / 6) * 3, y + (height / 2), id + 7);
        i = new VPoint(x - ((width / 6) * 2), y + (height / 2), id + 8);
        j = new VPoint(x - (width / 6), y + (height / 2), id + 9);
        k = new VPoint(x, y + (height / 2), id + 10);
        l = new VPoint(x + (width / 6), y + (height / 2), id + 11);
        m = new VPoint(x + ((width / 6) * 2), y + (height / 2), id + 12);
        n = new VPoint(x + ((width / 6) * 3), y + (height / 2), id + 13);

        a.FromBody = true;
        b.FromBody = true;
        c.FromBody = true;
        d.FromBody = true;
        e.FromBody = true;
        f.FromBody = true;
        g.FromBody = true;
        h.FromBody = true;

        i.FromBody = true;
        j.FromBody = true;
        k.FromBody = true;
        l.FromBody = true;
        m.FromBody = true;
        n.FromBody = true;

        brush = new SolidBrush(Color.FromArgb(50, 65, 255));

        Init(a, b, c, d, e, f, g, h, i, j, k, l, m, n);
    }

    private void Init(VPoint a, VPoint b, VPoint c, VPoint d, VPoint e, VPoint f, VPoint g, VPoint h, VPoint i, VPoint j, VPoint k, VPoint l, VPoint m, VPoint n)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        this.d = d;
        this.e = e;
        this.f = f;
        this.g = g;
        this.h = h;
        this.i = i;
        this.j = j;
        this.k = k;
        this.l = l;
        this.m = m;
        this.n = n;

        pts = new PointF[14];

        p1 = new VPole(a, b);
        p2 = new VPole(b, c);
        p3 = new VPole(c, d);
        p4 = new VPole(d, e);
        p5 = new VPole(e, f);
        p6 = new VPole(f, g);

        p7 = new VPole(h, i);
        p8 = new VPole(i, j);
        p9 = new VPole(j, k);
        p10 = new VPole(k, l);
        p11 = new VPole(l, m);
        p12 = new VPole(m, n);

        p13 = new VPole(a, h);
        p14 = new VPole(b, i);
        p15 = new VPole(c, j);
        p16 = new VPole(d, k);
        p17 = new VPole(e, l);
        p18 = new VPole(f, m);
        p19 = new VPole(g, n);

        p20 = new VPole(a, n);
        p21 = new VPole(g, h);

        p22 = new VPole(a, i);
        p23 = new VPole(h, b);

        p24 = new VPole(b, j);
        p25 = new VPole(i, c);

        p26 = new VPole(c, k);
        p27 = new VPole(j, d);

        p28 = new VPole(d, j);
        p29 = new VPole(k, e);

        p30 = new VPole(e, m);
        p31 = new VPole(l, f);

        p32 = new VPole(f, n);
        p33 = new VPole(g, m);


        c1 = Color.FromArgb(rand.Next(128, 256), rand.Next(128, 256), rand.Next(128, 256));
        brush = new SolidBrush(c1);

        color = Color.FromArgb(c1.R - 50, c1.G - 50, c1.B - 50);

        pe = new Pen(color, 14);
        pe = new Pen(color, a.Radius);
        dPts = new List<PointF>();
    }

    public void Render(Graphics ge, int width, int height)
    {
        Update(width, height);
        //g.DrawRectangle(Pens.Yellow, mX, mY, Mx - mX, My - mY);

        /* dPts.Clear();
         dPts.Add(new PointF(pts[0].X - a.Radius, pts[0].Y - a.Radius));
         dPts.Add(new PointF(pts[1].X + a.Radius, pts[1].Y - a.Radius));
         dPts.Add(new PointF(pts[2].X + a.Radius, pts[2].Y + a.Radius));
         dPts.Add(new PointF(pts[3].X - a.Radius, pts[3].Y + a.Radius));
         dPts.Add(new PointF(pts[4].X - a.Radius, pts[4].Y - a.Radius));
         dPts.Add(new PointF(pts[5].X + a.Radius, pts[5].Y - a.Radius));
         dPts.Add(new PointF(pts[6].X + a.Radius, pts[6].Y + a.Radius));
         dPts.Add(new PointF(pts[7].X - a.Radius, pts[7].Y + a.Radius));
         dPts.Add(new PointF(pts[8].X - a.Radius, pts[8].Y - a.Radius));*/


        DrawBox(ge);

        //Ver VerletPoints y VPoles
        a.Render(ge, width, height);
        b.Render(ge, width, height);
        c.Render(ge, width, height);
        d.Render(ge, width, height);
        e.Render(ge, width, height);
        f.Render(ge, width, height);
        g.Render(ge, width, height);
        h.Render(ge, width, height);
        i.Render(ge, width, height);
        j.Render(ge, width, height);
        k.Render(ge, width, height);
        l.Render(ge, width, height);
        m.Render(ge, width, height);
        n.Render(ge, width, height);


        p1.Render(ge, width, height);
        p2.Render(ge, width, height);
        p3.Render(ge, width, height);
        p4.Render(ge, width, height);
        p5.Render(ge, width, height);
        p6.Render(ge, width, height);
        p7.Render(ge, width, height);
        p8.Render(ge, width, height);
        p9.Render(ge, width, height);
        p10.Render(ge, width, height);
        p11.Render(ge, width, height);
        p12.Render(ge, width, height);
        p13.Render(ge, width, height);
        p14.Render(ge, width, height);
        p15.Render(ge, width, height);
        p16.Render(ge, width, height);
        p17.Render(ge, width, height);
        p18.Render(ge, width, height);
        p19.Render(ge, width, height);
        p20.Render(ge, width, height);
        p21.Render(ge, width, height);
        p22.Render(ge, width, height);
        p23.Render(ge, width, height);
        p24.Render(ge, width, height);
        p25.Render(ge, width, height);
        p26.Render(ge, width, height);
        p27.Render(ge, width, height);
        p28.Render(ge, width, height);
        p29.Render(ge, width, height);
        p30.Render(ge, width, height);
        p31.Render(ge, width, height);
        p32.Render(ge, width, height);
        p33.Render(ge, width, height);

    }

    private void Update(int width, int height)
    {
        a.Update(width, height); b.Update(width, height); c.Update(width, height); d.Update(width, height);
        e.Update(width, height); f.Update(width, height); g.Update(width, height); h.Update(width, height);
        i.Update(width, height); j.Update(width, height); k.Update(width, height); l.Update(width, height);
        m.Update(width, height); n.Update(width, height);
        if (!col)
        {
            a.Constraints(width, height); b.Constraints(width, height); c.Constraints(width, height); d.Constraints(width, height);
            e.Constraints(width, height); f.Constraints(width, height); g.Constraints(width, height); h.Constraints(width, height);
            i.Constraints(width, height); j.Constraints(width, height); k.Constraints(width, height); l.Constraints(width, height);
            m.Constraints(width, height); n.Constraints(width, height);
        }
        else
        {
            a.setGravity(1000); b.setGravity(1000); c.setGravity(1000); d.setGravity(1000); e.setGravity(1000);
            f.setGravity(1000); g.setGravity(1000); h.setGravity(1000); i.setGravity(1000); j.setGravity(1000);
            k.setGravity(1000); l.setGravity(1000); m.setGravity(1000); n.setGravity(1000);
        }

        p1.Update(); p2.Update(); p3.Update(); p4.Update(); p5.Update(); p6.Update();
        p7.Update(); p8.Update(); p9.Update(); p10.Update(); p11.Update(); p12.Update();
        p13.Update(); p14.Update(); p15.Update(); p16.Update(); p17.Update();
        p18.Update(); p19.Update(); p20.Update(); p21.Update();

        p22.Update(); p23.Update(); p24.Update(); p25.Update(); p26.Update();
        p27.Update(); p28.Update(); p29.Update(); p30.Update(); p31.Update(); p32.Update(); p33.Update();


        pts[0] = new PointF(a.Pos.X, a.Pos.Y);
        pts[1] = new PointF(b.Pos.X, b.Pos.Y);
        pts[2] = new PointF(c.Pos.X, c.Pos.Y);
        pts[3] = new PointF(d.Pos.X, d.Pos.Y);
        pts[4] = new PointF(e.Pos.X, e.Pos.Y);
        pts[5] = new PointF(f.Pos.X, f.Pos.Y);
        pts[6] = new PointF(g.Pos.X, g.Pos.Y);
        pts[7] = new PointF(n.Pos.X, n.Pos.Y);
        pts[8] = new PointF(m.Pos.X, m.Pos.Y);
        pts[9] = new PointF(l.Pos.X, l.Pos.Y);
        pts[10] = new PointF(k.Pos.X, k.Pos.Y);
        pts[11] = new PointF(j.Pos.X, j.Pos.Y);
        pts[12] = new PointF(i.Pos.X, i.Pos.Y);
        pts[13] = new PointF(h.Pos.X, h.Pos.Y);

        BoundingBox();
    }
    //--------------------------------------------------------------------------
    public void BoundingBox()
    {
        minX = float.MaxValue;
        maxX = float.MinValue;
        minY = float.MaxValue;
        maxY = float.MinValue;

        for (int i = 0; i < pts.Length; i++)
        {
            minX = Math.Min(minX, pts[i].X);
            maxX = Math.Max(maxX, pts[i].X);
            minY = Math.Min(minY, pts[i].Y);
            maxY = Math.Max(maxY, pts[i].Y);
        }
    }

    public void React(Graphics g, List<VPoint> pts, int width, int height)//----------------
    {
        Render(g, width, height);

        for (int p = 0; p < pts.Count; p++)
            React(g, pts[p]);//*/
    }

    private bool React(Graphics g, VPoint p)//--------------------------
    {
        if (p == null || p.FromBody)
            return false;

        //g.DrawRectangle(Pens.Cyan, minX, minY, maxX - minX, maxY - minY);//check for collision

        EdgeCollision(g, p);

        return false;
    }

    public void EdgeCollision(Graphics gr, VPoint p)//---------------------------------
    {
        int index;
        float distace, tmp;
        xp2.Clear();

        distace = float.MaxValue;
        VPole a, b, c, d, e, f, g, h, i, j, k, l, m, n;

        pos.X = pts[0].X + pts[1].X + pts[2].X + pts[3].X + pts[4].X + pts[5].X + pts[6].X + pts[7].X + pts[8].X + pts[9].X + pts[10].X + pts[11].X + pts[12].X + pts[13].X;
        pos.Y = pts[0].Y + pts[1].Y + pts[2].Y + pts[3].Y + pts[4].Y + pts[5].Y + pts[6].Y + pts[7].Y + pts[8].Y + pts[9].Y + pts[10].Y + pts[11].Y + pts[12].Y + pts[13].Y;

        pos.X /= 14;
        pos.Y /= 14;

        index = -1;

        a = new VPole(new VPoint((int)pts[0].X, (int)pts[0].Y), new VPoint((int)pts[1].X, (int)pts[1].Y));
        b = new VPole(new VPoint((int)pts[1].X, (int)pts[1].Y), new VPoint((int)pts[2].X, (int)pts[2].Y));
        c = new VPole(new VPoint((int)pts[2].X, (int)pts[2].Y), new VPoint((int)pts[3].X, (int)pts[3].Y));
        d = new VPole(new VPoint((int)pts[3].X, (int)pts[3].Y), new VPoint((int)pts[4].X, (int)pts[4].Y));
        e = new VPole(new VPoint((int)pts[4].X, (int)pts[4].Y), new VPoint((int)pts[5].X, (int)pts[5].Y));
        f = new VPole(new VPoint((int)pts[5].X, (int)pts[5].Y), new VPoint((int)pts[6].X, (int)pts[6].Y));

        g = new VPole(new VPoint((int)pts[6].X, (int)pts[6].Y), new VPoint((int)pts[7].X, (int)pts[7].Y));

        h = new VPole(new VPoint((int)pts[7].X, (int)pts[7].Y), new VPoint((int)pts[8].X, (int)pts[8].Y));
        i = new VPole(new VPoint((int)pts[8].X, (int)pts[8].Y), new VPoint((int)pts[9].X, (int)pts[9].Y));
        j = new VPole(new VPoint((int)pts[9].X, (int)pts[9].Y), new VPoint((int)pts[10].X, (int)pts[10].Y));
        k = new VPole(new VPoint((int)pts[10].X, (int)pts[10].Y), new VPoint((int)pts[11].X, (int)pts[11].Y));
        l = new VPole(new VPoint((int)pts[11].X, (int)pts[11].Y), new VPoint((int)pts[12].X, (int)pts[12].Y));
        m = new VPole(new VPoint((int)pts[12].X, (int)pts[12].Y), new VPoint((int)pts[13].X, (int)pts[13].Y));

        n = new VPole(new VPoint((int)pts[13].X, (int)pts[13].Y), new VPoint((int)pts[0].X, (int)pts[0].Y));

        FindIntersections(a, p.Pos);
        FindIntersections(b, p.Pos);
        FindIntersections(c, p.Pos);
        FindIntersections(d, p.Pos);
        FindIntersections(e, p.Pos);
        FindIntersections(f, p.Pos);
        FindIntersections(g, p.Pos);
        FindIntersections(h, p.Pos);
        FindIntersections(i, p.Pos);
        FindIntersections(j, p.Pos);
        FindIntersections(k, p.Pos);
        FindIntersections(l, p.Pos);
        FindIntersections(m, p.Pos);
        FindIntersections(n, p.Pos);

        for (int point = 0; point < xp2.Count; point++)
        {
            tmp = xp2[point].Distance(p.Pos);
            if (tmp < distace)
            {
                distace = tmp;
                index = point;
            }
        }

        if (distace < p.Radius + 3)
        {
            gr.DrawLine(Pens.Yellow, xp2[index].X, xp2[index].Y, p.Pos.X, p.Pos.Y);
            gr.DrawPolygon(alarm, pts);
            //si la velocidad es suficiente para romper el cubo
            if (p.vel.X > endurance || p.vel.Y / 5 > endurance)
            {
                col = true;
                destroyed = true;
            }
            //substraer la velocidad reduciendo la dureza
            else
            {
                endurance -= p.vel.Y / 5;
                endurance -= p.vel.X;
            }
            if (!p.IsPinned)//----------------FALTA CREAR LA REACCIÓN DE LA CAJA MOVIENDO LOS DOS PUNTOS DE MASA CORRESPONDIENTES AL RESORTE
            {
                this.a.setGravity(2);
                this.b.setGravity(2);
                this.c.setGravity(2);
                this.d.setGravity(2);
                this.e.setGravity(2);
                this.f.setGravity(2);
                this.g.setGravity(2);
                this.h.setGravity(2);
                this.i.setGravity(2);
                this.j.setGravity(2);
                this.k.setGravity(2);
                this.l.setGravity(2);
                this.m.setGravity(2);
                this.n.setGravity(2);
               

                Vec2 temp = p.Pos;
                p.Pos = p.Old + .01f;
                p.Old = temp - 1.5f;

                float minusTemp = 0.05f;
                this.a.Pos = this.a.Old + .01f;
                this.a.Old = temp - minusTemp;
                /*
                this.b.Pos = this.b.Old + .01f;
                this.b.Old = temp - minusTemp;
                
                this.c.Pos = this.c.Old + .01f;
                this.c.Old = temp - minusTemp;
                */
                this.d.Pos = this.d.Old + .01f;
                this.d.Old = temp - minusTemp;
                /*
                this.e.Pos = this.e.Old + .01f;
                this.e.Old = temp - minusTemp;

                this.f.Pos = this.f.Old + .01f;
                this.f.Old = temp - minusTemp;
                */
                this.g.Pos = this.g.Old + .01f;
                this.g.Old = temp - minusTemp;

                this.h.Pos = this.h.Old + .01f;
                this.h.Old = temp - minusTemp;
                /*
                this.i.Pos = this.i.Old + .01f;
                this.i.Old = temp - minusTemp;

                this.j.Pos = this.j.Old + .01f;
                this.j.Old = temp - minusTemp;
                */
                this.k.Pos = this.k.Old + .01f;
                this.k.Old = temp - minusTemp;
                /*
                this.l.Pos = this.l.Old + .01f;
                this.l.Old = temp - minusTemp;

                this.m.Pos = this.m.Old + .01f;
                this.m.Old = temp - minusTemp;
                */
                this.n.Pos = this.n.Old + .01f;
                this.n.Old = temp - minusTemp;
            }
        }
    }

    private void FindIntersections(VPole pole, Vec2 p)//--------------------------
    {
        if (Util.HasIn(pole.P1, pole.P2, p))
        {
            xp2.Add(Util.GetPointLineIntersection(pole.P1, pole.P2, p));
        }
    }

    private void DrawBox(Graphics g)
    {
        pe.Width = a.Diameter;
        g.FillPolygon(brush, pts);
        pe.Width = 2;
        g.DrawPolygon(pe, pts);


        /*g.DrawLine(pe, pts[3].X, pts[3].Y, pts[1].X, pts[1].Y);
        g.DrawLine(p, pts[2].X, pts[2].Y, pts[0].X, pts[0].Y);

        pe = new Pen(Color.FromArgb(color.R-65,color.G-55,color.B-55), 8);
        g.DrawLine(pe, pts[3].X, pts[3].Y, pts[0].X, pts[0].Y);
        g.DrawLines(pe, pts);

        color   = Color.FromArgb(c1.R - 55, c1.G - 55, c1.B - 55);
        pe       = new Pen(color, 1);

        g.DrawLine(pe, pts[3].X, pts[3].Y, pts[1].X, pts[1].Y);
        g.DrawLine(pe, pts[2].X, pts[2].Y, pts[0].X, pts[0].Y);
        g.DrawLine(pe, pts[3].X, pts[3].Y, pts[0].X, pts[0].Y);
        g.DrawLines(pe, pts);*/
    }
}