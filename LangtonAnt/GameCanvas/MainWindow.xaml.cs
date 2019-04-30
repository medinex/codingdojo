using LangtonAnt;
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
using Colors = LangtonAnt.Colors;

namespace GameCanvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var canvas = new Canvas();
            canvas.Width = 400;
            canvas.Height = 400;
            Background = Brushes.Turquoise;

            var game = new Game();
            var pane = game.CreateMap(20, 20);


            for (int x = 0; x < pane.Width; x++)
            {
                for (int y = 0; y < pane.Height; y++)
                {
                    var rectCanvas = new Canvas();
                    rectCanvas.Background = pane.GetCurrentColor(x,y) == Colors.Black ? Brushes.Black : Brushes.White;
                    rectCanvas.Height = 20;
                    rectCanvas.Width = 20;
                    Canvas.SetTop(rectCanvas, x * 20);
                    Canvas.SetLeft(rectCanvas, y * 20);
                    canvas.Children.Add(rectCanvas);
                }

            }

            var antCanvas = new Canvas();
            antCanvas.Height = 20;
            antCanvas.Width = 20;
            Canvas.SetTop(antCanvas, pane.Ant.Coordinate.X * 20);
            Canvas.SetLeft(antCanvas, pane.Ant.Coordinate.Y * 20);

            var head = new Ellipse();
            head.Stroke = Brushes.Red;
            head.HorizontalAlignment = HorizontalAlignment.Center;
            head.VerticalAlignment = VerticalAlignment.Top;
            head.Width = 5;
            head.Height = 5;
            head.StrokeThickness = 2;
            antCanvas.Children.Add(head);

            var body = new Ellipse();
            body.Stroke = Brushes.Red;
            body.HorizontalAlignment = HorizontalAlignment.Center;
            body.VerticalAlignment = VerticalAlignment.Bottom;
            body.Width = 10;
            body.Height = 15;
            body.StrokeThickness = 2;
            antCanvas.Children.Add(body);

            canvas.Children.Add(antCanvas);


            Content = canvas;


      
        }
    }
}
