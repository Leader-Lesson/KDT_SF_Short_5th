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
            this.button_input2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_result
            // 
            this.textBox_result.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_result.Font = new System.Drawing.Font("Gulim", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_result.Location = new System.Drawing.Point(255, 436);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.ReadOnly = true;
            this.textBox_result.Size = new System.Drawing.Size(950, 402);
            this.textBox_result.TabIndex = 2;
            // 
            // textBox_input
            // 
            this.textBox_input.Font = new System.Drawing.Font("Gulim", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_input.Location = new System.Drawing.Point(255, 222);
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.Size = new System.Drawing.Size(571, 44);
            this.textBox_input.TabIndex = 0;
            // 
            // button_input
            // 
            this.button_input.Font = new System.Drawing.Font("Gulim", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_input.Location = new System.Drawing.Point(922, 186);
            this.button_input.Name = "button_input";
            this.button_input.Size = new System.Drawing.Size(283, 98);
            this.button_input.TabIndex = 1;
            this.button_input.Text = "Input";
            this.button_input.UseVisualStyleBackColor = true;
            this.button_input.Click += new System.EventHandler(this.button_input_Click);
            // 
            // radioButton_true
            // 
            this.radioButton_true.AutoSize = true;
            this.radioButton_true.Checked = true;
            this.radioButton_true.Font = new System.Drawing.Font("Gulim", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioButton_true.Location = new System.Drawing.Point(279, 319);
            this.radioButton_true.Name = "radioButton_true";
            this.radioButton_true.Size = new System.Drawing.Size(192, 36);
            this.radioButton_true.TabIndex = 3;
            this.radioButton_true.TabStop = true;
            this.radioButton_true.Text = "true(앞면)";
            this.radioButton_true.UseVisualStyleBackColor = true;
            // 
            // radioButton_false
            // 
            this.radioButton_false.AutoSize = true;
            this.radioButton_false.Font = new System.Drawing.Font("Gulim", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioButton_false.Location = new System.Drawing.Point(593, 319);
            this.radioButton_false.Name = "radioButton_false";
            this.radioButton_false.Size = new System.Drawing.Size(207, 36);
            this.radioButton_false.TabIndex = 4;
            this.radioButton_false.Text = "false(뒷면)";
            this.radioButton_false.UseVisualStyleBackColor = true;
            // 
            // button_input2
            // 
            this.button_input2.Font = new System.Drawing.Font("Gulim", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_input2.Location = new System.Drawing.Point(922, 331);
            this.button_input2.Name = "button_input2";
            this.button_input2.Size = new System.Drawing.Size(283, 99);
            this.button_input2.TabIndex = 5;
            this.button_input2.Text = "요일 클릭";
            this.button_input2.UseVisualStyleBackColor = true;
            this.button_input2.Click += new System.EventHandler(this.button_input2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1704, 1020);
            this.Controls.Add(this.button_input2);
            this.Controls.Add(this.radioButton_false);
            this.Controls.Add(this.radioButton_true);
            this.Controls.Add(this.button_input);
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
        private System.Windows.Forms.Button button_input;
        private System.Windows.Forms.RadioButton radioButton_true;
        private System.Windows.Forms.RadioButton radioButton_false;
        private System.Windows.Forms.Button button_input2;
    }
}

