using LangtonAnt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        private Canvas _antCanvas;
        Game _game = new Game();
        Map _pane = null;
        Dictionary<LangtonAnt.Point, Canvas> _dict = new Dictionary<LangtonAnt.Point, Canvas>();

        public MainWindow()
        {
            InitializeComponent();
            var canvas = new Canvas();
            canvas.Width = 400;
            canvas.Height = 400;
            Background = Brushes.Turquoise;
            KeyDown += MainWindow_KeyDown;

            _pane = _game.CreateMap(20, 20);


            for (int x = 0; x < _pane.Width; x++)
            {
                for (int y = 0; y < _pane.Height; y++)
                {
                    var rectCanvas = new Canvas();
                    rectCanvas.Background = _pane.GetColor(x, y) == Colors.Black ? Brushes.Black : Brushes.White;
                    rectCanvas.Height = 20;
                    rectCanvas.Width = 20;
                    Canvas.SetTop(rectCanvas, x * 20);
                    Canvas.SetLeft(rectCanvas, y * 20);
                    canvas.Children.Add(rectCanvas);
                    var coordinate = LangtonAnt.Point.Construct(x, y);
                    _dict.Add(coordinate, rectCanvas);
                }

            }

            _antCanvas = new Canvas();
            _antCanvas.Height = 20;
            _antCanvas.Width = 20;

            var head = new Ellipse();
            head.Stroke = Brushes.Red;
            head.Width = 5;
            head.Height = 5;
            head.StrokeThickness = 2;
            _antCanvas.Children.Add(head);
            Canvas.SetLeft(head, 10 - 5 / 2);
            Canvas.SetTop(head, 0);

            var body = new Ellipse();
            body.Stroke = Brushes.Red;
            body.Width = 10;
            body.Height = 15;
            body.StrokeThickness = 2;
            _antCanvas.Children.Add(body);
            Canvas.SetLeft(body, 10 - 10 / 2);
            Canvas.SetTop(body, 4);

            canvas.Children.Add(_antCanvas);


            Content = canvas;

            MoveAnt();

        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                var beforeTick = _pane.Ant.Coordinate;

                _pane.Tick();

                //Canvas canvas = Content as Canvas;
                //foreach (var item in canvas.Children)
                //{
                //    if (item is Canvas c)
                //    {
                //        int x = (int)Canvas.GetLeft(c) / 20;
                //        int y = (int)Canvas.GetTop(c) / 20;

                //        if(beforeTick.X == x && beforeTick.Y == y)
                //        {
                //            c.Background = _pane.GetCurrentColor(beforeTick) == Colors.Black ? Brushes.Black : Brushes.White; 
                //        } 
                //    }
                //}

                var canvas = _dict.Where(s => s.Key.Equals(beforeTick)).FirstOrDefault().Value;

                if(canvas != null)
                {
                    canvas.Background = _pane.GetCurrentColor(beforeTick) == Colors.Black ? Brushes.Black : Brushes.White;
                }
                
                MoveAnt();
            }
           
        }

        private void MoveAnt()
        {

            var currentTransform = _antCanvas.RenderTransform as RotateTransform;
            if (currentTransform != null)
            {
                var rotate = new RotateTransform(-currentTransform.Angle, 10, 10);
                _antCanvas.RenderTransform = rotate;
            }

            //Debug.WriteLine(_pane.Ant.Angle);
            var rotateTransform = new RotateTransform(_pane.Ant.Angle, 10, 10);
            _antCanvas.RenderTransform = rotateTransform;


            Canvas.SetTop(_antCanvas, _pane.Ant.Coordinate.X * 20);
            Canvas.SetLeft(_antCanvas, _pane.Ant.Coordinate.Y * 20);
        }
    }
}
