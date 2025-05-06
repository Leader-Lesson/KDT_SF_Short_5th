namespace WindowsFormsApp_04_2_EnumEx
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
            this.textBox_userScore = new System.Windows.Forms.TextBox();
            this.textBox_comScore = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_scissor = new System.Windows.Forms.Button();
            this.button_rock = new System.Windows.Forms.Button();
            this.button_paper = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_result
            // 
            this.textBox_result.Font = new System.Drawing.Font("Gulim", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_result.Location = new System.Drawing.Point(258, 30);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.Size = new System.Drawing.Size(809, 287);
            this.textBox_result.TabIndex = 0;
            // 
            // textBox_userScore
            // 
            this.textBox_userScore.Font = new System.Drawing.Font("Gulim", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_userScore.Location = new System.Drawing.Point(258, 437);
            this.textBox_userScore.Name = "textBox_userScore";
            this.textBox_userScore.Size = new System.Drawing.Size(329, 44);
            this.textBox_userScore.TabIndex = 1;
            // 
            // textBox_comScore
            // 
            this.textBox_comScore.Font = new System.Drawing.Font("Gulim", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_comScore.Location = new System.Drawing.Point(751, 437);
            this.textBox_comScore.Name = "textBox_comScore";
            this.textBox_comScore.Size = new System.Drawing.Size(316, 44);
            this.textBox_comScore.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gulim", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(379, 379);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "용사";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gulim", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(870, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "마왕";
            // 
            // button_scissor
            // 
            this.button_scissor.Font = new System.Drawing.Font("Gulim", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_scissor.Location = new System.Drawing.Point(258, 585);
            this.button_scissor.Name = "button_scissor";
            this.button_scissor.Size = new System.Drawing.Size(252, 121);
            this.button_scissor.TabIndex = 5;
            this.button_scissor.Text = "가위";
            this.button_scissor.UseVisualStyleBackColor = true;
            this.button_scissor.Click += new System.EventHandler(this.button_scissor_Click);
            // 
            // button_rock
            // 
            this.button_rock.Font = new System.Drawing.Font("Gulim", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_rock.Location = new System.Drawing.Point(538, 585);
            this.button_rock.Name = "button_rock";
            this.button_rock.Size = new System.Drawing.Size(252, 121);
            this.button_rock.TabIndex = 6;
            this.button_rock.Text = "바위";
            this.button_rock.UseVisualStyleBackColor = true;
            this.button_rock.Click += new System.EventHandler(this.button_rock_Click);
            // 
            // button_paper
            // 
            this.button_paper.Font = new System.Drawing.Font("Gulim", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_paper.Location = new System.Drawing.Point(815, 585);
            this.button_paper.Name = "button_paper";
            this.button_paper.Size = new System.Drawing.Size(252, 121);
            this.button_paper.TabIndex = 7;
            this.button_paper.Text = "보";
            this.button_paper.UseVisualStyleBackColor = true;
            this.button_paper.Click += new System.EventHandler(this.button_paper_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 775);
            this.Controls.Add(this.button_paper);
            this.Controls.Add(this.button_rock);
            this.Controls.Add(this.button_scissor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_comScore);
            this.Controls.Add(this.textBox_userScore);
            this.Controls.Add(this.textBox_result);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.TextBox textBox_userScore;
        private System.Windows.Forms.TextBox textBox_comScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_scissor;
        private System.Windows.Forms.Button button_rock;
        private System.Windows.Forms.Button button_paper;
    }
}

