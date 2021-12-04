using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinAnim {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        public class WinAPIClass {
            #region Анимация окна
            [Flags]
            public enum AnimateWindowFlags : int {
                AW_HOR_POSITIVE = 1,
                AW_HOR_NEGATIVE = 2,
                AW_VER_POSITIVE = 4,
                AW_VER_NEGATive = 8,
                AW_CENTER = 16,
                AW_HIDE = 65536,
                AW_ACTIVATE = 131072,
                AW_SLIDE = 262144,
                AW_BLEND = 524288,
            };
            [DllImportAttribute("user32.dll", EntryPoint = "AnimateWindow", SetLastError = true)]
            public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
            public static bool AnimateWindow(Control ctrl, int dwTime, AnimateWindowFlags Flags) {
                return AnimateWindow(ctrl.Handle, dwTime, (int)Flags);
                #endregion
            }
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void btnAW_BLEND_CLICK(object sender, EventArgs e) {
            this.Hide();
            WinAPIClass.AnimateWindow(this, 3000, WinAPIClass.AnimateWindowFlags.AW_ACTIVATE | WinAPIClass.AnimateWindowFlags.AW_BLEND);
            this.btnAW_BLEND.Invalidate();
            this.btnHOR_AW_SLIDE.Invalidate();
            this.btnCenter_AW_SLIDE.Invalidate();
        }

        private void btnHOR_AW_SLIDE_Click(object sender, EventArgs e) {
            this.Hide();
            WinAPIClass.AnimateWindow(this, 3000, WinAPIClass.AnimateWindowFlags.AW_HOR_POSITIVE | WinAPIClass.AnimateWindowFlags.AW_SLIDE);
            this.btnAW_BLEND.Invalidate();
            this.btnHOR_AW_SLIDE.Invalidate();
            this.btnCenter_AW_SLIDE.Invalidate();
        }

        private void btnCenter_AW_SLIDE_Click(object sender, EventArgs e) {
            this.Hide();
            WinAPIClass.AnimateWindow(this, 3000, WinAPIClass.AnimateWindowFlags.AW_CENTER | WinAPIClass.AnimateWindowFlags.AW_SLIDE);
            this.btnAW_BLEND.Invalidate();
            this.btnHOR_AW_SLIDE.Invalidate();
            this.btnCenter_AW_SLIDE.Invalidate();
        }
    }
}
