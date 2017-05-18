namespace View
{
    partial class FMain
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
            this.btnTracks = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDrivers = new System.Windows.Forms.Button();
            this.btnMail = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRedact = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbValues = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTracks
            // 
            this.btnTracks.BackColor = System.Drawing.Color.Transparent;
            this.btnTracks.FlatAppearance.BorderSize = 0;
            this.btnTracks.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnTracks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTracks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTracks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTracks.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTracks.ForeColor = System.Drawing.Color.White;
            this.btnTracks.Location = new System.Drawing.Point(12, 95);
            this.btnTracks.Name = "btnTracks";
            this.btnTracks.Size = new System.Drawing.Size(188, 42);
            this.btnTracks.TabIndex = 13;
            this.btnTracks.Text = "Грузовики";
            this.btnTracks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTracks.UseVisualStyleBackColor = false;
            this.btnTracks.Click += new System.EventHandler(this.button5_Click);
            this.btnTracks.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            this.btnTracks.MouseLeave += new System.EventHandler(this.button5_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnOrders);
            this.panel1.Controls.Add(this.btnClients);
            this.panel1.Controls.Add(this.btnMail);
            this.panel1.Controls.Add(this.btnDrivers);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnTracks);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 400);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 40);
            this.panel2.TabIndex = 20;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 40);
            this.panel3.TabIndex = 21;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // btnDrivers
            // 
            this.btnDrivers.BackColor = System.Drawing.Color.Transparent;
            this.btnDrivers.FlatAppearance.BorderSize = 0;
            this.btnDrivers.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnDrivers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDrivers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDrivers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrivers.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDrivers.ForeColor = System.Drawing.Color.White;
            this.btnDrivers.Location = new System.Drawing.Point(12, 143);
            this.btnDrivers.Name = "btnDrivers";
            this.btnDrivers.Size = new System.Drawing.Size(188, 42);
            this.btnDrivers.TabIndex = 22;
            this.btnDrivers.Text = "Водители";
            this.btnDrivers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDrivers.UseVisualStyleBackColor = false;
            this.btnDrivers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button7_MouseClick);
            this.btnDrivers.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            this.btnDrivers.MouseLeave += new System.EventHandler(this.button5_MouseLeave);
            // 
            // btnMail
            // 
            this.btnMail.BackColor = System.Drawing.Color.Transparent;
            this.btnMail.FlatAppearance.BorderSize = 0;
            this.btnMail.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnMail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMail.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMail.ForeColor = System.Drawing.Color.White;
            this.btnMail.Location = new System.Drawing.Point(12, 191);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(188, 42);
            this.btnMail.TabIndex = 23;
            this.btnMail.Text = "Рассылка";
            this.btnMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMail.UseVisualStyleBackColor = false;
            this.btnMail.Click += new System.EventHandler(this.button8_Click);
            this.btnMail.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            this.btnMail.MouseLeave += new System.EventHandler(this.button5_MouseLeave);
            // 
            // btnClients
            // 
            this.btnClients.BackColor = System.Drawing.Color.Transparent;
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnClients.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClients.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClients.ForeColor = System.Drawing.Color.White;
            this.btnClients.Location = new System.Drawing.Point(12, 239);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(188, 42);
            this.btnClients.TabIndex = 24;
            this.btnClients.Text = "Клиенты";
            this.btnClients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClients.UseVisualStyleBackColor = false;
            this.btnClients.Click += new System.EventHandler(this.button9_Click);
            this.btnClients.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            this.btnClients.MouseLeave += new System.EventHandler(this.button5_MouseLeave);
            // 
            // btnOrders
            // 
            this.btnOrders.BackColor = System.Drawing.Color.Transparent;
            this.btnOrders.FlatAppearance.BorderSize = 0;
            this.btnOrders.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnOrders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOrders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOrders.ForeColor = System.Drawing.Color.White;
            this.btnOrders.Location = new System.Drawing.Point(12, 287);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(188, 42);
            this.btnOrders.TabIndex = 25;
            this.btnOrders.Text = "Заказы";
            this.btnOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrders.UseVisualStyleBackColor = false;
            this.btnOrders.Click += new System.EventHandler(this.button10_Click);
            this.btnOrders.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            this.btnOrders.MouseLeave += new System.EventHandler(this.button5_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(474, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(454, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "_";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            this.label2.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Sitka Small", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-2, -2);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 44);
            this.label3.TabIndex = 21;
            this.label3.Text = "THE GARAZH";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRedact
            // 
            this.btnRedact.BackColor = System.Drawing.Color.White;
            this.btnRedact.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRedact.FlatAppearance.BorderSize = 2;
            this.btnRedact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRedact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRedact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRedact.Location = new System.Drawing.Point(265, 345);
            this.btnRedact.Name = "btnRedact";
            this.btnRedact.Size = new System.Drawing.Size(113, 43);
            this.btnRedact.TabIndex = 22;
            this.btnRedact.Text = "Редактировать";
            this.btnRedact.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(396, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 43);
            this.button1.TabIndex = 23;
            this.button1.Text = "Удалить";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(527, 345);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 43);
            this.button2.TabIndex = 24;
            this.button2.Text = "Фильтр";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // lbValues
            // 
            this.lbValues.FormattingEnabled = true;
            this.lbValues.Location = new System.Drawing.Point(231, 80);
            this.lbValues.Name = "lbValues";
            this.lbValues.Size = new System.Drawing.Size(436, 251);
            this.lbValues.TabIndex = 25;
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.lbValues);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRedact);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FMain";
            this.Load += new System.EventHandler(this.FMain_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTracks;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnMail;
        private System.Windows.Forms.Button btnDrivers;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRedact;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox lbValues;
    }
}