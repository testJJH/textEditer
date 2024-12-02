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
        private bool isDarkMode = false; // 다크 모드 상태 저장

        public Form1()
        {
            InitializeComponent();
        }

        private void 글꼴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
            richTextBox1.ForeColor = fontDialog1.Color;
        }

        private void 다크모드ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isDarkMode)
            {
                // 라이트 모드 설정
                this.BackColor = Color.White; // 폼 배경색
                richTextBox1.BackColor = Color.White; // RichTextBox 배경색
                richTextBox1.ForeColor = Color.Black; // RichTextBox 글꼴색
                menuStrip1.BackColor = Color.LightGray; // 메뉴스트립 배경색
                menuStrip1.ForeColor = Color.Black; // 메뉴스트립 글꼴색

                // 메뉴 텍스트 변경
                다크모드ToolStripMenuItem.Text = "다크 모드";

                isDarkMode = false;
            }
            else
            {
                // 다크 모드 설정
                this.BackColor = Color.FromArgb(30, 30, 30); // 폼 배경색
                richTextBox1.BackColor = Color.FromArgb(45, 45, 45); // RichTextBox 배경색
                richTextBox1.ForeColor = Color.White; // RichTextBox 글꼴색
                menuStrip1.BackColor = Color.FromArgb(45, 45, 45); // 메뉴스트립 배경색
                menuStrip1.ForeColor = Color.White; // 메뉴스트립 글꼴색

                // 메뉴 텍스트 변경
                다크모드ToolStripMenuItem.Text = "화이트 모드";

                isDarkMode = true;
            }
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            int line = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart) + 1; // 현재 줄 (1부터 시작)
            int column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexOfCurrentLine() + 1; // 현재 열 (1부터 시작)

            CursorPoint.Text = $"줄: {line}, 열: {column}";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int length = richTextBox1.TextLength; // 텍스트 총 길이
            TextLength.Text = $"길이: {length}자";
        }
    }
}
