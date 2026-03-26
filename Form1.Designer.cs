namespace SimpleCalculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NumberOne = new Button();
            NumberTwo = new Button();
            NumberThree = new Button();
            NumberFour = new Button();
            NumberFive = new Button();
            NumberSix = new Button();
            NumberSeven = new Button();
            NumberEight = new Button();
            NumberNine = new Button();
            ButtonPlus = new Button();
            ButtonMinus = new Button();
            ButtonTimes = new Button();
            ButtonNegate = new Button();
            NumberZero = new Button();
            ButtonComma = new Button();
            ButtonResult = new Button();
            ButtonObelus = new Button();
            ButtonDel = new Button();
            ButtonClearAll = new Button();
            ButtonClearEntry = new Button();
            HeadLabel = new Label();
            InputAndResultTxt = new TextBox();
            HistoryTxt = new TextBox();
            HistoryListBox = new ListBox();
            SuspendLayout();
            // 
            // NumberOne
            // 
            NumberOne.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumberOne.ForeColor = SystemColors.ControlText;
            NumberOne.Location = new Point(7, 413);
            NumberOne.Name = "NumberOne";
            NumberOne.Size = new Size(90, 59);
            NumberOne.TabIndex = 0;
            NumberOne.Text = "1";
            NumberOne.UseVisualStyleBackColor = true;
            NumberOne.Click += NumberButton_Click;
            // 
            // NumberTwo
            // 
            NumberTwo.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumberTwo.ForeColor = SystemColors.ControlText;
            NumberTwo.Location = new Point(114, 413);
            NumberTwo.Name = "NumberTwo";
            NumberTwo.Size = new Size(90, 59);
            NumberTwo.TabIndex = 1;
            NumberTwo.Text = "2";
            NumberTwo.UseVisualStyleBackColor = true;
            NumberTwo.Click += NumberButton_Click;
            // 
            // NumberThree
            // 
            NumberThree.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumberThree.ForeColor = SystemColors.ControlText;
            NumberThree.Location = new Point(221, 413);
            NumberThree.Name = "NumberThree";
            NumberThree.Size = new Size(90, 59);
            NumberThree.TabIndex = 2;
            NumberThree.Text = "3";
            NumberThree.UseVisualStyleBackColor = true;
            NumberThree.Click += NumberButton_Click;
            // 
            // NumberFour
            // 
            NumberFour.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumberFour.ForeColor = SystemColors.ControlText;
            NumberFour.Location = new Point(7, 339);
            NumberFour.Name = "NumberFour";
            NumberFour.Size = new Size(90, 59);
            NumberFour.TabIndex = 3;
            NumberFour.Text = "4";
            NumberFour.UseVisualStyleBackColor = true;
            NumberFour.Click += NumberButton_Click;
            // 
            // NumberFive
            // 
            NumberFive.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumberFive.ForeColor = SystemColors.ControlText;
            NumberFive.Location = new Point(114, 339);
            NumberFive.Name = "NumberFive";
            NumberFive.Size = new Size(90, 59);
            NumberFive.TabIndex = 4;
            NumberFive.Text = "5";
            NumberFive.UseVisualStyleBackColor = true;
            NumberFive.Click += NumberButton_Click;
            // 
            // NumberSix
            // 
            NumberSix.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumberSix.ForeColor = SystemColors.ControlText;
            NumberSix.Location = new Point(221, 339);
            NumberSix.Name = "NumberSix";
            NumberSix.Size = new Size(90, 59);
            NumberSix.TabIndex = 5;
            NumberSix.Text = "6";
            NumberSix.UseVisualStyleBackColor = true;
            NumberSix.Click += NumberButton_Click;
            // 
            // NumberSeven
            // 
            NumberSeven.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumberSeven.ForeColor = SystemColors.ControlText;
            NumberSeven.Location = new Point(7, 265);
            NumberSeven.Name = "NumberSeven";
            NumberSeven.Size = new Size(90, 59);
            NumberSeven.TabIndex = 6;
            NumberSeven.Text = "7";
            NumberSeven.UseVisualStyleBackColor = true;
            NumberSeven.Click += NumberButton_Click;
            // 
            // NumberEight
            // 
            NumberEight.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumberEight.ForeColor = SystemColors.ControlText;
            NumberEight.Location = new Point(114, 265);
            NumberEight.Name = "NumberEight";
            NumberEight.Size = new Size(90, 59);
            NumberEight.TabIndex = 7;
            NumberEight.Text = "8";
            NumberEight.UseVisualStyleBackColor = true;
            NumberEight.Click += NumberButton_Click;
            // 
            // NumberNine
            // 
            NumberNine.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumberNine.ForeColor = SystemColors.ControlText;
            NumberNine.Location = new Point(221, 265);
            NumberNine.Name = "NumberNine";
            NumberNine.Size = new Size(90, 59);
            NumberNine.TabIndex = 8;
            NumberNine.Text = "9";
            NumberNine.UseVisualStyleBackColor = true;
            NumberNine.Click += NumberButton_Click;
            // 
            // ButtonPlus
            // 
            ButtonPlus.BackColor = SystemColors.Info;
            ButtonPlus.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonPlus.ForeColor = SystemColors.ControlText;
            ButtonPlus.Location = new Point(327, 413);
            ButtonPlus.Name = "ButtonPlus";
            ButtonPlus.Size = new Size(90, 59);
            ButtonPlus.TabIndex = 2;
            ButtonPlus.Text = "+";
            ButtonPlus.UseVisualStyleBackColor = false;
            ButtonPlus.Click += ButtonPlus_Click;
            // 
            // ButtonMinus
            // 
            ButtonMinus.BackColor = SystemColors.Info;
            ButtonMinus.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonMinus.ForeColor = SystemColors.ControlText;
            ButtonMinus.Location = new Point(327, 339);
            ButtonMinus.Name = "ButtonMinus";
            ButtonMinus.Size = new Size(90, 59);
            ButtonMinus.TabIndex = 5;
            ButtonMinus.Text = "−";
            ButtonMinus.UseVisualStyleBackColor = false;
            ButtonMinus.Click += ButtonMinus_Click;
            // 
            // ButtonTimes
            // 
            ButtonTimes.BackColor = SystemColors.Info;
            ButtonTimes.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonTimes.ForeColor = SystemColors.ControlText;
            ButtonTimes.Location = new Point(327, 265);
            ButtonTimes.Name = "ButtonTimes";
            ButtonTimes.Size = new Size(90, 59);
            ButtonTimes.TabIndex = 8;
            ButtonTimes.Text = "×";
            ButtonTimes.UseVisualStyleBackColor = false;
            ButtonTimes.Click += ButtonTimes_Click;
            // 
            // ButtonNegate
            // 
            ButtonNegate.BackColor = SystemColors.HotTrack;
            ButtonNegate.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonNegate.ForeColor = SystemColors.ControlText;
            ButtonNegate.Location = new Point(7, 485);
            ButtonNegate.Name = "ButtonNegate";
            ButtonNegate.Size = new Size(90, 59);
            ButtonNegate.TabIndex = 0;
            ButtonNegate.Text = "+ / −";
            ButtonNegate.UseVisualStyleBackColor = false;
            ButtonNegate.Click += ButtonNegate_Click;
            // 
            // NumberZero
            // 
            NumberZero.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NumberZero.ForeColor = SystemColors.ControlText;
            NumberZero.Location = new Point(114, 485);
            NumberZero.Name = "NumberZero";
            NumberZero.Size = new Size(90, 59);
            NumberZero.TabIndex = 1;
            NumberZero.Text = "0";
            NumberZero.UseVisualStyleBackColor = true;
            NumberZero.Click += NumberButton_Click;
            // 
            // ButtonComma
            // 
            ButtonComma.BackColor = SystemColors.HotTrack;
            ButtonComma.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonComma.ForeColor = SystemColors.ControlText;
            ButtonComma.Location = new Point(221, 485);
            ButtonComma.Name = "ButtonComma";
            ButtonComma.Size = new Size(90, 59);
            ButtonComma.TabIndex = 2;
            ButtonComma.Text = ".";
            ButtonComma.UseVisualStyleBackColor = false;
            ButtonComma.Click += ButtonComma_Click;
            // 
            // ButtonResult
            // 
            ButtonResult.BackColor = SystemColors.ActiveCaption;
            ButtonResult.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonResult.ForeColor = SystemColors.ControlText;
            ButtonResult.Location = new Point(327, 485);
            ButtonResult.Name = "ButtonResult";
            ButtonResult.Size = new Size(90, 59);
            ButtonResult.TabIndex = 2;
            ButtonResult.Text = "=";
            ButtonResult.UseVisualStyleBackColor = false;
            ButtonResult.Click += ButtonResult_Click;
            // 
            // ButtonObelus
            // 
            ButtonObelus.BackColor = SystemColors.Info;
            ButtonObelus.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonObelus.ForeColor = SystemColors.ControlText;
            ButtonObelus.Location = new Point(327, 189);
            ButtonObelus.Name = "ButtonObelus";
            ButtonObelus.Size = new Size(90, 59);
            ButtonObelus.TabIndex = 11;
            ButtonObelus.Text = "÷";
            ButtonObelus.UseVisualStyleBackColor = false;
            ButtonObelus.Click += ButtonObelus_Click;
            // 
            // ButtonDel
            // 
            ButtonDel.BackColor = SystemColors.InactiveCaption;
            ButtonDel.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonDel.ForeColor = SystemColors.ControlText;
            ButtonDel.Location = new Point(221, 189);
            ButtonDel.Name = "ButtonDel";
            ButtonDel.Size = new Size(90, 59);
            ButtonDel.TabIndex = 12;
            ButtonDel.Text = "del";
            ButtonDel.UseVisualStyleBackColor = false;
            ButtonDel.Click += ButtonDel_Click;
            // 
            // ButtonClearAll
            // 
            ButtonClearAll.BackColor = SystemColors.InactiveCaption;
            ButtonClearAll.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonClearAll.ForeColor = SystemColors.ControlText;
            ButtonClearAll.Location = new Point(114, 189);
            ButtonClearAll.Name = "ButtonClearAll";
            ButtonClearAll.Size = new Size(90, 59);
            ButtonClearAll.TabIndex = 10;
            ButtonClearAll.Text = "C";
            ButtonClearAll.UseVisualStyleBackColor = false;
            ButtonClearAll.Click += ButtonClearAll_Click;
            // 
            // ButtonClearEntry
            // 
            ButtonClearEntry.BackColor = SystemColors.InactiveCaption;
            ButtonClearEntry.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonClearEntry.ForeColor = SystemColors.ControlText;
            ButtonClearEntry.Location = new Point(7, 189);
            ButtonClearEntry.Name = "ButtonClearEntry";
            ButtonClearEntry.Size = new Size(90, 59);
            ButtonClearEntry.TabIndex = 9;
            ButtonClearEntry.Text = "CE";
            ButtonClearEntry.UseVisualStyleBackColor = false;
            ButtonClearEntry.Click += ButtonClearEntry_Click;
            // 
            // HeadLabel
            // 
            HeadLabel.AutoSize = true;
            HeadLabel.Font = new Font("서울한강 장체 L", 24F, FontStyle.Regular, GraphicsUnit.Point, 129);
            HeadLabel.Location = new Point(93, 9);
            HeadLabel.Name = "HeadLabel";
            HeadLabel.Size = new Size(239, 38);
            HeadLabel.TabIndex = 13;
            HeadLabel.Text = "Simple Calculator";
            // 
            // InputAndResultTxt
            // 
            InputAndResultTxt.Font = new Font("서울남산체 L", 24F, FontStyle.Regular, GraphicsUnit.Point, 129);
            InputAndResultTxt.Location = new Point(31, 113);
            InputAndResultTxt.Name = "InputAndResultTxt";
            InputAndResultTxt.ReadOnly = true;
            InputAndResultTxt.Size = new Size(372, 45);
            InputAndResultTxt.TabIndex = 14;
            InputAndResultTxt.TabStop = false;
            InputAndResultTxt.TextAlign = HorizontalAlignment.Right;
            // 
            // HistoryTxt
            // 
            HistoryTxt.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            HistoryTxt.Location = new Point(104, 70);
            HistoryTxt.Name = "HistoryTxt";
            HistoryTxt.ReadOnly = true;
            HistoryTxt.Size = new Size(299, 29);
            HistoryTxt.TabIndex = 15;
            HistoryTxt.TabStop = false;
            HistoryTxt.TextAlign = HorizontalAlignment.Right;
            // 
            // HistoryListBox
            // 
            HistoryListBox.Font = new Font("서울남산 장체 L", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 129);
            HistoryListBox.FormattingEnabled = true;
            HistoryListBox.Location = new Point(425, 9);
            HistoryListBox.Name = "HistoryListBox";
            HistoryListBox.Size = new Size(298, 532);
            HistoryListBox.TabIndex = 16;
            HistoryListBox.SelectedIndexChanged += HistoryListBox_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(735, 548);
            Controls.Add(HistoryListBox);
            Controls.Add(HistoryTxt);
            Controls.Add(InputAndResultTxt);
            Controls.Add(HeadLabel);
            Controls.Add(ButtonObelus);
            Controls.Add(ButtonDel);
            Controls.Add(ButtonClearAll);
            Controls.Add(ButtonClearEntry);
            Controls.Add(ButtonTimes);
            Controls.Add(NumberNine);
            Controls.Add(NumberEight);
            Controls.Add(ButtonMinus);
            Controls.Add(NumberSeven);
            Controls.Add(NumberSix);
            Controls.Add(NumberFive);
            Controls.Add(ButtonResult);
            Controls.Add(ButtonPlus);
            Controls.Add(ButtonComma);
            Controls.Add(NumberFour);
            Controls.Add(NumberZero);
            Controls.Add(NumberThree);
            Controls.Add(ButtonNegate);
            Controls.Add(NumberTwo);
            Controls.Add(NumberOne);
            Name = "Form1";
            Text = "The Calculator V1.0";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button NumberOne;
        private Button NumberTwo;
        private Button NumberThree;
        private Button NumberFour;
        private Button NumberFive;
        private Button NumberSix;
        private Button NumberSeven;
        private Button NumberEight;
        private Button NumberNine;
        private Button ButtonPlus;
        private Button ButtonMinus;
        private Button ButtonTimes;
        private Button ButtonNegate;
        private Button NumberZero;
        private Button ButtonComma;
        private Button ButtonResult;
        private Button ButtonObelus;
        private Button ButtonDel;
        private Button ButtonClearAll;
        private Button ButtonClearEntry;
        private Label HeadLabel;
        private TextBox InputAndResultTxt;
        private TextBox HistoryTxt;
        private ListBox HistoryListBox;
    }
}
