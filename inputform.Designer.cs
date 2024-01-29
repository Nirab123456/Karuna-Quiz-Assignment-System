namespace Karuna_assignment_quiz
{
    partial class inputform
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            subjects = new CheckedListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 19);
            label1.Name = "label1";
            label1.Size = new Size(127, 20);
            label1.TabIndex = 0;
            label1.Text = "Enter your Name :";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(168, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(436, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 76);
            label2.Name = "label2";
            label2.Size = new Size(248, 20);
            label2.TabIndex = 2;
            label2.Text = "Enter amount of question(30 to 50) :";
            label2.Click += label2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(289, 73);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(315, 27);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Crimson;
            label3.Location = new Point(35, 129);
            label3.Name = "label3";
            label3.Size = new Size(414, 38);
            label3.TabIndex = 4;
            label3.Text = "Select atleact 2 (two) subjects ";
            label3.Click += label3_Click;
            // 
            // subjects
            // 
            subjects.FormattingEnabled = true;
            subjects.Items.AddRange(new object[] { "Math", "Science", "General knowledge " });
            subjects.Location = new Point(44, 170);
            subjects.Name = "subjects";
            subjects.Size = new Size(167, 70);
            subjects.TabIndex = 5;
            subjects.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDark;
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(207, 283);
            button1.Name = "button1";
            button1.Size = new Size(260, 69);
            button1.TabIndex = 6;
            button1.Text = "START";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // inputform
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(subjects);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(label3);
            Name = "inputform";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private CheckedListBox subjects;
        private Button button1;
    }
}
