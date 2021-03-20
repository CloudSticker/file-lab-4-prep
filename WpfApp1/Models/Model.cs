using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace WpfApp1
{
    class Model
    {
        #region DrawCanvas
        /// <summary>
        ///Иницилизация переменных для рисования на холсте
        /// </summary>
        private readonly double thikness = 7.5;
        private readonly Brush color = Brushes.Black;
        private readonly List<Color> allColors = new List<Color>
        {
            Color.FromRgb(255, 153, 102),
            Color.FromRgb(255, 153, 204),
            Color.FromRgb(153, 102, 153),
            Color.FromRgb(153, 153, 255),
            Color.FromRgb(102, 255, 255),
            Color.FromRgb(51, 255, 102),
            Color.FromRgb(102, 0, 51),
            Color.FromRgb(153, 0, 51),
            Color.FromRgb(102, 153, 153),
            Color.FromRgb(0, 153, 51),
            Color.FromRgb(204, 255, 51),
            Color.FromRgb(153, 153, 102),
            Color.FromRgb(153, 102, 102)
        };
        /// <summary>
        /// Создаёт и возвращает холст
        /// </summary>
        /// <param name="canvasHeight">Высота холста</param>
        /// <param name="canvasWidth">ширина холста</param>
        /// <returns>Возвращает полностью нарисованный холст</returns>
        public Canvas DrawLine(double canvasHeight, double canvasWidth)
        {
            Canvas canvas = new Canvas();
           
            Line line = new Line();
            
            line.X1 = 0;
            line.Y1 = canvasHeight / 2;
            line.X2 = canvasWidth;
            line.Y2 = canvasHeight / 2;
            line.StrokeThickness = thikness;
            line.Stroke = color;

            canvas.Children.Add(line);

            return canvas;
        }
        /// <summary>
        /// Рисует блоки для отображения значений, работает с файлом 
        /// </summary>
        /// <param name="canvasHeight">Высота холста</param>
        /// <param name="canvasWidth">Ширина холста</param>
        /// <returns>Возвращает прямоугольник для отрисовки</returns>
        public List<Rectangle> DrawBlock(double canvasHeight, double canvasWidth)
        {
            int[] arr = MakeArr("Read.txt");
            List<Rectangle> rectangleArr = new List<Rectangle>();

            for (int i = 0; i < arr.Length; i++)
            {
                int k = RndColorNum();   
                SolidColorBrush brush = new SolidColorBrush(allColors[k]);
                Rectangle rectangle = new Rectangle();
                rectangle.Fill = brush;
                rectangle.Height = Math.Abs(arr[i]);
                rectangle.Stroke = Brushes.White;
                rectangle.StrokeThickness = 3;
                rectangle.Width = 50;
                if (arr[i] > 0)
                {
                    Canvas.SetTop(rectangle, canvasHeight / 2 - rectangle.Height);
                }
                else
                {
                    Canvas.SetTop(rectangle, canvasHeight / 2);
                }

                Canvas.SetLeft(rectangle, (rectangle.Width + 7) * i);
                rectangleArr.Add(rectangle);
            }
            return rectangleArr;
        }
        async public Task<Rectangle> DrawRectangle(double canvasHeight, double canvasWidth, int i)
        {
            List<Rectangle> rectangleArr = DrawBlock(canvasHeight, canvasWidth);
            Rectangle rectangle = rectangleArr[i];
            return rectangle;
        }
        #endregion

        #region GenerationRandColorNum

        private static List<int> rndColorNum = new List<int>();
        /// <summary>
        /// Молодой человек, не знаю ЧТО или КТО сподвиг вас на чтение этой части кода 
        /// которая просто отвратно работает, ну да ладно. Раз уж вы пришли то внемлите
        /// перед вами универсальная и неповторимая генерация рандомного неповторяющегося числа
        /// которая является индексом элемента в таком прекрасном листе как  allColor
        /// <param name="allColors"></param>
        /// </summary>
        /// <returns>Возвращает индекс ещё не использованного цвета из палитры allColors</returns>
        private int RndColorNum()
        {
            int k;
            Random rnd = new Random();
            if(rndColorNum.Count <= 1)
            {

                for (int j = 0; j < allColors.Count; j++)
                {
                    rndColorNum.Add(j);
                }
            }

            k = rnd.Next(0, rndColorNum.Count);
            int iEl = 0;
            for (int i = 0; i < rndColorNum.Count; i++)
            {
                if (k == rndColorNum[i])
                {
                    iEl = i;
                    break;
                }
            }

            k = rndColorNum[iEl];;
            rndColorNum.RemoveAt(iEl);
            return k;
        }
        #endregion

        #region FileWork
        /// <summary>
        /// Считывание из файла
        /// </summary>
        /// <param name="path"> путь до файла из которого идёт считывание</param>
        /// <returns>возвращает строку массив строк</returns>
        private string[] ReadFile(string path)
        {             
            if (File.Exists(path))
            {
                string[] str = File.ReadAllLines(path);
                return str;
            }
            else
                return null;
        }
        /// <summary>
        /// Преобразует строку из файла в массив чисел
        /// </summary>
        /// <param name="path">Путь до файла</param>
        /// <returns>Возвращает массив тип int[]</returns>
        private int[] MakeArr(string path)
        {
            string[] str = ReadFile(path); //"Read.txt"
            string[] l = str[0].Split(' ');
            int[] arr = new int[l.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(l[i]);
            }
            return arr;
        }
        #endregion

    }
}
