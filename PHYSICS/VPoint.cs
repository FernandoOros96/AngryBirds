using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PHYSICS;

namespace PHYSICS
{
    public class VPoint
    {
        bool isPinned = false;
        bool fromBody = false;
        public bool isPig = false,isBomb=false;
        public bool hits = false;
        public bool thrown = false,isBird=false,collides=false;
        public Vec2 pos, old, vel, gravity;
        int id;
        public float Mass;
        public float radius, bounce, diameter, m, frict = 0.98f;
        float groundFriction = 0.99f;
        Color c;
        SolidBrush brush;
        
        public int lifetime,birdtype=0;
        private Image MyImage;


        public bool FromBody
        {
            get { return fromBody; }
            set { fromBody = value; }
        }
        public float Diameter
        {
            get { return diameter; }
            set { diameter = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public bool IsPinned
        {
            get { return isPinned; }
            set { isPinned = value; }
        }
        public float X
        {
            get { return pos.X; }
            set { pos.X = value; }
        }
        public float Y
        {
            get { return pos.Y; }
            set { pos.Y = value; }
        }
        public Vec2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        public Vec2 Old
        {
            get { return old; }
            set { old = value; }
        }
        public float Radius
        {
            get { return radius; }
            set { radius = value; diameter = radius + radius; }
        }

        public VPoint(int x, int y)
        {
            this.id = -1;
            Init(x, y, 0, 0);
        }
        public VPoint(int x, int y, int id, bool Pinned)
        {
            this.id = id;
            isPinned = Pinned;
            Init(x, y, 0, 0);
        }
        public VPoint(int x, int y, int id)
        {
            this.id = id;
            Init(x, y, 0, 0);
        }
        public VPoint(int x, int y, float vx, float vy, int id, bool Pinned)
        {
            this.id = id;
            isPinned = Pinned;
            Init(x, y, vx, vy);
        }
        public VPoint(int x, int y, int id,int numBird)
        {
            this.id = id;
            birdtype = numBird;
            Init(x, y, 0, 0);
        }
        public VPoint(int x, int y, float vx, float vy, int id)
        {
            this.id = id;
            Init(x, y, vx, vy);
        }

        private void Init(int x, int y, float vx, float vy)
        {
            pos = new Vec2(x, y);
            old = new Vec2(x, y);
            gravity = new Vec2(0, 0.07);//
            vel = new Vec2(vx, vy);
            lifetime = 0;
            radius = 20;
            diameter = radius + radius;
            Mass = 0.001f;
            bounce = 0.00001f;
            c = Color.OrangeRed;
            brush = new SolidBrush(c);
            //Image img = birds.red;
            //texture = new TextureBrush(img);
            if (IsPinned)
            {
                Pin();
            }
        }
        public void setImage(Image image) {
            MyImage = image;
            
        }
        public void setSize(int r)
        {
            radius = r;
            diameter = r + r;
        }

        public void setPig(bool p)
        {
            isPig = p;
        }
        public void setColor(Color color)
        {
            c= color;
            brush = new SolidBrush(c);
        }
        public void setPinned(bool pinned)
        {
            this.isPinned = pinned;
        }
        public void setGravity(double value)
        {
           this.gravity=new Vec2(0,value);
        }
        public void setBird(bool ans)
        {
            isBird = ans;
        }
        public void setMass(float m)
        {
            this.Mass = m;
        }

        public void Pin()
        {
            brush = new SolidBrush(Color.Gray);
            radius = 10;
            diameter = radius + radius;
            isPinned = true;
        }

        public void Update(int width, int height)
        {
            int dist = 600;
            if (isPinned)
                return;//*/

            vel = (pos - old)*frict;
            if (isBird)
            {
                dist = 0;
                groundFriction = 0.7f;
            }
                
            
            if (pos.Y >= height - radius - dist && vel.MagSqr() > 0.000001 )//en el piso
            {
                m = vel.Length();
                vel /= m;
                vel *= (m * groundFriction);
                collides = true;
            }
            
            
            
            old = pos;
            pos += vel + gravity;
        }

        public void Constraints(int width, int height)
        {
                if (pos.X > width - radius || hits) { pos.X = width - radius; old.X = (pos.X + vel.X); }
                if (pos.X < radius || hits) { pos.X = radius; old.X = (pos.X + vel.X); }
                if (pos.Y > height - radius || hits) { pos.Y = height - radius; old.Y = (pos.Y + vel.Y); }
                if (pos.Y < radius || hits) { pos.Y = radius; old.Y = (pos.Y + vel.Y); }

        }

        public void Render(Graphics g, int width, int height)
        {
            if (fromBody)
                return;

            Update(width, height);
            Constraints(width, height);

            
            
            //if it is null draw ellipse else draw image
            if(MyImage == null)
                g.FillEllipse(brush, pos.X - radius, pos.Y - radius, diameter, diameter);
            else
                g.DrawImage(MyImage, pos.X - radius, pos.Y - radius, diameter, diameter);
        }


        public override string ToString()
        {
            return "ID: " + id + " : " + pos.ToString();
        }

    }
}
