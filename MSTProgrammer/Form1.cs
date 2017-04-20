using System;
using System.IO;                    // to retrieve application path
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
// classes are needed for the regex registry search functions see http://stackoverflow.com/questions/14991517/how-do-i-get-serial-port-device-id
using System.Text.RegularExpressions;
using Microsoft.Win32;
// added comment for git testing
namespace WindowsFormsApplication1
{
    public partial class MH482 : Form
    {
        int EEMaxParameters = 21;
        int EEMaxWords = 16;
        enum EEParameters { EE_LINE=0, EE_SERIAL=1, EE_YEAR=2, EE_MONTH=3, EE_DAY=4, EE_AMPM=5, EE_BAUD=6, EE_SPARE06=7, EE_SPARE07=8, EE_TC=9, EE_BFLIP=10, EE_SENS=11, EE_FOSC=12, EE_OFFTRIM=13, EE_ENTCPOS=14, EE_ENTCNEG=15, EE_BGTRIM=16, EE_PROGMODE1=17, EE_BIASTRIM=18, EE_TC2ND=19, EE_TEMPZ=20 };
        string[] EEParameterNames = {"Line", "Serial Number", "Year", "Month", "Day","AM/PM","Baud Rate","Spare 06", "Spare 07", "TC Setting","B-Field Flip","Sensitivity", "Osc. Trim", "Offset Trim", "Enable TC+", "Enable TC-", "Bandgap Trim", "Prog. Mode1","Bias Trim", "TC 2nd Order", "Temp Monitor"}; 
        int[] EE_ParamsRead = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] EE_WordsRead =  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] EE_ParamsTemp = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] EE_WordsTemp = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        enum Commands { HELP, IDN, VERSION, BAUDRATE, PURGE, SYNC, WRITE, READ, STOREBYTE, STORECHIP, EXIT, SETH, SETL, RESET, READA, I2CW, I2CR };
        string[] CommandSet = {"help","*idn?","version", "baudrate", "purge","sync","write","read","storebyte","storechip","exit","seth","setl","*rst","reada","i2cw","i2cr"};
        string RxString;        // all available data received from serial port
        string RxBuff;          // buffer of all received data (concatenated RxString)
        bool PauseSerialHandler = false;
        public MH482()
        {
            InitializeComponent();
            InitDisplay();
        }
        private void EnterProgMode()
        {           
            VddEnable(false);
            Thread.Sleep(50);
            VrefPullup(true);
            Thread.Sleep(50);
            VddEnable(true);
            Thread.Sleep(4);
            VrefPullup(false);
        }
        private void EnterRunningMode()
        {
            VddEnable(false);
            Thread.Sleep(1);
            VrefPullup(false);
            Thread.Sleep(50);
            VddEnable(true);
            Thread.Sleep(4);
        }
        private void RedLed(bool Status)
        {
            if (Status)
                ProgrammerWrite("seth 12");
            else
                ProgrammerWrite("setl 12");
        }
        private void GreenLed(bool Status)
        {
            if (Status)
                ProgrammerWrite("seth 13");
            else
                ProgrammerWrite("setl 13");
        }
        private void VddEnable(bool status)
        {
            if (status)
                ProgrammerWrite("setl 10");
            else
                ProgrammerWrite("seth 10");
        }
        private void VrefPullup(bool status)
        {
            if (status)
                ProgrammerWrite("seth 11");
            else
                ProgrammerWrite("setl 11");
        }
        private void Sync()
        {
            ProgrammerWrite("sync");
        }
        private void Purge()
        {
            ProgrammerWrite("purge");
        }
        private void WriteSRAM(int add, int data)
        {
            string txtcommand = string.Concat("write ", add.ToString(), " ", data.ToString());
            ProgrammerWrite(txtcommand);
        }
        private void StoreByte(int add)
        {
            string txtcommand = string.Concat("storebyte ", add.ToString());
            ProgrammerWrite(txtcommand);
        }
        private void StoreChip()
        {
            ProgrammerWrite("storechip");
        }
        private void WriteEEPROM(int add, int data)
        {
            WriteSRAM(add, data);
            StoreByte(add);
        }

        private int ReadEEPROM(int add)
        {
            string txtcommand = string.Concat("read ", add.ToString());
            ProgrammerWrite(txtcommand);
            EE_WordsRead[add] = Convert.ToInt32(textBoxResponse.Text);
            return (EE_WordsRead[add]);
        }
        private void ReadFullEEPROM()
        {
            EnterProgMode();
            ClearEEPROMDisplay();
            ClearParamDisplay();
            Sync();                 // even for trimmed parts, seems to be necessary?
            Purge();
            for (int i = 0; i < EEMaxWords; i++)
            {
                //Thread.Sleep(50);
                EE_WordsRead[i] = ReadEEPROM(i);
            }
            WordsToParameters(EE_WordsRead, EE_ParamsRead);
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (listBoxPorts.SelectedIndex >= 0)
            {
                string s = (string)listBoxPorts.SelectedItem;
                serialPort1.PortName = s.Substring(0, s.IndexOf(" "));
                //MessageBox.Show("Port Selected is " + serialPort1.PortName);
                //string b = (string) listBoxBaud.SelectedItem;
                serialPort1.BaudRate = Convert.ToInt32((string)listBoxBaud.SelectedItem);
                serialPort1.NewLine = "\x04";
                serialPort1.Open();
               // serialPort1.BaseStream.
                if (serialPort1.IsOpen)
                {
                    pictureBoxLEDCom.Image = (Image)MSTProgrammer.Properties.Resources.led_green;
                    buttonConnect.Enabled = false;
                    buttonDisconnect.Enabled = true;
                    listBoxBaud.Enabled = false;
                    listBoxPorts.Enabled = false;
                    listBoxCommands.Enabled = true;
                    listBoxCommands.SelectedIndex = 1;
                    textBoxResponse.Clear();
                    textBox1.ReadOnly = false;
                    textBox1.Clear();
                    serialPort1.DiscardOutBuffer();
                    serialPort1.DiscardInBuffer();
                    SerialCommandResponse(Commands.PURGE);
                    GreenLed(true);
                    listBoxCommands.Focus();
                        //byte[] eot = { 04 };
                        //serialPort1.Write(eot, 0, 1);
                    // prog_ReadIDN();
                }
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            //if (serialPort1.IsOpen)
            if (true)
            {
                GreenLed(false);
                RedLed(false);
                pictureBoxLEDCom.Image = (Image)MSTProgrammer.Properties.Resources.led_yellow;
                serialPort1.Close();
                buttonConnect.Enabled = true;
                buttonDisconnect.Enabled = false;
                listBoxBaud.Enabled = true;
                listBoxPorts.Enabled = true;
                textBox1.ReadOnly = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the port is closed, don't try to send a character.
            if (!serialPort1.IsOpen) return;

            // If the port is Open, declare a char[] array with one element.
            char[] buff = new char[1];
            char[] lf = new char[1];
            lf[0] = (char)10;

            // Load element 0 with the key character.
            buff[0] = e.KeyChar;
            serialPort1.Write(buff, 0, 1);
            if (e.KeyChar == 13)
            {
                serialPort1.Write(lf, 0, 1);
            }
            // Set the KeyPress event as handled so the character won't
            // display locally. If you want it to display, omit the next line.
            //e.Handled = true;
 
        }
        private void ProgrammerWrite(string wr)
        {
            if (!serialPort1.IsOpen) return;
            else
            {
                textBoxResponse.Clear();
                PauseSerialHandler = true;
                serialPort1.DiscardInBuffer();
                serialPort1.WriteLine(wr);
                textBox1.AppendText("->" + wr + "\n");
                textBoxResponse.Text = serialPort1.ReadLine();
                textBox1.AppendText(textBoxResponse.Text + "\n");
                PauseSerialHandler = false;
/*
                byte[] s = Encoding.ASCII.GetBytes(wr);
                byte[] e = { 04 };
                serialPort1.Write(s, 0, s.Length);
                serialPort1.Write(e, 0, 1);
*/
         }
 
        }
        private void SerialCommandResponse(Commands Command)
        {
            string txtcommand;
            // probably can't use writeline because of the EOT terminator
            if (!serialPort1.IsOpen) return;
            //serialPort1.WriteLine(CommandSet[(int)Command]);
            switch (Command)
            {   
                case Commands.WRITE:
                    // numericAddress between 0-31, numericData 0-255
                    // only writes to SRAM
                   txtcommand = string.Concat("write ", numericAddress.Value.ToString(), " ", numericData.Value.ToString());
                   ProgrammerWrite(txtcommand);
                   break;

                case Commands.BAUDRATE:
                   // numericAddress between 0-31, numericData 0-255
                   if (listBoxHallBaudRate.SelectedItem.Equals("Read")) 
                        txtcommand = "baudrate";
                   else
                       txtcommand = string.Concat("baudrate ", (string)listBoxHallBaudRate.SelectedItem);
                   ProgrammerWrite(txtcommand);
                   break;

                case Commands.READ:
                   // numericAddress between 0-31
                   //txtcommand = string.Concat("read ",numericAddress.Value.ToString());
                   //ProgrammerWrite(txtcommand);
                   ReadEEPROM((int)numericAddress.Value);
                   WordsToParameters(EE_WordsRead, EE_ParamsRead);
                   ShowEEPROMDisplay();
                   ShowParamDisplay();
                   break;

                case Commands.EXIT:
                   // numericAddress between 0-31
                   txtcommand = "exit";
                   ProgrammerWrite(txtcommand);
                   break;

                case Commands.READA:
                   txtcommand = string.Concat("reada ", numericAddress.Value.ToString());
                   ProgrammerWrite(txtcommand);
                   break;

                case Commands.STORECHIP:
                   StoreChip();
                   break;

                case Commands.SETH:
                   // numericData must be between 2 and 13
                    // 12: Red LED, seth = on, setl = off 
                    // 13: Green LED, seth = on, setl = off
                    // 11: Vref pin, seth = 5V, setl = 0V
                    // 10: Vcc pin, seth = 0V, setl = 5V
                   txtcommand = string.Concat("seth ",numericData.Value.ToString());
                   ProgrammerWrite(txtcommand);
                   break;

                case Commands.SETL:
                   // numericData must be between 2 and 13
                   txtcommand = string.Concat("setl ", numericData.Value.ToString());
                   ProgrammerWrite(txtcommand);
                   break;

                case Commands.STOREBYTE:
                   StoreByte((int)numericAddress.Value);
                   break;

                case Commands.SYNC:
                   Sync();
                   break;

                case Commands.PURGE:
                    ProgrammerWrite("purge");
                    /*
                    int len = CommandSet[(int)Command].Length;
                    char[] b = new char[len+1]; 
                    b = CommandSet[(int)Command].ToCharArray(0,len);
                   // b[len] = '\x04';
                    serialPort1.Write(b,0,len);
                    byte[] eot = { 04 };
                    serialPort1.Write(eot, 0, 1);
                     */
                    break;

                case Commands.IDN:
                    ProgrammerWrite("*idn?");
                    break;

                case Commands.VERSION:
                    ProgrammerWrite("version");
                    break;
                break;
                default:
                    break;
            }
        }

        private void ProcessSerialData()
        {
            // step through RxBuff until we reach \n
            int TermPosition;
            int CurrentPosition;
            string DataLine;

            CurrentPosition = 0;
            TermPosition = RxBuff.IndexOf("\n");
            DataLine = RxBuff.Substring(CurrentPosition, (TermPosition - CurrentPosition));
            RxBuff = RxBuff.Substring(TermPosition+1);
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (!PauseSerialHandler)
            {
                RxString = serialPort1.ReadExisting();
                RxBuff += RxString;
                RxString = RxString.Replace("\n", "\r\n");
                this.Invoke(new EventHandler(DisplayText));
            }
        }
        private void DisplayText(object sender, EventArgs e)
        {
            // textboxes require exctly CR+LF
            textBox1.AppendText(RxString);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // the port must be closed first or the program will hang.
            if (serialPort1.IsOpen) serialPort1.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void prog_ReadIDN()
        {
            // string cmd = "IDN\r\n"; 
            //string cmd = "*idn?";           
            string cmd = "version";        
            if (!serialPort1.IsOpen) return;
            else
            {   
                textBox1.AppendText("->"+cmd);
                byte[] s = Encoding.ASCII.GetBytes(cmd);
                byte[] e = {04};
                serialPort1.Write(s, 0,s.Length);
                serialPort1.Write(e,0,1);
            }
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            List<string> portlist;

            listBoxPorts.BeginUpdate();
            listBoxPorts.ClearSelected();
            listBoxPorts.Items.Clear();
            string[] ports = SerialPort.GetPortNames();

            //portlist = getPortByVPid("0D28", "0204"); // mbed 
            //portlist = getPortByVPid("2341", "0042");   // Mega 2560 ADK
            portlist = getPortByVid("2341");   // different Mega boards have different PIDs
            //portlist = getPortByVPid("2341", "0044");   // Mega 2560 clone
            foreach (string vidport in portlist)
            {   if (vidport != null)    
                foreach (string port in ports)
                {
                    if (vidport.Contains(port))
                        listBoxPorts.Items.Add(port + " - "+vidport);
                } 
            }
            listBoxPorts.Refresh();
            listBoxPorts.EndUpdate();
            if (listBoxPorts.Items.Count > 0)
            {
                pictureBoxLEDCom.Image = (Image)MSTProgrammer.Properties.Resources.led_yellow;
                listBoxPorts.SelectedIndex = 0;
                //listBoxPorts.Focus();
                buttonConnect.Focus();
                listBoxPorts.Refresh();
                if (!serialPort1.IsOpen)
                    buttonConnect.Enabled = true;
            }
            else
            {
                pictureBoxLEDCom.Image = (Image)MSTProgrammer.Properties.Resources.led_red;
                MessageBox.Show("No Programmer Detected");
                buttonConnect.Enabled = false;
            }

        }

        private void listBoxPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Compile an array of COM port names associated with given VID and PID
        /// </summary>
        /// <param name="VID">string representing the vendor id of the USB/Serial convertor</param>
        /// <param name="PID">string representing the product id of the USB/Serial convertor</param>
        /// <returns></returns>
        private static List<string> getPortByVPid(String VID, String PID)
        {
            String pattern = String.Format("^VID_{0}.PID_{1}", VID, PID);
            Regex _rx = new Regex(pattern, RegexOptions.IgnoreCase);
            List<string> comports = new List<string>();
            RegistryKey rk1 = Registry.LocalMachine;
            RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");
            foreach (String s3 in rk2.GetSubKeyNames())
            {
                RegistryKey rk3 = rk2.OpenSubKey(s3);
                foreach (String s in rk3.GetSubKeyNames())
                {
                    if (_rx.Match(s).Success)
                    {
                        RegistryKey rk4 = rk3.OpenSubKey(s);
                        foreach (String s2 in rk4.GetSubKeyNames())
                        {
                            RegistryKey rk5 = rk4.OpenSubKey(s2);
                            //RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
                            if (rk5 != null)
                                comports.Add((string)rk5.GetValue("FriendlyName"));
                            //if (rk6 != null)
                            //comports.Add((string)rk6.GetValue("PortName"));
                        }
                    }
                }
            }
            return comports;
        }
        private static List<string> getPortByVid(String VID)
        {
            String pattern = String.Format("^VID_{0}.PID_", VID);
            Regex _rx = new Regex(pattern, RegexOptions.IgnoreCase);
            List<string> comports = new List<string>();
            RegistryKey rk1 = Registry.LocalMachine;
            RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");
            foreach (String s3 in rk2.GetSubKeyNames())
            {
                RegistryKey rk3 = rk2.OpenSubKey(s3);
                foreach (String s in rk3.GetSubKeyNames())
                {
                    if (_rx.Match(s).Success)
                    {
                        RegistryKey rk4 = rk3.OpenSubKey(s);
                        foreach (String s2 in rk4.GetSubKeyNames())
                        {
                            RegistryKey rk5 = rk4.OpenSubKey(s2);
                            //RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
                            if (rk5 != null)
                                comports.Add((string)rk5.GetValue("FriendlyName"));
                            //if (rk6 != null)
                            //comports.Add((string)rk6.GetValue("PortName"));
                        }
                    }
                }
            }
            return comports;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // bitmapLED = new Bitmap("LED_Yellow.bmp");
            pictureBoxLEDCom.Image = (Image) MSTProgrammer.Properties.Resources.led_red;
            string AppPath = Path.GetDirectoryName(Application.ExecutablePath);
            //MessageBox.Show("Path: " + AppPath);
            listBoxBaud.SelectedIndex = 8;  // 8=115200 for
            listBoxPorts.Items.Clear();
            buttonConnect.Enabled = false;
            buttonDisconnect.Enabled = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonDebug_Click(object sender, EventArgs e)
        {
            int i = Array.IndexOf(CommandSet, listBoxCommands.GetItemText(listBoxCommands.SelectedItem).ToLower());
            SerialCommandResponse((Commands)i);
        }
        private void listBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDebug.Focus();
        }
        private void InitDisplay()
        {
            InitEEPROMDisplay();
            InitParamDisplay();
            textBoxVout.Text = "";
        }
        private void InitEEPROMDisplay()
        {
            dataGridEEPROM.RowCount = 0;
            dataGridEEPROM.ColumnHeadersHeight = 21;
            for (int i = 0; i < EEMaxWords; i++)
            {
                dataGridEEPROM.Rows.Add();
                dataGridEEPROM.Rows[i].Height = 21;
                dataGridEEPROM.Rows[i].Cells[0].Value = i;
            }
            dataGridEEPROM.Height = 21 * (EEMaxWords+1);
            ClearEEPROMDisplay();    
        }
        private void InitParamDisplay()
        {
            dataGridParam.RowCount = 0;
            dataGridParam.ColumnHeadersHeight = 21;
            for (int i = 0; i < EEMaxParameters; i++)
            {
                dataGridParam.Rows.Add();
                dataGridParam.Rows[i].Height = 21;
                dataGridParam.Rows[i].Cells[0].Value = EEParameterNames[i];
            }
            dataGridParam.Height = 21 * (EEMaxParameters+1);
            ClearParamDisplay();
        }
        private void ClearEEPROMDisplay()
        {
            for (int i = 0; i < EEMaxWords; i++)
            {
                dataGridEEPROM.Rows[i].Cells[1].Value ="";
            }
        }
        private void ClearParamDisplay()
        {
            for (int i = 0; i < EEMaxParameters; i++)
            {
                dataGridParam.Rows[i].Cells[1].Value = "";
            }
        }
        private void ShowParamDisplay()
        {
            for (int i = 0; i < EEMaxParameters; i++)
            {
                dataGridParam.Rows[i].Cells[1].Value = EE_ParamsRead[i];
            }
        }
        private void ShowEEPROMDisplay()
        {
            for (int i = 0; i < EEMaxWords; i++)
            {
                dataGridEEPROM.Rows[i].Cells[1].Value = EE_WordsRead[i];
     
            }
        }

        private void buttonReadEEPROM_Click(object sender, EventArgs e)
        {
            ReadFullEEPROM();
            ShowEEPROMDisplay();
            ShowParamDisplay();
        }

        private void buttonReadEEPROM2_Click(object sender, EventArgs e)
        {
            ReadFullEEPROM();
            ShowEEPROMDisplay();
            ShowParamDisplay();
        }

        private double MeasurePin(int pin)
        {
            double ret;
            string txtcommand = string.Concat("reada ", pin.ToString());
            ProgrammerWrite(txtcommand);
            ret = Convert.ToDouble(textBoxResponse.Text);
            return (ret);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonProgVrefMode_Click(object sender, EventArgs e)
        {
            EnterProgMode();
        }

        private void buttonRunningMode_Click(object sender, EventArgs e)
        {
            EnterRunningMode();
        }



        private void buttonMeasureOut_Click(object sender, EventArgs e)
        {
            double vcc = 5 * MeasurePin(0) / 1024;
            textBoxVcc.Text = vcc.ToString("N3");  //N3 = numerical value with 3 places after DP
            double vout = 5 * MeasurePin(1) / 1024;
            textBoxVout.Text = vout.ToString("N3");  //N3 = numerical value with 3 places after DP
        }

        private void buttonWriteEEPROM_Click(object sender, EventArgs e)
        {
            // 
            // 1. copy raw EEPROM from gridtableview to temp EEPROM array
            // 2. for each byte, compare temp array with read array
            // 3.  write if changed
            // don't need to update parameters at all
            bool ParamsChanged = false;
            string msg = "Change Memory?\n";
            CopyWordsToTemp();
            for (int i = 0; i < EEMaxWords; i++)
            {
                if (EE_WordsTemp[i] != EE_WordsRead[i])
                {
                    ParamsChanged = true;
                    msg = string.Concat(msg, "    Word " + i.ToString() + " from " + EE_WordsRead[i].ToString() + " to " + EE_WordsTemp[i].ToString() + "\n");
                }
            }
            if (ParamsChanged)
            {
                if (MessageBox.Show(msg, "Write EEPROM", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    // actually write
                    for (int i = 0; i < EEMaxWords; i++)
                    {
                        if (EE_WordsTemp[i] != EE_WordsRead[i])
                        {
                            WriteSRAM(i, EE_WordsTemp[i]);
                            MessageBox.Show("Changed Word " + i.ToString() + " from " + EE_WordsRead[i].ToString() + " to " + EE_WordsTemp[i].ToString());
                        }
                        StoreChip();
                    }
                }
            }
            else
            {
                MessageBox.Show("No Parameters Changed", "Write EEPROM", MessageBoxButtons.OK);
            }
        }

        private void buttonWriteParameters_Click(object sender, EventArgs e)
        {
            CopyParametersToTemp();
            // compare just for debugging
            bool ParamsChanged = false;
            string msg = "Change Parameters?\n";
            for (int i = 0; i < EEMaxParameters; i++)
            {   
                if (EE_ParamsTemp[i] != EE_ParamsRead[i])
                {
                    ParamsChanged = true;
                    msg = string.Concat(msg,"    " + EEParameterNames[i] + " from " + EE_ParamsRead[i].ToString() + " to " + EE_ParamsTemp[i].ToString()+"\n");
                }
            }
            if (ParamsChanged)
            {
                if (MessageBox.Show(msg, "Write EEPROM", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    // actually write
                    for (int i = 0; i < EEMaxWords; i++)
                    {
                        if (EE_WordsTemp[i] != EE_WordsRead[i])
                        {
                            WriteSRAM(i, EE_WordsTemp[i]);
                            MessageBox.Show("Changed Word " + i.ToString() + " from " + EE_WordsRead[i].ToString() + " to " + EE_WordsTemp[i].ToString());
                        }
                        StoreChip();
                    }
                }
            }
            else
            {
                MessageBox.Show("No Parameters Changed", "Write EEPROM", MessageBoxButtons.OK);
            }
        }

        private void CopyParametersToTemp()
        {
            for (int i = 0; i < EEMaxParameters; i++)
            {
                EE_ParamsTemp[i] = System.Convert.ToInt32(dataGridParam.Rows[i].Cells[1].Value);
            }
            ParametersToWords(EE_ParamsTemp, EE_WordsRead, EE_WordsTemp);
        }

        private void CopyWordsToTemp()
        {
            for (int i = 0; i < EEMaxWords; i++)
            {
                EE_WordsTemp[i] = System.Convert.ToInt32(dataGridEEPROM.Rows[i].Cells[1].Value);
            }
            // not sure if we should update parameters after changing words?
            WordsToParameters( EE_WordsTemp, EE_ParamsTemp);
        }

        private void WordsToParameters(int[] wordsin, int[] paramsout)
        {
            paramsout[0] = ((wordsin[0] & 0xF0) >> 4);
            paramsout[1] = ((wordsin[0] & 0x0F) << 16) + ((wordsin[1] & 0xFF) << 8) + (wordsin[2] & 0xFF);
            paramsout[2] = ((wordsin[3] & 0xFC) >> 2);
            paramsout[3] = ((wordsin[3] & 0x03) << 2) + ((wordsin[4] & 0xC0) >> 6);
            paramsout[4] = ((wordsin[4] & 0x3E) >> 1);
            paramsout[5] = (wordsin[4] & 0x01);
            paramsout[6] = (wordsin[5] & 0x03);
            paramsout[7] = (wordsin[6] & 0xFF);
            paramsout[8] = (wordsin[7] & 0xFF);
            paramsout[9] = (wordsin[8] & 0x7F);
            paramsout[10] = ((wordsin[9] & 0x40) >> 6);
            paramsout[11] = ((wordsin[9] & 0x1f) << 8) + wordsin[10];
            paramsout[12] = ((wordsin[11] & 0x07) << 3) + ((wordsin[12] & 0xE0) >> 5);
            paramsout[13] = (wordsin[12] & 0x1F);
            paramsout[14] = ((wordsin[13] & 0x80) >> 7);
            paramsout[15] = ((wordsin[13] & 0x40) >> 6);
            paramsout[16] = (wordsin[13] & 0x3F);
            paramsout[17] = ((wordsin[14] & 0x80) >> 7);
            paramsout[18] = (wordsin[14] & 0x3F);
            paramsout[19] = ((wordsin[15] & 0x60) >> 5);
            paramsout[20] = (wordsin[15] & 0x1F);
        }


        private void ParametersToWords(int[] paramsin, int[] wordsin, int [] wordsout)
        {

            // enum EEParameters { EE_LINE=0, EE_SERIAL=1, EE_YEAR=2, EE_MONTH=3, EE_DAY=4, EE_AMPM=5, EE_BAUD=6, EE_SPARE06=7, EE_SPARE07=8, 
            // EE_TC=9, EE_BFLIP=10, EE_SENS=11, EE_FOSC=12, EE_OFFTRIM=13, EE_ENTCPOS=14, EE_ENTCNEG=15, EE_BGTRIM=16, EE_PROGMODE1=17, EE_BIASTRIM=18, EE_TC2ND=19, EE_TEMPZ=20 };
            // Note: need to keep the unused bits the same!  use original  data from EE_Words_Read[]
            wordsout[0] = ((paramsin[0] & 0x0F) << 4) | ((paramsin[1] & 0x0F0000) >> 16);
            wordsout[1] = ((paramsin[1] & 0x00FF00) >> 8);
            wordsout[2] = (paramsin[1] & 0x0000FF);
            wordsout[3] = ((paramsin[2] & 0x3F) << 2) | ((paramsin[3] & 0x0C) >> 2);
            wordsout[4] = ((paramsin[3] & 0x03) << 6) | ((paramsin[4] & 0x1F) << 1) | (paramsin[5] & 0x01);
            wordsout[5] = (wordsin[5] & 0xFC) | (paramsin[6] & 0x03);
            wordsout[6] = (paramsin[7] & 0xFF);
            wordsout[7] = (paramsin[8] & 0xFF);
            wordsout[8] = (wordsin[8] & 0x80) | (paramsin[9] & 0x7F);
            wordsout[9] = (wordsin[9] & 0xA0) | ((paramsin[10] & 0x01) << 6) | ((paramsin[11] & 0x1F00) >> 8);
            wordsout[10] = (paramsin[11] & 0xFF);
            wordsout[11] = (EE_WordsRead[11] & 0xF8) | ((paramsin[12] & 0x38) >> 3);
            wordsout[12] = ((paramsin[12] & 0x07) << 5) | (paramsin[13] & 0x1F);
            wordsout[13] = ((paramsin[14] & 0x01) << 7) | ((paramsin[15] & 0x01) << 6) | (paramsin[16] & 0x3F);
            wordsout[14] = ((paramsin[17] & 0x01) << 7) | (EE_WordsRead[14] & 0x40) | (paramsin[18] & 0x3F);
            wordsout[15] = (EE_WordsRead[15] & 0x80) | ((paramsin[19] & 0x03) << 5) | (paramsin[20] & 0x1F);

        }

        private void buttonWriteSRAM_Click(object sender, EventArgs e)
        {

        }
        private void MeasureFromSRAM()
        {
        // assume that the EEPROM Read array is still valid
        // load the different parameters into RAM
        // send exit command
        // measure
        
        }



    }
}
