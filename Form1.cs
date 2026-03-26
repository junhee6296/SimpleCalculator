using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        // 1. int 대신 더 큰 숫자와 소수점을 다룰 수 있는 double로 변경
        double num1 = 0;
        double num2 = 0;
        string currentOperator = "";

        // 연산자 누른 직후 새 입력을 받을지 결정하는 플래그
        bool isNewInput = true;

        // '=' 버튼을 눌러서 결과가 나와 있는 상태인지 확인하는 플래그
        bool isResultDisplayed = false;

        public Form1()
        {
            InitializeComponent();
        }

        // 숫자 버튼 클릭 이벤트 (0~9)
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // '=' 누른 직후 연산자 없이 바로 숫자를 누르면 '완전 초기화' 후 새 숫자 입력
            if (isResultDisplayed)
            {
                HistoryTxt.Clear();
                InputAndResultTxt.Clear();
                num1 = 0;
                num2 = 0;
                currentOperator = "";
                isResultDisplayed = false; // 초기화했으므로 플래그 해제
                isNewInput = true;
            }

            // 연산자를 눌렀거나 방금 초기화되어서 화면을 비워야 하는 경우
            if (isNewInput)
            {
                InputAndResultTxt.Text = "";
                isNewInput = false;
            }

            // 클릭된 버튼의 숫자를 이어붙임 (MaxLength 속성 덕분에 15자리 이상은 안 써짐)
            InputAndResultTxt.Text += btn.Text;
        }

        // 더하기(+) 버튼 클릭 이벤트
        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            if (InputAndResultTxt.Text != "")
            {
                // int.Parse 대신 double.Parse 사용
                num1 = double.Parse(InputAndResultTxt.Text);
                currentOperator = "+";

                HistoryTxt.Text = num1.ToString() + " + ";

                isNewInput = true;

                // ★ 연산자를 눌렀으므로, 계산을 이어나가는 상태임 (초기화 방지)
                isResultDisplayed = false;
            }
        }

        // 결과(=) 버튼 클릭 이벤트
        private void ButtonResult_Click(object sender, EventArgs e)
        {
            if (InputAndResultTxt.Text != "" && currentOperator != "")
            {
                num2 = double.Parse(InputAndResultTxt.Text);
                double result = 0;

                if (currentOperator == "+")
                {
                    result = num1 + num2;
                }

                HistoryTxt.Text = num1.ToString() + " + " + num2.ToString() + " = ";

                // 범위초과 e단위 치환
                InputAndResultTxt.Text = result.ToString("g10");

                isNewInput = true;

                // = 으로 인한 결과 표시를 true로 하여 초기화상태 설정
                isResultDisplayed = true;
                currentOperator = "";
            }
        }
    }
}