namespace AutosGUI
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
            tableLayoutPanel1 = new TableLayoutPanel();
            listBoxAutok = new ListBox();
            panel1 = new Panel();
            label1 = new Label();
            textBox2 = new TextBox();
            labelGyartasiEv = new Label();
            textBoxGyartasiEv = new TextBox();
            buttonBezar = new Button();
            buttonBetolt = new Button();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(listBoxAutok, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // listBoxAutok
            // 
            listBoxAutok.Dock = DockStyle.Fill;
            listBoxAutok.FormattingEnabled = true;
            listBoxAutok.ItemHeight = 15;
            listBoxAutok.Location = new Point(15, 15);
            listBoxAutok.Margin = new Padding(15);
            listBoxAutok.Name = "listBoxAutok";
            listBoxAutok.Size = new Size(770, 195);
            listBoxAutok.TabIndex = 0;
            listBoxAutok.SelectedIndexChanged += listBoxAutok_SelectedIndexChanged;
            listBoxAutok.MouseEnter += listBoxAutok_MouseEnter;
            listBoxAutok.MouseLeave += listBoxAutok_MouseLeave;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(labelGyartasiEv);
            panel1.Controls.Add(textBoxGyartasiEv);
            panel1.Controls.Add(buttonBezar);
            panel1.Controls.Add(buttonBetolt);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 228);
            panel1.Name = "panel1";
            panel1.Size = new Size(794, 219);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(228, 172);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 5;
            label1.Text = "Átlagos eladási ár";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(350, 165);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 4;
            // 
            // labelGyartasiEv
            // 
            labelGyartasiEv.AutoSize = true;
            labelGyartasiEv.Location = new Point(263, 68);
            labelGyartasiEv.Name = "labelGyartasiEv";
            labelGyartasiEv.Size = new Size(64, 15);
            labelGyartasiEv.TabIndex = 3;
            labelGyartasiEv.Text = "Gyártási év";
            // 
            // textBoxGyartasiEv
            // 
            textBoxGyartasiEv.Location = new Point(350, 65);
            textBoxGyartasiEv.Name = "textBoxGyartasiEv";
            textBoxGyartasiEv.Size = new Size(100, 23);
            textBoxGyartasiEv.TabIndex = 2;
            // 
            // buttonBezar
            // 
            buttonBezar.Location = new Point(690, 164);
            buttonBezar.Name = "buttonBezar";
            buttonBezar.Size = new Size(75, 23);
            buttonBezar.TabIndex = 1;
            buttonBezar.Text = "Bezár";
            buttonBezar.UseVisualStyleBackColor = true;
            buttonBezar.Click += buttonBezar_Click;
            // 
            // buttonBetolt
            // 
            buttonBetolt.Location = new Point(350, 127);
            buttonBetolt.Name = "buttonBetolt";
            buttonBetolt.Size = new Size(75, 23);
            buttonBetolt.TabIndex = 0;
            buttonBetolt.Text = "Betölt";
            buttonBetolt.UseVisualStyleBackColor = true;
            buttonBetolt.Click += buttonBetolt_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ListBox listBoxAutok;
        private Panel panel1;
        private Label labelGyartasiEv;
        private TextBox textBox1;
        private Button buttonBezar;
        private Button buttonBetolt;
        private TextBox textBox2;
        private TextBox textBoxGyartasiEv;
        private Label label1;
    }
}