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
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            Btn_refresh = new Button();
            panel1 = new Panel();
            Lb_loading = new Label();
            Lb_searchDomain = new Label();
            Tb_searchDomain = new TextBox();
            Btn_enterSearsnDomain = new Button();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.AutoSize = false;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1040, 28);
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
            Btn_refresh.BackColor = SystemColors.Control;
            Btn_refresh.BackgroundImage = HistoryBrowser.Properties.Resources.png_transparent_computer_icons_computer_software_refresh_icon_text_business_rim;
            Btn_refresh.BackgroundImageLayout = ImageLayout.Zoom;
            Btn_refresh.Location = new Point(998, 31);
            Btn_refresh.Name = "Btn_refresh";
            Btn_refresh.Size = new Size(28, 29);
            Btn_refresh.TabIndex = 3;
            Btn_refresh.UseVisualStyleBackColor = false;
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
            // Lb_searchDomain
            // 
            Lb_searchDomain.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Lb_searchDomain.AutoSize = true;
            Lb_searchDomain.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Lb_searchDomain.Location = new Point(676, 48);
            Lb_searchDomain.Name = "Lb_searchDomain";
            Lb_searchDomain.Size = new Size(181, 28);
            Lb_searchDomain.TabIndex = 5;
            Lb_searchDomain.Text = "Search by domain";
            // 
            // Tb_searchDomain
            // 
            Tb_searchDomain.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Tb_searchDomain.Location = new Point(676, 79);
            Tb_searchDomain.Name = "Tb_searchDomain";
            Tb_searchDomain.Size = new Size(350, 27);
            Tb_searchDomain.TabIndex = 6;
            Tb_searchDomain.KeyPress += Tb_searchDomain_KeyPress;
            // 
            // Btn_enterSearsnDomain
            // 
            Btn_enterSearsnDomain.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Btn_enterSearsnDomain.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Btn_enterSearsnDomain.Location = new Point(948, 112);
            Btn_enterSearsnDomain.Name = "Btn_enterSearsnDomain";
            Btn_enterSearsnDomain.Size = new Size(80, 34);
            Btn_enterSearsnDomain.TabIndex = 7;
            Btn_enterSearsnDomain.Text = "Enter";
            Btn_enterSearsnDomain.TextAlign = ContentAlignment.TopCenter;
            Btn_enterSearsnDomain.UseVisualStyleBackColor = true;
            Btn_enterSearsnDomain.Click += Btn_enterSearsnDomain_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 450);
            Controls.Add(Btn_enterSearsnDomain);
            Controls.Add(Tb_searchDomain);
            Controls.Add(Lb_searchDomain);
            Controls.Add(panel1);
            Controls.Add(Btn_refresh);
            Controls.Add(menuStrip1);
            Name = "Form1";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Button Btn_refresh;
        public Panel panel1;
        public Label Lb_loading;
        private Label Lb_searchDomain;
        private TextBox Tb_searchDomain;
        private Button Btn_enterSearsnDomain;
    }
}
