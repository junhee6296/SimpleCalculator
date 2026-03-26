using System;
using System.Globalization;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        // 계산 연산 변수
        decimal num1 = 0;
        decimal num2 = 0;
        // 연산자 체킹
        string currentOperator = "";
        //실제 계산(e단위아닌)
        string rawInput = "";

        // 연산자 누른 직후 새 입력을 받을지 결정하는 플래그
        bool isNewInput = true;

        // '=' 버튼을 눌러서 결과가 나와 있는 상태인지 확인하는 플래그
        bool isResultDisplayed = false;

        public Form1()
        {
            InitializeComponent();
        }

        // 객체 클래스도 decimal로 자료형 변경
        public class CalculationHistory
        {
            public decimal Num1 { get; set; }
            public decimal Num2 { get; set; }
            public string Operator { get; set; }
            public decimal Result { get; set; }
            public string Expression { get; set; }

            public override string ToString()
            {
                return Expression + " " + Result.ToString();
            }
        }
        private void KeyDownCalc(object sender, KeyEventArgs e)
        {
            // 숫자 키 (상단 숫자키 & 우측 숫자 키패드)
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0) NumberZero.PerformClick();
            else if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1) NumberOne.PerformClick();
            else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2) NumberTwo.PerformClick();
            else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3) NumberThree.PerformClick();
            else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4) NumberFour.PerformClick();
            else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5) NumberFive.PerformClick();
            else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6) NumberSix.PerformClick();
            else if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7) NumberSeven.PerformClick();
            else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8) NumberEight.PerformClick();
            else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9) NumberNine.PerformClick();

            // 연산자 및 특수 키 (Shift 조합 포함)
            else if (e.KeyCode == Keys.Add || (e.Shift && e.KeyCode == Keys.Oemplus)) ButtonPlus.PerformClick();
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus) ButtonMinus.PerformClick();
            else if (e.KeyCode == Keys.Multiply || (e.Shift && e.KeyCode == Keys.D8)) ButtonTimes.PerformClick();
            else if (e.KeyCode == Keys.Divide || e.KeyCode == Keys.OemQuestion) ButtonObelus.PerformClick();
            else if (e.KeyCode == Keys.Enter || (!e.Shift && e.KeyCode == Keys.Oemplus)) ButtonResult.PerformClick();
            else if (e.KeyCode == Keys.Back) ButtonDel.PerformClick();
            else if (e.KeyCode == Keys.Escape) ButtonClearAll.PerformClick();
            else if (e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod) ButtonComma.PerformClick();
        }

        // 숫자 버튼 클릭 이벤트 (0~9)
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (isResultDisplayed)
            {
                HistoryTxt.Clear();
                rawInput = ""; // ★ 화면 대신 내부 데이터 비우기
                num1 = 0; num2 = 0; currentOperator = "";
                isResultDisplayed = false; isNewInput = true;
            }
            if (isNewInput)
            {
                rawInput = ""; // ★ 내부 데이터 비우기
                isNewInput = false;
            }

            rawInput += btn.Text; // ★ 내부 데이터에 숫자 추가
            InputAndResultTxt.Text = rawInput; // 화면에는 추가된 결과를 그대로 표시
        }

        // 더하기(+) 버튼 클릭 이벤트
        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            if (rawInput != "") // ★ 텍스트박스 대신 내부 데이터 확인
            {
                num1 = decimal.Parse(rawInput);
                currentOperator = "+";

                // 위쪽 창에 표시할 때만 "g10" 적용
                HistoryTxt.Text = num1.ToString("g10") + " + ";
                isNewInput = true; isResultDisplayed = false;
            }
        }

        // 빼기(−) 버튼 
        private void ButtonMinus_Click(object sender, EventArgs e)
        {
            if (rawInput != "") // 화면 텍스트가 아닌 실제 데이터를 확인
            {
                num1 = decimal.Parse(rawInput);
                currentOperator = "−";

                // 화면에 보여줄 때만 "g10" 포맷 적용
                HistoryTxt.Text = num1.ToString("g10") + " − ";

                isNewInput = true;
                isResultDisplayed = false;
            }
        }

        // 곱하기(×) 버튼
        private void ButtonTimes_Click(object sender, EventArgs e)
        {
            if (rawInput != "")
            {
                num1 = decimal.Parse(rawInput);
                currentOperator = "×";

                HistoryTxt.Text = num1.ToString("g10") + " × ";

                isNewInput = true;
                isResultDisplayed = false;
            }
        }

        // 나누기(÷) 버튼
        private void ButtonObelus_Click(object sender, EventArgs e)
        {
            if (rawInput != "")
            {
                num1 = decimal.Parse(rawInput);
                currentOperator = "÷";

                HistoryTxt.Text = num1.ToString("g10") + " ÷ ";

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
            if (rawInput != "" && rawInput != "0")
            {
                decimal currentNum = decimal.Parse(rawInput); // ★ 에러 발생 안 함
                currentNum = currentNum * -1;

                rawInput = currentNum.ToString(); // ★ 내부 데이터 업데이트 (포맷 없음)
                InputAndResultTxt.Text = currentNum.ToString("g10"); // 화면에만 포맷 적용
            }
        }

        // . (소수점) 버튼 클릭 이벤트
        private void ButtonComma_Click(object sender, EventArgs e)
        {
            // 1. 방금 계산이 끝났거나 새로 입력해야 하는 상태일 때 누르면 "0."으로 시작
            if (isResultDisplayed || isNewInput || rawInput == "")
            {
                if (isResultDisplayed)
                {
                    HistoryTxt.Clear();
                    num1 = 0;
                    num2 = 0;
                    currentOperator = "";
                    isResultDisplayed = false;
                }

                // ★ 핵심: 내부 데이터인 rawInput에 먼저 저장!
                rawInput = "0.";
                InputAndResultTxt.Text = rawInput;
                isNewInput = false;
            }
            // 2. 입력 중인 숫자에 소수점이 아직 없는 경우에만 추가
            else if (!rawInput.Contains("."))
            {
                // ★ 핵심: 내부 데이터인 rawInput에 소수점 추가!
                rawInput += ".";
                InputAndResultTxt.Text = rawInput; // 화면 갱신
            }
        }

        // 결과(=) 버튼 클릭 이벤트
        private void ButtonResult_Click(object sender, EventArgs e)
        {
            if (rawInput != "" && currentOperator != "")
            {
                try
                {
                    // ★ 앞서 추가했던 NumberStyles.Float 유지
                    num2 = decimal.Parse(rawInput, System.Globalization.NumberStyles.Float);
                    decimal result = 0;

                    if (currentOperator == "+") result = num1 + num2;
                    else if (currentOperator == "−") result = num1 - num2;
                    else if (currentOperator == "×") result = num1 * num2;
                    else if (currentOperator == "÷")
                    {
                        if (num2 == 0)
                        {
                            InputAndResultTxt.Text = "0으로 나눌 수 없습니다";
                            HistoryTxt.Text = num1.ToString("g10") + " ÷ 0 =";
                            isNewInput = true; isResultDisplayed = true; currentOperator = ""; rawInput = "";
                            return;
                        }
                        result = num1 / num2;
                    }

                    string currentExpression = num1.ToString("g10") + " " + currentOperator + " " + num2.ToString("g10") + " = ";
                    HistoryTxt.Text = currentExpression;

                    rawInput = result.ToString();
                    InputAndResultTxt.Text = result.ToString("g10");

                    CalculationHistory historyItem = new CalculationHistory
                    {
                        Num1 = num1,
                        Num2 = num2,
                        Operator = currentOperator,
                        Result = result,
                        Expression = currentExpression
                    };
                    HistoryListBox.Items.Add(historyItem);

                    isNewInput = true;
                    isResultDisplayed = true;
                    currentOperator = "";
                }
                catch (OverflowException)
                {
                    // ★ 숫자가 너무 커서 한계를 초과했을 때 프로그램이 튕기는 것을 막아줍니다!
                    InputAndResultTxt.Text = "숫자 범위 초과";
                    HistoryTxt.Text = "";
                    rawInput = "";
                    num1 = 0; num2 = 0;
                    isNewInput = true;
                    isResultDisplayed = true;
                    currentOperator = "";
                }
            }
        }

        private void HistoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 클릭된 항목이 없으면 작동하지 않음
            if (HistoryListBox.SelectedItem == null) return;

            // 선택된 항목을 CalculationHistory 객체로 변환
            CalculationHistory selectedHistory = (CalculationHistory)HistoryListBox.SelectedItem;

            // ★ 과거 데이터로 내부 상태 복원
            num1 = selectedHistory.Result;
            rawInput = selectedHistory.Result.ToString(); // 내부 데이터도 롤백

            // UI 화면 복원 (수식은 그대로, 결과값은 다시 g10을 씌워서 예쁘게)
            HistoryTxt.Text = selectedHistory.Expression;
            InputAndResultTxt.Text = selectedHistory.Result.ToString("g10");

            // 방금 '=' 버튼을 눌렀을 때와 똑같은 상태로 플래그 세팅
            isResultDisplayed = true;
            isNewInput = true;
            currentOperator = "";
        }
    }
}