namespace DemExTest
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            EditMenuItem = new ToolStripMenuItem();
            DeleteMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            AddProductButton = new Button();
            panel2 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1 });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(103, 186, 128);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(272, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.ContextMenuStrip = contextMenuStrip1;
            dataGridView1.Size = new Size(558, 714);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { EditMenuItem, DeleteMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(127, 48);
            // 
            // EditMenuItem
            // 
            EditMenuItem.Name = "EditMenuItem";
            EditMenuItem.Size = new Size(126, 22);
            EditMenuItem.Text = "изменить";
            EditMenuItem.Click += EditMenuItem_Click;
            // 
            // DeleteMenuItem
            // 
            DeleteMenuItem.Name = "DeleteMenuItem";
            DeleteMenuItem.Size = new Size(126, 22);
            DeleteMenuItem.Text = "удалить";
            DeleteMenuItem.Click += DeleteMenuItem_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(244, 232, 211);
            panel1.Controls.Add(AddProductButton);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(272, 714);
            panel1.TabIndex = 1;
            // 
            // AddProductButton
            // 
            AddProductButton.Location = new Point(12, 254);
            AddProductButton.Name = "AddProductButton";
            AddProductButton.Size = new Size(254, 36);
            AddProductButton.TabIndex = 3;
            AddProductButton.Text = "Добавить продукт";
            AddProductButton.UseVisualStyleBackColor = true;
            AddProductButton.Click += AddProductButton_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(244, 232, 211);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(830, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(376, 714);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(69, 9);
            label1.Name = "label1";
            label1.Size = new Size(240, 24);
            label1.TabIndex = 0;
            label1.Text = "Подробная информация";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1206, 714);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Мастер пол";
            Shown += MainForm_Shown;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panel1;
        private Panel panel2;
        private ContextMenuStrip contextMenuStrip1;
        private Label label1;
        private DataGridViewTextBoxColumn Column1;
        private ToolStripMenuItem EditMenuItem;
        private ToolStripMenuItem DeleteMenuItem;
        private Button AddProductButton;
    }
}
