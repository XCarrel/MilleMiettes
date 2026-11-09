namespace MilleMiettes
{
    partial class Backoffice
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
            pictureBoxLogo = new PictureBox();
            labelBusinessName = new Label();
            labelBusinessId = new Label();
            groupBoxSpecial = new GroupBox();
            numericUpDownSpecialPrice = new NumericUpDown();
            labelSpecialCurrency = new Label();
            labelSpecialId = new Label();
            labelSpecialName = new Label();
            pictureBoxSpecial = new PictureBox();
            buttonSave = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            groupBoxSpecial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSpecialPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSpecial).BeginInit();
            SuspendLayout();
            //
            // pictureBoxLogo
            //
            pictureBoxLogo.Location = new Point(20, 20);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(300, 150);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            //
            // labelBusinessName
            //
            labelBusinessName.AutoSize = true;
            labelBusinessName.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelBusinessName.Location = new Point(340, 50);
            labelBusinessName.Name = "labelBusinessName";
            labelBusinessName.Size = new Size(0, 37);
            labelBusinessName.TabIndex = 1;
            //
            // labelBusinessId
            //
            labelBusinessId.AutoSize = true;
            labelBusinessId.ForeColor = SystemColors.GrayText;
            labelBusinessId.Location = new Point(344, 100);
            labelBusinessId.Name = "labelBusinessId";
            labelBusinessId.Size = new Size(0, 15);
            labelBusinessId.TabIndex = 2;
            //
            // groupBoxSpecial
            //
            groupBoxSpecial.Controls.Add(labelSpecialCurrency);
            groupBoxSpecial.Controls.Add(numericUpDownSpecialPrice);
            groupBoxSpecial.Controls.Add(labelSpecialId);
            groupBoxSpecial.Controls.Add(labelSpecialName);
            groupBoxSpecial.Controls.Add(pictureBoxSpecial);
            groupBoxSpecial.Location = new Point(20, 190);
            groupBoxSpecial.Name = "groupBoxSpecial";
            groupBoxSpecial.Size = new Size(720, 330);
            groupBoxSpecial.TabIndex = 3;
            groupBoxSpecial.TabStop = false;
            groupBoxSpecial.Text = "Spécial";
            //
            // labelSpecialPrice
            //
            numericUpDownSpecialPrice.DecimalPlaces = 2;
            numericUpDownSpecialPrice.Font = new Font("Segoe UI", 16F);
            numericUpDownSpecialPrice.Increment = new decimal(new int[] { 10, 0, 0, 131072 });
            numericUpDownSpecialPrice.Location = new Point(320, 160);
            numericUpDownSpecialPrice.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownSpecialPrice.Name = "numericUpDownSpecialPrice";
            numericUpDownSpecialPrice.Size = new Size(110, 36);
            numericUpDownSpecialPrice.TabIndex = 3;
            numericUpDownSpecialPrice.TextAlign = HorizontalAlignment.Right;
            //
            // labelSpecialCurrency
            //
            labelSpecialCurrency.AutoSize = true;
            labelSpecialCurrency.Font = new Font("Segoe UI", 16F);
            labelSpecialCurrency.Location = new Point(436, 162);
            labelSpecialCurrency.Name = "labelSpecialCurrency";
            labelSpecialCurrency.Size = new Size(51, 30);
            labelSpecialCurrency.TabIndex = 4;
            labelSpecialCurrency.Text = "CHF";
            //
            // labelSpecialId
            //
            labelSpecialId.AutoSize = true;
            labelSpecialId.ForeColor = SystemColors.GrayText;
            labelSpecialId.Location = new Point(323, 120);
            labelSpecialId.Name = "labelSpecialId";
            labelSpecialId.Size = new Size(0, 15);
            labelSpecialId.TabIndex = 2;
            //
            // labelSpecialName
            //
            labelSpecialName.AutoSize = true;
            labelSpecialName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelSpecialName.Location = new Point(320, 80);
            labelSpecialName.Name = "labelSpecialName";
            labelSpecialName.Size = new Size(0, 30);
            labelSpecialName.TabIndex = 1;
            //
            // pictureBoxSpecial
            //
            pictureBoxSpecial.Location = new Point(20, 30);
            pictureBoxSpecial.Name = "pictureBoxSpecial";
            pictureBoxSpecial.Size = new Size(280, 280);
            pictureBoxSpecial.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxSpecial.TabIndex = 0;
            pictureBoxSpecial.TabStop = false;
            //
            // buttonSave
            //
            buttonSave.Location = new Point(620, 535);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(120, 32);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Enregistrer";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            //
            // Backoffice
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 585);
            Controls.Add(buttonSave);
            Controls.Add(groupBoxSpecial);
            Controls.Add(labelBusinessId);
            Controls.Add(labelBusinessName);
            Controls.Add(pictureBoxLogo);
            Name = "Backoffice";
            Text = "Backoffice";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            groupBoxSpecial.ResumeLayout(false);
            groupBoxSpecial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSpecialPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSpecial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxLogo;
        private Label labelBusinessName;
        private Label labelBusinessId;
        private GroupBox groupBoxSpecial;
        private NumericUpDown numericUpDownSpecialPrice;
        private Label labelSpecialCurrency;
        private Label labelSpecialId;
        private Label labelSpecialName;
        private PictureBox pictureBoxSpecial;
        private Button buttonSave;
    }
}
