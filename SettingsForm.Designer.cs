namespace HistoryBrowser
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Cbox_night_treme = new CheckBox();
            Cbox_autoStart = new CheckBox();
            Cbox_openWindowInFullScreen = new CheckBox();
            Btn_save = new Button();
            SuspendLayout();
            // 
            // Cbox_night_treme
            // 
            Cbox_night_treme.AutoSize = true;
            Cbox_night_treme.Location = new Point(13, 13);
            Cbox_night_treme.Margin = new Padding(4);
            Cbox_night_treme.Name = "Cbox_night_treme";
            Cbox_night_treme.Size = new Size(154, 32);
            Cbox_night_treme.TabIndex = 0;
            Cbox_night_treme.Text = "Night theme";
            Cbox_night_treme.UseVisualStyleBackColor = true;
            Cbox_night_treme.CheckedChanged += Cbox_night_treme_CheckedChanged;
            // 
            // Cbox_autoStart
            // 
            Cbox_autoStart.AutoSize = true;
            Cbox_autoStart.Location = new Point(13, 53);
            Cbox_autoStart.Margin = new Padding(4);
            Cbox_autoStart.Name = "Cbox_autoStart";
            Cbox_autoStart.Size = new Size(133, 32);
            Cbox_autoStart.TabIndex = 1;
            Cbox_autoStart.Text = "Auto Start";
            Cbox_autoStart.UseVisualStyleBackColor = true;
            Cbox_autoStart.CheckedChanged += Cbox_autoStart_CheckedChanged;
            // 
            // Cbox_openWindowInFullScreen
            // 
            Cbox_openWindowInFullScreen.CheckAlign = ContentAlignment.TopLeft;
            Cbox_openWindowInFullScreen.Location = new Point(13, 93);
            Cbox_openWindowInFullScreen.Margin = new Padding(4);
            Cbox_openWindowInFullScreen.Name = "Cbox_openWindowInFullScreen";
            Cbox_openWindowInFullScreen.Size = new Size(265, 66);
            Cbox_openWindowInFullScreen.TabIndex = 2;
            Cbox_openWindowInFullScreen.Text = "Open the window in full screen";
            Cbox_openWindowInFullScreen.TextAlign = ContentAlignment.TopLeft;
            Cbox_openWindowInFullScreen.UseVisualStyleBackColor = true;
            Cbox_openWindowInFullScreen.CheckedChanged += Cbox_openWindowInFullScreen_CheckedChanged;
            // 
            // Btn_save
            // 
            Btn_save.Location = new Point(87, 298);
            Btn_save.Name = "Btn_save";
            Btn_save.Size = new Size(94, 38);
            Btn_save.TabIndex = 3;
            Btn_save.Text = "Save";
            Btn_save.TextAlign = ContentAlignment.TopCenter;
            Btn_save.UseVisualStyleBackColor = true;
            Btn_save.Click += Btn_save_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(280, 348);
            Controls.Add(Btn_save);
            Controls.Add(Cbox_openWindowInFullScreen);
            Controls.Add(Cbox_autoStart);
            Controls.Add(Cbox_night_treme);
            Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox Cbox_night_treme;
        private CheckBox Cbox_autoStart;
        private CheckBox Cbox_openWindowInFullScreen;
        private Button Btn_save;
    }
}