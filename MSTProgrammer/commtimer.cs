﻿// automatically generated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// I added
using System.Timers;
namespace MSTProgrammer
{
    public class CommTimer
    {
        public Timer tmrComm = new Timer();        // millisecond timer
        public bool timedout = false;
        public CommTimer()
        {
            timedout = false;
            tmrComm.AutoReset = false;
            tmrComm.Enabled = false;
            tmrComm.Interval = 1000; //default to 1 second
            tmrComm.Elapsed += new ElapsedEventHandler(OnTimedCommEvent);
        }

        public void OnTimedCommEvent(object source, ElapsedEventArgs e)
        {
            timedout = true;
            tmrComm.Stop();
        }

        public void Start(double timeoutperiod)
        {
            tmrComm.Interval = timeoutperiod;             //time to time out in milliseconds
            tmrComm.Stop();
            timedout = false;
            tmrComm.Start();
        }
    }
}
/*
        public void SendReceiveData()
        {
            byte[] cmdByteArray = new byte[1];
            SerialObj.DiscardInBuffer();
            SerialObj.DiscardOutBuffer();

            //send         
            cmdByteArray[0] = 0x7a;
            SerialObj.Write(cmdByteArray, 0, 1);

            CommTimer tmrComm = new CommTimer();
            tmrComm.Start(4000);
            while ((SerialObj.BytesToRead == 0) && (tmrComm.timedout == false))
            {
                Application.DoEvents();
            }
            if (SerialObj.BytesToRead > 0)
            {
                byte[] inbyte = new byte[1];
                SerialObj.Read(inbyte, 0, 1);
                if (inbyte.Length > 0)
                {
                    byte value = (byte)inbyte.GetValue(0);
                    //do other necessary processing you may want. 
                }
            }
            tmrComm.tmrComm.Dispose();
            SerialObj.DiscardInBuffer();
            SerialObj.DiscardOutBuffer();
            SerialObj.Close();
        }
    }
}
*/