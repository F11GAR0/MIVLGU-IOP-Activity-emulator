using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIVLGU_IOP_Activity_emulator
{
    public partial class MainForm : Form
    {
        Emulator emul = new Emulator();
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void bStart_Click(object sender, EventArgs e)
        {
            emul.TryLogin("pks-117-student14", "fktrcfylh2A_");
        }
    }
}
