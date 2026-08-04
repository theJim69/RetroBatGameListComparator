namespace RetroBatGameListComparator;

partial class AboutForm
{
    private System.ComponentModel.IContainer? components = null;

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
        lblVersion = new Label();
        lblDescription = new Label();
        grpFeatures = new GroupBox();
        lblFeatures = new Label();
        lblAuthor = new Label();
        linkGithub = new LinkLabel();
        lblFooter = new Label();
        btnClose = new Button();

        grpFeatures.SuspendLayout();
        SuspendLayout();

        //
        // lblTitle
        //
        lblTitle.Font = new Font(
            "Segoe UI",
            16F,
            FontStyle.Bold);

        lblTitle.Location = new Point(20, 18);
        lblTitle.Size = new Size(500, 36);
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        lblTitle.Text = "🎮 RetroBat GameList Comparator";

        //
        // lblVersion
        //
        lblVersion.Font = new Font(
            "Segoe UI",
            10F,
            FontStyle.Italic);

        lblVersion.Location = new Point(20, 55);
        lblVersion.Size = new Size(500, 22);
        lblVersion.TextAlign = ContentAlignment.MiddleCenter;
        lblVersion.Text = "Version 1.0.0";

        //
        // lblDescription
        //
        lblDescription.Location = new Point(25, 85);
        lblDescription.Size = new Size(490, 48);
        lblDescription.TextAlign = ContentAlignment.MiddleCenter;

        lblDescription.Text =
            "Compare les ROMs présentes sur le disque avec les entrées\r\n" +
            "du fichier gamelist.xml, détecte les différences et facilite\r\n" +
            "la maintenance des collections RetroBat.";

        //
        // grpFeatures
        //

        grpFeatures.Controls.Add(lblFeatures);

        grpFeatures.Location = new Point(20, 145);
        grpFeatures.Name = "grpFeatures";
        grpFeatures.Size = new Size(500, 220);
        grpFeatures.TabIndex = 0;
        grpFeatures.TabStop = false;
        grpFeatures.Text = "Fonctionnalités";

        //
        // lblFeatures
        //

        lblFeatures.AutoSize = false;
        lblFeatures.Location = new Point(15, 25);
        lblFeatures.Size = new Size(470, 180);
        lblFeatures.TextAlign = ContentAlignment.TopLeft;
        lblFeatures.Text =
@"✔ Comparaison ROMs ↔ GameList.xml
✔ Détection des ROMs absentes du XML
✔ Détection des ROMs absentes du disque
✔ Gestion de plusieurs extensions (.zip, .7z, .chd...)
✔ Recherche dans les sous-dossiers
✔ Analyse récursive des sous-dossiers
✔ Recherche instantanée des extensions
✔ Sélection multiple des extensions
✔ Détection automatique des nouvelles extensions
✔ Ouverture directe d'une ROM dans l'Explorateur Windows
✔ Export des résultats au format TXT
✔ Export des résultats au format CSV";
        //
        // lblAuthor
        //
        lblAuthor.Location = new Point(20, 375);
        lblAuthor.Size = new Size(500, 40);
        lblAuthor.TextAlign = ContentAlignment.MiddleCenter;

        lblAuthor.Text =
            "Développé par\r\ntheJim";

        //
        // linkGithub
        //
        linkGithub.Location = new Point(20, 420);
        linkGithub.Size = new Size(500, 22);
        linkGithub.TextAlign = ContentAlignment.MiddleCenter;

        linkGithub.Text = "🌐 https://github.com/theJim69/RetroBatGameListComparator";

        //
        // lblFooter
        //
        lblFooter.Location = new Point(20, 450);
        lblFooter.Size = new Size(500, 45);

        lblFooter.ForeColor = SystemColors.GrayText;

        lblFooter.TextAlign = ContentAlignment.MiddleCenter;

        lblFooter.Text =
            "Version : 1.0.0      Framework : .NET 8\r\n" +
            "© 2026 theJim • Windows Forms • C#";

        //
        // btnClose
        //
        btnClose.Location = new Point(220, 505);
        btnClose.Size = new Size(100, 32);

        btnClose.Text = "Fermer";
        btnClose.UseVisualStyleBackColor = true;
        btnClose.Click += btnClose_Click;

        //
        // AboutForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;

        ClientSize = new Size(540, 555);

        Controls.Add(btnClose);
        Controls.Add(lblFooter);
        Controls.Add(linkGithub);
        Controls.Add(lblAuthor);
        Controls.Add(grpFeatures);
        Controls.Add(lblDescription);
        Controls.Add(lblVersion);
        Controls.Add(lblTitle);

        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowIcon = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "À propos";

        grpFeatures.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Label lblTitle;
    private Label lblVersion;
    private Label lblDescription;
    private GroupBox grpFeatures;
    private Label lblFeatures;
    private Label lblAuthor;
    private LinkLabel linkGithub;
    private Label lblFooter;
    private Button btnClose;
}