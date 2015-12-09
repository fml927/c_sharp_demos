using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thread_poll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }


        static int i = 0;

        Func<System.Threading.Tasks.Task> taskFunc = () =>
        {
               return System.Threading.Tasks.Task.Run(
                   () =>
                   {
                        System.Threading.Thread.Sleep(10000);  //模拟耗时较长的任务
                        i += 1;
                   }
               );
         };

        private async void button1_Click(object sender, EventArgs e)
        {
            await taskFunc(); //耗时较长的处理程序

            button1.Text = i.ToString();  //此处会立即执行 最终显示的是初始值
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.Text = i.ToString();  //刷新 异步执行结果
        }
    }
}
