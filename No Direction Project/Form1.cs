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
        /// November 18th Edit: Updating commenting / adding more background information
        /// 
        /// *This program uses a custom visualizer in C# called GDIDrawer created by
        /// the amazing professors at the Northern Alberta Institute of Technology
        /// 
        /////////////////////////////////////////////////////////////////////////////////////

        // Canvas will be our visual interface for this program
        private CDrawer canvas = null;

        // recList will contain our Rectangle class to edit them in real time
        List<Rectangle> recList = new List<Rectangle>();

        // Timer will be used to update the canvas each tick
        Timer canvasUpdater = new Timer();

        // Width and Height values for our rectangle class
        private int passingWidth = 1;
        private int passingHeight = 1;

        // Fun tracking statistic
        public int totalBounces;

        /// <summary>
        /// General Form Constructor: Creates a new canvas with dimensions of 500x500 and contiuous update set to false, sets the canvas scale to 10
        /// Initializes our timer with a tick interval of 30ms, adds event callbacks for Form_Load, Trackbar edits, Timer ticks, and Canvas clicks
        /// </summary>
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

        /// <summary>
        /// Initializes the visual canvas beside our main form
        /// </summary>
        /// <param name="sender">null</param>
        /// <param name="e">null</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Point canvasSpawning = new Point();
            canvasSpawning.X = Right;
            canvasSpawning.Y = Top;

            canvas.Position = canvasSpawning;

        }

        /// <summary>
        /// When the trackbar is edited it will update the floating height text and save the trackbar value into a height integer
        /// </summary>
        /// <param name="sender">null</param>
        /// <param name="e">null</param>
        private void TkbHeight_ValueChanged(object sender, EventArgs e)
        {
            // simple trackbar variable saving + display 
            lblheight.Text = $"Rectangle Height: {tkbHeight.Value}";
            passingHeight = tkbHeight.Value;
        }


        /// <summary>
        /// When the trackbar is edited it will update the width floating text and save the trackbar value into a width integer
        /// </summary>
        /// <param name="sender">null</param>
        /// <param name="e">null</param>
        private void TkbWidth_ValueChanged(object sender, EventArgs e)
        {
            // simple trackbar variable saving + display 
            lblwidth.Text = $"Rectangle Width: {tkbWidth.Value}";
            passingWidth = tkbWidth.Value;
        }

        /// <summary>
        /// Captures a left click mouse event within the visual canvas and saves a new Rectangle class with pre-determined dimensions
        /// at the coordinate point of the click, provided a rectangle is not currently at that point
        /// </summary>
        /// <param name="pos">xY coordinates of the click</param>
        /// <param name="dr">visual canvas used</param>
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

        /// <summary>
        /// Tick event will clear the visual canvas, reset the total amount of bounces to 0, iterate through the list of Rectangles
        /// and for each rectangle, call the Rectangle.Move() method and the Rectangle.Show() method to move and redisplay each rectangle,
        /// additionally, it will increase the total bounce metric by that rectangles local bounces, finally, render the visual canvas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanvasUpdater_Tick(object sender, EventArgs e)
        {

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
