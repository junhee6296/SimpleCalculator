namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 1. 계산에 필요한 전역 변수 선언
        int num1 = 0;
        int num2 = 0;
        string currentOperator = "";

        // ★ 핵심: 다음 숫자를 누를 때 화면을 비울지 결정하는 플래그
        bool isNewInput = true;

        // 2. 숫자 버튼 클릭 이벤트 (0~9 모두 연결)
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // 방금 연산자(+ 등)나 '='을 눌러서 새 입력이 필요한 상태라면 화면을 비움
            if (isNewInput)
            {
                InputAndResultTxt.Text = "";
                isNewInput = false; // 화면을 비웠으니 다시 false로 변경하여 숫자가 이어붙게 함
            }

            // 클릭된 버튼의 숫자를 메인 텍스트박스에 이어붙임
            InputAndResultTxt.Text += btn.Text;
        }
        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            if (InputAndResultTxt.Text != "")
            {
                // 현재 메인 화면의 숫자를 num1에 저장
                num1 = int.Parse(InputAndResultTxt.Text);
                currentOperator = "+";

                // 히스토리 창에 "숫자 + " 형태로 표시
                HistoryTxt.Text = num1.ToString() + " + ";

                // ★ 연산자를 눌렀으므로, 다음 숫자 클릭 시 화면이 새로워지도록 플래그 설정
                isNewInput = true;
            }
        }

        private void ButtonResult_Click(object sender, EventArgs e)
        {
            if (InputAndResultTxt.Text != "" && currentOperator != "")
            {
                // 두 번째 숫자를 num2에 저장
                num2 = int.Parse(InputAndResultTxt.Text);

                if (currentOperator == "+")
                {
                    // 더하기 연산
                    int result = num1 + num2;

                    // 히스토리 창에 전체 수식 표시 (예: 5 + 2 = )
                    HistoryTxt.Text = num1.ToString() + " + " + num2.ToString() + " = ";

                    // 결과를 메인 창에 표시
                    InputAndResultTxt.Text = result.ToString();

                    // ★ 계산이 끝났으므로, 다음 숫자 클릭 시 화면이 새로워지도록 플래그 설정
                    isNewInput = true;
                    currentOperator = ""; // 연산 종료 후 연산자 초기화
                }
            }
        }
    }
}
