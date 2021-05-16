
namespace goodsNumCaculate
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.labelColumn = new System.Windows.Forms.Label();
            this.labelRow = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(251, 315);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "清空一号仓库";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelColumn
            // 
            this.labelColumn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelColumn.Location = new System.Drawing.Point(210, 40);
            this.labelColumn.Name = "labelColumn";
            this.labelColumn.Size = new System.Drawing.Size(346, 48);
            this.labelColumn.TabIndex = 1;
            this.labelColumn.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelRow
            // 
            this.labelRow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelRow.Location = new System.Drawing.Point(80, 99);
            this.labelRow.Name = "labelRow";
            this.labelRow.Size = new System.Drawing.Size(105, 159);
            this.labelRow.TabIndex = 2;
            // 
            // labelResult
            // 
            this.labelResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelResult.Location = new System.Drawing.Point(210, 99);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(346, 159);
            this.labelResult.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 381);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.labelRow);
            this.Controls.Add(this.labelColumn);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "商品数量计算";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelResult1;
        private System.Windows.Forms.Label labelColumn;
        private System.Windows.Forms.Label labelRow;
        private System.Windows.Forms.Label labelResult;
    }
}

