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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.btnTracks = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnMail = new System.Windows.Forms.Button();
            this.btnDrivers = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRedact = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dgwValues = new System.Windows.Forms.DataGridView();
            this.btnDriverInfo = new System.Windows.Forms.Button();
            this.btnProfitDriver = new System.Windows.Forms.Button();
            this.panRateClients = new System.Windows.Forms.Panel();
            this.btnrating = new System.Windows.Forms.Button();
            this.bgwrate = new System.ComponentModel.BackgroundWorker();
            this.bgwclient = new System.ComponentModel.BackgroundWorker();
            this.bgwdrivers = new System.ComponentModel.BackgroundWorker();
            this.bgworders = new System.ComponentModel.BackgroundWorker();
            this.bgwtracks = new System.ComponentModel.BackgroundWorker();
            this.bgwdriverpayment = new System.ComponentModel.BackgroundWorker();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnprintsalary = new System.Windows.Forms.Button();
            this.btnGraph = new System.Windows.Forms.Button();
            this.btnSetReady = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwValues)).BeginInit();
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
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click_1);
            this.btnOrders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button7_MouseClick);
            this.btnOrders.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            this.btnOrders.MouseLeave += new System.EventHandler(this.button5_MouseLeave);
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
            // btnMail
            // 
            this.btnMail.BackColor = System.Drawing.Color.Transparent;
            this.btnMail.Enabled = false;
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
            this.btnDrivers.Click += new System.EventHandler(this.button10_Click);
            this.btnDrivers.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            this.btnDrivers.MouseLeave += new System.EventHandler(this.button5_MouseLeave);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(199, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(694, 40);
            this.panel2.TabIndex = 20;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(646, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "_";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            this.label2.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(666, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // btnRedact
            // 
            this.btnRedact.BackColor = System.Drawing.Color.White;
            this.btnRedact.Enabled = false;
            this.btnRedact.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRedact.FlatAppearance.BorderSize = 2;
            this.btnRedact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRedact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRedact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRedact.Location = new System.Drawing.Point(426, 345);
            this.btnRedact.Name = "btnRedact";
            this.btnRedact.Size = new System.Drawing.Size(113, 43);
            this.btnRedact.TabIndex = 22;
            this.btnRedact.Text = "Редактировать";
            this.btnRedact.UseVisualStyleBackColor = false;
            this.btnRedact.Click += new System.EventHandler(this.btnRedact_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete.Location = new System.Drawing.Point(557, 345);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 43);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.White;
            this.btnFilter.Enabled = false;
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnFilter.FlatAppearance.BorderSize = 2;
            this.btnFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFilter.Location = new System.Drawing.Point(688, 345);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(113, 43);
            this.btnFilter.TabIndex = 24;
            this.btnFilter.Text = "Фильтр";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // dgwValues
            // 
            this.dgwValues.AllowUserToAddRows = false;
            this.dgwValues.AllowUserToDeleteRows = false;
            this.dgwValues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgwValues.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgwValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwValues.Location = new System.Drawing.Point(226, 83);
            this.dgwValues.Name = "dgwValues";
            this.dgwValues.ReadOnly = true;
            this.dgwValues.Size = new System.Drawing.Size(642, 246);
            this.dgwValues.TabIndex = 26;
            this.dgwValues.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwValues_CellContentClick);
            this.dgwValues.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgwValues_MouseClick);
            // 
            // btnDriverInfo
            // 
            this.btnDriverInfo.BackColor = System.Drawing.Color.White;
            this.btnDriverInfo.Enabled = false;
            this.btnDriverInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDriverInfo.Location = new System.Drawing.Point(346, 54);
            this.btnDriverInfo.Name = "btnDriverInfo";
            this.btnDriverInfo.Size = new System.Drawing.Size(130, 23);
            this.btnDriverInfo.TabIndex = 27;
            this.btnDriverInfo.Text = "Данные водителя";
            this.btnDriverInfo.UseVisualStyleBackColor = false;
            this.btnDriverInfo.Visible = false;
            this.btnDriverInfo.Click += new System.EventHandler(this.button10_Click);
            // 
            // btnProfitDriver
            // 
            this.btnProfitDriver.BackColor = System.Drawing.Color.White;
            this.btnProfitDriver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfitDriver.Location = new System.Drawing.Point(613, 55);
            this.btnProfitDriver.Name = "btnProfitDriver";
            this.btnProfitDriver.Size = new System.Drawing.Size(154, 23);
            this.btnProfitDriver.TabIndex = 28;
            this.btnProfitDriver.Text = "Информация о выплатах";
            this.btnProfitDriver.UseVisualStyleBackColor = false;
            this.btnProfitDriver.Visible = false;
            this.btnProfitDriver.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // panRateClients
            // 
            this.panRateClients.AutoScroll = true;
            this.panRateClients.BackColor = System.Drawing.Color.White;
            this.panRateClients.Location = new System.Drawing.Point(206, 83);
            this.panRateClients.Name = "panRateClients";
            this.panRateClients.Size = new System.Drawing.Size(674, 256);
            this.panRateClients.TabIndex = 29;
            this.panRateClients.Visible = false;
            // 
            // btnrating
            // 
            this.btnrating.BackColor = System.Drawing.Color.White;
            this.btnrating.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrating.Location = new System.Drawing.Point(494, 54);
            this.btnrating.Name = "btnrating";
            this.btnrating.Size = new System.Drawing.Size(113, 23);
            this.btnrating.TabIndex = 30;
            this.btnrating.Text = "Рейтинг";
            this.btnrating.UseVisualStyleBackColor = false;
            this.btnrating.Visible = false;
            this.btnrating.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // bgwrate
            // 
            this.bgwrate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwrate_DoWork);
            this.bgwrate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwrate_RunWorkerCompleted);
            // 
            // bgwclient
            // 
            this.bgwclient.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwclient_DoWork);
            // 
            // bgwdrivers
            // 
            this.bgwdrivers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwdrivers_DoWork);
            // 
            // bgworders
            // 
            this.bgworders.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworders_DoWork);
            // 
            // bgwtracks
            // 
            this.bgwtracks.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwtracks_DoWork);
            // 
            // bgwdriverpayment
            // 
            this.bgwdriverpayment.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwdriverpayment_DoWork);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.White;
            this.btnInsert.Enabled = false;
            this.btnInsert.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnInsert.FlatAppearance.BorderSize = 2;
            this.btnInsert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnInsert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnInsert.Location = new System.Drawing.Point(295, 345);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(113, 43);
            this.btnInsert.TabIndex = 35;
            this.btnInsert.Text = "Добавить";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // btnprintsalary
            // 
            this.btnprintsalary.BackColor = System.Drawing.Color.Transparent;
            this.btnprintsalary.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnprintsalary.BackgroundImage")));
            this.btnprintsalary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnprintsalary.FlatAppearance.BorderSize = 0;
            this.btnprintsalary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprintsalary.Location = new System.Drawing.Point(785, 54);
            this.btnprintsalary.Name = "btnprintsalary";
            this.btnprintsalary.Size = new System.Drawing.Size(24, 24);
            this.btnprintsalary.TabIndex = 36;
            this.btnprintsalary.UseVisualStyleBackColor = false;
            this.btnprintsalary.Visible = false;
            this.btnprintsalary.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // btnGraph
            // 
            this.btnGraph.BackColor = System.Drawing.Color.White;
            this.btnGraph.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGraph.BackgroundImage")));
            this.btnGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGraph.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnGraph.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleGreen;
            this.btnGraph.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Honeydew;
            this.btnGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGraph.Location = new System.Drawing.Point(835, 49);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(30, 30);
            this.btnGraph.TabIndex = 37;
            this.btnGraph.UseVisualStyleBackColor = false;
            this.btnGraph.Visible = false;
            this.btnGraph.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // btnSetReady
            // 
            this.btnSetReady.BackColor = System.Drawing.Color.White;
            this.btnSetReady.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetReady.BackgroundImage")));
            this.btnSetReady.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetReady.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnSetReady.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleGreen;
            this.btnSetReady.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Honeydew;
            this.btnSetReady.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetReady.Location = new System.Drawing.Point(799, 49);
            this.btnSetReady.Name = "btnSetReady";
            this.btnSetReady.Size = new System.Drawing.Size(30, 30);
            this.btnSetReady.TabIndex = 38;
            this.btnSetReady.UseVisualStyleBackColor = false;
            this.btnSetReady.Visible = false;
            this.btnSetReady.Click += new System.EventHandler(this.button1_Click_4);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(892, 400);
            this.Controls.Add(this.btnSetReady);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.btnprintsalary);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnrating);
            this.Controls.Add(this.panRateClients);
            this.Controls.Add(this.btnProfitDriver);
            this.Controls.Add(this.btnDriverInfo);
            this.Controls.Add(this.dgwValues);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRedact);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FMain";
            this.Load += new System.EventHandler(this.FMain_Load_1);
            this.Click += new System.EventHandler(this.FMain_Click);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwValues)).EndInit();
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
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView dgwValues;
        private System.Windows.Forms.Button btnDriverInfo;
        private System.Windows.Forms.Button btnProfitDriver;
        private System.Windows.Forms.Panel panRateClients;
        private System.Windows.Forms.Button btnrating;
        private System.ComponentModel.BackgroundWorker bgwrate;
        private System.ComponentModel.BackgroundWorker bgwclient;
        private System.ComponentModel.BackgroundWorker bgwdrivers;
        private System.ComponentModel.BackgroundWorker bgworders;
        private System.ComponentModel.BackgroundWorker bgwtracks;
        private System.ComponentModel.BackgroundWorker bgwdriverpayment;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnprintsalary;
        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.Button btnSetReady;
    }
}