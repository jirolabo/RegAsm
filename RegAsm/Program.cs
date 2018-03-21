using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace RegAsmExecute
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), "RegAsm.exe");
            using (var process = new Process())
            {
                process.StartInfo.FileName = path;
                process.StartInfo.Arguments = String.Join(" ", args);
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                process.Start();
                process.WaitForExit();
                var output = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();
                process.Close();

                Console.Write(output);
                Console.Write(error);
            }
        }
    }
}
