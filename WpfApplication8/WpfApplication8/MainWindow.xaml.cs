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

namespace WpfApplication8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyCanvas my_canvas = new MyCanvas();

        public MainWindow()
        {
            InitializeComponent();
            stack_panel.Children.Add(my_canvas);
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Random random = new Random();
            int rand = random.Next(0, 2);

            Brush b = null;
            
            if (rand == 0)         
                b = Brushes.Pink;
            else
                b = Brushes.Yellow;

            my_canvas.draw_triangle(b);

        }
    }

    class MyCanvas : Canvas
    {
        List<DrawingVisual> dv_list = new List<DrawingVisual>();
        
        public MyCanvas(): base()
        { 
            // dv_list[0] <-- rectangle
            // dv_list[1] <-- triangle
            dv_list.Add(new DrawingVisual());
            dv_list.Add(new DrawingVisual());

            foreach (DrawingVisual dv in dv_list)
            {
                AddVisualChild(dv);
            }


            draw_rectangle();
            draw_triangle(Brushes.Orange);     
        }

        protected override int VisualChildrenCount // Override the getter
        {
            get
            {
                return dv_list.Count;
            }
        }

        protected override Visual GetVisualChild(int index)
        {
            return dv_list[index];
        }


        public void draw_rectangle()
        {
            using (DrawingContext dc = dv_list[0].RenderOpen())
            {

                dc.DrawRectangle(Brushes.Aqua,
                new Pen(Brushes.Black, 5),
                new Rect(new Point(100, 0), new Point(300, 100)));
            }
        }

        public void draw_triangle(Brush b)
        {
            using (DrawingContext dc = dv_list[1].RenderOpen())
            {
                PathFigure path_figure = new PathFigure();

                path_figure.StartPoint = new Point(100, 100);
                path_figure.IsClosed = true;
                path_figure.Segments.Add(new LineSegment(new Point(0, 200), true));
                path_figure.Segments.Add(new LineSegment(new Point(200, 200), true));

                PathGeometry geometry = new PathGeometry();
                geometry.Figures.Add(path_figure);

                dc.DrawGeometry(b,
                    new Pen(Brushes.Black, 5), geometry);
            }
        }
    }
}
