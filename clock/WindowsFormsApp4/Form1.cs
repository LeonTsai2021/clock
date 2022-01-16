using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;
namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        const double DEGREE_TO_RAD = 0.01745329; // 3.1415926/180
        double Radius = 5.0, Longitude = 90.0, Latitude = 0.0;
        int time = 0;
        int time1 =0;
        int time2 = 0;
        int time3 = 0;
        int time4 = 0;
        public Form1()
        {
            InitializeComponent();
            this.openGLControl1.InitializeContexts();
            Glut.glutInit();
        }
        private void SetViewingVolume()
        {
            Gl.glViewport(0, 0, openGLControl1.Size.Width, openGLControl1.Size.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            double aspect =
                   (double)openGLControl1.Size.Width / (double)openGLControl1.Size.Height;
            Glu.gluPerspective(45, aspect, 0.1, 10.0);
        }
        private void MyInit()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClearDepth(1.0f);

            Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE);

            float[] global_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light0_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light0_diffuse = new float[] { 0.6f, 0.6f, 0.6f, 1.0f };
            float[] light0_specular = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };

            float[] light1_ambient = new float[] { 0.1f, 0.1f, 0.1f, 0.5f };
            float[] light1_diffuse = new float[] { 0.3f, 0.3f, 0.3f, 0.5f };
            float[] light1_specular = new float[] { 0.5f, 0.5f, 0.5f, 0.5f };

            float[] light2_ambient = new float[] { 0.1f, 0.1f, 0.1f, 0.5f };
            float[] light2_diffuse = new float[] { 0.3f, 0.3f, 0.3f, 0.5f };
            float[] light2_specular = new float[] { 0.5f, 0.5f, 0.5f, 0.5f };

            float[] light3_ambient = new float[] { 0.1f, 0.1f, 0.1f, 0.5f };
            float[] light3_diffuse = new float[] { 0.3f, 0.3f, 0.3f, 0.5f };
            float[] light3_specular = new float[] { 0.5f, 0.5f, 0.5f, 0.5f };

            float[] light4_ambient = new float[] { 0.1f, 0.1f, 0.1f, 0.5f };
            float[] light4_diffuse = new float[] { 0.3f, 0.3f, 0.3f, 0.5f };
            float[] light4_specular = new float[] { 0.5f, 0.5f, 0.5f, 0.5f };

            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_TRUE);
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_LOCAL_VIEWER, Gl.GL_TRUE);
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, global_ambient);

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, light0_specular);
            Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_SPOT_CUTOFF, 10.0f);
            Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_SPOT_EXPONENT,10.0f);
            
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, light1_specular);
            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_CUTOFF, 80.0f);
            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_EXPONENT, 3.0f);

            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_AMBIENT, light2_ambient);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, light2_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPECULAR, light2_specular);
            Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_SPOT_CUTOFF, 90.0f);
            Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_SPOT_EXPONENT, 3.0f);

            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_AMBIENT, light3_ambient);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_DIFFUSE, light3_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_SPECULAR, light3_specular);
            Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_SPOT_CUTOFF, 90.0f);
            Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_SPOT_EXPONENT, 3.0f);

            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_AMBIENT, light4_ambient);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_DIFFUSE, light4_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_SPECULAR, light4_specular);
            Gl.glLightf(Gl.GL_LIGHT4, Gl.GL_SPOT_CUTOFF, 90.0f);
            Gl.glLightf(Gl.GL_LIGHT4, Gl.GL_SPOT_EXPONENT, 3.0f);
            
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);

            Gl.glEnable(Gl.GL_NORMALIZE);
        }

        private void openGLControl1_Load(object sender, EventArgs e)
        {
            MyInit();
            SetViewingVolume();
        }

        private void openGLControl1_Resize(object sender, EventArgs e)
        {
            SetViewingVolume();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.openGLControl1.Refresh();
        }

        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Longitude -= 5.0;
                    break;
                case Keys.Right:
                    Longitude += 5.0;
                    break;
                case Keys.Up:
                      Latitude += 5.0;
                     if (Latitude >= 90.0) Latitude = 89.0;
                    break;
                case Keys.Down:
                    Latitude -= 5.0;
                    if (Latitude <= -90.0) Latitude = -89.0;
                    break;
                case Keys.PageUp:
                     Radius += 0.1;
                    break;
                case Keys.PageDown:
                    Radius -=0.1;
                    if (Radius < 0.1) Radius = 0.1;
                    break;
                case Keys.NumPad0:
                    if (time % 2 == 0)
                    {
                        Gl.glDisable(Gl.GL_LIGHT0);
                        time++;
                    }
                    else
                    {
                        Gl.glEnable(Gl.GL_LIGHT0);
                        time++;
                    }
                    break;
                case Keys.NumPad1:
                    if (time1 % 2 != 0)
                    {
                        Gl.glDisable(Gl.GL_LIGHT1);
                        time1++;
                    }
                    else
                    {
                        Gl.glEnable(Gl.GL_LIGHT1);
                        time1++;
                    }
                    break;
                case Keys.NumPad2:
                    if (time2 % 2 != 0)
                    {
                        Gl.glDisable(Gl.GL_LIGHT2);
                        time2++;
                    }
                    else
                    {
                        Gl.glEnable(Gl.GL_LIGHT2);
                        time2++;
                    }
                    break;
                case Keys.NumPad3:
                    if (time3 % 2 != 0)
                    {
                        Gl.glDisable(Gl.GL_LIGHT3);
                        time3++;
                    }
                    else
                    {
                        Gl.glEnable(Gl.GL_LIGHT3);
                        time3++;
                    }
                    break;
                case Keys.NumPad4:
                    if (time4 % 2 != 0)
                    {
                        Gl.glDisable(Gl.GL_LIGHT4);
                        time4++;
                    }
                    else
                    {
                        Gl.glEnable(Gl.GL_LIGHT4);
                        time4++;
                    }
                    break;
                default:
                    break;
            }
            this.openGLControl1.Refresh();

        }

        private void openGLControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            float[] light0_position = new float[] { 0.0f, 0.0f, 0.0f, 1.0f };
            float[] light0_direction = new float[] { 0.0f, -1.0f, 0.0f };

            Glu.gluLookAt(Radius * Math.Cos(Latitude * DEGREE_TO_RAD)
                     * Math.Sin(Longitude * DEGREE_TO_RAD),
              Radius * Math.Sin(Latitude * DEGREE_TO_RAD),
              Radius * Math.Cos(Latitude * DEGREE_TO_RAD)
                     * Math.Cos(Longitude * DEGREE_TO_RAD),
              0.0, 0.0, 0.0, 0.0, 1.0, 0.0);

            Gl.glPushMatrix();
            Gl.glRotated(120, 1.0, 0, 0);
            Gl.glTranslated(0, 1.0, 0.1);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, light0_position);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPOT_DIRECTION, light0_direction);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(-120, 1.0, 0, 0);
            Gl.glTranslated(0, 0.9, 0);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_POSITION, light0_position);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPOT_DIRECTION, light0_direction);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(-60, 1.0, 0, 0);
            Gl.glTranslated(0, 1.0, 0.3);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_POSITION, light0_position);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_SPOT_DIRECTION, light0_direction);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(60, 1.0, 0, 0);
            Gl.glTranslated(0, 0.9, 0);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_POSITION, light0_position);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_SPOT_DIRECTION, light0_direction);
            Gl.glPopMatrix();

            int hour = DateTime.Now.Hour;
            int miniute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;

            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glColor3ub(208, 208, 208);
            Gl.glRotated(90, 0, 1.0, 0);
            Glut.glutSolidTorus(0.1, 1.0, 100, 30);//外圍
            Gl.glScaled(1, 1, 0.01);
       
            Gl.glColor3ub(240, 240, 240);
            Glut.glutSolidSphere(1.0,128,128);//鐘面

            Gl.glColor3ub(157, 157, 157);
            Gl.glPushMatrix();
            Gl.glScaled(0.01, 0.2, 1);
            Gl.glTranslated(0, 4.1, 1.0);
            Glut.glutSolidCube(1.0);//時刻
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(30, 0, 0, 1.0);
            Gl.glScaled(0.01, 0.2, 1);
            Gl.glTranslated(0, 4.1, 1.0);
            Glut.glutSolidCube(1.0);//時刻
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(60, 0, 0, 1.0);
            Gl.glScaled(0.01, 0.2, 1);
            Gl.glTranslated(0, 4.1, 1.0);
            Glut.glutSolidCube(1.0);//時刻
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(90, 0, 0, 1.0);
            Gl.glScaled(0.01, 0.2, 1);
            Gl.glTranslated(0, 4.1, 1.0);
            Glut.glutSolidCube(1.0);//時刻
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(120, 0, 0, 1.0);
            Gl.glScaled(0.01, 0.2, 1);
            Gl.glTranslated(0, 4.1, 1.0);
            Glut.glutSolidCube(1.0);//時刻
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(150, 0, 0, 1.0);
            Gl.glScaled(0.01, 0.2, 1);
            Gl.glTranslated(0, 4.1, 1.0);
            Glut.glutSolidCube(1.0);//時刻
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(180, 0, 0, 1.0);
            Gl.glScaled(0.01, 0.2, 1);
            Gl.glTranslated(0, 4.1, 1.0);
            Glut.glutSolidCube(1.0);//時刻
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(210, 0, 0, 1.0);
            Gl.glScaled(0.01, 0.2, 1);
            Gl.glTranslated(0, 4.1, 1.0);
            Glut.glutSolidCube(1.0);//時刻
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(240, 0, 0, 1.0);
            Gl.glScaled(0.01, 0.2, 1);
            Gl.glTranslated(0, 4.1, 1.0);
            Glut.glutSolidCube(1.0);//時刻
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(270, 0, 0, 1.0);
            Gl.glScaled(0.01, 0.2, 1);
            Gl.glTranslated(0, 4.1, 1.0);
            Glut.glutSolidCube(1.0);//時刻
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(300, 0, 0, 1.0);
            Gl.glScaled(0.01, 0.2, 1);
            Gl.glTranslated(0, 4.1, 1.0);
            Glut.glutSolidCube(1.0);//時刻
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(330, 0, 0, 1.0);
            Gl.glScaled(0.01, 0.2, 1);
            Gl.glTranslated(0, 4.1, 1.0);
            Glut.glutSolidCube(1.0);//時刻
            Gl.glPopMatrix();

            Gl.glColor3ub(157, 157, 157);
            Gl.glPushMatrix();
            Gl.glRotated(-(DateTime.Now.Hour * 30), 0, 0, 1.5);
            Gl.glScaled(0.05, 0.4,1);
            Gl.glTranslated(0,0.4,1.5);
            Glut.glutSolidCube(1.0);//時針
            Gl.glPopMatrix();
        
            
            Gl.glColor3ub(157, 157, 157);
            Gl.glPushMatrix();
            Gl.glRotated(-(DateTime.Now.Minute * 6), 0, 0, 1.6);
            Gl.glScaled(0.05, 0.6, 1);
            Gl.glTranslated(0, 0.5, 1.6);
            Glut.glutSolidCube(1.0);//分針
            Gl.glPopMatrix();

            Gl.glColor3ub(157, 157, 157);
            Gl.glPushMatrix();
            Gl.glRotated(-(DateTime.Now.Second * 6), 0, 0, 1.7);
            Gl.glScaled(0.03, 0.7, 1);
            Gl.glTranslated(0, 0.5, 1.7);
            Glut.glutSolidCube(1.0);//秒針
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_COLOR_MATERIAL);


        }
    }
}
