using System.Diagnostics;

namespace ServUOControlUI
{
    internal static class ServUOControlUtility
    {
        private static Dictionary<RichTextBox, string> RTBList { get; set; } = [];

        internal static void AddRTB(RichTextBox rtb, string file)
        {
            if (!RTBList.TryAdd(rtb, file))
            {
                RTBList[rtb] = file;
            }
        }

        public static string ShowFolderBrowserDialog()
        {
            using (FolderBrowserDialog folderBrowserDialog = new())
            {
                folderBrowserDialog.Description = "Select ServUO folder:";

                folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    return folderBrowserDialog.SelectedPath;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        internal static void ApplyBoldFormatting(RichTextBox rtb)
        {
            for (int i = 0; i < rtb.Lines.Length; i++)
            {
                string line = rtb.Lines[i];

                if (!line.StartsWith("#"))
                {
                    rtb.Select(rtb.GetFirstCharIndexFromLine(i), line.Length);

                    rtb.SelectionFont = new Font(rtb.Font, FontStyle.Bold);
                }
            }
        }

        internal static bool IsAppRunning(string appName)
        {
            Process[] processes = Process.GetProcessesByName(appName);

            return processes.Length > 0;
        }

        internal static void RunProcess(string loc)
        {
            try
            {
                if (loc.StartsWith("http"))
                {
                    Process.Start(new ProcessStartInfo(loc) { UseShellExecute = true });
                }
                else
                {
                    Process.Start(loc);
                }
            }
            catch (Exception ex)
            {
                SendError(ex.Message);
            }
        }

        internal static void SaveFiles()
        {
            if (RTBList.Count > 0 && !string.IsNullOrEmpty(Properties.ServUOInfo.Default.ServUODir))
            {
                try
                {
                    foreach (var pair in RTBList)
                    {
                        File.WriteAllText(Path.Combine(Properties.ServUOInfo.Default.ServUODir, "Config", pair.Value), pair.Key.Text);
                    }
                }
                catch (Exception ex)
                {
                    SendError(ex.Message);
                }
            }
        }

        internal static void SendError(string message)
        {
            MessageBox.Show($"Error: {message}");
        }

        internal static void SendMessageRunning(string name)
        {
            MessageBox.Show($"{name} already started!");
        }
    }
}
