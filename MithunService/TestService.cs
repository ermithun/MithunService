using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MithunService
{
    public partial class TestService : ServiceBase
    {
        System.Timers.Timer timeDelay;
        int count;  
        public TestService()
        {
            InitializeComponent();
            timeDelay = new System.Timers.Timer();
            timeDelay.Elapsed += new System.Timers.ElapsedEventHandler(WorkProcess);
        }

        private void WorkProcess(object sender, System.Timers.ElapsedEventArgs e)
        {
            string process = "Timer Tick " + count;
            
            LogService(process);
            count++; 
        }

        private void LogService(string process)
        {
            // FileStream fs = new FileStream(@"d:\TestServiceLog.txt", FileMode.OpenOrCreate, FileAccess.Write);  
            //StreamWriter sw = new StreamWriter(fs);  
            //sw.BaseStream.Seek(0, SeekOrigin.End);  
            //sw.WriteLine(process);  
            //sw.Flush();  
            //sw.Close(); 
            System.Diagnostics.Process process1 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.WorkingDirectory = @"D:";
            string folder = "back"+System.DateTime.Now.ToShortDateString();
            startInfo.Arguments = "mkdir xxxxxxx";
            process1.StartInfo = startInfo;
            process1.Start();
        }

        protected override void OnStart(string[] args)
        {
            LogService("Service is Started");
            timeDelay.Enabled = true;
        }
        protected override void OnStop()
        {
            LogService("Service Stoped");
            timeDelay.Enabled = false;
        }  
    }
}
