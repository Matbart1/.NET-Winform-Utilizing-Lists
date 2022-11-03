using GDIDrawer;
using System;
using System.Drawing;

namespace No_Direction_Project
{
    internal class Rectangle
    {
        /////////////////////////////////////////////////////////////////////////////////////
        /// 
        /// Created by: Mathieu Barrette
        /// Purpose: Display current knowledge in a zero-guidance display without reference
        /// 
        /////////////////////////////////////////////////////////////////////////////////////


        // this will be the class containing my rectangle that will bounce accross the screen
        private Random rand = null;

        // can be used instead of a randomized color every time
        private Color blockColor = RandColor.GetKnownColor();

        // need properties to communicate back to main form
        private int _width = 1;

        public int width
        {
            get { return _width; }
            set { _width = value; }
        }

        private int _height = 1;

        public int height
        {
            get { return _height; }
            set { _height = value; }
        }

        private Point _coords;

        public Point coords
        {
            get { return _coords; }
            set { _coords = value; }
        }

        public Rectangle(Point coordinateClick, int width, int height)
        {
            // this will only set values once, upon rectangle creation
            rand = new Random();

            // assign main form variables to protected class variables
            _coords.X = coordinateClick.X;
            _coords.Y = coordinateClick.Y;

            _width = width;
            _height = height;
        }

        public void MethodToDrawShapes(CDrawer passedCanvas)
        {
            // create a variable rectangle from user decided values with a randomized prime color and a random border size
            passedCanvas.AddCenteredRectangle(coords, width, height, RandColor.GetKnownColor(), rand.Next(0, 11));
        }

        public void MethodToMoveShapes(CDrawer passedCanvas)
        {
            // now if i want a shape to move around the canvas.. 1 tile at a time.. how would i do that?

            // new x coordinate thats either 1 left, 0, or 1 right of current location
            _coords.X = _coords.X + rand.Next(-1, 2);

            // new y coordinate thats either 1 above, 0, or 1 below of current location
            _coords.Y = _coords.Y + rand.Next(-1, 2);

            // I need error checking to ensure the shapes stay within the boundaries of the canvas!
            // four simple If statements should handle this

            // OOB left
            if (_coords.X + width < 0)
            {
                _coords.X = width;
            }

            // OOB right
            if (_coords.X + width > passedCanvas.ScaledWidth)
            {
                _coords.X = passedCanvas.ScaledWidth - width;
            }

            // OOB up
            if (_coords.Y + height < 0)
            {
                _coords.Y = height;
            }

            // OOB down
            if (_coords.Y + height > passedCanvas.ScaledHeight)
            {
                _coords.Y = passedCanvas.ScaledHeight - height;
            }

            // REMINDER: canvas is 50 x 50 grid format
        }
    }
}
