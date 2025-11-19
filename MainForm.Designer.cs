namespace JonathanHandProject2
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            letterButton1 = new Button();
            letterButton2 = new Button();
            letterButton3 = new Button();
            letterButton4 = new Button();
            letterButton5 = new Button();
            letterButton6 = new Button();
            letterButton7 = new Button();
            timerLabel = new Label();
            wordInputTextBox = new TextBox();
            submitButton = new Button();
            twistButton = new Button();
            newGameButton = new Button();
            attemptsGrid = new DataGridView();
            WordCol = new DataGridViewTextBoxColumn();
            ScoreCol = new DataGridViewTextBoxColumn();
            StatusCol = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)attemptsGrid).BeginInit();
            SuspendLayout();
            // 
            // letterButton1
            // 
            letterButton1.Location = new Point(50, 217);
            letterButton1.Name = "letterButton1";
            letterButton1.Size = new Size(94, 29);
            letterButton1.TabIndex = 0;
            letterButton1.Text = "A";
            letterButton1.UseVisualStyleBackColor = true;
            // 
            // letterButton2
            // 
            letterButton2.Location = new Point(150, 217);
            letterButton2.Name = "letterButton2";
            letterButton2.Size = new Size(94, 29);
            letterButton2.TabIndex = 1;
            letterButton2.Text = "B";
            letterButton2.UseVisualStyleBackColor = true;
            // 
            // letterButton3
            // 
            letterButton3.Location = new Point(250, 217);
            letterButton3.Name = "letterButton3";
            letterButton3.Size = new Size(94, 29);
            letterButton3.TabIndex = 2;
            letterButton3.Text = "C";
            letterButton3.UseVisualStyleBackColor = true;
            // 
            // letterButton4
            // 
            letterButton4.Location = new Point(350, 217);
            letterButton4.Name = "letterButton4";
            letterButton4.Size = new Size(94, 29);
            letterButton4.TabIndex = 3;
            letterButton4.Text = "D";
            letterButton4.UseVisualStyleBackColor = true;
            // 
            // letterButton5
            // 
            letterButton5.Location = new Point(450, 217);
            letterButton5.Name = "letterButton5";
            letterButton5.Size = new Size(94, 29);
            letterButton5.TabIndex = 4;
            letterButton5.Text = "E";
            letterButton5.UseVisualStyleBackColor = true;
            // 
            // letterButton6
            // 
            letterButton6.Location = new Point(550, 217);
            letterButton6.Name = "letterButton6";
            letterButton6.Size = new Size(94, 29);
            letterButton6.TabIndex = 5;
            letterButton6.Text = "F";
            letterButton6.UseVisualStyleBackColor = true;
            // 
            // letterButton7
            // 
            letterButton7.Location = new Point(650, 217);
            letterButton7.Name = "letterButton7";
            letterButton7.Size = new Size(94, 29);
            letterButton7.TabIndex = 6;
            letterButton7.Text = "G";
            letterButton7.UseVisualStyleBackColor = true;
            // 
            // timerLabel
            // 
            timerLabel.AutoSize = true;
            timerLabel.Location = new Point(673, 30);
            timerLabel.Name = "timerLabel";
            timerLabel.Size = new Size(71, 20);
            timerLabel.TabIndex = 7;
            timerLabel.Text = "Time: 60s";
            // 
            // wordInputTextBox
            // 
            wordInputTextBox.Location = new Point(318, 144);
            wordInputTextBox.Name = "wordInputTextBox";
            wordInputTextBox.Size = new Size(190, 27);
            wordInputTextBox.TabIndex = 8;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(538, 144);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(94, 29);
            submitButton.TabIndex = 9;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // twistButton
            // 
            twistButton.Location = new Point(186, 144);
            twistButton.Name = "twistButton";
            twistButton.Size = new Size(94, 29);
            twistButton.TabIndex = 10;
            twistButton.Text = "Twist";
            twistButton.UseVisualStyleBackColor = true;
            twistButton.Click += twistButton_Click;
            // 
            // newGameButton
            // 
            newGameButton.Location = new Point(50, 30);
            newGameButton.Name = "newGameButton";
            newGameButton.Size = new Size(94, 29);
            newGameButton.TabIndex = 11;
            newGameButton.Text = "New Game";
            newGameButton.UseVisualStyleBackColor = true;
            newGameButton.Click += newGameButton_Click;
            // 
            // attemptsGrid
            // 
            attemptsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            attemptsGrid.Columns.AddRange(new DataGridViewColumn[] { WordCol, ScoreCol, StatusCol });
            attemptsGrid.Location = new Point(186, 30);
            attemptsGrid.Name = "attemptsGrid";
            attemptsGrid.RowHeadersWidth = 51;
            attemptsGrid.Size = new Size(429, 59);
            attemptsGrid.TabIndex = 12;
            // 
            // WordCol
            // 
            WordCol.HeaderText = "Word";
            WordCol.MinimumWidth = 6;
            WordCol.Name = "WordCol";
            WordCol.Width = 125;
            // 
            // ScoreCol
            // 
            ScoreCol.HeaderText = "Score";
            ScoreCol.MinimumWidth = 6;
            ScoreCol.Name = "ScoreCol";
            ScoreCol.Width = 125;
            // 
            // StatusCol
            // 
            StatusCol.HeaderText = "Status";
            StatusCol.MinimumWidth = 6;
            StatusCol.Name = "StatusCol";
            StatusCol.Width = 125;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 450);
            Controls.Add(attemptsGrid);
            Controls.Add(newGameButton);
            Controls.Add(twistButton);
            Controls.Add(submitButton);
            Controls.Add(wordInputTextBox);
            Controls.Add(timerLabel);
            Controls.Add(letterButton7);
            Controls.Add(letterButton6);
            Controls.Add(letterButton5);
            Controls.Add(letterButton4);
            Controls.Add(letterButton3);
            Controls.Add(letterButton2);
            Controls.Add(letterButton1);
            Name = "MainForm";
            Text = "Text Twist by Hand";
            ((System.ComponentModel.ISupportInitialize)attemptsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button letterButton1;
        private Button letterButton2;
        private Button letterButton3;
        private Button letterButton4;
        private Button letterButton5;
        private Button letterButton6;
        private Button letterButton7;
        private Label timerLabel;
        private TextBox wordInputTextBox;
        private Button submitButton;
        private Button twistButton;
        private Button newGameButton;
        private DataGridView attemptsGrid;
        private DataGridViewTextBoxColumn WordCol;
        private DataGridViewTextBoxColumn ScoreCol;
        private DataGridViewTextBoxColumn StatusCol;
    }
}
