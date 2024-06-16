using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xploit
{
    public partial class ProcessWindow : Form
    {
        /// <summary>
        /// Contains the selected process.
        /// </summary>
        public Process SelectedProcess;

        /// <summary>
        /// Constructs the process window.
        /// </summary>
        public ProcessWindow()
        {
            // Generated component initialization.
            InitializeComponent();
        }

        /// <summary>
        /// Loads the processes into the process list.
        /// </summary>
        private void LoadProcesses()
        {
            // Sets the debug privilege to view more processes.
            // ExploitTools.SetDebugPrivilege(WinApi.GetCurrentProcess(), true);
            // Gets all of the system processes.
            Process[] Processes = Process.GetProcesses();
            // Iterates through the processes.
            foreach (Process process in Processes)
            {
                // Adds the process to the process list.
                processList.Items.Add(new ListViewItem(new string[] { process.Id.ToString(), process.ProcessName }));
            }
            // Removes the debug privilege.
            // ExploitTools.SetDebugPrivilege(WinApi.GetCurrentProcess(), false);
        }

        private void processList_DoubleClick(object sender, EventArgs e)
        {
            openButton_Click(sender, e);
        }

        private void ProcessWindow_Load(object sender, EventArgs e)
        {
            // Populates the process list.
            LoadProcesses();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Closes the form.
            Close();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            // Sets the selected process.
            ExploitTools.GetProcessHandle(Convert.ToInt32(processList.SelectedItems[0].Text), ProcessAccessFlags.FullControl);
            // Closes the form.
            Close();
        }
    }
}
