using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Globalization;

namespace X_0
{
    class Graph
    {
        List<Line> lineList = new List<Line>();
        

        public List<Line> Grid(double CanvasHeigh, double CanvasWidth, int n)
        {
            double CellSize = CanvasHeigh / n;

            for (int i = 0; i <= CanvasHeigh; i += Convert.ToInt32(CellSize))
            {
              
                    lineList.Add(DrawLine(0, i, CanvasWidth, i, Brushes.Black, 0.5));
                

            }

            for (int i = 0; i <= CanvasWidth; i += Convert.ToInt32(CellSize))
            {
               
                    lineList.Add(DrawLine(i, 0, i, CanvasHeigh, Brushes.Black, 0.5));
               

            }
            return lineList;
        }

        public Line DrawLine(double X1, double Y1, double X2, double Y2, Brush color, double thikness)
        {
            Line line = new Line();
            line.X1 = X1;
            line.Y1 = Y1;
            line.X2 = X2;
            line.Y2 = Y2;
            line.StrokeThickness = thikness;
            line.Stroke = color;
            return line;
        }

        public Polyline DrawGraph(double a, double b, bool check)
        {
            Polyline myPolygon = new Polyline();
            myPolygon.Stroke = System.Windows.Media.Brushes.Blue;
            myPolygon.StrokeThickness = 2;
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;


            PointCollection points = new PointCollection();
            for (double x = -10; x < 10; x += 0.001)
            {
                if (check)
                {
                    if ((x > 0) && (x < 3 * Math.PI))
                    {
                        Point p = new Point(x * 25 + 250, x * Math.Sin(x) * 25 + 250);
                        points.Add(p);
                    }
                } else
                {
                    if ((x > a) && (x < b))
                    {
                        Point p = new Point(x * 25 + 250, (2 * Math.Sin(x) + Math.Sin(2*x) )* 25 + 250);
                        points.Add(p);
                    }
                }
            }

            myPolygon.Points = points;

            return myPolygon;
        }

        public Ellipse DrawCircle(double BlockX, double BlockY, double CanvasWidth, double CanvasHeight, int CountOfCell)
        {
            Ellipse circle = new Ellipse();
            circle.Height = CanvasWidth / CountOfCell - 10;
            circle.Width = CanvasHeight / CountOfCell - 10;
            circle.SetValue(Canvas.LeftProperty, (double)(BlockX + 5));
            circle.SetValue(Canvas.TopProperty, (double)(BlockY + 5));
            circle.Stroke = Brushes.Blue;
            circle.StrokeThickness = 10;
            return(circle);
        }

        public List<Line> DrawCross(double BlockX, double BlockY, double CanvasWidth, double CanvasHeight, int CountOfCell)
        {
            List<Line> Cross = new List<Line>();
            Cross.Add(DrawLine(BlockX + 5, BlockY + 5, BlockX + 70, BlockY + 70, Brushes.Red, 10));
            Cross.Add(DrawLine(BlockX + 5, BlockY + 70, BlockX + 70, BlockY + 5, Brushes.Red, 10));
            return (Cross);
        }

    }

}
