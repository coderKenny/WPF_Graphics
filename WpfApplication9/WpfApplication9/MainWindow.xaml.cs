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

namespace WpfApplication9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Color color = new Color();
            color.R = 255;
            color.B = 255;
            color.A = 255;

            color.ScR = 0.5f;

            //SolidColorBrush brush = new SolidColorBrush(color);

            LinearGradientBrush brush = new LinearGradientBrush();
            brush.StartPoint = new Point(0.3, 0.5);
            brush.EndPoint = new Point(0.7, 0.5);
            // Start -->
            brush.GradientStops.Add(new GradientStop(Colors.Red, 0.3));
            // Stop -->
            brush.GradientStops.Add(new GradientStop(Colors.Blue, 0.7));

            brush.ColorInterpolationMode = ColorInterpolationMode.ScRgbLinearInterpolation;

            brush.SpreadMethod = GradientSpreadMethod.Reflect;

            rectangle.Fill = brush;

           
        }
    }
}
