namespace View
{
    partial class OfferMailF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfferMailF));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnText = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnTheme = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.nupdScaleText = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdScaleText)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(630, 758);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // btnText
            // 
            this.btnText.BackColor = System.Drawing.Color.DimGray;
            this.btnText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnText.ForeColor = System.Drawing.Color.White;
            this.btnText.Location = new System.Drawing.Point(547, 12);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(75, 42);
            this.btnText.TabIndex = 1;
            this.btnText.Text = "Добавить текст";
            this.btnText.UseVisualStyleBackColor = false;
            this.btnText.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(12, 75);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(610, 226);
            this.textBox1.TabIndex = 2;
            this.textBox1.Visible = false;
            // 
            // btnTheme
            // 
            this.btnTheme.BackColor = System.Drawing.Color.DimGray;
            this.btnTheme.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTheme.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTheme.ForeColor = System.Drawing.Color.White;
            this.btnTheme.Location = new System.Drawing.Point(12, 12);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(75, 42);
            this.btnTheme.TabIndex = 3;
            this.btnTheme.Text = "Сменить тему";
            this.btnTheme.UseVisualStyleBackColor = false;
            this.btnTheme.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(547, 707);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 42);
            this.button3.TabIndex = 4;
            this.button3.Text = "Отправить";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // nupdScaleText
            // 
            this.nupdScaleText.Location = new System.Drawing.Point(575, 307);
            this.nupdScaleText.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nupdScaleText.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nupdScaleText.Name = "nupdScaleText";
            this.nupdScaleText.Size = new System.Drawing.Size(47, 20);
            this.nupdScaleText.TabIndex = 5;
            this.nupdScaleText.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nupdScaleText.Visible = false;
            // 
            // OfferMailF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 761);
            this.Controls.Add(this.nupdScaleText);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnTheme);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnText);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "OfferMailF";
            this.Text = "OfferMailF";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdScaleText)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnTheme;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown nupdScaleText;
    }
}