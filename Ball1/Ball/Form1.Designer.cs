namespace Ball
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
            mainPanel = new Panel();
            btnStart = new Button();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPanel.BackColor = Color.White;
            mainPanel.Cursor = Cursors.Cross;
            mainPanel.Location = new Point(14, 16);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(635, 558);
            mainPanel.TabIndex = 0;
            mainPanel.MouseClick += mainPanel_MouseClick;
            mainPanel.Resize += mainPanel_Resize;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnStart.BackColor = SystemColors.Control;
            btnStart.Cursor = Cursors.Hand;
            btnStart.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnStart.Location = new Point(756, 499);
            btnStart.Margin = new Padding(3, 4, 3, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(192, 75);
            btnStart.TabIndex = 1;
            btnStart.Text = "Старт";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dataGridView.BackgroundColor = SystemColors.GradientActiveCaption;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(693, 16);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.ScrollBars = ScrollBars.None;
            dataGridView.Size = new Size(300, 476);
            dataGridView.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.шарики;
            ClientSize = new Size(1033, 620);
            Controls.Add(dataGridView);
            Controls.Add(btnStart);
            Controls.Add(mainPanel);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(453, 446);
            Name = "Form1";
            Text = "Анимация";
            FormClosed += Form1_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Button btnStart;
        public DataGridView dataGridView;
    }
}