using System.Security.Cryptography.X509Certificates;

namespace Ball
{
    delegate void Changes(int id);
    delegate void Insert(Color color);
    internal class Painter
    {
        public event Changes changes;
        public event Insert insert;
        private object locker = new();
        private List<Animator> animators = new();
        private List<Square> squares = new();
        private Size containerSize;
        private Thread t;
        private Thread sqT;
        private Graphics mainGraphics;
        private BufferedGraphics bg;
        private int squareid = 1;

        private volatile int objectsPainted = 0;
        public Thread PainterThread => t;
        public Graphics MainGraphics
        {
            get => mainGraphics;
            set
            {
                lock (locker)
                {
                    mainGraphics = value;
                    ContainerSize = mainGraphics.VisibleClipBounds.Size.ToSize();
                    bg = BufferedGraphicsManager.Current.Allocate(
                        mainGraphics, new Rectangle(new Point(0, 0), ContainerSize)
                    );
                    objectsPainted = 0;
                }
            }
        }

        public Size ContainerSize
        {
            get => containerSize;
            set
            {
                containerSize = value;
                foreach (var animator in animators)
                {
                    animator.ContainerSize = ContainerSize;
                }
            }
        }

        public Painter(Graphics mainGraphics)
        {
            MainGraphics = mainGraphics;
        }

        /*public void AddNew()
        {
            var a = new Animator(ContainerSize);
            animators.Add(a);
            a.Start();
        }*/


        public void AddSquare(MouseEventArgs e)
        {
            Square square = new Square(e.X, e.Y, squareid);
            insert(square.color);
            try
            {
                squares.Add(square);
                square.Paint(mainGraphics);
            }
            catch (Exception exception) { }
            AddCircle(e, square.color, squareid);
            squareid++;
        }

        public void AddCircle(MouseEventArgs e, Color clr, int id)
        {
            sqT = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        //lock (locker)
                        //{

                            var a = new Animator(ContainerSize, e.X, e.Y, clr, id);
                            animators.Add(a);
                            a.Start();
                            //Thread.Sleep(3000);
                        //}
                        Thread.Sleep(1000);
                    }

                }
                catch (ArgumentException e) { }
                
            });
            
            sqT.IsBackground = true;
            sqT.Start();
            
        }

        public void ShowCircle()
		{
            t = new Thread(() =>
            {
            try
            {
                while (true)
                {
                    lock (locker)
                    {
                        if (PaintOnBuffer())
                            {
                                bg.Render(MainGraphics);
                                check_crash();
                            }
                        }
                    }
                }
                catch (ArgumentException e) { }
            });
            t.IsBackground = true;
            t.Start();

        }
    

        


        public void Stop()
        {
            t.Interrupt();
        }

        private double dist(Circle A, Circle B)
        {
            return Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
        }

        private void check_crash()
        {
            for(int i = 0; i < animators.Count; i++)
            {
                for (int j = 0; j < animators.Count; j++)
                {
                    if (!animators[i].Equals(animators[j]))
                    {
                        if (dist(animators[i].C, animators[j].C) <= animators[i].C.Diam && animators[i].C.Color != animators[j].C.Color)
                        {
                            Random rnd = new Random();
                            int r = rnd.Next(1, 3);
                            if (r == 1)
                            {
                                changes(animators[j].ID);
                                animators.Remove(animators[i]);
                            }
                            if (r == 2)
                            {
                                changes(animators[i].ID);
                                animators.Remove(animators[j]);
                            }
                            /*int x = animator1.C.Dx;
                            int y = animator1.C.Dy;
                            animator1.C.Dx = 3;
                            animator1.C.Dy = 4;
                            animator2.C.Dx = -4;
                            animator2.C.Dy = -3;*/
                        }
                    }
                }
            }
        }
        

        

        private bool PaintOnBuffer()
        {
            Thread.Sleep(10);
            objectsPainted = 0;
            var objectsCount = animators.Count + squares.Count;
            bg.Graphics.Clear(Color.White);
            for(int i = 0; i < animators.Count; i++)
            {
                animators[i].PaintCircle(bg.Graphics);
                objectsPainted++;
            }
            /*foreach (var animator in animators)
            {
                animator.PaintCircle(bg.Graphics);
                objectsPainted++;
            }*/

            foreach (var square in squares)
            {
                square.Paint(bg.Graphics);
                objectsPainted++;
            }

            return objectsPainted == objectsCount;
        }
    }
}
