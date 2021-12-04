﻿using System;
using System.Windows.Forms;

namespace WinAsynchMethod {
    public partial class Form1 : Form {
        private delegate int AsyncSumm(int a, int b);
        public Form1() {
            InitializeComponent();
        }

        private int Summ(int a, int b) {
            System.Threading.Thread.Sleep(9000);
            return a + b;
        }

        private void CallBackMethod(IAsyncResult ar) {
            AsyncSumm summdelegate = (AsyncSumm)ar.AsyncState;
            MessageBox.Show($"Сумма введенных чисел равна {summdelegate.EndInvoke(ar)}", "Результат операции");
        }

        private void btnWork_Click(object sender, EventArgs e) {
            MessageBox.Show("Работа кипит!!!");
        }

        private void btnRun_Click(object sender, System.EventArgs e) {
            int a, b;

            try {
                a = int.Parse(txbA.Text);
                b = int.Parse(txbB.Text);
            }
            catch (Exception) {
                MessageBox.Show("При выполнении преобразования типов возникла ошибка");

                txbA.Text = txbB.Text = "";
                return;
            }

            AsyncSumm summdelegate = new AsyncSumm(Summ);
            AsyncCallback cb = new AsyncCallback(CallBackMethod);
            summdelegate.BeginInvoke(a, b, cb, summdelegate);
        }
    }
}