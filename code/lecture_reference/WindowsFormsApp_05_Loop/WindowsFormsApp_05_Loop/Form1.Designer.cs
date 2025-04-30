namespace WindowsFormsApp_05_Loop
{
    partial class Form1
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
            if (disposing && (components != null))
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
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.textBox_input = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button_scissors = new System.Windows.Forms.Button();
            this.button_rock = new System.Windows.Forms.Button();
            this.button_paper = new System.Windows.Forms.Button();
            this.textBox_result2 = new System.Windows.Forms.TextBox();
            this.textBox_comScore = new System.Windows.Forms.TextBox();
            this.textBox_userScore = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_result
            // 
            this.textBox_result.Location = new System.Drawing.Point(12, 53);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.Size = new System.Drawing.Size(198, 108);
            this.textBox_result.TabIndex = 0;
            // 
            // textBox_input
            // 
            this.textBox_input.Location = new System.Drawing.Point(12, 24);
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.Size = new System.Drawing.Size(172, 21);
            this.textBox_input.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_scissors
            // 
            this.button_scissors.Location = new System.Drawing.Point(409, 310);
            this.button_scissors.Name = "button_scissors";
            this.button_scissors.Size = new System.Drawing.Size(108, 60);
            this.button_scissors.TabIndex = 3;
            this.button_scissors.Text = "가위";
            this.button_scissors.UseVisualStyleBackColor = true;
            this.button_scissors.Click += new System.EventHandler(this.button_scissors_Click);
            // 
            // button_rock
            // 
            this.button_rock.Location = new System.Drawing.Point(523, 310);
            this.button_rock.Name = "button_rock";
            this.button_rock.Size = new System.Drawing.Size(108, 60);
            this.button_rock.TabIndex = 4;
            this.button_rock.Text = "바위";
            this.button_rock.UseVisualStyleBackColor = true;
            this.button_rock.Click += new System.EventHandler(this.button_rock_Click);
            // 
            // button_paper
            // 
            this.button_paper.Location = new System.Drawing.Point(637, 310);
            this.button_paper.Name = "button_paper";
            this.button_paper.Size = new System.Drawing.Size(108, 60);
            this.button_paper.TabIndex = 5;
            this.button_paper.Text = "보";
            this.button_paper.UseVisualStyleBackColor = true;
            this.button_paper.Click += new System.EventHandler(this.button_paper_Click);
            // 
            // textBox_result2
            // 
            this.textBox_result2.Location = new System.Drawing.Point(409, 24);
            this.textBox_result2.Multiline = true;
            this.textBox_result2.Name = "textBox_result2";
            this.textBox_result2.Size = new System.Drawing.Size(336, 192);
            this.textBox_result2.TabIndex = 6;
            // 
            // textBox_comScore
            // 
            this.textBox_comScore.Location = new System.Drawing.Point(637, 262);
            this.textBox_comScore.Name = "textBox_comScore";
            this.textBox_comScore.Size = new System.Drawing.Size(100, 21);
            this.textBox_comScore.TabIndex = 7;
            // 
            // textBox_userScore
            // 
            this.textBox_userScore.Location = new System.Drawing.Point(409, 262);
            this.textBox_userScore.Name = "textBox_userScore";
            this.textBox_userScore.Size = new System.Drawing.Size(100, 21);
            this.textBox_userScore.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(439, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "용사";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(669, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "마왕";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_userScore);
            this.Controls.Add(this.textBox_comScore);
            this.Controls.Add(this.textBox_result2);
            this.Controls.Add(this.button_paper);
            this.Controls.Add(this.button_rock);
            this.Controls.Add(this.button_scissors);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_input);
            this.Controls.Add(this.textBox_result);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.TextBox textBox_input;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_scissors;
        private System.Windows.Forms.Button button_rock;
        private System.Windows.Forms.Button button_paper;
        private System.Windows.Forms.TextBox textBox_result2;
        private System.Windows.Forms.TextBox textBox_comScore;
        private System.Windows.Forms.TextBox textBox_userScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

