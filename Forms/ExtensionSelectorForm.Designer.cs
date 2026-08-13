using RetroBatGameListComparator.Localization;

namespace RetroBatGameListComparator;

partial class ExtensionSelectorForm
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();

        base.Dispose(disposing);
    }

    #region Code généré par le Concepteur Windows Form

    private Label lblSearch;
    private TextBox txtSearch;

    private void InitializeComponent()
    {
        lvExtensions = new ListView();
        colExtension = new ColumnHeader();
        colDefault = new ColumnHeader();
        btnSelectAll = new Button();
        btnClearAll = new Button();
        btnOK = new Button();
        btnCancel = new Button();
        lblSearch = new Label();
        txtSearch = new TextBox();
        lblCount = new Label();
        SuspendLayout();
        //
        // lvExtensions
        //
        lvExtensions.CheckBoxes = true;
        lvExtensions.Columns.AddRange(
    new ColumnHeader[]
    {
        colExtension,
        colDefault
    });
        lvExtensions.FullRowSelect = true;
        lvExtensions.GridLines = true;
        lvExtensions.Location = new Point(12, 75);
        lvExtensions.MultiSelect = false;
        lvExtensions.Name = "lvExtensions";
        lvExtensions.Size = new Size(360, 360);
        lvExtensions.TabIndex = 0;
        lvExtensions.UseCompatibleStateImageBehavior = false;
        lvExtensions.View = View.Details;
        lvExtensions.ItemChecked += lvExtensions_ItemChecked;
        //
        // colExtension
        //
        colExtension.Text = "Extension";
        colExtension.Width = 235;
        //
        // colDefault
        //
        colDefault.Text = L.DefaultColumn;
        //
        // btnSelectAll
        //
        btnSelectAll.Location = new Point(28, 41);
        btnSelectAll.Name = "btnSelectAll";
        btnSelectAll.Size = new Size(100, 26);
        btnSelectAll.TabIndex = 2;
        btnSelectAll.Text = "Tout cocher";
        btnSelectAll.UseVisualStyleBackColor = true;
        btnSelectAll.Click += btnSelectAll_Click;
        //
        // btnClearAll
        //
        btnClearAll.Location = new Point(143, 42);
        btnClearAll.Name = "btnClearAll";
        btnClearAll.Size = new Size(110, 26);
        btnClearAll.TabIndex = 3;
        btnClearAll.Text = "Tout décocher";
        btnClearAll.UseVisualStyleBackColor = true;
        btnClearAll.Click += btnClearAll_Click;
        //
        // btnOK
        //
        btnOK.Location = new Point(216, 425);
        btnOK.Name = "btnOK";
        btnOK.Size = new Size(75, 30);
        btnOK.TabIndex = 1;
        btnOK.Text = "OK";
        btnOK.UseVisualStyleBackColor = true;
        btnOK.Click += btnOK_Click;
        //
        // btnCancel
        //
        btnCancel.Location = new Point(297, 425);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(75, 30);
        btnCancel.TabIndex = 2;
        btnCancel.Text = "Annuler";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        //
        // lblSearch
        //
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(12, 15);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(66, 15);
        lblSearch.TabIndex = 5;
        lblSearch.Text = "Rechercher";
        //
        // txtSearch
        //
        txtSearch.Location = new Point(90, 12);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(282, 23);
        txtSearch.TabIndex = 4;
        txtSearch.TextChanged += txtSearch_TextChanged;
        //
        // lblCount
        //
        lblCount.AutoSize = true;
        lblCount.Location = new Point(12, 445);
        lblCount.Name = "lblCount";
        lblCount.Size = new Size(0, 15);
        lblCount.TabIndex = 5;
        //
        // ExtensionSelectorForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(384, 470);
        Controls.Add(btnCancel);
        Controls.Add(btnOK);
        Controls.Add(btnSelectAll);
        Controls.Add(btnClearAll);
        Controls.Add(txtSearch);
        Controls.Add(lblSearch);
        Controls.Add(lvExtensions);
        Controls.Add(lblCount);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ExtensionSelectorForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Sélection des extensions";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ListView lvExtensions;
    private ColumnHeader colExtension;
    private ColumnHeader colDefault;
    private Button btnOK;
    private Button btnCancel;
    private Button btnSelectAll;
    private Button btnClearAll;
    private Label lblCount;
}
