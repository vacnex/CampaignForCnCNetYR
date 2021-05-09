using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Yuri_s_Revenge___Campaign
{
    class Program
    {
        static string cncnet5 = "cncnet5.dll";
        static string spawn = "spawn.ini";
        static string newcncnet5 = "cncnet5.no";
        static string newspawn = "Nospawn.ini";
        static void Main(string[] args)
        {
            if (IsFileExist(cncnet5) && IsFileExist(spawn))
            {
                Rename(cncnet5, newcncnet5);
                Rename(spawn, newspawn);
                RunAres();
            }
            else
                RunAres();
        }
        static private bool IsFileExist(string filename)
        {
            if (File.Exists(filename))
                return true;
            return false;
        }
        static private void Rename(string fileName, string newFileName)
        {
            File.Move(fileName, newFileName);
        }
        static private void RunAres()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C Syringe \"gamemd.exe\" -CD";
            process.StartInfo = startInfo;
            process.Start();
            bool Running = true;
            while (Running)
                if (process.HasExited)
                {
                    Rename(newcncnet5, cncnet5);
                    Rename(newspawn, spawn);
                    Running = false;
                }
        }
    }
}
