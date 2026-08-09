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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
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
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.Location = new Point(20, 18);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(500, 36);
        lblTitle.TabIndex = 6;
        lblTitle.Text = "🎮 RetroBat GameList Comparator";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblVersion
        // 
        lblVersion.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
        lblVersion.Location = new Point(20, 55);
        lblVersion.Name = "lblVersion";
        lblVersion.Size = new Size(500, 22);
        lblVersion.TabIndex = 5;
        lblVersion.Text = "Version 1.0.0";
        lblVersion.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblDescription
        // 
        lblDescription.Location = new Point(25, 85);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new Size(490, 48);
        lblDescription.TabIndex = 4;
        lblDescription.Text = "Compare les ROMs présentes sur le disque avec les entrées\r\ndu fichier gamelist.xml, détecte les différences et facilite\r\nla maintenance des collections RetroBat.";
        lblDescription.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // grpFeatures
        // 
        grpFeatures.Controls.Add(lblFeatures);
        grpFeatures.Location = new Point(20, 145);
        grpFeatures.Name = "grpFeatures";
        grpFeatures.Size = new Size(500, 244);
        grpFeatures.TabIndex = 0;
        grpFeatures.TabStop = false;
        grpFeatures.Text = "Fonctionnalités";
        // 
        // lblFeatures
        // 
        lblFeatures.Location = new Point(15, 25);
        lblFeatures.Name = "lblFeatures";
        lblFeatures.Size = new Size(470, 216);
        lblFeatures.TabIndex = 0;
        lblFeatures.Text = resources.GetString("lblFeatures.Text");
        // 
        // lblAuthor
        // 
        lblAuthor.Location = new Point(20, 392);
        lblAuthor.Name = "lblAuthor";
        lblAuthor.Size = new Size(500, 40);
        lblAuthor.TabIndex = 3;
        lblAuthor.Text = "Développé par\r\ntheJim";
        lblAuthor.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // linkGithub
        // 
        linkGithub.Location = new Point(20, 428);
        linkGithub.Name = "linkGithub";
        linkGithub.Size = new Size(500, 22);
        linkGithub.TabIndex = 2;
        linkGithub.TabStop = true;
        linkGithub.Text = "🌐 github.com/theJim69/RetroBatGameListComparator";
        linkGithub.TextAlign = ContentAlignment.MiddleCenter;
        linkGithub.LinkClicked += linkGithub_LinkClicked_1;
        // 
        // lblFooter
        // 
        lblFooter.ForeColor = SystemColors.GrayText;
        lblFooter.Location = new Point(20, 457);
        lblFooter.Name = "lblFooter";
        lblFooter.Size = new Size(500, 45);
        lblFooter.TabIndex = 1;
        lblFooter.Text = "Version : 1.0.0      Framework : .NET 8\r\n© 2026 theJim • Windows Forms • C#";
        lblFooter.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btnClose
        // 
        btnClose.Location = new Point(220, 505);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(100, 32);
        btnClose.TabIndex = 0;
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
        Name = "AboutForm";
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