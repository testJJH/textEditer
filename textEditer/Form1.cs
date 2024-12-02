using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace textEditer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 형광펜ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                if (richTextBox1.SelectionBackColor != Color.Yellow)
                    richTextBox1.SelectionBackColor = Color.Yellow; // 선택된 텍스트 배경색 설정
            }
            else
            {
                MessageBox.Show("텍스트를 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void 형광펜삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                if (richTextBox1.SelectionBackColor != richTextBox1.BackColor)
                    richTextBox1.SelectionBackColor = richTextBox1.BackColor; // 선택된 텍스트 배경색 초기화
            }
            else
            {
                MessageBox.Show("텍스트를 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
