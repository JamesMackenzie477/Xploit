using System;
using System.Windows.Forms;

namespace Xploit
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void openProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Opens a new process list form.
            new ProcessWindow().Show();
        }
    }
}
