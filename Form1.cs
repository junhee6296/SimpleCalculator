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
        bool isScientificMode = false; // 모드 전환

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

        private void ButtonMode_Click(object sender, EventArgs e)
        {
            isScientificMode = !isScientificMode; // 모드 반전 (true <-> false)

            // 버튼 텍스트 변경
            ButtonMode.Text = isScientificMode ? "공학용 모드" : "표준 모드";

            // 버그 방지를 위해 모든 기록과 화면을 초기화 (기존에 만든 C버튼 로직 활용)
            ButtonClearAll_Click(sender, e);
            HistoryListBox.Items.Clear(); // 우측 기록창도 비우기
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

            if (isScientificMode)
            {
                // 공학용 모드: 수식 뒤에 숫자 이어 붙이기
                if (isResultDisplayed)
                {
                    HistoryTxt.Clear();
                    rawInput = "";
                    isResultDisplayed = false;
                }
                rawInput += btn.Text;
                InputAndResultTxt.Text = rawInput;
            }
            else
            {
                // 표준 모드 (기존 로직)
                if (isResultDisplayed)
                {
                    HistoryTxt.Clear();
                    rawInput = "";
                    num1 = 0; num2 = 0; currentOperator = "";
                    isResultDisplayed = false; isNewInput = true;
                }
                if (isNewInput)
                {
                    rawInput = "";
                    isNewInput = false;
                }

                rawInput += btn.Text;
                InputAndResultTxt.Text = rawInput;
            }
        }

        // --- [더하기 버튼] ---
        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            if (isScientificMode)
            {
                rawInput += "+";
                InputAndResultTxt.Text = rawInput;
                isResultDisplayed = false;
            }
            else
            {
                if (rawInput != "")
                {
                    num1 = decimal.Parse(rawInput, System.Globalization.NumberStyles.Float);
                    currentOperator = "+";
                    HistoryTxt.Text = num1.ToString("g10") + " + ";
                    isNewInput = true; isResultDisplayed = false;
                }
            }
        }

        // --- [빼기 버튼] ---
        private void ButtonMinus_Click(object sender, EventArgs e)
        {
            if (isScientificMode)
            {
                rawInput += "−";
                InputAndResultTxt.Text = rawInput;
                isResultDisplayed = false;
            }
            else
            {
                if (rawInput != "")
                {
                    num1 = decimal.Parse(rawInput, System.Globalization.NumberStyles.Float);
                    currentOperator = "−";
                    HistoryTxt.Text = num1.ToString("g10") + " − ";
                    isNewInput = true; isResultDisplayed = false;
                }
            }
        }

        // --- [곱하기 버튼] ---
        private void ButtonTimes_Click(object sender, EventArgs e)
        {
            if (isScientificMode)
            {
                rawInput += "×";
                InputAndResultTxt.Text = rawInput;
                isResultDisplayed = false;
            }
            else
            {
                if (rawInput != "")
                {
                    num1 = decimal.Parse(rawInput, System.Globalization.NumberStyles.Float);
                    currentOperator = "×";
                    HistoryTxt.Text = num1.ToString("g10") + " × ";
                    isNewInput = true; isResultDisplayed = false;
                }
            }
        }

        // --- [나누기 버튼] ---
        private void ButtonObelus_Click(object sender, EventArgs e)
        {
            if (isScientificMode)
            {
                rawInput += "÷";
                InputAndResultTxt.Text = rawInput;
                isResultDisplayed = false;
            }
            else
            {
                if (rawInput != "")
                {
                    num1 = decimal.Parse(rawInput, System.Globalization.NumberStyles.Float);
                    currentOperator = "÷";
                    HistoryTxt.Text = num1.ToString("g10") + " ÷ ";
                    isNewInput = true; isResultDisplayed = false;
                }
            }
        }

        // C 버튼 클릭 이벤트 (전체삭제)
        private void ButtonClearAll_Click(object sender, EventArgs e)
        {
            // 계산기의 모든 상태와 텍스트를 처음 상태로 되돌림
            num1 = 0;
            num2 = 0;
            currentOperator = "";
            rawInput = ""; // ★ 누락되었던 내부 데이터 초기화 추가!
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
            rawInput = ""; // ★ 누락되었던 내부 데이터 초기화 추가!
            InputAndResultTxt.Text = "";
            isNewInput = true;
        }

        // --- [del (백스페이스) 버튼] ---
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (rawInput == "" || isResultDisplayed) return;

            if (rawInput.Length > 0)
            {
                // 마지막 글자 하나 지우기 (두 모드 공통 적용 가능)
                rawInput = rawInput.Substring(0, rawInput.Length - 1);
                InputAndResultTxt.Text = rawInput;
            }
        }

        // +/- (부호 반전) 버튼 클릭 이벤트
        private void ButtonNegate_Click(object sender, EventArgs e)
        {
            if (rawInput != "" && rawInput != "0")
            {
                decimal currentNum = decimal.Parse(rawInput); 
                currentNum = currentNum * -1;

                rawInput = currentNum.ToString(); // ★ 내부 데이터 업데이트 (포맷 없음)
                InputAndResultTxt.Text = currentNum.ToString("g10"); // 화면에만 포맷 적용
            }
        }
        // 공학모드에서만 연산버튼 먹힘
        private void ButtonOpenParen_Click(object sender, EventArgs e)
        {
            if (isScientificMode) { rawInput += "("; InputAndResultTxt.Text = rawInput; }
        }
        private void ButtonCloseParen_Click(object sender, EventArgs e)
        {
            if (isScientificMode) { rawInput += ")"; InputAndResultTxt.Text = rawInput; }
        }

        // 콤마 (소숫점)
        private void ButtonComma_Click(object sender, EventArgs e)
        {
            if (isScientificMode)
            {
                if (isResultDisplayed) { rawInput = ""; isResultDisplayed = false; }
                rawInput += ".";
                InputAndResultTxt.Text = rawInput;
            }
            else
            {
                if (isResultDisplayed || isNewInput || rawInput == "")
                {
                    if (isResultDisplayed)
                    {
                        HistoryTxt.Clear();
                        num1 = 0; num2 = 0; currentOperator = "";
                        isResultDisplayed = false;
                    }
                    rawInput = "0.";
                    InputAndResultTxt.Text = rawInput;
                    isNewInput = false;
                }
                else if (!rawInput.Contains("."))
                {
                    rawInput += ".";
                    InputAndResultTxt.Text = rawInput;
                }
            }
        }

        private void ButtonResult_Click(object sender, EventArgs e)
        {
            if (isScientificMode)
            {
                if (string.IsNullOrWhiteSpace(rawInput)) return;

                try
                {
                    // 1. C# DataTable이 이해할 수 있는 기호로 변환
                    string expression = rawInput.Replace("×", "*").Replace("÷", "/").Replace("−", "-");

                    // 2. 괄호와 우선순위를 포함한 전체 수식 자동 계산
                    System.Data.DataTable table = new System.Data.DataTable();
                    var result = table.Compute(expression, "");

                    // 3. 결과 표시 및 데이터 업데이트
                    decimal finalResult = Convert.ToDecimal(result);
                    HistoryTxt.Text = rawInput + " = " + finalResult.ToString("g10");

                    rawInput = finalResult.ToString();
                    InputAndResultTxt.Text = finalResult.ToString("g10");

                    // 4. 리스트박스에 기록 저장
                    CalculationHistory historyItem = new CalculationHistory
                    {
                        Expression = HistoryTxt.Text
                    };
                    HistoryListBox.Items.Add(historyItem);

                    isResultDisplayed = true;
                }
                catch (Exception)
                {
                    // 괄호 개수가 안 맞거나 0으로 나누는 등 수식 오류 발생 시 튕김 방지
                    InputAndResultTxt.Text = "수식 오류";
                    rawInput = "";
                    isResultDisplayed = true;
                }
            }
            else
            {
                // --- [표준 모드 (기존 로직 유지)] ---
                if (rawInput != "" && currentOperator != "")
                {
                    try
                    {
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

                        string currentExpression = num1.ToString("g10") + " " + currentOperator + " " + num2.ToString("g10") + " = " + result.ToString("g10");
                        HistoryTxt.Text = currentExpression;

                        rawInput = result.ToString();
                        InputAndResultTxt.Text = result.ToString("g10");

                        CalculationHistory historyItem = new CalculationHistory
                        {
                            Expression = currentExpression
                        };
                        HistoryListBox.Items.Add(historyItem);

                        isNewInput = true;
                        isResultDisplayed = true;
                        currentOperator = "";
                    }
                    catch (OverflowException)
                    {
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