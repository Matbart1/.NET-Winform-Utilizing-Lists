using GDIDrawer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace No_Direction_Project
{
    public partial class Form1 : Form
    {
        /////////////////////////////////////////////////////////////////////////////////////
        /// 
        /// Created by: Mathieu Barrette
        /// Purpose: Display current knowledge in a zero-guidance display without reference
        /// 
        /// Lack of Git Commits?: 03/11/2022 12:32pm Clearwave Broadband Internet is DOWN
        /// so it is not possible to commit any progress to a respository
        /// 
        /////////////////////////////////////////////////////////////////////////////////////

        private CDrawer canvas = null;

        List<Rectangle> recList = new List<Rectangle>();

        Timer canvasUpdater = new Timer();

        private int passingWidth = 1;
        private int passingHeight = 1;

        public int totalBounces;

        public Form1()
        {
            canvas = new CDrawer(500, 500, false);

            // 50x50 grid
            canvas.Scale = 10;

            InitializeComponent();

            canvasUpdater.Start();

            canvasUpdater.Interval = 30;

            // used to ensure canvas spawning is nearby the form
            Load += Form1_Load;

            // will update variables and ui text
            tkbWidth.ValueChanged += TkbWidth_ValueChanged;
            tkbHeight.ValueChanged += TkbHeight_ValueChanged;

            // Will contain all the inner mechanisms of shape creation and movement
            canvasUpdater.Tick += CanvasUpdater_Tick;

            // event will throw when canvas is left-clicked anywhere
            canvas.MouseLeftClickScaled += Canvas_MouseLeftClickScaled;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Point canvasSpawning = new Point();
            canvasSpawning.X = Right;
            canvasSpawning.Y = Top;

            canvas.Position = canvasSpawning;

        }

        private void TkbHeight_ValueChanged(object sender, EventArgs e)
        {
            // simple trackbar variable saving + display 
            lblheight.Text = $"Rectangle Height: {tkbHeight.Value}";
            passingHeight = tkbHeight.Value;
        }

        private void TkbWidth_ValueChanged(object sender, EventArgs e)
        {
            // simple trackbar variable saving + display 
            lblwidth.Text = $"Rectangle Width: {tkbWidth.Value}";
            passingWidth = tkbWidth.Value;
        }

        private void Canvas_MouseLeftClickScaled(System.Drawing.Point pos, CDrawer dr)
        {
            // ScaledMouseLeftClick should take into consideration the 50x50 grid we have
            Rectangle newRec = new Rectangle(pos, passingWidth, passingHeight);

            // if this rectangle doesnt currently exist within the list of rectangles, add it!
            if (!recList.Contains(newRec))
            {
                recList.Add(newRec);
            }
        }

        private void CanvasUpdater_Tick(object sender, EventArgs e)
        {
            // Will be responsible for the population and movement of rectangles on the canvas

            // Tick has occured, time to:
            // clear the created objects...
            // give them NEW coordinates (+1 or -1 X AND Y) <- this gets done within the class method
            // move the 'cleared' shapes <- this gets done within the class method
            // draw the moved shapes <- this gets done within the class method
            // re-render the canvas

            canvas.Clear();

            // now iterate through the list of rectanges and commit the method changes

            totalBounces = 0;

            foreach (Rectangle rec in recList)
            {
                rec.MethodToMoveShapes(canvas);

                rec.MethodToDrawShapes(canvas);

                // Tally total bounces
                totalBounces += rec.bounces;
            }

            canvas.Render();

            lblBounce.Text = $"Total numer of bounces : {totalBounces}";


        }


    }
}
