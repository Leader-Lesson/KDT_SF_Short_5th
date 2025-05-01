namespace WindowsFormsApp_04_Condition
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
            this.button_input = new System.Windows.Forms.Button();
            this.radioButton_true = new System.Windows.Forms.RadioButton();
            this.radioButton_false = new System.Windows.Forms.RadioButton();
            this.textBox_print = new System.Windows.Forms.TextBox();
            this.button_input2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_result
            // 
            this.textBox_result.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_result.Location = new System.Drawing.Point(47, 250);
            this.textBox_result.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.ReadOnly = true;
            this.textBox_result.Size = new System.Drawing.Size(624, 157);
            this.textBox_result.TabIndex = 2;
            this.textBox_result.Text = " ";
            // 
            // textBox_input
            // 
            this.textBox_input.Location = new System.Drawing.Point(73, 100);
            this.textBox_input.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.Size = new System.Drawing.Size(330, 28);
            this.textBox_input.TabIndex = 0;
            // 
            // button_input
            // 
            this.button_input.Location = new System.Drawing.Point(459, 70);
            this.button_input.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_input.Name = "button_input";
            this.button_input.Size = new System.Drawing.Size(130, 88);
            this.button_input.TabIndex = 1;
            this.button_input.Text = "Input";
            this.button_input.UseVisualStyleBackColor = true;
            this.button_input.Click += new System.EventHandler(this.button_input_Click);
            // 
            // radioButton_true
            // 
            this.radioButton_true.AutoSize = true;
            this.radioButton_true.Location = new System.Drawing.Point(89, 166);
            this.radioButton_true.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton_true.Name = "radioButton_true";
            this.radioButton_true.Size = new System.Drawing.Size(64, 22);
            this.radioButton_true.TabIndex = 3;
            this.radioButton_true.TabStop = true;
            this.radioButton_true.Text = "true";
            this.radioButton_true.UseVisualStyleBackColor = true;
            // 
            // radioButton_false
            // 
            this.radioButton_false.AutoSize = true;
            this.radioButton_false.Location = new System.Drawing.Point(253, 165);
            this.radioButton_false.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton_false.Name = "radioButton_false";
            this.radioButton_false.Size = new System.Drawing.Size(71, 22);
            this.radioButton_false.TabIndex = 4;
            this.radioButton_false.TabStop = true;
            this.radioButton_false.Text = "false";
            this.radioButton_false.UseVisualStyleBackColor = true;
            // 
            // textBox_print
            // 
            this.textBox_print.Font = new System.Drawing.Font("Gulim", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_print.Location = new System.Drawing.Point(225, 446);
            this.textBox_print.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_print.Multiline = true;
            this.textBox_print.Name = "textBox_print";
            this.textBox_print.Size = new System.Drawing.Size(300, 203);
            this.textBox_print.TabIndex = 5;
            // 
            // button_input2
            // 
            this.button_input2.Location = new System.Drawing.Point(610, 70);
            this.button_input2.Name = "button_input2";
            this.button_input2.Size = new System.Drawing.Size(111, 88);
            this.button_input2.TabIndex = 6;
            this.button_input2.Text = "요일";
            this.button_input2.UseVisualStyleBackColor = true;
            this.button_input2.Click += new System.EventHandler(this.button_input2_Click2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 704);
            this.Controls.Add(this.button_input2);
            this.Controls.Add(this.textBox_print);
            this.Controls.Add(this.radioButton_false);
            this.Controls.Add(this.radioButton_true);
            this.Controls.Add(this.button_input);
            this.Controls.Add(this.textBox_input);
            this.Controls.Add(this.textBox_result);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.TextBox textBox_input;
        private System.Windows.Forms.Button button_input;
        private System.Windows.Forms.RadioButton radioButton_true;
        private System.Windows.Forms.RadioButton radioButton_false;
        private System.Windows.Forms.TextBox textBox_print;
        private System.Windows.Forms.Button button_input2;
    }
}

