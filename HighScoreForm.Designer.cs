namespace JonathanHandProject2
{
    partial class HighScoreForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.scoreGrid = new System.Windows.Forms.DataGridView();
            this.PlayerCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resetButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scoreGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // scoreGrid
            // 
            this.scoreGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scoreGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerCol,
            this.ScoreCol,
            this.TimeCol});
            this.scoreGrid.Location = new System.Drawing.Point(330, 50);
            this.scoreGrid.Name = "scoreGrid";
            this.scoreGrid.RowHeadersWidth = 51;
            this.scoreGrid.Size = new System.Drawing.Size(375, 260);
            this.scoreGrid.TabIndex = 0;
            scoreGrid.BackgroundColor = Color.White;
            scoreGrid.BorderStyle = BorderStyle.FixedSingle;

            scoreGrid.RowHeadersVisible = false;
            scoreGrid.AllowUserToAddRows = false;

            scoreGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            scoreGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            scoreGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            scoreGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            scoreGrid.DefaultCellStyle.Font = new Font("Segoe UI", 10F);

            scoreGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            scoreGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            scoreGrid.GridColor = Color.Silver;
            scoreGrid.AllowUserToResizeRows = false;
            scoreGrid.AllowUserToResizeColumns = false;

            scoreGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            // 
            // PlayerCol
            // 
            this.PlayerCol.HeaderText = "Player";
            this.PlayerCol.MinimumWidth = 6;
            this.PlayerCol.Name = "PlayerCol";
            this.PlayerCol.Width = 150;
            // 
            // ScoreCol
            // 
            this.ScoreCol.HeaderText = "Score";
            this.ScoreCol.MinimumWidth = 6;
            this.ScoreCol.Name = "ScoreCol";
            this.ScoreCol.Width = 90;
            // 
            // TimeCol
            // 
            this.TimeCol.HeaderText = "Time (sec)";
            this.TimeCol.MinimumWidth = 6;
            this.TimeCol.Name = "TimeCol";
            this.TimeCol.Width = 90;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(80, 90);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(120, 32);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "Reset Scores";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(80, 160);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(120, 32);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // HighScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.scoreGrid);
            this.Name = "HighScoreForm";
            this.Text = "High Scores";
            this.Load += new System.EventHandler(this.HighScoreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scoreGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView scoreGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCol;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button closeButton;
    }
}
