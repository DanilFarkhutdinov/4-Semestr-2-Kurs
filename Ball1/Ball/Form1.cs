using System.Reflection;
using System.Windows.Forms;

namespace Ball
{
    public partial class Form1 : Form
    {
        private Painter p;
        bool flag = false;
        bool checkfirst = true;
        object locker = new();
        int count = 0;
        DataBase db = new DataBase();
        public TextBox txtbox1 { get; set; }
        public Form1()
        {
            InitializeComponent();
            p = new Painter(mainPanel.CreateGraphics());
            p.insert += DataGridViewInsertTable;
            p.changes += DataGridViewChange;
            dataGridView.Height = 0;
            //p.Start();
            p.ShowCircle();
        }

        public void DataGridViewChange(int id)
        {
            db.TableChange(id);
            int y = db.Select(id);
            dataGridView.Invoke(new Action(() => dataGridView.Rows[id - 1].Cells[2].Value = y));
        }
        public void DataGridViewInsertTable(Color color)
        {
            //dataGridView.Height = 0;
            if (this.dataGridView.InvokeRequired) { Invoke(DataGridViewInsertTable); }
            else
            {
                db.Insert("Color, Score", "'" + color.ToString() + "', 0");
                if (checkfirst)
                {
                    List<string> components = new List<string> { "id", "Color", "Score" };
                    dataGridView.ColumnCount = 3;
                    dataGridView.Columns[0].Width = 50;
                    for (int i = 0; i < dataGridView.ColumnCount; i++)
                    {
                        dataGridView.Columns[i].HeaderText = components[i];
                    }
                    dataGridView.Height += 2 * dataGridView.RowTemplate.Height;
                    dataGridView.Rows.Add();
                    dataGridView.Rows[count].Cells[0].Value = count + 1;
                    dataGridView.Rows[count].Cells[2].Value = 0;
                    dataGridView.Rows[count].Cells[1].Style.BackColor = color;
                    checkfirst = false;
                    count += 1;
                }
                else
                {
                    dataGridView.Height += dataGridView.RowTemplate.Height;
                    dataGridView.Rows.Add();
                    dataGridView.Rows[count].Cells[0].Value = count + 1;
                    dataGridView.Rows[count].Cells[2].Value = 0;
                    dataGridView.Rows[count].Cells[1].Style.BackColor = color;
                    count += 1;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            flag = true;
            //p.AddNew();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.Stop();
        }

        private void mainPanel_Resize(object sender, EventArgs e)
        {
            if (p != null)
                p.MainGraphics = mainPanel.CreateGraphics();
        }

        private void mainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                p.AddSquare(e);
                /*ProgressBar progressBar = new ProgressBar();
                progressBar.Location = new Point(e.X - 25, e.Y - 40);
                progressBar.Width = 50;
                progressBar.Height = 10;
                progressBar.Visible = true;
                mainPanel.Controls.Add(progressBar);*/
            }
            flag = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.Delete("points");
        }
    }
}