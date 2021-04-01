namespace NSBM_Food_Corner
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblFoodPriceInv = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFoodPrice = new System.Windows.Forms.Label();
            this.lblFoodID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFoodCal = new System.Windows.Forms.Label();
            this.lblFoodIng = new System.Windows.Forms.Label();
            this.numFoodqty = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFoodname = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.chromeButton6 = new ChromeButton();
            this.chromeButton5 = new ChromeButton();
            this.chromeButton1 = new ChromeButton();
            this.chromeButton4 = new ChromeButton();
            this.chromeButton3 = new ChromeButton();
            this.chromeButton2 = new ChromeButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFoodqty)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(15, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 52);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(183, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 52);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.Location = new System.Drawing.Point(15, 159);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(498, 435);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview1_cell_click);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 608);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Foods";
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(351, 90);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(162, 52);
            this.button4.TabIndex = 9;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(15, 90);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(162, 52);
            this.button5.TabIndex = 7;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(183, 90);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(162, 52);
            this.button6.TabIndex = 8;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(351, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 52);
            this.button3.TabIndex = 6;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblFoodPriceInv);
            this.groupBox2.Controls.Add(this.chromeButton2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblFoodPrice);
            this.groupBox2.Controls.Add(this.lblFoodID);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblFoodCal);
            this.groupBox2.Controls.Add(this.lblFoodIng);
            this.groupBox2.Controls.Add(this.numFoodqty);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblFoodname);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(548, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(725, 205);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add to List";
            // 
            // lblFoodPriceInv
            // 
            this.lblFoodPriceInv.AutoSize = true;
            this.lblFoodPriceInv.Location = new System.Drawing.Point(369, 162);
            this.lblFoodPriceInv.Name = "lblFoodPriceInv";
            this.lblFoodPriceInv.Size = new System.Drawing.Size(45, 16);
            this.lblFoodPriceInv.TabIndex = 20;
            this.lblFoodPriceInv.Text = "label2";
            this.lblFoodPriceInv.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(34, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Calories :";
            // 
            // lblFoodPrice
            // 
            this.lblFoodPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoodPrice.ForeColor = System.Drawing.Color.Red;
            this.lblFoodPrice.Location = new System.Drawing.Point(513, 36);
            this.lblFoodPrice.Name = "lblFoodPrice";
            this.lblFoodPrice.Size = new System.Drawing.Size(173, 58);
            this.lblFoodPrice.TabIndex = 19;
            this.lblFoodPrice.Text = "SubT";
            this.lblFoodPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFoodID
            // 
            this.lblFoodID.AutoSize = true;
            this.lblFoodID.Location = new System.Drawing.Point(295, 162);
            this.lblFoodID.Name = "lblFoodID";
            this.lblFoodID.Size = new System.Drawing.Size(45, 16);
            this.lblFoodID.TabIndex = 18;
            this.lblFoodID.Text = "label2";
            this.lblFoodID.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(34, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ingredients :";
            // 
            // lblFoodCal
            // 
            this.lblFoodCal.AutoSize = true;
            this.lblFoodCal.ForeColor = System.Drawing.Color.Gray;
            this.lblFoodCal.Location = new System.Drawing.Point(127, 120);
            this.lblFoodCal.Name = "lblFoodCal";
            this.lblFoodCal.Size = new System.Drawing.Size(45, 16);
            this.lblFoodCal.TabIndex = 17;
            this.lblFoodCal.Text = "label2";
            // 
            // lblFoodIng
            // 
            this.lblFoodIng.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoodIng.ForeColor = System.Drawing.Color.Gray;
            this.lblFoodIng.Location = new System.Drawing.Point(127, 78);
            this.lblFoodIng.Name = "lblFoodIng";
            this.lblFoodIng.Size = new System.Drawing.Size(380, 35);
            this.lblFoodIng.TabIndex = 16;
            this.lblFoodIng.Text = "label2";
            // 
            // numFoodqty
            // 
            this.numFoodqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numFoodqty.Location = new System.Drawing.Point(130, 154);
            this.numFoodqty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFoodqty.Name = "numFoodqty";
            this.numFoodqty.Size = new System.Drawing.Size(92, 26);
            this.numFoodqty.TabIndex = 15;
            this.numFoodqty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFoodqty.ValueChanged += new System.EventHandler(this.numFoodqty_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(34, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Quantity :";
            // 
            // lblFoodname
            // 
            this.lblFoodname.AutoSize = true;
            this.lblFoodname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoodname.ForeColor = System.Drawing.Color.Black;
            this.lblFoodname.Location = new System.Drawing.Point(33, 36);
            this.lblFoodname.Name = "lblFoodname";
            this.lblFoodname.Size = new System.Drawing.Size(151, 24);
            this.lblFoodname.TabIndex = 13;
            this.lblFoodname.Text = "Select a food first";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chromeButton6);
            this.groupBox3.Controls.Add(this.chromeButton5);
            this.groupBox3.Controls.Add(this.chromeButton1);
            this.groupBox3.Controls.Add(this.chromeButton4);
            this.groupBox3.Controls.Add(this.chromeButton3);
            this.groupBox3.Controls.Add(this.lblTotal);
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox3.Location = new System.Drawing.Point(548, 339);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(725, 397);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "My List";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(484, 308);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(214, 24);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "Total: 0 LKR";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView2.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView2.Location = new System.Drawing.Point(18, 32);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 30;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(680, 273);
            this.dataGridView2.TabIndex = 11;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview2_cell_click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "foodID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Item";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Unit (Rs.)";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Qty.";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 70;
            // 
            // Column5
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column5.HeaderText = "Total";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(-14, -3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(1402, 109);
            this.pictureBox4.TabIndex = 25;
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(635, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Version 1.5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(1081, 739);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Copyright 2021 - 19.2 NSBM - Team 99";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(492, 114);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(56, 14);
            this.button7.TabIndex = 27;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // chromeButton6
            // 
            this.chromeButton6.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.chromeButton6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chromeButton6.Image = null;
            this.chromeButton6.Location = new System.Drawing.Point(228, 347);
            this.chromeButton6.Name = "chromeButton6";
            this.chromeButton6.NoRounding = false;
            this.chromeButton6.Size = new System.Drawing.Size(69, 35);
            this.chromeButton6.TabIndex = 19;
            this.chromeButton6.Text = "Help";
            this.chromeButton6.Transparent = false;
            this.chromeButton6.Click += new System.EventHandler(this.chromeButton6_Click);
            // 
            // chromeButton5
            // 
            this.chromeButton5.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.chromeButton5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chromeButton5.Image = null;
            this.chromeButton5.Location = new System.Drawing.Point(153, 348);
            this.chromeButton5.Name = "chromeButton5";
            this.chromeButton5.NoRounding = false;
            this.chromeButton5.Size = new System.Drawing.Size(69, 35);
            this.chromeButton5.TabIndex = 18;
            this.chromeButton5.Text = "About";
            this.chromeButton5.Transparent = false;
            this.chromeButton5.Click += new System.EventHandler(this.chromeButton5_Click);
            // 
            // chromeButton1
            // 
            this.chromeButton1.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.chromeButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chromeButton1.Image = null;
            this.chromeButton1.Location = new System.Drawing.Point(18, 348);
            this.chromeButton1.Name = "chromeButton1";
            this.chromeButton1.NoRounding = false;
            this.chromeButton1.Size = new System.Drawing.Size(129, 35);
            this.chromeButton1.TabIndex = 17;
            this.chromeButton1.Text = "Service Login";
            this.chromeButton1.Transparent = false;
            this.chromeButton1.Click += new System.EventHandler(this.chromeButton1_Click_1);
            // 
            // chromeButton4
            // 
            this.chromeButton4.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.chromeButton4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chromeButton4.Image = null;
            this.chromeButton4.Location = new System.Drawing.Point(394, 347);
            this.chromeButton4.Name = "chromeButton4";
            this.chromeButton4.NoRounding = false;
            this.chromeButton4.Size = new System.Drawing.Size(88, 36);
            this.chromeButton4.TabIndex = 16;
            this.chromeButton4.Text = "Clear";
            this.chromeButton4.Transparent = false;
            this.chromeButton4.Click += new System.EventHandler(this.chromeButton4_Click);
            // 
            // chromeButton3
            // 
            this.chromeButton3.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.chromeButton3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chromeButton3.Image = null;
            this.chromeButton3.Location = new System.Drawing.Point(488, 347);
            this.chromeButton3.Name = "chromeButton3";
            this.chromeButton3.NoRounding = false;
            this.chromeButton3.Size = new System.Drawing.Size(210, 36);
            this.chromeButton3.TabIndex = 15;
            this.chromeButton3.Text = "Review Order";
            this.chromeButton3.Transparent = false;
            this.chromeButton3.Click += new System.EventHandler(this.chromeButton3_Click);
            // 
            // chromeButton2
            // 
            this.chromeButton2.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.chromeButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chromeButton2.Image = null;
            this.chromeButton2.Location = new System.Drawing.Point(579, 120);
            this.chromeButton2.Name = "chromeButton2";
            this.chromeButton2.NoRounding = false;
            this.chromeButton2.Size = new System.Drawing.Size(107, 60);
            this.chromeButton2.TabIndex = 20;
            this.chromeButton2.Text = "Add";
            this.chromeButton2.Transparent = false;
            this.chromeButton2.Click += new System.EventHandler(this.chromeButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1286, 759);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1302, 798);
            this.MinimumSize = new System.Drawing.Size(1302, 798);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NSBM Food Corner  : Canteen Management System";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFoodqty)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblFoodPrice;
        private System.Windows.Forms.Label lblFoodID;
        private System.Windows.Forms.Label lblFoodCal;
        private System.Windows.Forms.Label lblFoodIng;
        private System.Windows.Forms.NumericUpDown numFoodqty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFoodname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ChromeButton chromeButton2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label lblTotal;
        private ChromeButton chromeButton3;
        private ChromeButton chromeButton4;
        private System.Windows.Forms.Label lblFoodPriceInv;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
        private ChromeButton chromeButton1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ChromeButton chromeButton5;
        private ChromeButton chromeButton6;
        private System.Windows.Forms.Button button7;
    }
}

