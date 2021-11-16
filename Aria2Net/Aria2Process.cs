using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Aria2Net
{
    public class Aria2Process : IDisposable
    {
        private Process _process;
        private readonly string _file;
        private readonly string _arguments;

        public Aria2Process(string file, string arguments)
        {
            _file = file;
            _arguments = arguments;
        }

        public void Start()
        {
            EnsureKillExistAria2Process();

            var workDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            if (!File.Exists(_file))
                throw new FileNotFoundException(_file);

            var info = new ProcessStartInfo
            {
                FileName = _file,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                ErrorDialog = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                WorkingDirectory = workDir,
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = _arguments,
            };

            _process = new Process
            {
                StartInfo = info,
            };

            _process.Start();
        }

        public void Stop()
        {
            _process?.Kill();
            _process?.Dispose();
        }

        public void Dispose()
        {
            Stop();
        }

        private void EnsureKillExistAria2Process()
        {
            var process = Process.GetProcesses().FirstOrDefault(x => x.ProcessName.Contains(Path.GetFileNameWithoutExtension(_file)));

            if (process == null)
                return;

            if (process.MainModule.FileName != _file)
                return;

            try
            {
                process.Kill();
                process?.Dispose();
            }
            catch (Exception)
            {
                // 
            }
        }
    }
}
