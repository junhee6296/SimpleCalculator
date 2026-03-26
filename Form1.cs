using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        // 계산 연산 변수
        double num1 = 0;
        double num2 = 0;
        // 연산자 체킹
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

        // 빼기(−) 버튼 클릭 이벤트
        private void ButtonMinus_Click(object sender, EventArgs e)
        {
            if (InputAndResultTxt.Text != "")
            {
                num1 = double.Parse(InputAndResultTxt.Text);
                currentOperator = "−"; // 특수기호 주의
                HistoryTxt.Text = num1.ToString() + " − ";
                isNewInput = true;
                isResultDisplayed = false;
            }
        }

        // 곱하기(×) 버튼 클릭 이벤트
        private void ButtonTimes_Click(object sender, EventArgs e)
        {
            if (InputAndResultTxt.Text != "")
            {
                num1 = double.Parse(InputAndResultTxt.Text);
                currentOperator = "×";
                HistoryTxt.Text = num1.ToString() + " × ";
                isNewInput = true;
                isResultDisplayed = false;
            }
        }

        // 나누기(÷) 버튼 클릭 이벤트
        private void ButtonObelus_Click(object sender, EventArgs e)
        {
            if (InputAndResultTxt.Text != "")
            {
                num1 = double.Parse(InputAndResultTxt.Text);
                currentOperator = "÷";
                HistoryTxt.Text = num1.ToString() + " ÷ ";
                isNewInput = true;
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

                // 선택된 연산자에 따라 사칙연산 수행
                if (currentOperator == "+") result = num1 + num2;
                else if (currentOperator == "−") result = num1 - num2;
                else if (currentOperator == "×") result = num1 * num2;
                else if (currentOperator == "÷")
                {
                    // 0으로 나누기 방어 로직
                    if (num2 == 0)
                    {
                        InputAndResultTxt.Text = "0으로 나눌 수 없습니다";
                        HistoryTxt.Text = num1.ToString() + " ÷ 0 =";
                        isNewInput = true;
                        isResultDisplayed = true;
                        currentOperator = "";
                        return; // 여기서 함수를 종료시켜버림
                    }
                    result = num1 / num2;
                }

                // 히스토리 창에 전체 수식 표시
                HistoryTxt.Text = num1.ToString() + " " + currentOperator + " " + num2.ToString() + " = ";

                // 결과를 메인 창에 표시 (최대 10자리 & e 표기법 적용)
                InputAndResultTxt.Text = result.ToString("g10");

                isNewInput = true;
                isResultDisplayed = true;
                currentOperator = "";
            }
        }
    }
}