namespace ffile
{
    partial class Ffile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ffile));
            this.FilePanel = new System.Windows.Forms.Panel();
            this.FileList = new System.Windows.Forms.ListBox();
            this.TransactionStatusLabel = new System.Windows.Forms.Label();
            this.ControlModeCheckBox = new System.Windows.Forms.CheckBox();
            this.HomePageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.EncryptRounds = new System.Windows.Forms.NumericUpDown();
            this.TextLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EncryptRounds)).BeginInit();
            this.SuspendLayout();
            // 
            // FilePanel
            // 
            this.FilePanel.AllowDrop = true;
            this.FilePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FilePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FilePanel.BackgroundImage")));
            this.FilePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FilePanel.Location = new System.Drawing.Point(12, 240);
            this.FilePanel.Name = "FilePanel";
            this.FilePanel.Size = new System.Drawing.Size(458, 148);
            this.FilePanel.TabIndex = 0;
            this.FilePanel.Click += new System.EventHandler(this.FilePanel_Click);
            this.FilePanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.FilePanel_DragDrop);
            this.FilePanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.FilePanel_DragEnter);
            // 
            // FileList
            // 
            this.FileList.FormattingEnabled = true;
            this.FileList.ItemHeight = 16;
            this.FileList.Location = new System.Drawing.Point(12, 12);
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(463, 148);
            this.FileList.TabIndex = 1;
            // 
            // TransactionStatusLabel
            // 
            this.TransactionStatusLabel.AutoSize = true;
            this.TransactionStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(200)));
            this.TransactionStatusLabel.Location = new System.Drawing.Point(12, 163);
            this.TransactionStatusLabel.Name = "TransactionStatusLabel";
            this.TransactionStatusLabel.Size = new System.Drawing.Size(17, 18);
            this.TransactionStatusLabel.TabIndex = 2;
            this.TransactionStatusLabel.Text = "~";
            // 
            // ControlModeCheckBox
            // 
            this.ControlModeCheckBox.AutoSize = true;
            this.ControlModeCheckBox.Checked = true;
            this.ControlModeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ControlModeCheckBox.Location = new System.Drawing.Point(12, 214);
            this.ControlModeCheckBox.Name = "ControlModeCheckBox";
            this.ControlModeCheckBox.Size = new System.Drawing.Size(109, 20);
            this.ControlModeCheckBox.TabIndex = 3;
            this.ControlModeCheckBox.Tag = "";
            this.ControlModeCheckBox.Text = "Control Mode";
            this.ControlModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // HomePageFileDialog
            // 
            this.HomePageFileDialog.Multiselect = true;
            this.HomePageFileDialog.Title = "Select file(s)";
            // 
            // EncryptRounds
            // 
            this.EncryptRounds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.EncryptRounds.Location = new System.Drawing.Point(414, 213);
            this.EncryptRounds.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.EncryptRounds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EncryptRounds.Name = "EncryptRounds";
            this.EncryptRounds.Size = new System.Drawing.Size(56, 24);
            this.EncryptRounds.TabIndex = 4;
            this.EncryptRounds.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // TextLabel1
            // 
            this.TextLabel1.AutoSize = true;
            this.TextLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TextLabel1.Location = new System.Drawing.Point(344, 215);
            this.TextLabel1.Name = "TextLabel1";
            this.TextLabel1.Size = new System.Drawing.Size(64, 18);
            this.TextLabel1.TabIndex = 5;
            this.TextLabel1.Text = "Rounds:";
            // 
            // Ffile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(482, 403);
            this.Controls.Add(this.TextLabel1);
            this.Controls.Add(this.EncryptRounds);
            this.Controls.Add(this.ControlModeCheckBox);
            this.Controls.Add(this.TransactionStatusLabel);
            this.Controls.Add(this.FileList);
            this.Controls.Add(this.FilePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 450);
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "Ffile";
            this.Text = "Ffile | Just for fun";
            this.Load += new System.EventHandler(this.Ffile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EncryptRounds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel FilePanel;
        private System.Windows.Forms.ListBox FileList;
        private System.Windows.Forms.Label TransactionStatusLabel;
        private System.Windows.Forms.CheckBox ControlModeCheckBox;
        private System.Windows.Forms.OpenFileDialog HomePageFileDialog;
        private System.Windows.Forms.NumericUpDown EncryptRounds;
        private System.Windows.Forms.Label TextLabel1;
    }
}

