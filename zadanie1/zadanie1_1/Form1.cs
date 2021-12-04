using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PDF_Reader {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) {

        }

        private void axAcroPDF1_Enter(object sender, EventArgs e) {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "Файлы pdf|*.pdf";
            openFileDialog1.ShowDialog();
            axAcroPDF1.LoadFile(openFileDialog1.FileName);
        }
    }
}
