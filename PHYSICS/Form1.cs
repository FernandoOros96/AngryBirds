using PHYSICS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PHYSICS
{
    public partial class Form1 : Form
    {
        public bool Air;
        int b2, b3;
        List<VPoint> balls;
        VRope rope;
        List<Box> boxes;
        List<LBox> lBoxes;
        List<Hbox> hBoxes;
        List<VPole> poles;
        VSolver solver;
        public int power =0,index=0;
        Point mouse, trigger;
        Graphics g;
        bool isMouseDown, isRightButton,setCross, executeMet=true;
        int ballId;
        int[] crystal, wood, stone;
        float radius, top, left, size;
        int BirdsNum = 0,finishGame=0;
        bool respawn=true, isBirdType2Added = false,isDuplicated=false,hasSpeed=false;
        int currentID;
        int[] birdtype = { 2,2, 3,4 };
        private static Image background = birds.background;

        public Form1()
        {
            InitializeComponent();
        }

        private void PCT_CANVAS_Click(object sender, EventArgs e)
        {
            if(Air)
            {
                power += 1;
            }
            
            
        }

        private void Init()
        {

            BirdsNum = 0;
            finishGame = 0;
            respawn = true;
            setCross = false;
            Random rand = new Random();
            Bitmap bmp = new Bitmap(PCT_CANVAS.Width,PCT_CANVAS.Height);
            g = Graphics.FromImage(bmp);
            PCT_CANVAS.Image = bmp;
            balls = new List<VPoint>();
            boxes = new List<Box>();
            hBoxes = new List<Hbox>();
            poles= new List<VPole>();
            lBoxes= new List<LBox>();
            solver = new VSolver(balls);

            /*
            rope = new VRope(450, 400, 15, 25, balls.Count);
            balls.AddRange(rope.pts);//*/// hay que añadir las pelotas de cada cuerpo a la lista para ser tratadas
            
            
            balls.Add(new VPoint(220, 350, balls.Count,0));
            balls[balls.Count-1].setGravity(1);
            //balls[0].setSize(10);
            balls[balls.Count-1].setBird(true);
            balls[balls.Count - 1].setImage(birds.red);
            balls[balls.Count-1].setPinned(true);

            VPoint pig = new VPoint(800, 386, balls.Count, 0);
            balls.Add(pig);
            balls[balls.Count-1].isPig= true;
            
            balls[balls.Count - 1].setImage(birds.pig);
            balls[balls.Count-1].setSize(35);
            


            balls.Add(new VPoint(900, 386, balls.Count, 0));
            balls[balls.Count - 1].isPig = true;
            
            balls[balls.Count - 1].setImage(birds.pig);
            balls[balls.Count - 1].setSize(35);
            
            



            /*
            hBoxes.Add(new Hbox(300, 454, 200, 40, balls.Count,10));
            balls.Add(hBoxes[hBoxes.Count - 1].a);
            balls.Add(hBoxes[hBoxes.Count - 1].b);
            balls.Add(hBoxes[hBoxes.Count - 1].c);
            balls.Add(hBoxes[hBoxes.Count - 1].d);
            balls.Add(hBoxes[hBoxes.Count - 1].e);
            balls.Add(hBoxes[hBoxes.Count - 1].f);
            balls.Add(hBoxes[hBoxes.Count - 1].g);
            balls.Add(hBoxes[hBoxes.Count - 1].h);
            balls.Add(hBoxes[hBoxes.Count - 1].i);
            balls.Add(hBoxes[hBoxes.Count - 1].j);
            balls.Add(hBoxes[hBoxes.Count - 1].k);
            balls.Add(hBoxes[hBoxes.Count - 1].l);
            balls.Add(hBoxes[hBoxes.Count - 1].m);
            balls.Add(hBoxes[hBoxes.Count - 1].n);
            /*
            hBoxes[hBoxes.Count - 1].a.setGravity(-0.9);
            hBoxes[hBoxes.Count - 1].h.setGravity(-0.9);
            hBoxes[hBoxes.Count - 1].g.setGravity(1);
            hBoxes[hBoxes.Count - 1].n.setGravity(1);
            */



            for (int b = 0; b < 25; b++)//stompers265
                balls.Add(new VPoint(0 + (b * 15), (int)(Height * .2f + b * 2), balls.Count, true));
            /*
            for (int b = 0; b < 25; b++)//stompers265
                balls.Add(new VPoint(800 + (b * 15), (int)(Height * .5f - b * 6), balls.Count, true));
            //*/
            ///////*************CAJAS/*
            int []cX =
            {
                45, 88, 127, 170, 209, 252, 291, 334, 373, 416, 455, 498, 537, 140
            };
            int[]cY=
            {
                380, 299, 380, 299, 380, 299, 380, 299, 380, 299, 380, 299, 380, 218
            };
            
            for(int i=0;i<cX.Length;i++)
            {
                boxes.Add(new Box(cX[i]+550, cY[i]+170, 40, 40, balls.Count, 0.1f));
                balls.Add(boxes[boxes.Count - 1].a);
                balls.Add(boxes[boxes.Count - 1].b);
                balls.Add(boxes[boxes.Count - 1].c);
                balls.Add(boxes[boxes.Count - 1].d);

                boxes[boxes.Count - 1].a.setGravity(-0.9);
                boxes[boxes.Count - 1].b.setGravity(-0.9);
                boxes[boxes.Count - 1].c.setGravity(1 );
                boxes[boxes.Count - 1].d.setGravity(1 );
                /*
                boxes[boxes.Count - 1].a.setSize(15);
                boxes[boxes.Count - 1].b.setSize(15);
                boxes[boxes.Count - 1].c.setSize(15);
                boxes[boxes.Count - 1].d.setSize(15);
                */


            }


            /*
            // X,Y,WIDTH,HEIGTH,ID,ENDURANCE
            boxes.Add(new Box(300,454, 40, 40, balls.Count,50));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);
            boxes[boxes.Count - 1].a.setGravity(-0.90*3);
            boxes[boxes.Count - 1].b.setGravity(-0.90*3);
            boxes[boxes.Count - 1].c.setGravity(1*3);
            boxes[boxes.Count - 1].d.setGravity(1 * 3);



            boxes.Add(new Box(300, 542, 40, 40, balls.Count,50));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);
            
            boxes[boxes.Count - 1].a.setGravity(-0.90);
            boxes[boxes.Count - 1].b.setGravity(-0.90);
            boxes[boxes.Count - 1].c.setGravity(1);
            boxes[boxes.Count - 1].d.setGravity(1);
            


            Box box = new Box(1060, 470, 40, 40, balls.Count, 4);
            box.SetColor(230, 230, 250);

            boxes.Add(box);
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);
            boxes[boxes.Count - 1].a.setGravity(-0.90);
            boxes[boxes.Count - 1].b.setGravity(-0.90);
            boxes[boxes.Count - 1].c.setGravity(1);
            boxes[boxes.Count - 1].d.setGravity(1);

            Box cristal = new Box(995, 470, 40, 40, balls.Count, 4);
            cristal.SetColor(201, 235, 255);

            boxes.Add(cristal);
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);
            boxes[boxes.Count - 1].a.setGravity(-0.90);
            boxes[boxes.Count - 1].b.setGravity(-0.90);
            boxes[boxes.Count - 1].c.setGravity(1);
            boxes[boxes.Count - 1].d.setGravity(1);
            boxes.Add(new Box(930, 470, 40, 40, balls.Count,4));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);
            boxes[boxes.Count - 1].a.setGravity(-0.90);
            boxes[boxes.Count - 1].b.setGravity(-0.90);
            boxes[boxes.Count - 1].c.setGravity(1);
            boxes[boxes.Count - 1].d.setGravity(1);
            boxes.Add(new Box(1080, 390, 40, 40, balls.Count,4));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);
            boxes[boxes.Count - 1].a.setGravity(-0.90);
            boxes[boxes.Count - 1].b.setGravity(-0.90);
            boxes[boxes.Count - 1].c.setGravity(1);
            boxes[boxes.Count - 1].d.setGravity(1);
            boxes.Add(new Box(1005, 390, 40, 40, balls.Count,1));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);
            boxes[boxes.Count - 1].a.setGravity(-0.90);
            boxes[boxes.Count - 1].b.setGravity(-0.90);
            boxes[boxes.Count - 1].c.setGravity(1);
            boxes[boxes.Count - 1].d.setGravity(1);
            */

            /*
          (1060, 460)
(1020, 460)
(980, 460)
(1060, 420)
(1020, 420)
            boxes.Add(new Box(700, 400, 40, 400, balls.Count));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);
            
            boxes.Add(new Box(1000, 500, 40, 40, balls.Count));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);
            */
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }

        

        private void Form1_Resize(object sender, EventArgs e)
        {
            Init();

        }

        private void BTN_EXE_Click(object sender, EventArgs e)
        {
            Init();
            
        }

        

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
                isMouseDown = true;
            
                isRightButton = (e.Button == MouseButtons.Right);
                if (isRightButton)
                    trigger = e.Location;

                mouse = e.Location;
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (e.Button == MouseButtons.Left)//MOVE BALL TO POINTER
                {
                    ///*
                    //LBL_STATUS.Text = "Ahh !!" + e.Location.ToString();
                    mouse = e.Location;
                   /* if (ballId > -1)
                    {
                        balls[ballId].Pos.X = e.Location.X;
                        balls[ballId].Pos.Y = e.Location.Y;

                        balls[ballId].Old = balls[ballId].Pos;
                        balls[ballId].IsPinned= false;
                    }
                    */
                }
                else
                    trigger = e.Location;
            }
        }



        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            
            if (e.Button == MouseButtons.Right && ballId != -1 && executeMet)
            {
                currentID = ballId;
                VPoint ball = balls[ballId];
                
                float maxDistance = 200.0f; // Establecer un rango máximo de 50 unidades
                float distance = (float)Math.Sqrt(Math.Pow(e.Location.X - ball.Old.X, 2) + Math.Pow(e.Location.Y - ball.Old.Y, 2));
                if (distance > maxDistance)
                {
                    // Si la distancia es mayor que el rango máximo permitido, establecer la posición anterior de la bola a una posición en la dirección y distancia del rango máximo permitido desde la posición actual del cursor.
                    float angle = (float)Math.Atan2(e.Location.Y - ball.Old.Y, e.Location.X - ball.Old.X);
                    ball.Old.X = (int)(ball.Pos.X - maxDistance * (float)Math.Cos(angle));
                    ball.Old.Y = (int)(ball.Pos.Y - maxDistance * (float)Math.Sin(angle));
                }
                else
                {
                    ball.Old.X = e.Location.X;
                    ball.Old.Y = e.Location.Y;
                }

                ball.IsPinned = false;
                //LBL_STATUS.Text = "FIRE !!!";
                setCross = true;
                BirdsNum += 1;
                ball.thrown = true;
                
                executeMet = false;
            }

            ballId = -1;
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            int valorEntero = birdtype.Length-index ; // El valor que deseas asignar al Label.
            NBirds.Text = valorEntero.ToString(); // Asignar el valor al Label.
            if ((currentID >= 0 && currentID < balls.Count) && power >= 1)
            {
                //poder Amarillo
                if(balls[currentID].birdtype == 1 )
                {
                    balls[currentID].Pos.X += 0.95f;
                    balls[currentID].Pos.Y += 0.05f;
                    
                }
                //poder blanco
                if (balls[currentID].birdtype == 2 && !isBirdType2Added)
                {
                    VPoint egg = new VPoint(
                        (int)balls[currentID].Pos.X, (int)balls[currentID].Pos.Y+50,
                    balls.Count,-1);
                    egg.setBird(true);
                    egg.setGravity(2);
                    egg.setMass(50f);
                    egg.isBomb = true;
                    
                    egg.setImage(birds.egg);
                    //blue.thrown = true;
                    balls.Add(egg);
                    
                    isBirdType2Added = true;
                }
                //poder azul
                if (balls[currentID].birdtype == 3 && !isDuplicated)
                {
                    
                    VPoint blue2 = new VPoint((int)balls[currentID].Pos.X, (int)balls[currentID].Pos.Y + 55,
                         balls.Count,3);
                    blue2.setBird(true);
                    
                    blue2.setImage(birds.blue);
                    blue2.setGravity(1);
                    balls.Add(blue2);
                    balls[balls.Count-1].Pos.X += 30;
                    balls[balls.Count-1].Pos.Y += 6;

                    //b3=balls.Count;
                    VPoint blue3 = new VPoint((int)balls[currentID].Pos.X, (int)balls[currentID].Pos.Y - 55,
                         balls.Count, 3);
                    blue3.setBird(true);
                    
                    blue3.setImage(birds.blue);
                    blue2.setGravity(1);
                    balls.Add(blue3);
                    balls[balls.Count-1].Pos.X += 30;
                    balls[balls.Count-1].Pos.Y += 6;
                    
                    isDuplicated = true;
                }
              
            }

            if (BirdsNum>birdtype.Length)
            {
                finishGame += 1;
                respawn = false;
            }
            if (finishGame >= 270)
            {
                timer1.Stop();
                var result = MessageBox.Show("GAME OVER. ¿Deseas continuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    // si el usuario selecciona OK, se cierra la aplicación
                    Application.Exit();
                }
                else if (result == DialogResult.Yes)
                {
                    // si el usuario selecciona Continuar, se reinicia la aplicación
                    Application.Restart();
                }

            }
            
            g.Clear(Color.Black);
            g.DrawImage(background, 0, 0);

            ballId = solver.Update(g,PCT_CANVAS.Width, PCT_CANVAS.Height, mouse, isMouseDown);
            
            if (rope != null)
                rope.Update(g, PCT_CANVAS.Width, PCT_CANVAS.Height);
            for(int bal=0;bal<balls.Count;bal++)
            {
                if (balls[bal].isBomb)
                {
                    if (balls[bal].Old.X != balls[bal].Pos.X || balls[bal].Pos.Y >= PCT_CANVAS.Height - balls[bal].radius)
                    {
                        balls.Remove(balls[bal]);
                    }
                }
            }
            for(int bal = 0; bal < balls.Count; bal++)
            {
                bool allFalse = true;
                for (int i = 0; i < balls.Count; i++)
                {
                    if (balls[i].isPig)
                    {
                        allFalse = false;
                        break;
                    }
                }

                if (allFalse)
                {
                    timer1.Stop();
                    var result = MessageBox.Show("You won. ¿Deseas continuar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        // si el usuario selecciona OK, se cierra la aplicación
                        Application.Exit();
                    }
                    else if (result == DialogResult.Yes)
                    {
                        // si el usuario selecciona Continuar, se reinicia la aplicación
                        Application.Restart();
                    }
                    break;
                }
               
                if (balls[bal].hits)
                {
                    balls.Remove(balls[bal]);
                }
                if (balls[bal].thrown)
                {
                    balls[bal].lifetime += 1;
                }
                if (balls[bal].lifetime > 10)
                {
                    Air = true;
                }
                if(balls[bal].lifetime>200)
                {
                    //resetear poder amarillo
                    balls[bal].Pos.X-= 0.95f;
                    balls[bal].Pos.Y -= 0.05f;
                    //resetear poder azul
                    Air = false;
                    isBirdType2Added = false;
                    
                    isDuplicated=false;
                    balls.Remove(balls[bal]);
                   
                    power = 0;
                   
                    
                    if (respawn)
                    {
                        executeMet = true;
                        int newId = balls.Count;
                        balls.Add(new VPoint(220, 350, newId, birdtype[index]));
                        balls[newId].setGravity(0.0000009);
                        switch (birdtype[index])
                        {
                            case 1:
                                balls[newId].setImage(birds.yellow);

                                break;
                            case 2:
                                balls[newId].setImage(birds.white);
                                break;
                            case 3:
                                balls[newId].setImage(birds.blue);
                                break;
                            default:
                                balls[newId].setImage(birds.red);
                                break;
                        }
                        
                        balls[newId].setBird(true);
                        balls[newId].setPinned(true);
                        index++;
                        
                    }
                    
                }
                

            }
            int count = 0;
            for (int b = 0; b < boxes.Count; b++)
            {
                boxes[b].React(g, balls, PCT_CANVAS.Width, PCT_CANVAS.Height);
                
                if (boxes[b].col)
                {
                    boxes[b].col = true;
                    count += 1;
                    



                }
                
            }



            if (isMouseDown && isRightButton && ballId != -1)
                g.DrawLine(Pens.Green, balls[ballId].X, balls[ballId].Y, trigger.X, trigger.Y);



            if (setCross && executeMet)
            {
                g.DrawLine(Pens.Green, left, top, size, size);

            }
            // Dibujar el círculo

            for (int b = 0; b < hBoxes.Count; b++)
            {
                hBoxes[b].React(g, balls, PCT_CANVAS.Width, PCT_CANVAS.Height);

            }
            
            PCT_CANVAS.Invalidate();
        }
    }
}
