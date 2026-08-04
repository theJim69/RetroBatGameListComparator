namespace RetroBatGameListComparator.Forms
{
    partial class UpdateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblCurrentVersion = new Label();
            lblLatestVersion = new Label();
            panel1 = new Panel();
            lblFileName = new Label();
            lblFileSize = new Label();
            panel2 = new Panel();
            btnDownload = new Button();
            btnGitHub = new Button();
            btnLater = new Button();
            progressBarDownload = new ProgressBar();
            lblProgress = new Label();
            lblStatus = new Label();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(111, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(319, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🚀 Une nouvelle version est disponible !";
            // 
            // lblCurrentVersion
            // 
            lblCurrentVersion.AutoSize = true;
            lblCurrentVersion.Location = new Point(30, 70);
            lblCurrentVersion.Name = "lblCurrentVersion";
            lblCurrentVersion.Size = new Size(97, 15);
            lblCurrentVersion.TabIndex = 1;
            lblCurrentVersion.Text = "Version installée :";
            // 
            // lblLatestVersion
            // 
            lblLatestVersion.AutoSize = true;
            lblLatestVersion.Location = new Point(30, 100);
            lblLatestVersion.Name = "lblLatestVersion";
            lblLatestVersion.Size = new Size(101, 15);
            lblLatestVersion.TabIndex = 2;
            lblLatestVersion.Text = "Nouvelle version :";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Location = new Point(30, 135);
            panel1.Name = "panel1";
            panel1.Size = new Size(520, 1);
            panel1.TabIndex = 3;
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Location = new Point(30, 155);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(48, 15);
            lblFileName.TabIndex = 4;
            lblFileName.Text = "Fichier :";
            // 
            // lblFileSize
            // 
            lblFileSize.AutoSize = true;
            lblFileSize.Location = new Point(30, 185);
            lblFileSize.Name = "lblFileSize";
            lblFileSize.Size = new Size(40, 15);
            lblFileSize.TabIndex = 5;
            lblFileSize.Text = "Taille :";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gainsboro;
            panel2.Location = new Point(30, 220);
            panel2.Name = "panel2";
            panel2.Size = new Size(520, 1);
            panel2.TabIndex = 6;
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(220, 304);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(140, 28);
            btnDownload.TabIndex = 7;
            btnDownload.Text = "Télécharger";
            btnDownload.UseVisualStyleBackColor = true;
            // 
            // btnGitHub
            // 
            btnGitHub.Location = new Point(160, 342);
            btnGitHub.Name = "btnGitHub";
            btnGitHub.Size = new Size(110, 28);
            btnGitHub.TabIndex = 8;
            btnGitHub.Text = "Ouvrir GitHub";
            btnGitHub.UseVisualStyleBackColor = true;
            // 
            // btnLater
            // 
            btnLater.Location = new Point(310, 342);
            btnLater.Name = "btnLater";
            btnLater.Size = new Size(110, 28);
            btnLater.TabIndex = 9;
            btnLater.Text = "Plus tard";
            btnLater.UseVisualStyleBackColor = true;
            // 
            // progressBarDownload
            // 
            progressBarDownload.Location = new Point(30, 248);
            progressBarDownload.Name = "progressBarDownload";
            progressBarDownload.Size = new Size(520, 23);
            progressBarDownload.TabIndex = 10;
            progressBarDownload.Visible = false;
                        // 
            // lblProgress
            // 
            lblProgress.Location = new Point(30, 274);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(520, 18);
            lblProgress.TabIndex = 11;
            lblProgress.Text = "0 %";
            lblProgress.TextAlign = ContentAlignment.MiddleCenter;
            lblProgress.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(30, 228);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(101, 15);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Téléchargement...";
            lblStatus.Visible = false;
            // 
            // btnCancel
            // 
            btnCancel.Enabled = false;
            btnCancel.Location = new Point(220, 304);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 28);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Annuler";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Visible = false;
            // 
            // UpdateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 390);
            Controls.Add(btnCancel);
            Controls.Add(lblStatus);
            Controls.Add(lblProgress);
            Controls.Add(progressBarDownload);
            Controls.Add(btnLater);
            Controls.Add(btnGitHub);
            Controls.Add(btnDownload);
            Controls.Add(panel2);
            Controls.Add(lblFileSize);
            Controls.Add(lblFileName);
            Controls.Add(panel1);
            Controls.Add(lblLatestVersion);
            Controls.Add(lblCurrentVersion);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdateForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Mise à jour disponible";
            FormClosing += UpdateForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCurrentVersion;
        private Label lblLatestVersion;
        private Label lblFileName;
        private Label lblFileSize;
        private Button btnDownload;
        private Button btnGitHub;
        private Button btnLater;
        private Panel panel1;
        private Panel panel2;
        private ProgressBar progressBarDownload;
        private Label lblProgress;
        private Label lblStatus;
        private Button btnCancel;
    }
}