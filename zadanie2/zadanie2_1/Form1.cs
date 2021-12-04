using System;
using System.Windows.Forms;

namespace WinBackgroundWorker {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

            }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Поле должно содержать цифры");
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
            int i;
            i = int.Parse(e.Argument.ToString());
            for (int j=1; j <= i; j++) {
                if (backgroundWorker1.CancellationPending) {
                    e.Cancel = true;
                    return;
                }
                System.Threading.Thread.Sleep(1000);
                backgroundWorker1.ReportProgress((int)(j * 100 / i));
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e) {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
            if (!(e.Cancelled))
                System.Windows.Forms.MessageBox.Show("Run Completed!");
            else
                System.Windows.Forms.MessageBox.Show("Run Cancelled");
        }
        private void button1_Click(object sender, EventArgs e) {
            if (!(textBox1.Text == "")) {
                int i = int.Parse(textBox1.Text);
                backgroundWorker1.RunWorkerAsync(i);
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
