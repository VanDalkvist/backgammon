namespace BackgammonDrawer
{
	partial class BackgammonForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if ( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.DrawingPanel = new System.Windows.Forms.Panel();
			this.groupBoxControlPanel = new System.Windows.Forms.GroupBox();
			this.buttonStart = new System.Windows.Forms.Button();
			this.groupBoxGameState = new System.Windows.Forms.GroupBox();
			this.labelProgressUser2 = new System.Windows.Forms.Label();
			this.progressBarUser2 = new System.Windows.Forms.ProgressBar();
			this.labelProgressUser1 = new System.Windows.Forms.Label();
			this.progressBarUser1 = new System.Windows.Forms.ProgressBar();
			this.labelUserName2 = new System.Windows.Forms.Label();
			this.labelUserName1 = new System.Windows.Forms.Label();
			this.groupBoxDice = new System.Windows.Forms.GroupBox();
			this.groupBoxTurn = new System.Windows.Forms.GroupBox();
			this.panelColorTurn = new System.Windows.Forms.Panel();
			this.labelTurn = new System.Windows.Forms.Label();
			this.groupBoxControlPanel.SuspendLayout();
			this.groupBoxGameState.SuspendLayout();
			this.groupBoxTurn.SuspendLayout();
			this.SuspendLayout();
			// 
			// DrawingPanel
			// 
			this.DrawingPanel.BackColor = System.Drawing.Color.White;
			this.DrawingPanel.Location = new System.Drawing.Point(12, 12);
			this.DrawingPanel.Name = "DrawingPanel";
			this.DrawingPanel.Size = new System.Drawing.Size(603, 447);
			this.DrawingPanel.TabIndex = 0;
			this.DrawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingPanelPaint);
			// 
			// groupBoxControlPanel
			// 
			this.groupBoxControlPanel.BackColor = System.Drawing.Color.White;
			this.groupBoxControlPanel.Controls.Add(this.buttonStart);
			this.groupBoxControlPanel.Controls.Add(this.groupBoxGameState);
			this.groupBoxControlPanel.Controls.Add(this.groupBoxDice);
			this.groupBoxControlPanel.Controls.Add(this.groupBoxTurn);
			this.groupBoxControlPanel.Location = new System.Drawing.Point(622, 12);
			this.groupBoxControlPanel.Name = "groupBoxControlPanel";
			this.groupBoxControlPanel.Size = new System.Drawing.Size(190, 447);
			this.groupBoxControlPanel.TabIndex = 1;
			this.groupBoxControlPanel.TabStop = false;
			this.groupBoxControlPanel.Text = "Control panel";
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(117, 418);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(67, 23);
			this.buttonStart.TabIndex = 3;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.ButtonStartClick);
			// 
			// groupBoxGameState
			// 
			this.groupBoxGameState.BackColor = System.Drawing.Color.White;
			this.groupBoxGameState.Controls.Add(this.labelProgressUser2);
			this.groupBoxGameState.Controls.Add(this.progressBarUser2);
			this.groupBoxGameState.Controls.Add(this.labelProgressUser1);
			this.groupBoxGameState.Controls.Add(this.progressBarUser1);
			this.groupBoxGameState.Controls.Add(this.labelUserName2);
			this.groupBoxGameState.Controls.Add(this.labelUserName1);
			this.groupBoxGameState.Location = new System.Drawing.Point(7, 199);
			this.groupBoxGameState.Name = "groupBoxGameState";
			this.groupBoxGameState.Size = new System.Drawing.Size(176, 138);
			this.groupBoxGameState.TabIndex = 2;
			this.groupBoxGameState.TabStop = false;
			this.groupBoxGameState.Text = "State of game";
			// 
			// labelProgressUser2
			// 
			this.labelProgressUser2.AutoSize = true;
			this.labelProgressUser2.Location = new System.Drawing.Point(145, 108);
			this.labelProgressUser2.Name = "labelProgressUser2";
			this.labelProgressUser2.Size = new System.Drawing.Size(24, 13);
			this.labelProgressUser2.TabIndex = 5;
			this.labelProgressUser2.Text = "0 %";
			// 
			// progressBarUser2
			// 
			this.progressBarUser2.Location = new System.Drawing.Point(10, 103);
			this.progressBarUser2.Name = "progressBarUser2";
			this.progressBarUser2.Size = new System.Drawing.Size(125, 23);
			this.progressBarUser2.TabIndex = 4;
			// 
			// labelProgressUser1
			// 
			this.labelProgressUser1.AutoSize = true;
			this.labelProgressUser1.Location = new System.Drawing.Point(145, 57);
			this.labelProgressUser1.Name = "labelProgressUser1";
			this.labelProgressUser1.Size = new System.Drawing.Size(24, 13);
			this.labelProgressUser1.TabIndex = 3;
			this.labelProgressUser1.Text = "0 %";
			// 
			// progressBarUser1
			// 
			this.progressBarUser1.Location = new System.Drawing.Point(10, 52);
			this.progressBarUser1.Name = "progressBarUser1";
			this.progressBarUser1.Size = new System.Drawing.Size(125, 23);
			this.progressBarUser1.TabIndex = 2;
			// 
			// labelUserName2
			// 
			this.labelUserName2.AutoSize = true;
			this.labelUserName2.Location = new System.Drawing.Point(7, 84);
			this.labelUserName2.Name = "labelUserName2";
			this.labelUserName2.Size = new System.Drawing.Size(81, 13);
			this.labelUserName2.TabIndex = 1;
			this.labelUserName2.Text = "Name of User 2";
			// 
			// labelUserName1
			// 
			this.labelUserName1.AutoSize = true;
			this.labelUserName1.Location = new System.Drawing.Point(7, 31);
			this.labelUserName1.Name = "labelUserName1";
			this.labelUserName1.Size = new System.Drawing.Size(81, 13);
			this.labelUserName1.TabIndex = 0;
			this.labelUserName1.Text = "Name of User 1";
			// 
			// groupBoxDice
			// 
			this.groupBoxDice.BackColor = System.Drawing.Color.White;
			this.groupBoxDice.Location = new System.Drawing.Point(7, 93);
			this.groupBoxDice.Name = "groupBoxDice";
			this.groupBoxDice.Size = new System.Drawing.Size(176, 99);
			this.groupBoxDice.TabIndex = 1;
			this.groupBoxDice.TabStop = false;
			this.groupBoxDice.Text = "Dice";
			this.groupBoxDice.Paint += new System.Windows.Forms.PaintEventHandler(this.GroupBoxDicePaint);
			// 
			// groupBoxTurn
			// 
			this.groupBoxTurn.BackColor = System.Drawing.Color.White;
			this.groupBoxTurn.Controls.Add(this.panelColorTurn);
			this.groupBoxTurn.Controls.Add(this.labelTurn);
			this.groupBoxTurn.Location = new System.Drawing.Point(6, 20);
			this.groupBoxTurn.Name = "groupBoxTurn";
			this.groupBoxTurn.Size = new System.Drawing.Size(177, 66);
			this.groupBoxTurn.TabIndex = 0;
			this.groupBoxTurn.TabStop = false;
			this.groupBoxTurn.Text = "Turn";
			// 
			// panelColorTurn
			// 
			this.panelColorTurn.Location = new System.Drawing.Point(111, 23);
			this.panelColorTurn.Name = "panelColorTurn";
			this.panelColorTurn.Size = new System.Drawing.Size(25, 22);
			this.panelColorTurn.TabIndex = 1;
			// 
			// labelTurn
			// 
			this.labelTurn.AutoSize = true;
			this.labelTurn.Location = new System.Drawing.Point(6, 28);
			this.labelTurn.Name = "labelTurn";
			this.labelTurn.Size = new System.Drawing.Size(75, 13);
			this.labelTurn.TabIndex = 0;
			this.labelTurn.Text = "Turn on White";
			// 
			// BackgammonForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(824, 471);
			this.Controls.Add(this.groupBoxControlPanel);
			this.Controls.Add(this.DrawingPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "BackgammonForm";
			this.Text = "Backgammon";
			this.groupBoxControlPanel.ResumeLayout(false);
			this.groupBoxGameState.ResumeLayout(false);
			this.groupBoxGameState.PerformLayout();
			this.groupBoxTurn.ResumeLayout(false);
			this.groupBoxTurn.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel DrawingPanel;
		private System.Windows.Forms.GroupBox groupBoxControlPanel;
		private System.Windows.Forms.GroupBox groupBoxTurn;
		private System.Windows.Forms.Panel panelColorTurn;
		private System.Windows.Forms.Label labelTurn;
		private System.Windows.Forms.GroupBox groupBoxDice;
		private System.Windows.Forms.GroupBox groupBoxGameState;
		private System.Windows.Forms.Label labelUserName2;
		private System.Windows.Forms.Label labelUserName1;
		private System.Windows.Forms.Label labelProgressUser2;
		private System.Windows.Forms.ProgressBar progressBarUser2;
		private System.Windows.Forms.Label labelProgressUser1;
		private System.Windows.Forms.ProgressBar progressBarUser1;
		private System.Windows.Forms.Button buttonStart;
	}
}

