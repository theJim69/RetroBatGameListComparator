namespace RetroBatGameListComparator
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        private void InitializeComponent()
        {
            lblRomFolder = new Label();
            txtRomFolder = new TextBox();
            btnBrowseRomFolder = new Button();
            lblGameList = new Label();
            txtGameList = new TextBox();
            btnBrowseGameList = new Button();
            lblExtension = new Label();
            cmbExtension = new ComboBox();
            btnSelectExtensions = new Button();
            chkRecursive = new CheckBox();
            btnCompare = new Button();
            lvMissingFromXml = new ListView();
            colXmlRom = new ColumnHeader();
            colXmlFolder = new ColumnHeader();
            lblMissingXmlTitle = new Label();
            lblMissingDiskTitle = new Label();
            lvMissingFromDisk = new ListView();
            colDiskRom = new ColumnHeader();
            colDiskFolder = new ColumnHeader();
            btnExportTxt = new Button();
            btnExportCsv = new Button();
            menuStrip1 = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            mnuHelp = new ToolStripMenuItem();
            mnuGitHub = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            mnuAbout = new ToolStripMenuItem();
            lblHint = new Label();
            lblMissingDisk = new Label();
            lblMissingXml = new Label();
            lblMatching = new Label();
            lblXmlCount = new Label();
            lblDiskCount = new Label();
            progressBar = new ProgressBar();
            grpStatistics = new GroupBox();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            grpStatistics.SuspendLayout();
            SuspendLayout();
            pnlDropOverlay = new Panel();
            lblDropOverlay = new Label();
            // 
            // lblRomFolder
            // 
            lblRomFolder.AutoSize = true;
            lblRomFolder.Location = new Point(13, 32);
            lblRomFolder.Name = "lblRomFolder";
            lblRomFolder.Size = new Size(101, 15);
            lblRomFolder.TabIndex = 0;
            lblRomFolder.Text = "Dossier des ROMs";
            // 
            // txtRomFolder
            // 
            txtRomFolder.Location = new Point(13, 48);
            txtRomFolder.Margin = new Padding(3, 2, 3, 2);
            txtRomFolder.Name = "txtRomFolder";
            txtRomFolder.PlaceholderText =
            "📁 Glissez ici un dossier de ROMs... Ou sélectionnez un dossier";
            txtRomFolder.Size = new Size(560, 23);
            txtRomFolder.TabIndex = 1;
            // 
            // btnBrowseRomFolder
            // 
            btnBrowseRomFolder.Location = new Point(582, 48);
            btnBrowseRomFolder.Margin = new Padding(3, 2, 3, 2);
            btnBrowseRomFolder.Name = "btnBrowseRomFolder";
            btnBrowseRomFolder.Size = new Size(35, 22);
            btnBrowseRomFolder.TabIndex = 2;
            btnBrowseRomFolder.Text = "...";
            btnBrowseRomFolder.Click += btnBrowseRomFolder_Click;
            // 
            // lblGameList
            // 
            lblGameList.AutoSize = true;
            lblGameList.Location = new Point(13, 77);
            lblGameList.Name = "lblGameList";
            lblGameList.Size = new Size(78, 15);
            lblGameList.TabIndex = 3;
            lblGameList.Text = "GameList.xml";
            // 
            // txtGameList
            // 
            txtGameList.Location = new Point(13, 92);
            txtGameList.Margin = new Padding(3, 2, 3, 2);
            txtGameList.Name = "txtGameList";
            txtGameList.PlaceholderText =
            "📄 Glissez ici un fichier gamelist.xml... ou sélectionnez un fichier";
            txtGameList.Size = new Size(560, 23);
            txtGameList.TabIndex = 4;
            // 
            // btnBrowseGameList
            // 
            btnBrowseGameList.Location = new Point(582, 92);
            btnBrowseGameList.Margin = new Padding(3, 2, 3, 2);
            btnBrowseGameList.Name = "btnBrowseGameList";
            btnBrowseGameList.Size = new Size(35, 22);
            btnBrowseGameList.TabIndex = 5;
            btnBrowseGameList.Text = "...";
            btnBrowseGameList.Click += btnBrowseGameList_Click;
            // 
            // lblExtension
            // 
            lblExtension.AutoSize = true;
            lblExtension.Location = new Point(13, 124);
            lblExtension.Name = "lblExtension";
            lblExtension.Size = new Size(319, 15);
            lblExtension.TabIndex = 6;
            lblExtension.Text = "Extensions (ex. : .zip ; .7z ; .chd - séparées par ; , | ou espace)";
            // 
            // cmbExtension
            // 
            cmbExtension.FormattingEnabled = true;
            cmbExtension.Location = new Point(13, 140);
            cmbExtension.Name = "cmbExtension";
            cmbExtension.Size = new Size(410, 23);
            cmbExtension.TabIndex = 7;
            // 
            // btnSelectExtensions
            // 
            btnSelectExtensions.Location = new Point(430, 140);
            btnSelectExtensions.Name = "btnSelectExtensions";
            btnSelectExtensions.Size = new Size(30, 23);
            btnSelectExtensions.TabIndex = 8;
            btnSelectExtensions.Text = "...";
            btnSelectExtensions.UseVisualStyleBackColor = true;
            btnSelectExtensions.Click += btnSelectExtensions_Click;
            // 
            // chkRecursive
            // 
            chkRecursive.AutoSize = true;
            chkRecursive.Location = new Point(175, 167);
            chkRecursive.Margin = new Padding(3, 2, 3, 2);
            chkRecursive.Name = "chkRecursive";
            chkRecursive.Size = new Size(204, 19);
            chkRecursive.TabIndex = 9;
            chkRecursive.Text = "Rechercher dans les sous-dossiers";
            // 
            // btnCompare
            // 
            btnCompare.Location = new Point(499, 138);
            btnCompare.Margin = new Padding(3, 2, 3, 2);
            btnCompare.Name = "btnCompare";
            btnCompare.Size = new Size(118, 26);
            btnCompare.TabIndex = 10;
            btnCompare.Text = "Comparer";
            btnCompare.Click += btnCompare_Click;
            // 
            // lvMissingFromXml
            // 
            lvMissingFromXml.Columns.AddRange(new ColumnHeader[] { colXmlRom, colXmlFolder });
            lvMissingFromXml.FullRowSelect = true;
            lvMissingFromXml.GridLines = true;
            lvMissingFromXml.Location = new Point(13, 303);
            lvMissingFromXml.Margin = new Padding(3, 2, 3, 2);
            lvMissingFromXml.Name = "lvMissingFromXml";
            lvMissingFromXml.Size = new Size(298, 166);
            lvMissingFromXml.TabIndex = 11;
            lvMissingFromXml.UseCompatibleStateImageBehavior = false;
            lvMissingFromXml.View = View.Details;
            lvMissingFromXml.DoubleClick += lvMissingFromXml_DoubleClick;
            // 
            // colXmlRom
            // 
            colXmlRom.Text = "ROM";
            colXmlRom.Width = 180;
            // 
            // colXmlFolder
            // 
            colXmlFolder.Text = "Dossier";
            colXmlFolder.Width = 130;
            // 
            // lblMissingXmlTitle
            // 
            lblMissingXmlTitle.AutoSize = true;
            lblMissingXmlTitle.Location = new Point(13, 286);
            lblMissingXmlTitle.Name = "lblMissingXmlTitle";
            lblMissingXmlTitle.Size = new Size(116, 15);
            lblMissingXmlTitle.TabIndex = 10;
            lblMissingXmlTitle.Text = "Absentes du XML (0)";
            // 
            // lblMissingDiskTitle
            // 
            lblMissingDiskTitle.AutoSize = true;
            lblMissingDiskTitle.Location = new Point(319, 286);
            lblMissingDiskTitle.Name = "lblMissingDiskTitle";
            lblMissingDiskTitle.Size = new Size(127, 15);
            lblMissingDiskTitle.TabIndex = 11;
            lblMissingDiskTitle.Text = "Absentes du disque (0)";
            // 
            // lvMissingFromDisk
            // 
            lvMissingFromDisk.Columns.AddRange(new ColumnHeader[] { colDiskRom, colDiskFolder });
            lvMissingFromDisk.FullRowSelect = true;
            lvMissingFromDisk.GridLines = true;
            lvMissingFromDisk.Location = new Point(319, 303);
            lvMissingFromDisk.Margin = new Padding(3, 2, 3, 2);
            lvMissingFromDisk.Name = "lvMissingFromDisk";
            lvMissingFromDisk.Size = new Size(298, 166);
            lvMissingFromDisk.TabIndex = 12;
            lvMissingFromDisk.UseCompatibleStateImageBehavior = false;
            lvMissingFromDisk.View = View.Details;
            lvMissingFromDisk.DoubleClick += lvMissingFromDisk_DoubleClick;
            // 
            // colDiskRom
            // 
            colDiskRom.Text = "ROM";
            colDiskRom.Width = 180;
            // 
            // colDiskFolder
            // 
            colDiskFolder.Text = "Dossier";
            colDiskFolder.Width = 130;
            // 
            // btnExportTxt
            // 
            btnExportTxt.Location = new Point(175, 505);
            btnExportTxt.Margin = new Padding(3, 2, 3, 2);
            btnExportTxt.Name = "btnExportTxt";
            btnExportTxt.Size = new Size(105, 26);
            btnExportTxt.TabIndex = 13;
            btnExportTxt.Text = "Exporter TXT";
            btnExportTxt.Click += btnExportTxt_Click;
            // 
            // btnExportCsv
            // 
            btnExportCsv.Location = new Point(341, 505);
            btnExportCsv.Margin = new Padding(3, 2, 3, 2);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(105, 26);
            btnExportCsv.TabIndex = 14;
            btnExportCsv.Text = "Exporter CSV";
            btnExportCsv.Click += btnExportCsv_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuFile, mnuHelp });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(634, 24);
            menuStrip1.TabIndex = 0;
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuExit });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(54, 20);
            mnuFile.Text = "&Fichier";
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(111, 22);
            mnuExit.Text = "&Quitter";
            mnuExit.Click += mnuExit_Click;
            // 
            // mnuHelp
            // 
            mnuHelp.DropDownItems.AddRange(new ToolStripItem[] { mnuGitHub, toolStripSeparator1, mnuAbout });
            mnuHelp.Name = "mnuHelp";
            mnuHelp.Size = new Size(43, 20);
            mnuHelp.Text = "&Aide";
            // 
            // mnuGitHub
            // 
            mnuGitHub.Name = "mnuGitHub";
            mnuGitHub.Size = new Size(146, 22);
            mnuGitHub.Text = "Projet GitHub";
            mnuGitHub.Click += mnuGitHub_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(143, 6);
            // 
            // mnuAbout
            // 
            mnuAbout.Name = "mnuAbout";
            mnuAbout.Size = new Size(146, 22);
            mnuAbout.Text = "À propos...";
            mnuAbout.Click += mnuAbout_Click;
            // 
            // lblHint
            // 
            lblHint.ForeColor = SystemColors.GrayText;
            lblHint.Location = new Point(18, 480);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(594, 18);
            lblHint.TabIndex = 20;
            lblHint.Text = "💡 Astuce : double-cliquez sur une ROM pour l'ouvrir directement dans l'Explorateur Windows.";
            lblHint.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMissingDisk
            // 
            lblMissingDisk.AutoSize = true;
            lblMissingDisk.Location = new Point(158, 47);
            lblMissingDisk.Name = "lblMissingDisk";
            lblMissingDisk.Size = new Size(108, 15);
            lblMissingDisk.TabIndex = 4;
            lblMissingDisk.Text = "Absentes disque : 0";
            // 
            // lblMissingXml
            // 
            lblMissingXml.AutoSize = true;
            lblMissingXml.Location = new Point(13, 47);
            lblMissingXml.Name = "lblMissingXml";
            lblMissingXml.Size = new Size(97, 15);
            lblMissingXml.TabIndex = 3;
            lblMissingXml.Text = "Absentes XML : 0";
            // 
            // lblMatching
            // 
            lblMatching.AutoSize = true;
            lblMatching.Location = new Point(332, 18);
            lblMatching.Name = "lblMatching";
            lblMatching.Size = new Size(114, 15);
            lblMatching.TabIndex = 2;
            lblMatching.Text = "Correspondances : 0";
            // 
            // lblXmlCount
            // 
            lblXmlCount.AutoSize = true;
            lblXmlCount.Location = new Point(158, 23);
            lblXmlCount.Name = "lblXmlCount";
            lblXmlCount.Size = new Size(87, 15);
            lblXmlCount.TabIndex = 1;
            lblXmlCount.Text = "Entrées XML : 0";
            // 
            // lblDiskCount
            // 
            lblDiskCount.AutoSize = true;
            lblDiskCount.Location = new Point(13, 23);
            lblDiskCount.Name = "lblDiskCount";
            lblDiskCount.Size = new Size(92, 15);
            lblDiskCount.TabIndex = 0;
            lblDiskCount.Text = "ROMs disque : 0";
            // 
            // progressBar
            // 
            progressBar.ForeColor = Color.Blue;
            progressBar.Location = new Point(337, 39);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(261, 23);
            progressBar.TabIndex = 21;
            progressBar.Visible = false;
            // 
            // grpStatistics
            // 
            grpStatistics.Controls.Add(label1);
            grpStatistics.Controls.Add(progressBar);
            grpStatistics.Controls.Add(lblDiskCount);
            grpStatistics.Controls.Add(lblXmlCount);
            grpStatistics.Controls.Add(lblMatching);
            grpStatistics.Controls.Add(lblMissingXml);
            grpStatistics.Controls.Add(lblMissingDisk);
            grpStatistics.Location = new Point(13, 181);
            grpStatistics.Margin = new Padding(3, 2, 3, 2);
            grpStatistics.Name = "grpStatistics";
            grpStatistics.Padding = new Padding(3, 2, 3, 2);
            grpStatistics.Size = new Size(604, 84);
            grpStatistics.TabIndex = 10;
            grpStatistics.TabStop = false;
            grpStatistics.Text = "Statistiques";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(338, 65);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 22;
            label1.Text = "Prêt";
            label1.Visible = false;
            // Overlay Drag & Drop

            pnlDropOverlay.Dock = DockStyle.Fill;
            pnlDropOverlay.BackColor = Color.FromArgb(60, Color.DeepSkyBlue);
            pnlDropOverlay.Visible = false;

            lblDropOverlay.Dock = DockStyle.Fill;
            lblDropOverlay.TextAlign = ContentAlignment.MiddleCenter;

            lblDropOverlay.Font = new Font(
                "Segoe UI",
                18F,
                FontStyle.Bold);

            lblDropOverlay.Text =
                "📁\n\nDéposez ici votre dossier de ROMs\n\nou un fichier GameList.xml";

            pnlDropOverlay.Controls.Add(lblDropOverlay);

            Controls.Add(pnlDropOverlay);
            pnlDropOverlay.BringToFront();

            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 553);
            Controls.Add(menuStrip1);
            Controls.Add(lblRomFolder);
            Controls.Add(txtRomFolder);
            Controls.Add(btnBrowseRomFolder);
            Controls.Add(lblGameList);
            Controls.Add(txtGameList);
            Controls.Add(btnBrowseGameList);
            Controls.Add(lblExtension);
            Controls.Add(cmbExtension);
            Controls.Add(btnSelectExtensions);
            Controls.Add(chkRecursive);
            Controls.Add(btnCompare);
            Controls.Add(grpStatistics);
            Controls.Add(lvMissingFromXml);
            Controls.Add(lvMissingFromDisk);
            Controls.Add(lblMissingXmlTitle);
            Controls.Add(lblMissingDiskTitle);
            Controls.Add(lblHint);
            Controls.Add(btnExportTxt);
            Controls.Add(btnExportCsv);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RetroBat GameList Comparator";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            grpStatistics.ResumeLayout(false);
            grpStatistics.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlDropOverlay; 
        private Label lblDropOverlay;
        private Label lblRomFolder;
        private TextBox txtRomFolder;
        private Button btnBrowseRomFolder;
        private Label lblGameList;
        private TextBox txtGameList;
        private Button btnBrowseGameList;
        private Label lblExtension;
        private ComboBox cmbExtension;
        private Button btnSelectExtensions;
        private CheckBox chkRecursive;
        private Button btnCompare;
        private Label lblMissingXmlTitle;
        private Label lblMissingDiskTitle;
        private ListView lvMissingFromXml;
        private ColumnHeader colXmlRom;
        private ColumnHeader colXmlFolder;
        private ListView lvMissingFromDisk;
        private ColumnHeader colDiskRom;
        private ColumnHeader colDiskFolder;
        private Button btnExportTxt;
        private Button btnExportCsv;
        private Label lblHint;
        private MenuStrip menuStrip1;

        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuExit;

        private ToolStripMenuItem mnuHelp;
        private ToolStripMenuItem mnuGitHub;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mnuAbout;
        private Label label1;
        private Label lblMissingDisk;
        private Label lblMissingXml;
        private Label lblMatching;
        private Label lblXmlCount;
        private Label lblDiskCount;
        private ProgressBar progressBar;
        private GroupBox grpStatistics;
    }
}
