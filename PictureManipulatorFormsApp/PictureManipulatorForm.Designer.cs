﻿namespace PictureManipulatorFormsApp
{
    partial class PictureManipulatorForm
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
            this.pbSourcePicture = new System.Windows.Forms.PictureBox();
            this.pbConvertedPicture = new System.Windows.Forms.PictureBox();
            this.btnImportPicture = new System.Windows.Forms.Button();
            this.rbGrayscale = new System.Windows.Forms.RadioButton();
            this.rbNegative = new System.Windows.Forms.RadioButton();
            this.rbBlurr = new System.Windows.Forms.RadioButton();
            this.btnConvert = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbSourcePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConvertedPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSourcePicture
            // 
            this.pbSourcePicture.Location = new System.Drawing.Point(12, 91);
            this.pbSourcePicture.Name = "pbSourcePicture";
            this.pbSourcePicture.Size = new System.Drawing.Size(300, 300);
            this.pbSourcePicture.TabIndex = 0;
            this.pbSourcePicture.TabStop = false;
            // 
            // pbConvertedPicture
            // 
            this.pbConvertedPicture.Location = new System.Drawing.Point(488, 91);
            this.pbConvertedPicture.Name = "pbConvertedPicture";
            this.pbConvertedPicture.Size = new System.Drawing.Size(300, 300);
            this.pbConvertedPicture.TabIndex = 1;
            this.pbConvertedPicture.TabStop = false;
            // 
            // btnImportPicture
            // 
            this.btnImportPicture.Location = new System.Drawing.Point(110, 397);
            this.btnImportPicture.Name = "btnImportPicture";
            this.btnImportPicture.Size = new System.Drawing.Size(75, 23);
            this.btnImportPicture.TabIndex = 2;
            this.btnImportPicture.Text = "Import";
            this.btnImportPicture.UseVisualStyleBackColor = true;
            this.btnImportPicture.Click += new System.EventHandler(this.BtnImportPicture_Click);
            // 
            // rbGrayscale
            // 
            this.rbGrayscale.AutoSize = true;
            this.rbGrayscale.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.rbGrayscale.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbGrayscale.Location = new System.Drawing.Point(319, 116);
            this.rbGrayscale.Name = "rbGrayscale";
            this.rbGrayscale.Size = new System.Drawing.Size(93, 21);
            this.rbGrayscale.TabIndex = 3;
            this.rbGrayscale.TabStop = true;
            this.rbGrayscale.Text = "Grayscale";
            this.rbGrayscale.UseVisualStyleBackColor = true;
            // 
            // rbNegative
            // 
            this.rbNegative.AutoSize = true;
            this.rbNegative.Location = new System.Drawing.Point(319, 143);
            this.rbNegative.Name = "rbNegative";
            this.rbNegative.Size = new System.Drawing.Size(85, 21);
            this.rbNegative.TabIndex = 4;
            this.rbNegative.TabStop = true;
            this.rbNegative.Text = "Negative";
            this.rbNegative.UseVisualStyleBackColor = true;
            // 
            // rbBlurr
            // 
            this.rbBlurr.AutoSize = true;
            this.rbBlurr.Location = new System.Drawing.Point(319, 170);
            this.rbBlurr.Name = "rbBlurr";
            this.rbBlurr.Size = new System.Drawing.Size(59, 21);
            this.rbBlurr.TabIndex = 5;
            this.rbBlurr.TabStop = true;
            this.rbBlurr.Text = "Blurr";
            this.rbBlurr.UseVisualStyleBackColor = true;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(319, 198);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 6;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.BtnConvert_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(613, 397);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // PictureManipulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.rbBlurr);
            this.Controls.Add(this.rbNegative);
            this.Controls.Add(this.rbGrayscale);
            this.Controls.Add(this.btnImportPicture);
            this.Controls.Add(this.pbConvertedPicture);
            this.Controls.Add(this.pbSourcePicture);
            this.Name = "PictureManipulatorForm";
            this.Text = "PictureManipulator";
            ((System.ComponentModel.ISupportInitialize)(this.pbSourcePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConvertedPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSourcePicture;
        private System.Windows.Forms.PictureBox pbConvertedPicture;
        private System.Windows.Forms.Button btnImportPicture;
        private System.Windows.Forms.RadioButton rbGrayscale;
        private System.Windows.Forms.RadioButton rbNegative;
        private System.Windows.Forms.RadioButton rbBlurr;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnSave;
    }
}

