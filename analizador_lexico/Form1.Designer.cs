namespace Proyecto1_calc
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.b_correr = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.comen = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // b_correr
            // 
            this.b_correr.Location = new System.Drawing.Point(86, 304);
            this.b_correr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.b_correr.Name = "b_correr";
            this.b_correr.Size = new System.Drawing.Size(100, 28);
            this.b_correr.TabIndex = 0;
            this.b_correr.Text = "Correr";
            this.b_correr.UseVisualStyleBackColor = true;
            this.b_correr.Click += new System.EventHandler(this.b_correr_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Location = new System.Drawing.Point(48, 31);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(739, 265);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // comen
            // 
            this.comen.Location = new System.Drawing.Point(49, 341);
            this.comen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comen.Name = "comen";
            this.comen.Size = new System.Drawing.Size(573, 117);
            this.comen.TabIndex = 2;
            this.comen.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 501);
            this.Controls.Add(this.comen);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.b_correr);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Analizador Léxico ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_correr;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox comen;
    }
}

