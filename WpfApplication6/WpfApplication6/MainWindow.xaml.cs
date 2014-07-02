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

namespace WpfApplication6
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
            rectangle.Height = 100;
            rectangle.Width = 200;
            rectangle.Fill = Brushes.Aqua;
            rectangle.Stroke = Brushes.Red;
            rectangle.StrokeThickness = 20;

            path.Fill = Brushes.Orange;
            path.Stroke = Brushes.Black;

            path.StrokeThickness = 10;

            PathFigure pf = new PathFigure();
            pf.StartPoint=new Point (110,0);
            pf.IsClosed = true; 
            pf.Segments.Add(new LineSegment(new Point(10,200),true));
            pf.Segments.Add(new LineSegment(new Point(210, 200), true));

            PathGeometry pg = new PathGeometry();
            pg.Figures.Add(pf);
            path.Data = pg;
        }

        private void rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Rectangle got clicked");
        }

        private void path_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Triangle got clicked");
        }
    }
}
