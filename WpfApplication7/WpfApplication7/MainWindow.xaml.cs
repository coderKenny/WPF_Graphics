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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RectangleGeometry rectangle = new RectangleGeometry(new Rect(new Point(100, 0), new Point(300, 100)));
            
            PathFigure pf_triangle = new PathFigure();
            pf_triangle.StartPoint=new Point(100,100);
            pf_triangle.IsClosed=true;
            pf_triangle.Segments.Add(new LineSegment(new Point(0,200),true));
            pf_triangle.Segments.Add(new LineSegment(new Point(200, 200), true));


            PathGeometry triangle = new PathGeometry();
            triangle.Figures.Add(pf_triangle);

            GeometryGroup geometry_group1 = new GeometryGroup();
            geometry_group1.Children.Add(rectangle);


            GeometryGroup geometry_group2 = new GeometryGroup();
            geometry_group2.Children.Add(triangle);




            // Rectangle
            GeometryDrawing geometry_drawing1 = new GeometryDrawing();
            geometry_drawing1.Brush = Brushes.Aqua;
            geometry_drawing1.Pen = new Pen(Brushes.Red, 5);
            geometry_drawing1.Geometry = geometry_group1;



            // Triangle
            GeometryDrawing geometry_drawing2= new GeometryDrawing();
            geometry_drawing2.Brush = Brushes.Orange;
            geometry_drawing2.Pen = new Pen(Brushes.Black, 5);
            geometry_drawing2.Geometry = geometry_group2;

            // Drawing group = rectangle + triangle
            DrawingGroup drawing_group = new DrawingGroup();
            drawing_group.Children.Add(geometry_drawing1);
            drawing_group.Children.Add(geometry_drawing2);

            DrawingImage drawing_image = new DrawingImage(drawing_group);
            image.Source = drawing_image;

        }


        private void image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Get the x and y coordinates of the mouse pointer.
            System.Windows.Point position = e.GetPosition(this);
            double pX = position.X;
            double pY = position.Y;


            Console.WriteLine("X-position : "+pX+" , "+"Y-position : "+pY);
            MessageBox.Show("Drawing hit!");
        }
    }
}
