namespace SMOModeling
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
            StartButton = new Button();
            WaitingLabel = new Label();
            DoneLabel = new Label();
            SuspendLayout();
            // 
            // StartButton
            // 
            StartButton.Location = new Point(12, 12);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(138, 46);
            StartButton.TabIndex = 0;
            StartButton.Text = "Начать моделирование";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += SMOStarted;
            // 
            // WaitingLabel
            // 
            WaitingLabel.AutoSize = true;
            WaitingLabel.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            WaitingLabel.ForeColor = SystemColors.ButtonFace;
            WaitingLabel.Location = new Point(181, 33);
            WaitingLabel.Name = "WaitingLabel";
            WaitingLabel.Size = new Size(199, 18);
            WaitingLabel.TabIndex = 1;
            WaitingLabel.Text = "Ждут обслуживания:";
            // 
            // DoneLabel
            // 
            DoneLabel.AutoSize = true;
            DoneLabel.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            DoneLabel.ForeColor = SystemColors.ButtonFace;
            DoneLabel.Location = new Point(517, 33);
            DoneLabel.Name = "DoneLabel";
            DoneLabel.Size = new Size(168, 18);
            DoneLabel.TabIndex = 2;
            DoneLabel.Text = "Готовы к выдаче:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(784, 861);
            Controls.Add(DoneLabel);
            Controls.Add(WaitingLabel);
            Controls.Add(StartButton);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Система массового обслуживания";
            Paint += MainForm_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button StartButton;
        private Label WaitingLabel;
        private Label DoneLabel;
    }
}