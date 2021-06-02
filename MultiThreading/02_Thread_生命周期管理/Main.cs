using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_Thread_生命周期管理
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        Thread thread = null;
        int index = 0;
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (null == thread)
            {
                thread = new Thread(new ThreadStart(() =>
                {
                    while (true)
                    {
                        try
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(1));
                            txtNumber.Invoke(new Action(() =>
                            {
                                txtNumber.AppendText($"{ index++},");
                            }));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"{ex.Message}, { index++}");
                        }
                    }
                }));

                thread.Start();
            }

        }

        [Obsolete]
        private void btnSuspend_Click(object sender, EventArgs e)
        {
            if (null != thread && thread.ThreadState == ThreadState.Running || thread.ThreadState == ThreadState.WaitSleepJoin)
            {
                thread.Suspend();
            }
        }

        [Obsolete]
        private void btnResume_Click(object sender, EventArgs e)
        {
            if (null != thread && thread.ThreadState == ThreadState.Suspended)
            {
                thread.Resume();
            }
        }

        private void btnInterrupt_Click(object sender, EventArgs e)
        {
            if (null != thread)
            {
                thread.Interrupt();
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            if (null != thread)
            {
                thread.Abort();
            }
        }
    }
}
