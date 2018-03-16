using OnymojiAuto.Code.Hooks;
using OnymojiAuto.Code.Sample;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OnymojiAuto.Code.Hooks.HookHelper;

namespace OnymojiAuto.Code.UI
{
    public partial class MainForm : Form
    {
        private MouseHookGlobal mouseHook;

        public MainForm()
        {
            InitializeComponent();
            mouseHook = new MouseHookGlobal();
            mouseHook.MouseAction += (MouseMessages mouseMessage, int x, int y) =>
            {
                txtData.Text = getStateMouse(mouseMessage) + " " + "x: " + x + " y: " + y;
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mouseHook.Install();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mouseHook.StopHook();
        }

        ReactiveX rx = new ReactiveX();
        private void button3_Click(object sender, EventArgs e)
        {
            rx.test();
        }
    }
}
