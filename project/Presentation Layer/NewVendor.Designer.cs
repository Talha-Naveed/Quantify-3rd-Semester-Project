namespace project.Presentation_Layer
{
    partial class NewVendor
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
            this.lblVendorVendorName = new System.Windows.Forms.Label();
            this.txtVendorVendorName = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.btnVendorDiscard = new MaterialSkin.Controls.MaterialButton();
            this.btnVendorContinue = new MaterialSkin.Controls.MaterialButton();
            this.txtVendorVendorPhone = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.lblVendorVendorPhone = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblVendorVendorName
            // 
            this.lblVendorVendorName.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendorVendorName.Location = new System.Drawing.Point(61, 94);
            this.lblVendorVendorName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVendorVendorName.Name = "lblVendorVendorName";
            this.lblVendorVendorName.Size = new System.Drawing.Size(116, 19);
            this.lblVendorVendorName.TabIndex = 0;
            this.lblVendorVendorName.Text = "Vendor Name";
            // 
            // txtVendorVendorName
            // 
            this.txtVendorVendorName.Location = new System.Drawing.Point(182, 87);
            this.txtVendorVendorName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtVendorVendorName.Name = "txtVendorVendorName";
            this.txtVendorVendorName.Size = new System.Drawing.Size(163, 33);
            this.txtVendorVendorName.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.txtVendorVendorName.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtVendorVendorName.StateCommon.Border.Rounding = 10;
            this.txtVendorVendorName.StateCommon.Content.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendorVendorName.TabIndex = 1;
            this.txtVendorVendorName.Text = "";
            // 
            // btnVendorDiscard
            // 
            this.btnVendorDiscard.AutoSize = false;
            this.btnVendorDiscard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnVendorDiscard.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnVendorDiscard.Depth = 0;
            this.btnVendorDiscard.HighEmphasis = true;
            this.btnVendorDiscard.Icon = null;
            this.btnVendorDiscard.Location = new System.Drawing.Point(182, 264);
            this.btnVendorDiscard.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnVendorDiscard.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnVendorDiscard.Name = "btnVendorDiscard";
            this.btnVendorDiscard.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnVendorDiscard.Size = new System.Drawing.Size(101, 29);
            this.btnVendorDiscard.TabIndex = 2;
            this.btnVendorDiscard.Text = "Discard";
            this.btnVendorDiscard.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnVendorDiscard.UseAccentColor = false;
            this.btnVendorDiscard.UseVisualStyleBackColor = true;
            this.btnVendorDiscard.Click += new System.EventHandler(this.btnVendorDiscard_Click);
            // 
            // btnVendorContinue
            // 
            this.btnVendorContinue.AutoSize = false;
            this.btnVendorContinue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnVendorContinue.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnVendorContinue.Depth = 0;
            this.btnVendorContinue.HighEmphasis = true;
            this.btnVendorContinue.Icon = null;
            this.btnVendorContinue.Location = new System.Drawing.Point(76, 264);
            this.btnVendorContinue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnVendorContinue.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnVendorContinue.Name = "btnVendorContinue";
            this.btnVendorContinue.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnVendorContinue.Size = new System.Drawing.Size(101, 29);
            this.btnVendorContinue.TabIndex = 3;
            this.btnVendorContinue.Text = "Continue";
            this.btnVendorContinue.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnVendorContinue.UseAccentColor = false;
            this.btnVendorContinue.UseVisualStyleBackColor = true;
            this.btnVendorContinue.Click += new System.EventHandler(this.btnVendorContinue_Click);
            // 
            // txtVendorVendorPhone
            // 
            this.txtVendorVendorPhone.Location = new System.Drawing.Point(182, 139);
            this.txtVendorVendorPhone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtVendorVendorPhone.Name = "txtVendorVendorPhone";
            this.txtVendorVendorPhone.Size = new System.Drawing.Size(166, 32);
            this.txtVendorVendorPhone.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.txtVendorVendorPhone.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtVendorVendorPhone.StateCommon.Border.Rounding = 10;
            this.txtVendorVendorPhone.StateCommon.Content.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendorVendorPhone.TabIndex = 5;
            this.txtVendorVendorPhone.Text = "+92-3";
            // 
            // lblVendorVendorPhone
            // 
            this.lblVendorVendorPhone.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendorVendorPhone.Location = new System.Drawing.Point(61, 145);
            this.lblVendorVendorPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVendorVendorPhone.Name = "lblVendorVendorPhone";
            this.lblVendorVendorPhone.Size = new System.Drawing.Size(116, 19);
            this.lblVendorVendorPhone.TabIndex = 4;
            this.lblVendorVendorPhone.Text = "Vendor Phone";
            // 
            // NewVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(396, 366);
            this.Controls.Add(this.txtVendorVendorPhone);
            this.Controls.Add(this.lblVendorVendorPhone);
            this.Controls.Add(this.btnVendorContinue);
            this.Controls.Add(this.btnVendorDiscard);
            this.Controls.Add(this.txtVendorVendorName);
            this.Controls.Add(this.lblVendorVendorName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewVendor";
            this.Padding = new System.Windows.Forms.Padding(2, 52, 2, 2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Vendor";
            this.Load += new System.EventHandler(this.NewVendor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblVendorVendorName;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtVendorVendorName;
        private MaterialSkin.Controls.MaterialButton btnVendorDiscard;
        private MaterialSkin.Controls.MaterialButton btnVendorContinue;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtVendorVendorPhone;
        private System.Windows.Forms.Label lblVendorVendorPhone;
    }
}