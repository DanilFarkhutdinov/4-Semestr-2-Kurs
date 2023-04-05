using Microsoft.Win32;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.Xml;

namespace Интеграл_test_
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap btm;
        Pen pen;
        Point[] points;
        public Form1()
        {
            InitializeComponent();
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pen = new Pen(Color.Black, 3f);
            g = Graphics.FromImage(btm);
            g.Clear(Color.White);
            g.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);
            g.ScaleTransform(1, -1);
            drawbtn.FlatStyle = FlatStyle.Flat;
            drawbtn.FlatAppearance.BorderSize = 1;
            drawbtn.FlatAppearance.BorderColor = Color.Black;
            calculatebtn.FlatStyle = FlatStyle.Flat;
            calculatebtn.FlatAppearance.BorderSize = 1;
            calculatebtn.FlatAppearance.BorderColor = Color.Black;
            clearbtn.FlatStyle = FlatStyle.Flat;
            clearbtn.FlatAppearance.BorderSize = 1;
            clearbtn.FlatAppearance.BorderColor = Color.Black;
            /*g.FillEllipse(Brushes.Black, 0, 0, 10, 10);
            g.FillEllipse(Brushes.Red, -100, -100, 10, 10);
            g.FillEllipse(Brushes.Green, -100, 100, 10, 10);
            g.FillEllipse(Brushes.Blue, 100, 100, 10, 10);
            g.FillEllipse(Brushes.Yellow, 100, -100, 10, 10);*/
            coordinate_system();
        }
        public void coordinate_system()
        {
            pen = new Pen(Color.FromArgb(255, 0, 0, 0), 3f);
            Point a = new Point(-(pictureBox1.Width / 2), 0);
            Point b = new Point(pictureBox1.Width / 2, 0);
            Point c = new Point(0, -(pictureBox1.Height / 2));
            Point d = new Point(0, pictureBox1.Height / 2);
            g.DrawLine(pen, a, b);
            g.DrawLine(pen, c, d);
            pictureBox1.Image = btm;
        }

        private void drawbtn_Click(object sender, EventArgs e)
        {
            pen = new Pen(Color.Red, 3f);
            points = new Point[pictureBox1.Width];
            for (int i = 0; i < points.Length; i++)
            {
                int x = i - pictureBox1.Width / 2;
                double y = Math.Sqrt(Math.Abs(x)) * 10;
                try
                {
                    points[i] = new Point(x, Convert.ToInt32(y));
                }
                catch
                {
                    points[i] = new Point(x, 1);
                }
            }
            g.DrawLines(pen, points);
            pictureBox1.Image = btm;
        }
        private double Fun(double x)
        {
            //Math.Pow(x, 3) / 10000
            //Math.Sin(x / 10) * 100
            //Math.Pow(x, 2) / 100
            //Math.Sqrt(Math.Abs(x)) * 10
            //100000 / (1 + Math.Pow(x, 2))
            //-Math.Pow(x, 2) / 100 + 150
            double rez = Math.Sqrt(Math.Abs(x)) * 10;
            return rez;
        }
        public double LeftRectangle(Func<double, double> f, double a, double b, int n)
        {
            var h = (b - a) / n;
            var sum = 0d;
            for (var i = 0; i <= n - 1; i++)
            {
                var x = a + i * h;
                sum += f(x);
            }

            var result = h * sum;
            return result;
        }
        public double RightRectangle(Func<double, double> f, double a, double b, int n)
        {
            var h = (b - a) / n;
            var sum = 0d;
            for (var i = 1; i <= n; i++)
            {
                var x = a + i * h;
                sum += f(x);
            }

            var Result = h * sum;
            return Result;
        }
        public double CentralRectangle(Func<double, double> f, double a, double b, int n)
        {
            var h = (b - a) / n;
            var sum = (f(a) + f(b)) / 2;
            for (var i = 1; i < n; i++)
            {
                var x = a + h * i;
                sum += f(x);
            }

            var result = h * sum;
            return result;
        }
        static double Trapezium(Func<double, double> f, double a, double b, double n)
        {
            double x, h, s;
            h = (b - a) / n;
            s = (f(a) + f(b)) / 2;
            for (x = a + h; x < b; x += h)
            {
                s += f(x);
            }
            return s * h;
        }
        private void calculatebtn_Click(object sender, EventArgs e)
        {
            if (mthdcombox.Text == "Левые прямоугольники")
            {
                int start = Convert.ToInt32(startbox.Text);
                int end = Convert.ToInt32(endbox.Text);
                if (start < -(btm.Width / 2))
                {
                    start = -(btm.Width / 2);
                }
                if (end >= btm.Width)
                {
                    end = btm.Width / 2;
                }
                int x = start;
                int y = 0;
                int x1 = pictureBox1.Width / 2;
                int y1 = 0;
                int count = 0;
                Rectangle rect = new Rectangle();
                while (x <= end)
                {
                    if (Fun(x) > 1)
                    {
                        y1 = pictureBox1.Height / 2 - 1;
                        while ((btm.GetPixel(x1 + x, y1 - 1) == Color.FromArgb(255, 255, 255, 255) || btm.GetPixel(x1 + x, y1 - 1) == Color.FromArgb(255, 0, 0, 0)) && y1 - 1 > 0 && y1 - 1 < btm.Height - 1)
                        {
                            count++;
                            y1--;
                        }
                        rect.Width = 10;
                        rect.Height = count + 3;
                        rect.Location = new Point(x, y);
                        g.FillRectangle(Brushes.Blue, rect);
                        rect.Width = 9;
                        g.DrawRectangle(Pens.Purple, rect);
                        count = 0;
                        x1 = pictureBox1.Width / 2;
                        y1 = pictureBox1.Height / 2 - 1;
                        x += 10;
                    }
                    else
                    {
                        if (Fun(x) < -1)
                        {
                            y1 = pictureBox1.Height / 2 + 1;
                            while ((btm.GetPixel(x1 + x, y1 + 1) == Color.FromArgb(255, 255, 255, 255) || btm.GetPixel(x1 + x, y1 + 1) == Color.FromArgb(255, 0, 0, 0)) && y1 + 1 > 0 && y1 + 1 < btm.Height - 1)
                            {
                                count++;
                                y1++;
                            }
                            rect.Width = 10;
                            rect.Height = count + 6;
                            rect.Location = new Point(x, y - count - 6);
                            g.FillRectangle(Brushes.Blue, rect);
                            rect.Width = 9;
                            g.DrawRectangle(Pens.Purple, rect);
                            count = 0;
                            x1 = pictureBox1.Width / 2;
                            y1 = pictureBox1.Height / 2 + 1;
                            x += 10;
                        }
                        else
                        {
                            x += 10;
                        }
                    }
                }
                pen = new Pen(Color.Red, 3f);
                if (points != null)
                {
                    g.DrawLines(pen, points);
                }
                double a = Convert.ToDouble(startbox.Text);
                double b = Convert.ToDouble(endbox.Text);
                double f(double x) => Fun(x);
                int n = 10000;
                infobox.Text = Math.Round(LeftRectangle(f, a, b, n), 3).ToString();
                pictureBox1.Image = btm;
            }
            if (mthdcombox.Text == "Правые прямоугольники")
            {
                int start = Convert.ToInt32(startbox.Text);
                int end = Convert.ToInt32(endbox.Text);
                if (start < -(btm.Width / 2))
                {
                    start = -(btm.Width / 2);
                }
                if (end >= btm.Width)
                {
                    end = btm.Width / 2;
                }
                int x = start;
                int y = 0;
                int x1 = pictureBox1.Width / 2;
                int y1 = 0;
                int count = 0;
                Rectangle rect = new Rectangle();
                while (x <= end)
                {
                    if (Fun(x) > 1)
                    {
                        y1 = pictureBox1.Height / 2 - 1;
                        while ((btm.GetPixel(x1 + x, y1 - 1) == Color.FromArgb(255, 255, 255, 255) || btm.GetPixel(x1 + x, y1 - 1) == Color.FromArgb(255, 0, 0, 0)) && y1 - 1 > 0 && y1 - 1 < btm.Height - 1)
                        {
                            count++;
                            y1--;
                        }
                        rect.Width = 10;
                        rect.Height = count + 3;
                        rect.Location = new Point(x - 10, y);
                        g.FillRectangle(Brushes.Blue, rect);
                        rect.Width = 9;
                        g.DrawRectangle(Pens.Purple, rect);
                        count = 0;
                        x1 = pictureBox1.Width / 2;
                        y1 = pictureBox1.Height / 2 - 1;
                        x += 10;
                    }
                    else
                    {
                        if (Fun(x) < -1)
                        {
                            y1 = pictureBox1.Height / 2 + 1;
                            while ((btm.GetPixel(x1 + x, y1 + 1) == Color.FromArgb(255, 255, 255, 255) || btm.GetPixel(x1 + x, y1 + 1) == Color.FromArgb(255, 0, 0, 0)) && y1 + 1 > 0 && y1 + 1 < btm.Height - 1)
                            {
                                count++;
                                y1++;
                            }
                            rect.Width = 10;
                            rect.Height = count + 6;
                            rect.Location = new Point(x - 10, y - count - 6);
                            g.FillRectangle(Brushes.Blue, rect);
                            rect.Width = 9;
                            g.DrawRectangle(Pens.Purple, rect);
                            count = 0;
                            x1 = pictureBox1.Width / 2;
                            y1 = pictureBox1.Height / 2 + 1;
                            x += 10;
                        }
                        else
                        {
                            x += 10;
                        }
                    }
                }
                pen = new Pen(Color.Red, 3f);
                if (points != null)
                {
                    g.DrawLines(pen, points);
                }
                double a = Convert.ToDouble(startbox.Text);
                double b = Convert.ToDouble(endbox.Text);
                double f(double x) => Fun(x);
                int n = 10000;
                infobox.Text = Math.Round(RightRectangle(f, a, b, n), 3).ToString();
                pictureBox1.Image = btm;
            }
            if (mthdcombox.Text == "Центральные прямоугольники")
            {
                int start = Convert.ToInt32(startbox.Text);
                int end = Convert.ToInt32(endbox.Text);
                if (start < -(btm.Width / 2))
                {
                    start = -(btm.Width / 2);
                }
                if (end >= btm.Width)
                {
                    end = btm.Width / 2;
                }
                int x = start;
                int y = 0;
                int x1 = pictureBox1.Width / 2;
                int y1 = 0;
                int count = 0;
                Rectangle rect = new Rectangle();
                while (x <= end)
                {
                    if (Fun(x) > 1)
                    {
                        y1 = pictureBox1.Height / 2 - 1;
                        while ((btm.GetPixel(x1 + x, y1 - 1) == Color.FromArgb(255, 255, 255, 255) || btm.GetPixel(x1 + x, y1 - 1) == Color.FromArgb(255, 0, 0, 0)) && y1 - 1 > 0 && y1 - 1 < btm.Height - 1)
                        {
                            count++;
                            y1--;
                        }
                        rect.Width = 10;
                        rect.Height = count + 3;
                        rect.Location = new Point(x - 6, y);
                        g.FillRectangle(Brushes.Blue, rect);
                        rect.Width = 9;
                        g.DrawRectangle(Pens.Purple, rect);
                        count = 0;
                        x1 = pictureBox1.Width / 2;
                        y1 = pictureBox1.Height / 2 - 1;
                        x += 10;
                    }
                    else
                    {
                        if (Fun(x) < -1)
                        {
                            y1 = pictureBox1.Height / 2 + 1;
                            while ((btm.GetPixel(x1 + x, y1 + 1) == Color.FromArgb(255, 255, 255, 255) || btm.GetPixel(x1 + x, y1 + 1) == Color.FromArgb(255, 0, 0, 0)) && y1 + 1 > 0 && y1 + 1 < btm.Height - 1)
                            {
                                count++;
                                y1++;
                            }
                            rect.Width = 10;
                            rect.Height = count + 6;
                            rect.Location = new Point(x - 4, y - count - 6);
                            g.FillRectangle(Brushes.Blue, rect); ;
                            rect.Width = 9;
                            g.DrawRectangle(Pens.Purple, rect);
                            count = 0;
                            x1 = pictureBox1.Width / 2;
                            y1 = pictureBox1.Height / 2 + 1;
                            x += 10;
                        }
                        else
                        {
                            x += 10;
                        }
                    }
                }
                pen = new Pen(Color.Red, 3f);
                if (points != null)
                {
                    g.DrawLines(pen, points);
                }
                double a = Convert.ToDouble(startbox.Text);
                double b = Convert.ToDouble(endbox.Text);
                double f(double x) => Fun(x);
                int n = 10000;
                infobox.Text = Math.Round(CentralRectangle(f, a, b, n), 3).ToString();
                pictureBox1.Image = btm;
            }
            if (mthdcombox.Text == "Трапеции")
            {
                int start = Convert.ToInt32(startbox.Text);
                int end = Convert.ToInt32(endbox.Text);
                if (start < -(btm.Width / 2))
                {
                    start = -(btm.Width / 2);
                }
                if (end >= btm.Width)
                {
                    end = btm.Width / 2;
                }
                int x = start;
                int y = 0;
                int x1 = pictureBox1.Width / 2;
                int y1 = 0;
                int count = 0;
                int count1 = 0;
                Point[] array = new Point[4];
                Pen pen1 = new Pen(Color.Purple, 2f);
                while (x + 10 <= end)
                {
                    if (Fun(x) > 1 && Fun(x + 10) > 1)
                    {
                        y1 = pictureBox1.Height / 2 - 1;
                        while ((btm.GetPixel(x1 + x, y1 - 1) == Color.FromArgb(255, 255, 255, 255) || btm.GetPixel(x1 + x, y1 - 1) == Color.FromArgb(255, 0, 0, 0)) && y1 - 1 > 0 && y1 - 1 < btm.Height - 1)
                        {
                            count++;
                            y1--;
                        }
                        array[0] = new Point(x, 0);
                        x += 9;
                        array[1] = new Point(x, 0);
                        y1 = pictureBox1.Height / 2 - 1;
                        while ((btm.GetPixel(x1 + x, y1 - 1) == Color.FromArgb(255, 255, 255, 255) || btm.GetPixel(x1 + x, y1 - 1) == Color.FromArgb(255, 0, 0, 0)) && y1 - 1 > 0 && y1 - 1 < btm.Height - 1)
                        {
                            count1++;
                            y1--;
                        }
                        array[2] = new Point(x, count1 + 3);
                        array[3] = new Point(x - 10, count + 3);
                        g.FillPolygon(Brushes.Blue, array);
                        g.DrawPolygon(pen1, array);
                        count = 0;
                        count1 = 0;
                        x += 1;
                        x1 = pictureBox1.Width / 2;
                        y1 = pictureBox1.Height / 2 - 1;
                    }
                    else
                    {
                        if (Fun(x) < -1 && Fun(x + 10) < -1)
                        {
                            y1 = pictureBox1.Height / 2 + 1;
                            while ((btm.GetPixel(x1 + x, y1 + 1) == Color.FromArgb(255, 255, 255, 255) || btm.GetPixel(x1 + x, y1 + 1) == Color.FromArgb(255, 0, 0, 0)) && y1 + 1 > 0 && y1 + 1 < btm.Height - 1)
                            {
                                count++;
                                y1++;
                            }
                            array[0] = new Point(x, 0);
                            x += 9;
                            array[1] = new Point(x, 0);
                            y1 = pictureBox1.Height / 2 + 1;
                            while ((btm.GetPixel(x1 + x, y1 - 1) == Color.FromArgb(255, 255, 255, 255) || btm.GetPixel(x1 + x, y1 - 1) == Color.FromArgb(255, 0, 0, 0)) && y1 - 1 > 0 && y1 - 1 < btm.Height - 1)
                            {
                                count1++;
                                y1++;
                            }
                            array[2] = new Point(x, -(count1 + 3));
                            array[3] = new Point(x - 10, -(count + 3));
                            g.FillPolygon(Brushes.Blue, array);
                            g.DrawPolygon(pen1, array);
                            count = 0;
                            count1 = 0;
                            count = 0;
                            x1 = pictureBox1.Width / 2;
                            y1 = pictureBox1.Height / 2 + 1;
                            x += 1;
                        }
                        else
                        {
                            x += 10;
                        }
                    }
                }
                pen = new Pen(Color.LimeGreen, 3f);
                /*if (points != null)
                {
                    g.DrawLines(pen, points);
                }*/
                double a = Convert.ToDouble(startbox.Text);
                double b = Convert.ToDouble(endbox.Text);
                double f(double x) => Fun(x);
                int n = 10000;
                infobox.Text = Math.Round(Trapezium(f, a, b, n), 3).ToString();
                pictureBox1.Image = btm;
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            coordinate_system();
            infobox.Text = string.Empty;
        }
    }
}