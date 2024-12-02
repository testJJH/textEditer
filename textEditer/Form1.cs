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
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("검색어를 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("바꿀 내용을 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string searchText = textBox2.Text; // 검색할 텍스트
            string replaceText = textBox3.Text; // 교체할 텍스트
            string richText = richTextBox1.Text; // RichTextBox의 전체 텍스트

            int startIndex = 0; // 검색 시작 위치
            bool found = false; // 검색 결과 여부

            while (startIndex < richText.Length)
            {
                // 검색어 위치 찾기
                int foundIndex = richText.IndexOf(searchText, startIndex, StringComparison.OrdinalIgnoreCase);

                if (foundIndex != -1)
                {
                    // 검색된 텍스트 선택
                    richTextBox1.Select(foundIndex, searchText.Length);

                    // 선택된 텍스트를 교체
                    richTextBox1.SelectedText = replaceText;

                    // 다음 검색을 위해 시작 위치 업데이트
                    startIndex = foundIndex + replaceText.Length;

                    found = true;
                }
                else
                {
                    break; // 더 이상 검색 결과가 없으면 종료
                }
            }

            if (!found)
            {
                MessageBox.Show("검색 결과가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void 바꾸기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel2.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("검색어를 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("바꿀 내용을 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string searchText = textBox2.Text; // 검색할 텍스트
            string replaceText = textBox3.Text; // 교체할 텍스트

            int startIndex = 0; // 검색 시작 위치
            bool found = false; // 검색 결과 여부

            while (startIndex < richTextBox1.TextLength)
            {
                // 검색어 위치 찾기
                int foundIndex = richTextBox1.Text.IndexOf(searchText, startIndex, StringComparison.OrdinalIgnoreCase);

                if (foundIndex != -1)
                {
                    // 검색된 텍스트 선택
                    richTextBox1.Select(foundIndex, searchText.Length);

                    // 선택된 텍스트를 교체
                    richTextBox1.SelectedText = replaceText;

                    // 다음 검색 시작 위치 업데이트
                    startIndex = foundIndex + replaceText.Length;

                    found = true;
                }
                else
                {
                    break; // 더 이상 검색 결과가 없으면 종료
                }
            }

            if (!found)
            {
                MessageBox.Show("검색 결과가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
    }
}
