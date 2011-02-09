using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace FXBC
{
    class ConsoleCommand
    {
        public void Execute(string fileName, string arguments, string working_directory, int timeout, string standardInputData)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = fileName;
                if (arguments != null)
                    process.StartInfo.Arguments = arguments;
                if (working_directory != null)
                    process.StartInfo.WorkingDirectory = working_directory;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                if (standardInputData != null)
                {
                    process.StandardInput.Write(standardInputData);
                    process.StandardInput.Close();
                }

                DateTime end_time = DateTime.Now + TimeSpan.FromMilliseconds((double)timeout);
                bool process_exit = false, output_end = false, error_end = false;
                for (; ; )
                {
                    if (!output_end)
                    {
                        if (process.StandardOutput.EndOfStream)
                            output_end = true;
                        else
                            m_StandardOutputData.Append(process.StandardOutput.ReadToEnd());
                    }

                    if (!error_end)
                    {
                        if (process.StandardError.EndOfStream)
                            error_end = true;
                        else
                            m_StandardErrorData.Append(process.StandardError.ReadToEnd());
                    }

                    if (!process_exit)
                        process_exit = process.WaitForExit(0);

                    if (DateTime.Now > end_time)
                    {
                        process.Close();
                        throw new Exception("Process execution timeout.");
                    }

                    if (process_exit && output_end && error_end)
                        break;                       

                    System.Threading.Thread.Yield();
                }

                m_ExitCode = process.ExitCode;
            }
        }

        public int ExitCode { get { return m_ExitCode; } }
        public string StandardOutputData { get { return m_StandardOutputData.ToString(); } }
        public string StandardErrorData { get { return m_StandardErrorData.ToString(); } }

        private int m_ExitCode;
        private StringBuilder m_StandardOutputData = new StringBuilder();
        private StringBuilder m_StandardErrorData = new StringBuilder();
    }
}
