namespace MilleMiettes
{
    partial class OpeningHoursForm
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
            tableLayoutPanelDays = new TableLayoutPanel();
            labelSlot1 = new Label();
            labelOpen1 = new Label();
            labelClose1 = new Label();
            labelSlot2 = new Label();
            labelOpen2 = new Label();
            labelClose2 = new Label();
            buttonOk = new Button();
            buttonCancel = new Button();
            tableLayoutPanelDays.SuspendLayout();
            SuspendLayout();
            //
            // tableLayoutPanelDays
            //
            tableLayoutPanelDays.AutoSize = true;
            tableLayoutPanelDays.ColumnCount = 7;
            tableLayoutPanelDays.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tableLayoutPanelDays.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            tableLayoutPanelDays.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanelDays.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanelDays.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            tableLayoutPanelDays.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanelDays.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanelDays.Controls.Add(labelSlot1, 1, 0);
            tableLayoutPanelDays.Controls.Add(labelOpen1, 2, 0);
            tableLayoutPanelDays.Controls.Add(labelClose1, 3, 0);
            tableLayoutPanelDays.Controls.Add(labelSlot2, 4, 0);
            tableLayoutPanelDays.Controls.Add(labelOpen2, 5, 0);
            tableLayoutPanelDays.Controls.Add(labelClose2, 6, 0);
            tableLayoutPanelDays.Location = new Point(20, 20);
            tableLayoutPanelDays.Name = "tableLayoutPanelDays";
            tableLayoutPanelDays.RowCount = 8;
            tableLayoutPanelDays.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanelDays.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanelDays.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanelDays.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanelDays.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanelDays.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanelDays.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanelDays.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanelDays.Size = new Size(580, 256);
            tableLayoutPanelDays.TabIndex = 0;
            //
            // labelSlot1
            //
            labelSlot1.Anchor = AnchorStyles.Left;
            labelSlot1.AutoSize = true;
            labelSlot1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelSlot1.Name = "labelSlot1";
            labelSlot1.Text = "Matin";
            //
            // labelOpen1
            //
            labelOpen1.Anchor = AnchorStyles.Left;
            labelOpen1.AutoSize = true;
            labelOpen1.Name = "labelOpen1";
            labelOpen1.Text = "Ouverture";
            //
            // labelClose1
            //
            labelClose1.Anchor = AnchorStyles.Left;
            labelClose1.AutoSize = true;
            labelClose1.Name = "labelClose1";
            labelClose1.Text = "Fermeture";
            //
            // labelSlot2
            //
            labelSlot2.Anchor = AnchorStyles.Left;
            labelSlot2.AutoSize = true;
            labelSlot2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelSlot2.Name = "labelSlot2";
            labelSlot2.Text = "Après-midi";
            //
            // labelOpen2
            //
            labelOpen2.Anchor = AnchorStyles.Left;
            labelOpen2.AutoSize = true;
            labelOpen2.Name = "labelOpen2";
            labelOpen2.Text = "Ouverture";
            //
            // labelClose2
            //
            labelClose2.Anchor = AnchorStyles.Left;
            labelClose2.AutoSize = true;
            labelClose2.Name = "labelClose2";
            labelClose2.Text = "Fermeture";
            //
            // buttonOk
            //
            buttonOk.DialogResult = DialogResult.OK;
            buttonOk.Location = new Point(400, 295);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(90, 32);
            buttonOk.TabIndex = 1;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            //
            // buttonCancel
            //
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(500, 295);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(90, 32);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Annuler";
            buttonCancel.UseVisualStyleBackColor = true;
            //
            // OpeningHoursForm
            //
            AcceptButton = buttonOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(610, 345);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(tableLayoutPanelDays);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OpeningHoursForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Horaires d'ouverture";
            tableLayoutPanelDays.ResumeLayout(false);
            tableLayoutPanelDays.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelDays;
        private Label labelSlot1;
        private Label labelOpen1;
        private Label labelClose1;
        private Label labelSlot2;
        private Label labelOpen2;
        private Label labelClose2;
        private Button buttonOk;
        private Button buttonCancel;
    }
}
