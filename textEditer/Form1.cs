using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace textEditer
{
    public partial class Form1 : Form
    {
        private int searchStartIndex = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void 찾기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"{textBox1.Text}");
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("검색어를 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string searchText = textBox1.Text;
            string richText = richTextBox1.Text;

            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = richTextBox1.BackColor;
            richTextBox1.SelectionLength = 0; // 선택 초기화
            // 검색 시작
            if (searchStartIndex >= richText.Length)
            {
                MessageBox.Show("검색 결과가 더 이상 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchStartIndex = 0; // 검색 위치 초기화
                return;
            }
            // 검색어 위치 찾기
            int foundIndex = richText.IndexOf(searchText, searchStartIndex, StringComparison.OrdinalIgnoreCase);

            if (foundIndex != -1)
            {
                richTextBox1.Select(0, 0);

                // 검색된 텍스트 강조
                richTextBox1.Select(foundIndex, searchText.Length);
                richTextBox1.SelectionBackColor = Color.Yellow; //

                // 검색 시작 위치 업데이트 (다음 검색을 위해)
                searchStartIndex = foundIndex + searchText.Length;
            }
            else
            {
                MessageBox.Show("검색 결과가 더 이상 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchStartIndex = 0; // 검색 위치 초기화
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
    }
}
