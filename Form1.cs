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

        // C (Clear All) 버튼 클릭 이벤트
        private void ButtonClearAll_Click(object sender, EventArgs e)
        {
            // 계산기의 모든 상태와 텍스트를 처음 상태로 되돌림
            num1 = 0;
            num2 = 0;
            currentOperator = "";
            InputAndResultTxt.Text = "";
            HistoryTxt.Text = "";

            isNewInput = true;
            isResultDisplayed = false;
        }

        // CE (Clear Entry) 버튼 클릭 이벤트
        private void ButtonClearEntry_Click(object sender, EventArgs e)
        {
            // 계산이 완료된 직후라면 C버튼처럼 전체를 초기화
            if (isResultDisplayed)
            {
                ButtonClearAll_Click(sender, e);
                return;
            }

            // 그렇지 않다면 현재 입력 중이던 피연산자 화면만 지움
            InputAndResultTxt.Text = "";
            isNewInput = true;
        }

        // del (백스페이스) 버튼 클릭 이벤트
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            // 화면이 비어있거나, 계산 결과가 띄워져 있는 상태라면 지우기를 무시
            if (InputAndResultTxt.Text == "" || isResultDisplayed) return;

            // 현재 텍스트의 길이가 1 이상일 때, 맨 마지막 글자 하나를 잘라냄
            if (InputAndResultTxt.Text.Length > 0)
            {
                InputAndResultTxt.Text = InputAndResultTxt.Text.Substring(0, InputAndResultTxt.Text.Length - 1);
            }
        }

        // +/- (부호 반전) 버튼 클릭 이벤트
        private void ButtonNegate_Click(object sender, EventArgs e)
        {
            // 입력창이 비어있지 않고, "0"이 아닐 때만 작동
            if (InputAndResultTxt.Text != "" && InputAndResultTxt.Text != "0")
            {
                double currentNum = double.Parse(InputAndResultTxt.Text);
                currentNum = currentNum * -1; // -1을 곱해 부호 반전

                // 다시 문자열로 변환하여 창에 띄움
                InputAndResultTxt.Text = currentNum.ToString("g10");
            }
        }

        // . (소수점) 버튼 클릭 이벤트
        private void ButtonComma_Click(object sender, EventArgs e)
        {
            // 1. 방금 계산이 끝났거나 새로 입력해야 하는 상태일 때 누르면 "0."으로 시작
            if (isResultDisplayed || isNewInput || InputAndResultTxt.Text == "")
            {
                if (isResultDisplayed)
                {
                    HistoryTxt.Clear();
                    num1 = 0;
                    num2 = 0;
                    currentOperator = "";
                    isResultDisplayed = false;
                }

                InputAndResultTxt.Text = "0.";
                isNewInput = false;
            }
            // 2. 입력 중인 숫자에 소수점이 아직 없는 경우에만 소수점 추가 (예: "1.2.3" 방지)
            else if (!InputAndResultTxt.Text.Contains("."))
            {
                InputAndResultTxt.Text += ".";
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