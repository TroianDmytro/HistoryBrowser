namespace WinFormsApp1
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
            Dgv_history = new DataGridView();
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            Btn_refresh = new Button();
            panel1 = new Panel();
            Lb_loading = new Label();
            ((System.ComponentModel.ISupportInitialize)Dgv_history).BeginInit();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Dgv_history
            // 
            Dgv_history.AllowUserToAddRows = false;
            Dgv_history.AllowUserToDeleteRows = false;
            Dgv_history.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Dgv_history.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Dgv_history.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_history.Location = new Point(598, 104);
            Dgv_history.Name = "Dgv_history";
            Dgv_history.RowHeadersVisible = false;
            Dgv_history.RowHeadersWidth = 51;
            Dgv_history.Size = new Size(168, 422);
            Dgv_history.TabIndex = 0;
            Dgv_history.CellContentClick += Dgv_history_CellContentClick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(76, 24);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // Btn_refresh
            // 
            Btn_refresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Btn_refresh.BackgroundImage = HistoryBrowser.Properties.Resources.png_transparent_computer_icons_computer_software_refresh_icon_text_business_rim;
            Btn_refresh.BackgroundImageLayout = ImageLayout.Zoom;
            Btn_refresh.Location = new Point(749, 31);
            Btn_refresh.Name = "Btn_refresh";
            Btn_refresh.Size = new Size(39, 38);
            Btn_refresh.TabIndex = 3;
            Btn_refresh.UseVisualStyleBackColor = true;
            Btn_refresh.Click += Btn_refresh_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(Lb_loading);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(670, 422);
            panel1.TabIndex = 4;
            // 
            // Lb_loading
            // 
            Lb_loading.AutoSize = true;
            Lb_loading.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lb_loading.Location = new Point(236, 176);
            Lb_loading.Name = "Lb_loading";
            Lb_loading.Size = new Size(204, 43);
            Lb_loading.TabIndex = 0;
            Lb_loading.Text = "Loading...";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(Btn_refresh);
            Controls.Add(Dgv_history);
            Controls.Add(menuStrip1);
            Name = "Form1";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)Dgv_history).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView Dgv_history;
        public MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Button Btn_refresh;
        private Panel panel1;
        private Label Lb_loading;
    }
}
