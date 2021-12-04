using System;
using System.Windows.Forms;

namespace WinAsynchDelegate {
    public partial class Form1 : Form {
        private delegate void TimeConsumingMethodDelegate(int seconds);
        public delegate void SetProgressDelegate(int val);

        private bool Cancel { get; set; } = false;

        public Form1() {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar)) {
                e.Handled = true;
                MessageBox.Show("Поле должно содержать цифры");
            }
        }

        private void TimeConsumingMethod(int seconds)
        {
            for (int j = 1; j <= seconds; j++) {
                if (Cancel) {
                    break;
                }

                SetProgress((int)(j * 100) / seconds);
                System.Threading.Thread.Sleep(1000);
            }

            if (Cancel) {
                MessageBox.Show("Cancelled");
                Cancel = false;
            }
            else {
                MessageBox.Show("Complete");
            }
        }

        public void SetProgress(int val) {
            if (progressBar1.InvokeRequired) {
                SetProgressDelegate del = new SetProgressDelegate(SetProgress);
                this.Invoke(del, new object[] { val });
            }
        else {
                progressBar1.Value = val;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            TimeConsumingMethodDelegate del = new TimeConsumingMethodDelegate(TimeConsumingMethod);
            del.BeginInvoke(int.Parse(textBox1.Text), null, null);
        }

        private void button2_Click(object sender, EventArgs e) {
            Cancel = true;
        }
    }
}