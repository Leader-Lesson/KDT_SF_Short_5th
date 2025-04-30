namespace WindowsFormsApp_04_Condition_Enum_If_prac
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_userScore = new System.Windows.Forms.TextBox();
            this.textBox_comScore = new System.Windows.Forms.TextBox();
            this.textBox_result2 = new System.Windows.Forms.TextBox();
            this.button_paper = new System.Windows.Forms.Button();
            this.button_rock = new System.Windows.Forms.Button();
            this.button_scissors = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(492, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "마왕";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(262, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "용사";
            // 
            // textBox_userScore
            // 
            this.textBox_userScore.Location = new System.Drawing.Point(232, 290);
            this.textBox_userScore.Name = "textBox_userScore";
            this.textBox_userScore.Size = new System.Drawing.Size(100, 21);
            this.textBox_userScore.TabIndex = 16;
            // 
            // textBox_comScore
            // 
            this.textBox_comScore.Location = new System.Drawing.Point(460, 290);
            this.textBox_comScore.Name = "textBox_comScore";
            this.textBox_comScore.Size = new System.Drawing.Size(100, 21);
            this.textBox_comScore.TabIndex = 15;
            // 
            // textBox_result2
            // 
            this.textBox_result2.Location = new System.Drawing.Point(232, 52);
            this.textBox_result2.Multiline = true;
            this.textBox_result2.Name = "textBox_result2";
            this.textBox_result2.Size = new System.Drawing.Size(336, 192);
            this.textBox_result2.TabIndex = 14;
            // 
            // button_paper
            // 
            this.button_paper.Location = new System.Drawing.Point(460, 338);
            this.button_paper.Name = "button_paper";
            this.button_paper.Size = new System.Drawing.Size(108, 60);
            this.button_paper.TabIndex = 13;
            this.button_paper.Text = "보";
            this.button_paper.UseVisualStyleBackColor = true;
            this.button_paper.Click += new System.EventHandler(this.button_paper_Click);
            // 
            // button_rock
            // 
            this.button_rock.Location = new System.Drawing.Point(346, 338);
            this.button_rock.Name = "button_rock";
            this.button_rock.Size = new System.Drawing.Size(108, 60);
            this.button_rock.TabIndex = 12;
            this.button_rock.Text = "바위";
            this.button_rock.UseVisualStyleBackColor = true;
            this.button_rock.Click += new System.EventHandler(this.button_rock_Click);
            // 
            // button_scissors
            // 
            this.button_scissors.Location = new System.Drawing.Point(232, 338);
            this.button_scissors.Name = "button_scissors";
            this.button_scissors.Size = new System.Drawing.Size(108, 60);
            this.button_scissors.TabIndex = 11;
            this.button_scissors.Text = "가위";
            this.button_scissors.UseVisualStyleBackColor = true;
            this.button_scissors.Click += new System.EventHandler(this.button_scissors_Click);
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
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_userScore;
        private System.Windows.Forms.TextBox textBox_comScore;
        private System.Windows.Forms.TextBox textBox_result2;
        private System.Windows.Forms.Button button_paper;
        private System.Windows.Forms.Button button_rock;
        private System.Windows.Forms.Button button_scissors;
    }
}

