namespace Интеграл_test_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            drawbtn = new Button();
            distlbl = new Label();
            startbox = new TextBox();
            endbox = new TextBox();
            calculatebtn = new Button();
            infobox = new TextBox();
            mthdcombox = new ComboBox();
            method = new Label();
            clearbtn = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(13, 63);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(542, 501);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // drawbtn
            // 
            drawbtn.BackColor = Color.Cyan;
            drawbtn.Cursor = Cursors.Hand;
            drawbtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            drawbtn.ForeColor = Color.Purple;
            drawbtn.Location = new Point(607, 63);
            drawbtn.Name = "drawbtn";
            drawbtn.Size = new Size(267, 60);
            drawbtn.TabIndex = 1;
            drawbtn.Text = "Отрисовка графика";
            drawbtn.UseVisualStyleBackColor = false;
            drawbtn.Click += drawbtn_Click;
            // 
            // distlbl
            // 
            distlbl.BackColor = Color.Cyan;
            distlbl.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            distlbl.ForeColor = Color.Purple;
            distlbl.Location = new Point(578, 157);
            distlbl.Name = "distlbl";
            distlbl.Size = new Size(211, 37);
            distlbl.TabIndex = 2;
            distlbl.Text = "Введите интервал";
            // 
            // startbox
            // 
            startbox.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            startbox.Location = new Point(808, 156);
            startbox.Name = "startbox";
            startbox.Size = new Size(59, 38);
            startbox.TabIndex = 3;
            startbox.Text = "-100";
            // 
            // endbox
            // 
            endbox.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            endbox.Location = new Point(884, 157);
            endbox.Name = "endbox";
            endbox.Size = new Size(54, 38);
            endbox.TabIndex = 4;
            endbox.Text = "100";
            // 
            // calculatebtn
            // 
            calculatebtn.BackColor = Color.Cyan;
            calculatebtn.Cursor = Cursors.Hand;
            calculatebtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            calculatebtn.ForeColor = Color.Purple;
            calculatebtn.Location = new Point(690, 364);
            calculatebtn.Name = "calculatebtn";
            calculatebtn.Size = new Size(266, 51);
            calculatebtn.TabIndex = 5;
            calculatebtn.Text = "Вычислить интеграл";
            calculatebtn.UseVisualStyleBackColor = false;
            calculatebtn.Click += calculatebtn_Click;
            // 
            // infobox
            // 
            infobox.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            infobox.Location = new Point(769, 437);
            infobox.Name = "infobox";
            infobox.Size = new Size(187, 38);
            infobox.TabIndex = 6;
            // 
            // mthdcombox
            // 
            mthdcombox.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            mthdcombox.FormattingEnabled = true;
            mthdcombox.Items.AddRange(new object[] { "Левые прямоугольники", "Правые прямоугольники", "Центральные прямоугольники", "Трапеции" });
            mthdcombox.Location = new Point(690, 213);
            mthdcombox.Name = "mthdcombox";
            mthdcombox.Size = new Size(280, 39);
            mthdcombox.TabIndex = 7;
            // 
            // method
            // 
            method.BackColor = Color.Cyan;
            method.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            method.ForeColor = Color.Purple;
            method.Location = new Point(561, 216);
            method.Name = "method";
            method.Size = new Size(123, 68);
            method.TabIndex = 8;
            method.Text = "Выберите метод";
            // 
            // clearbtn
            // 
            clearbtn.BackColor = Color.Cyan;
            clearbtn.Cursor = Cursors.Hand;
            clearbtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            clearbtn.ForeColor = Color.Purple;
            clearbtn.Location = new Point(778, 503);
            clearbtn.Name = "clearbtn";
            clearbtn.Size = new Size(178, 61);
            clearbtn.TabIndex = 9;
            clearbtn.Text = "Очистить";
            clearbtn.UseVisualStyleBackColor = false;
            clearbtn.Click += clearbtn_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.Cyan;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Purple;
            label1.Location = new Point(96, 2);
            label1.Name = "label1";
            label1.Size = new Size(778, 45);
            label1.TabIndex = 10;
            label1.Text = "Приближенное вычисление определенного интеграла";
            // 
            // label2
            // 
            label2.BackColor = Color.Cyan;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Purple;
            label2.Location = new Point(690, 437);
            label2.Name = "label2";
            label2.Size = new Size(82, 38);
            label2.TabIndex = 11;
            label2.Text = "Ответ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 255, 128);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(982, 753);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(clearbtn);
            Controls.Add(method);
            Controls.Add(mthdcombox);
            Controls.Add(infobox);
            Controls.Add(calculatebtn);
            Controls.Add(endbox);
            Controls.Add(startbox);
            Controls.Add(distlbl);
            Controls.Add(drawbtn);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button drawbtn;
        private Label distlbl;
        private TextBox startbox;
        private TextBox endbox;
        private Button calculatebtn;
        private TextBox infobox;
        private ComboBox mthdcombox;
        private Label method;
        private Button clearbtn;
        private Label label1;
        private Label label2;
    }
}