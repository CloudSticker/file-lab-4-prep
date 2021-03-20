using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace WpfApp1
{
    public class MainViewModel : INotifyPropertyChanged
    {
        Model model = new Model();
        Canvas canvas = new Canvas();
        private double canvasWidth = 1234;
        private double canvasHeight = 675;



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private List<Line> lineList = new List<Line>();
        public Canvas Canvas
        {
            get 
            { 
                return canvas;
            }
            set
            {
                canvas = value;
                OnPropertyChanged();
            }
        }

        public Canvas AddCanvas
        {
            get
            {
                return canvas;
            }
            set
            {
                canvas = value;
                OnPropertyChanged();
            }
        }
        public ICommand ClickAdd
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    List<Rectangle> rectangleArr = model.DrawBlock(canvasHeight, canvasWidth);
                    
                    for (int i = 0; i < rectangleArr.Count; i++)
                    {
                        var rectangle = model.DrawRectangle(canvasHeight, canvasWidth, i).Result;
                        AddCanvas.Children.Add(rectangle);
                    }
                    OnPropertyChanged();
                });
            }
        }

        public MainViewModel()
        {
            Canvas = model.DrawLine(canvasHeight, canvasWidth);
        }
    }
}
