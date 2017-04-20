namespace WindowsFormsApplication1
{
    partial class MH482
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MH482));
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.listBoxPorts = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonScan = new System.Windows.Forms.Button();
            this.listBoxBaud = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.buttonDebug = new System.Windows.Forms.Button();
            this.listBoxCommands = new System.Windows.Forms.ListBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBoxResponse = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.numericData = new System.Windows.Forms.NumericUpDown();
            this.labelData = new System.Windows.Forms.Label();
            this.numericAddress = new System.Windows.Forms.NumericUpDown();
            this.tabMainMenu = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBoxHallBaudRate = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonWriteSRAM = new System.Windows.Forms.Button();
            this.buttonWriteParameters = new System.Windows.Forms.Button();
            this.textBoxVout = new System.Windows.Forms.TextBox();
            this.dataGridParam = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonReadEEPROM = new System.Windows.Forms.Button();
            this.textBoxVcc = new System.Windows.Forms.TextBox();
            this.buttonProgVrefMode = new System.Windows.Forms.Button();
            this.buttonRunningMode = new System.Windows.Forms.Button();
            this.buttonMeasureOut = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonWriteEEPROM = new System.Windows.Forms.Button();
            this.buttonReadEEPROM2 = new System.Windows.Forms.Button();
            this.dataGridEEPROM = new System.Windows.Forms.DataGridView();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkLabelMagnesensor = new System.Windows.Forms.LinkLabel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pictureBoxTestResult = new System.Windows.Forms.PictureBox();
            this.pictureBoxLEDCom = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAddress)).BeginInit();
            this.tabMainMenu.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridParam)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEEPROM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTestResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLEDCom)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(6, 124);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Location = new System.Drawing.Point(87, 124);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(75, 23);
            this.buttonDisconnect.TabIndex = 1;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 263);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(272, 182);
            this.textBox1.TabIndex = 2;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // listBoxPorts
            // 
            this.listBoxPorts.FormattingEnabled = true;
            this.listBoxPorts.Location = new System.Drawing.Point(6, 73);
            this.listBoxPorts.Name = "listBoxPorts";
            this.listBoxPorts.ScrollAlwaysVisible = true;
            this.listBoxPorts.Size = new System.Drawing.Size(182, 30);
            this.listBoxPorts.TabIndex = 2;
            this.listBoxPorts.SelectedIndexChanged += new System.EventHandler(this.listBoxPorts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Port";
            // 
            // buttonScan
            // 
            this.buttonScan.Location = new System.Drawing.Point(6, 18);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(75, 22);
            this.buttonScan.TabIndex = 0;
            this.buttonScan.Text = "Scan Ports";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // listBoxBaud
            // 
            this.listBoxBaud.FormattingEnabled = true;
            this.listBoxBaud.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "14600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.listBoxBaud.Location = new System.Drawing.Point(87, 179);
            this.listBoxBaud.Name = "listBoxBaud";
            this.listBoxBaud.ScrollAlwaysVisible = true;
            this.listBoxBaud.Size = new System.Drawing.Size(68, 69);
            this.listBoxBaud.TabIndex = 6;
            this.listBoxBaud.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AccessibleName = "Baud Rate";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Baud Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 9;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 163);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(37, 13);
            this.label23.TabIndex = 42;
            this.label23.Text = "Result";
            // 
            // buttonDebug
            // 
            this.buttonDebug.Location = new System.Drawing.Point(17, 148);
            this.buttonDebug.Name = "buttonDebug";
            this.buttonDebug.Size = new System.Drawing.Size(95, 40);
            this.buttonDebug.TabIndex = 43;
            this.buttonDebug.Text = "Send Command";
            this.buttonDebug.UseVisualStyleBackColor = true;
            this.buttonDebug.Click += new System.EventHandler(this.buttonDebug_Click);
            // 
            // listBoxCommands
            // 
            this.listBoxCommands.FormattingEnabled = true;
            this.listBoxCommands.Items.AddRange(new object[] {
            "help",
            "*idn?",
            "version",
            "baudrate",
            "purge",
            "sync",
            "write",
            "read",
            "storebyte",
            "storechip",
            "exit",
            "seth",
            "setl",
            "*rst",
            "reada",
            "i2cw",
            "i2cr"});
            this.listBoxCommands.Location = new System.Drawing.Point(17, 34);
            this.listBoxCommands.Name = "listBoxCommands";
            this.listBoxCommands.Size = new System.Drawing.Size(86, 108);
            this.listBoxCommands.TabIndex = 44;
            this.listBoxCommands.SelectedIndexChanged += new System.EventHandler(this.listBoxCommands_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.AccessibleName = "S";
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(14, 18);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(89, 13);
            this.label24.TabIndex = 45;
            this.label24.Text = "Debug Command";
            // 
            // textBoxResponse
            // 
            this.textBoxResponse.Location = new System.Drawing.Point(10, 237);
            this.textBoxResponse.Name = "textBoxResponse";
            this.textBoxResponse.Size = new System.Drawing.Size(272, 20);
            this.textBoxResponse.TabIndex = 46;
            // 
            // label25
            // 
            this.label25.AccessibleName = "S";
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(14, 221);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(55, 13);
            this.label25.TabIndex = 47;
            this.label25.Text = "Response";
            // 
            // labelAddress
            // 
            this.labelAddress.AccessibleName = "S";
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(122, 38);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(73, 13);
            this.labelAddress.TabIndex = 49;
            this.labelAddress.Text = "Address (Hex)";
            // 
            // numericData
            // 
            this.numericData.Hexadecimal = true;
            this.numericData.Location = new System.Drawing.Point(125, 96);
            this.numericData.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericData.Name = "numericData";
            this.numericData.Size = new System.Drawing.Size(70, 20);
            this.numericData.TabIndex = 50;
            // 
            // labelData
            // 
            this.labelData.AccessibleName = "S";
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(122, 80);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(58, 13);
            this.labelData.TabIndex = 51;
            this.labelData.Text = "Data (Hex)";
            // 
            // numericAddress
            // 
            this.numericAddress.Hexadecimal = true;
            this.numericAddress.Location = new System.Drawing.Point(124, 54);
            this.numericAddress.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numericAddress.Name = "numericAddress";
            this.numericAddress.Size = new System.Drawing.Size(71, 20);
            this.numericAddress.TabIndex = 52;
            // 
            // tabMainMenu
            // 
            this.tabMainMenu.Controls.Add(this.tabPage1);
            this.tabMainMenu.Controls.Add(this.tabPage2);
            this.tabMainMenu.Controls.Add(this.tabPage4);
            this.tabMainMenu.Controls.Add(this.tabPage3);
            this.tabMainMenu.Location = new System.Drawing.Point(2, 3);
            this.tabMainMenu.Name = "tabMainMenu";
            this.tabMainMenu.SelectedIndex = 0;
            this.tabMainMenu.Size = new System.Drawing.Size(301, 499);
            this.tabMainMenu.TabIndex = 53;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBoxLogo);
            this.tabPage1.Controls.Add(this.buttonScan);
            this.tabPage1.Controls.Add(this.listBoxPorts);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.buttonConnect);
            this.tabPage1.Controls.Add(this.buttonDisconnect);
            this.tabPage1.Controls.Add(this.pictureBoxTestResult);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.listBoxBaud);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.pictureBoxLEDCom);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(293, 473);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "USB";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBoxHallBaudRate);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.listBoxCommands);
            this.tabPage2.Controls.Add(this.numericData);
            this.tabPage2.Controls.Add(this.labelData);
            this.tabPage2.Controls.Add(this.numericAddress);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.labelAddress);
            this.tabPage2.Controls.Add(this.buttonDebug);
            this.tabPage2.Controls.Add(this.textBoxResponse);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(293, 473);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Debug";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBoxHallBaudRate
            // 
            this.listBoxHallBaudRate.FormattingEnabled = true;
            this.listBoxHallBaudRate.Items.AddRange(new object[] {
            "Read",
            "4800",
            "9600",
            "19200",
            "38400"});
            this.listBoxHallBaudRate.Location = new System.Drawing.Point(124, 137);
            this.listBoxHallBaudRate.Name = "listBoxHallBaudRate";
            this.listBoxHallBaudRate.Size = new System.Drawing.Size(86, 69);
            this.listBoxHallBaudRate.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AccessibleName = "S";
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(122, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Hall Baud Rate";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.buttonWriteSRAM);
            this.tabPage4.Controls.Add(this.buttonWriteParameters);
            this.tabPage4.Controls.Add(this.textBoxVout);
            this.tabPage4.Controls.Add(this.dataGridParam);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.buttonReadEEPROM);
            this.tabPage4.Controls.Add(this.textBoxVcc);
            this.tabPage4.Controls.Add(this.buttonProgVrefMode);
            this.tabPage4.Controls.Add(this.buttonRunningMode);
            this.tabPage4.Controls.Add(this.buttonMeasureOut);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(293, 473);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Parameters";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AccessibleName = "S";
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 431);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 62;
            this.label6.Text = "Vout";
            // 
            // buttonWriteSRAM
            // 
            this.buttonWriteSRAM.Location = new System.Drawing.Point(8, 160);
            this.buttonWriteSRAM.Name = "buttonWriteSRAM";
            this.buttonWriteSRAM.Size = new System.Drawing.Size(71, 40);
            this.buttonWriteSRAM.TabIndex = 3;
            this.buttonWriteSRAM.Text = "Write RAM";
            this.buttonWriteSRAM.UseVisualStyleBackColor = true;
            this.buttonWriteSRAM.Click += new System.EventHandler(this.buttonWriteSRAM_Click);
            // 
            // buttonWriteParameters
            // 
            this.buttonWriteParameters.Location = new System.Drawing.Point(6, 276);
            this.buttonWriteParameters.Name = "buttonWriteParameters";
            this.buttonWriteParameters.Size = new System.Drawing.Size(71, 40);
            this.buttonWriteParameters.TabIndex = 2;
            this.buttonWriteParameters.Text = "Write ROM";
            this.buttonWriteParameters.UseVisualStyleBackColor = true;
            this.buttonWriteParameters.Click += new System.EventHandler(this.buttonWriteParameters_Click);
            // 
            // textBoxVout
            // 
            this.textBoxVout.Location = new System.Drawing.Point(8, 447);
            this.textBoxVout.Name = "textBoxVout";
            this.textBoxVout.Size = new System.Drawing.Size(57, 20);
            this.textBoxVout.TabIndex = 59;
            // 
            // dataGridParam
            // 
            this.dataGridParam.AllowUserToAddRows = false;
            this.dataGridParam.AllowUserToDeleteRows = false;
            this.dataGridParam.AllowUserToResizeColumns = false;
            this.dataGridParam.AllowUserToResizeRows = false;
            this.dataGridParam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridParam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridParam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridParam.Location = new System.Drawing.Point(89, 6);
            this.dataGridParam.Name = "dataGridParam";
            this.dataGridParam.RowHeadersVisible = false;
            this.dataGridParam.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridParam.Size = new System.Drawing.Size(201, 445);
            this.dataGridParam.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.FillWeight = 50F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Parameter";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.FillWeight = 50F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Data";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // label5
            // 
            this.label5.AccessibleName = "S";
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Vcc";
            // 
            // buttonReadEEPROM
            // 
            this.buttonReadEEPROM.Location = new System.Drawing.Point(6, 114);
            this.buttonReadEEPROM.Name = "buttonReadEEPROM";
            this.buttonReadEEPROM.Size = new System.Drawing.Size(71, 40);
            this.buttonReadEEPROM.TabIndex = 1;
            this.buttonReadEEPROM.Text = "Read ROM";
            this.buttonReadEEPROM.UseVisualStyleBackColor = true;
            this.buttonReadEEPROM.Click += new System.EventHandler(this.buttonReadEEPROM_Click);
            // 
            // textBoxVcc
            // 
            this.textBoxVcc.Location = new System.Drawing.Point(6, 398);
            this.textBoxVcc.Name = "textBoxVcc";
            this.textBoxVcc.Size = new System.Drawing.Size(59, 20);
            this.textBoxVcc.TabIndex = 60;
            // 
            // buttonProgVrefMode
            // 
            this.buttonProgVrefMode.Location = new System.Drawing.Point(6, 6);
            this.buttonProgVrefMode.Name = "buttonProgVrefMode";
            this.buttonProgVrefMode.Size = new System.Drawing.Size(71, 40);
            this.buttonProgVrefMode.TabIndex = 56;
            this.buttonProgVrefMode.Text = "Program Mode";
            this.buttonProgVrefMode.UseVisualStyleBackColor = true;
            this.buttonProgVrefMode.Click += new System.EventHandler(this.buttonProgVrefMode_Click);
            // 
            // buttonRunningMode
            // 
            this.buttonRunningMode.Location = new System.Drawing.Point(6, 52);
            this.buttonRunningMode.Name = "buttonRunningMode";
            this.buttonRunningMode.Size = new System.Drawing.Size(71, 40);
            this.buttonRunningMode.TabIndex = 57;
            this.buttonRunningMode.Text = "Run Mode";
            this.buttonRunningMode.UseVisualStyleBackColor = true;
            this.buttonRunningMode.Click += new System.EventHandler(this.buttonRunningMode_Click);
            // 
            // buttonMeasureOut
            // 
            this.buttonMeasureOut.AutoSize = true;
            this.buttonMeasureOut.Location = new System.Drawing.Point(8, 339);
            this.buttonMeasureOut.Name = "buttonMeasureOut";
            this.buttonMeasureOut.Size = new System.Drawing.Size(71, 40);
            this.buttonMeasureOut.TabIndex = 58;
            this.buttonMeasureOut.Text = "Measure";
            this.buttonMeasureOut.UseVisualStyleBackColor = true;
            this.buttonMeasureOut.Click += new System.EventHandler(this.buttonMeasureOut_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonWriteEEPROM);
            this.tabPage3.Controls.Add(this.buttonReadEEPROM2);
            this.tabPage3.Controls.Add(this.dataGridEEPROM);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(293, 473);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "EEPROM";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonWriteEEPROM
            // 
            this.buttonWriteEEPROM.Location = new System.Drawing.Point(6, 46);
            this.buttonWriteEEPROM.Name = "buttonWriteEEPROM";
            this.buttonWriteEEPROM.Size = new System.Drawing.Size(71, 34);
            this.buttonWriteEEPROM.TabIndex = 3;
            this.buttonWriteEEPROM.Text = "Write";
            this.buttonWriteEEPROM.UseVisualStyleBackColor = true;
            this.buttonWriteEEPROM.Click += new System.EventHandler(this.buttonWriteEEPROM_Click);
            // 
            // buttonReadEEPROM2
            // 
            this.buttonReadEEPROM2.Location = new System.Drawing.Point(6, 6);
            this.buttonReadEEPROM2.Name = "buttonReadEEPROM2";
            this.buttonReadEEPROM2.Size = new System.Drawing.Size(71, 34);
            this.buttonReadEEPROM2.TabIndex = 2;
            this.buttonReadEEPROM2.Text = "Read";
            this.buttonReadEEPROM2.UseVisualStyleBackColor = true;
            this.buttonReadEEPROM2.Click += new System.EventHandler(this.buttonReadEEPROM2_Click);
            // 
            // dataGridEEPROM
            // 
            this.dataGridEEPROM.AllowUserToAddRows = false;
            this.dataGridEEPROM.AllowUserToDeleteRows = false;
            this.dataGridEEPROM.AllowUserToResizeColumns = false;
            this.dataGridEEPROM.AllowUserToResizeRows = false;
            this.dataGridEEPROM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridEEPROM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridEEPROM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEEPROM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Address,
            this.Data});
            this.dataGridEEPROM.Location = new System.Drawing.Point(87, 6);
            this.dataGridEEPROM.Name = "dataGridEEPROM";
            this.dataGridEEPROM.RowHeadersVisible = false;
            this.dataGridEEPROM.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridEEPROM.Size = new System.Drawing.Size(200, 348);
            this.dataGridEEPROM.TabIndex = 0;
            // 
            // Address
            // 
            this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Address.FillWeight = 50F;
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Data
            // 
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Data.FillWeight = 50F;
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // linkLabelMagnesensor
            // 
            this.linkLabelMagnesensor.AutoSize = true;
            this.linkLabelMagnesensor.Location = new System.Drawing.Point(-1, 569);
            this.linkLabelMagnesensor.Name = "linkLabelMagnesensor";
            this.linkLabelMagnesensor.Size = new System.Drawing.Size(120, 13);
            this.linkLabelMagnesensor.TabIndex = 54;
            this.linkLabelMagnesensor.TabStop = true;
            this.linkLabelMagnesensor.Text = "www.magnesensor.com";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::MSTProgrammer.Properties.Resources.footer;
            this.pictureBoxLogo.Location = new System.Drawing.Point(-4, 411);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(252, 62);
            this.pictureBoxLogo.TabIndex = 55;
            this.pictureBoxLogo.TabStop = false;
            // 
            // pictureBoxTestResult
            // 
            this.pictureBoxTestResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxTestResult.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxTestResult.InitialImage")));
            this.pictureBoxTestResult.Location = new System.Drawing.Point(6, 179);
            this.pictureBoxTestResult.Name = "pictureBoxTestResult";
            this.pictureBoxTestResult.Size = new System.Drawing.Size(36, 36);
            this.pictureBoxTestResult.TabIndex = 41;
            this.pictureBoxTestResult.TabStop = false;
            this.pictureBoxTestResult.UseWaitCursor = true;
            // 
            // pictureBoxLEDCom
            // 
            this.pictureBoxLEDCom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxLEDCom.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxLEDCom.InitialImage")));
            this.pictureBoxLEDCom.Location = new System.Drawing.Point(6, 232);
            this.pictureBoxLEDCom.Name = "pictureBoxLEDCom";
            this.pictureBoxLEDCom.Size = new System.Drawing.Size(36, 36);
            this.pictureBoxLEDCom.TabIndex = 8;
            this.pictureBoxLEDCom.TabStop = false;
            this.pictureBoxLEDCom.UseWaitCursor = true;
            // 
            // MH482
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 598);
            this.Controls.Add(this.linkLabelMagnesensor);
            this.Controls.Add(this.tabMainMenu);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MaximizeBox = false;
            this.Name = "MH482";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MH482";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAddress)).EndInit();
            this.tabMainMenu.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridParam)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEEPROM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTestResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLEDCom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.TextBox textBox1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ListBox listBoxPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.ListBox listBoxBaud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxLEDCom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxTestResult;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button buttonDebug;
        private System.Windows.Forms.ListBox listBoxCommands;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBoxResponse;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.NumericUpDown numericData;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.NumericUpDown numericAddress;
        private System.Windows.Forms.TabControl tabMainMenu;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridEEPROM;
        private System.Windows.Forms.Button buttonReadEEPROM;
        private System.Windows.Forms.Button buttonWriteParameters;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridParam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxHallBaudRate;
        private System.Windows.Forms.Button buttonProgVrefMode;
        private System.Windows.Forms.Button buttonRunningMode;
        private System.Windows.Forms.Button buttonWriteEEPROM;
        private System.Windows.Forms.Button buttonReadEEPROM2;
        private System.Windows.Forms.TextBox textBoxVout;
        private System.Windows.Forms.Button buttonMeasureOut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxVcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button buttonWriteSRAM;
        private System.Windows.Forms.LinkLabel linkLabelMagnesensor;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}

