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

namespace WpfApplication10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LinearGradientBrush brush = new LinearGradientBrush(Colors.Red, Colors.Blue, 0);

            GeometryDrawing drawing = new GeometryDrawing();

            drawing.Geometry = new RectangleGeometry(new Rect(new Point(100, 0), new Point(300, 100)));
            drawing.Brush = Brushes.Aqua;

            drawing.Pen = new Pen(brush,20);

            DrawingImage source = new DrawingImage(drawing);

            image.Source = source;
        }
    }
}
