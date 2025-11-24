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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
            menuStrip1 = new MenuStrip();
            gameToolStripMenuItem = new ToolStripMenuItem();
            menuViewHighScores = new ToolStripMenuItem();
            menuExportStats = new ToolStripMenuItem();
            invalidListBox = new ListBox();
            invalidLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)attemptsGrid).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // letterButton1
            // 
            letterButton1.Location = new Point(119, 241);
            letterButton1.Name = "letterButton1";
            letterButton1.Size = new Size(76, 51);
            letterButton1.TabIndex = 0;
            letterButton1.Text = "*";
            letterButton1.UseVisualStyleBackColor = true;
            // 
            // letterButton2
            // 
            letterButton2.Location = new Point(201, 240);
            letterButton2.Name = "letterButton2";
            letterButton2.Size = new Size(74, 51);
            letterButton2.TabIndex = 1;
            letterButton2.Text = "T";
            letterButton2.UseVisualStyleBackColor = true;
            // 
            // letterButton3
            // 
            letterButton3.Location = new Point(281, 241);
            letterButton3.Name = "letterButton3";
            letterButton3.Size = new Size(74, 51);
            letterButton3.TabIndex = 2;
            letterButton3.Text = "W";
            letterButton3.UseVisualStyleBackColor = true;
            // 
            // letterButton4
            // 
            letterButton4.Location = new Point(361, 241);
            letterButton4.Name = "letterButton4";
            letterButton4.Size = new Size(74, 51);
            letterButton4.TabIndex = 3;
            letterButton4.Text = "I";
            letterButton4.UseVisualStyleBackColor = true;
            // 
            // letterButton5
            // 
            letterButton5.Location = new Point(441, 241);
            letterButton5.Name = "letterButton5";
            letterButton5.Size = new Size(74, 51);
            letterButton5.TabIndex = 4;
            letterButton5.Text = "S";
            letterButton5.UseVisualStyleBackColor = true;
            // 
            // letterButton6
            // 
            letterButton6.Location = new Point(521, 241);
            letterButton6.Name = "letterButton6";
            letterButton6.Size = new Size(76, 51);
            letterButton6.TabIndex = 5;
            letterButton6.Text = "T";
            letterButton6.UseVisualStyleBackColor = true;
            // 
            // letterButton7
            // 
            letterButton7.Location = new Point(603, 241);
            letterButton7.Name = "letterButton7";
            letterButton7.Size = new Size(75, 50);
            letterButton7.TabIndex = 6;
            letterButton7.Text = "*";
            letterButton7.UseVisualStyleBackColor = true;
            // 
            // timerLabel
            // 
            timerLabel.AutoSize = true;
            timerLabel.Location = new Point(521, 211);
            timerLabel.Name = "timerLabel";
            timerLabel.Size = new Size(100, 20);
            timerLabel.TabIndex = 7;
            timerLabel.Text = "Time Left: 60s";
            // 
            // wordInputTextBox
            // 
            wordInputTextBox.Location = new Point(299, 204);
            wordInputTextBox.Name = "wordInputTextBox";
            wordInputTextBox.Size = new Size(190, 27);
            wordInputTextBox.TabIndex = 8;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(705, 241);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(80, 50);
            submitButton.TabIndex = 9;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // twistButton
            // 
            twistButton.Location = new Point(12, 240);
            twistButton.Name = "twistButton";
            twistButton.Size = new Size(82, 52);
            twistButton.TabIndex = 10;
            twistButton.Text = "Twist";
            twistButton.UseVisualStyleBackColor = true;
            twistButton.Click += twistButton_Click;
            // 
            // newGameButton
            // 
            newGameButton.Location = new Point(66, 69);
            newGameButton.Name = "newGameButton";
            newGameButton.Size = new Size(94, 29);
            newGameButton.TabIndex = 11;
            newGameButton.Text = "New Game";
            newGameButton.UseVisualStyleBackColor = true;
            newGameButton.Click += newGameButton_Click;
            // 
            // attemptsGrid
            // 
            attemptsGrid.AllowUserToAddRows = false;
            attemptsGrid.AllowUserToResizeColumns = false;
            attemptsGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            attemptsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            attemptsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            attemptsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            attemptsGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            attemptsGrid.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.LightGray;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            attemptsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            attemptsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            attemptsGrid.Columns.AddRange(new DataGridViewColumn[] { WordCol, ScoreCol, StatusCol });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            attemptsGrid.DefaultCellStyle = dataGridViewCellStyle3;
            attemptsGrid.GridColor = Color.Silver;
            attemptsGrid.Location = new Point(186, 12);
            attemptsGrid.Name = "attemptsGrid";
            attemptsGrid.RowHeadersVisible = false;
            attemptsGrid.RowHeadersWidth = 51;
            attemptsGrid.Size = new Size(429, 155);
            attemptsGrid.TabIndex = 12;
            // 
            // WordCol
            // 
            WordCol.HeaderText = "Word";
            WordCol.MinimumWidth = 6;
            WordCol.Name = "WordCol";
            // 
            // ScoreCol
            // 
            ScoreCol.HeaderText = "Score";
            ScoreCol.MinimumWidth = 6;
            ScoreCol.Name = "ScoreCol";
            // 
            // StatusCol
            // 
            StatusCol.HeaderText = "Status";
            StatusCol.MinimumWidth = 6;
            StatusCol.Name = "StatusCol";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(797, 28);
            menuStrip1.TabIndex = 13;
            menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuViewHighScores, menuExportStats });
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(62, 24);
            gameToolStripMenuItem.Text = "Game";
            // 
            // menuViewHighScores
            // 
            menuViewHighScores.Name = "menuViewHighScores";
            menuViewHighScores.Size = new Size(207, 26);
            menuViewHighScores.Text = "View High Scores";
            menuViewHighScores.Click += menuViewHighScores_Click;
            // 
            // menuExportStats
            // 
            menuExportStats.Name = "menuExportStats";
            menuExportStats.Size = new Size(207, 26);
            menuExportStats.Text = "Export Stats";
            menuExportStats.Click += menuExportStats_Click;
            // 
            // invalidListBox
            // 
            invalidListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            invalidListBox.HorizontalScrollbar = true;
            invalidListBox.Location = new Point(186, 334);
            invalidListBox.Name = "invalidListBox";
            invalidListBox.Size = new Size(429, 104);
            invalidListBox.TabIndex = 0;
            // 
            // invalidLabel
            // 
            invalidLabel.AutoSize = true;
            invalidLabel.Location = new Point(186, 310);
            invalidLabel.Name = "invalidLabel";
            invalidLabel.Size = new Size(102, 20);
            invalidLabel.TabIndex = 0;
            invalidLabel.Text = "Invalid Words:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 520);
            Controls.Add(invalidLabel);
            Controls.Add(invalidListBox);
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
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Text Twist by Hand";
            ((System.ComponentModel.ISupportInitialize)attemptsGrid).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem menuViewHighScores;
        private ToolStripMenuItem menuExportStats;
        private Label invalidLabel;
        private ListBox invalidListBox;
        private ToolStripMenuItem menuGameTime;
        private ToolStripMenuItem menuTime60;
        private ToolStripMenuItem menuTime120;
        private ToolStripMenuItem menuTime180;

    }
}
