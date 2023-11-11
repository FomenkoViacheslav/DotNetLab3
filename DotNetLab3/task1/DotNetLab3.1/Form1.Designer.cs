namespace DotNetLab3._1
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
            EncryptBtn = new Button();
            type_key_label = new Label();
            KeyInput = new TextBox();
            progressBar1 = new ProgressBar();
            descript_file_btn = new Button();
            from_label = new Label();
            To_label = new Label();
            from_info_label = new Label();
            to_info_label = new Label();
            size_label = new Label();
            size_inf_label = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // EncryptBtn
            // 
            EncryptBtn.Location = new Point(94, 208);
            EncryptBtn.Name = "EncryptBtn";
            EncryptBtn.Size = new Size(145, 68);
            EncryptBtn.TabIndex = 0;
            EncryptBtn.Text = "Encrypt file";
            EncryptBtn.UseVisualStyleBackColor = true;
            EncryptBtn.Click += open_Click;
            // 
            // type_key_label
            // 
            type_key_label.AutoSize = true;
            type_key_label.Location = new Point(174, 67);
            type_key_label.Name = "type_key_label";
            type_key_label.Size = new Size(122, 32);
            type_key_label.TabIndex = 1;
            type_key_label.Text = "Select key";
            type_key_label.Click += type_key_label_Click;
            // 
            // KeyInput
            // 
            KeyInput.Location = new Point(142, 122);
            KeyInput.Name = "KeyInput";
            KeyInput.Size = new Size(200, 39);
            KeyInput.TabIndex = 2;
            KeyInput.Text = "key";
            KeyInput.TextChanged += KeyInput_TextChanged;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(74, 559);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(349, 45);
            progressBar1.TabIndex = 3;
            // 
            // descript_file_btn
            // 
            descript_file_btn.Location = new Point(285, 208);
            descript_file_btn.Name = "descript_file_btn";
            descript_file_btn.Size = new Size(170, 68);
            descript_file_btn.TabIndex = 4;
            descript_file_btn.Text = "Descrypt file";
            descript_file_btn.UseVisualStyleBackColor = true;
            descript_file_btn.Click += descript_file_btn_Click;
            // 
            // from_label
            // 
            from_label.AutoSize = true;
            from_label.Location = new Point(74, 329);
            from_label.Name = "from_label";
            from_label.Size = new Size(74, 32);
            from_label.TabIndex = 5;
            from_label.Text = "From:";
            // 
            // To_label
            // 
            To_label.AutoSize = true;
            To_label.Location = new Point(74, 402);
            To_label.Name = "To_label";
            To_label.Size = new Size(44, 32);
            To_label.TabIndex = 6;
            To_label.Text = "To:";
            // 
            // from_info_label
            // 
            from_info_label.AutoSize = true;
            from_info_label.Location = new Point(142, 329);
            from_info_label.Name = "from_info_label";
            from_info_label.Size = new Size(0, 32);
            from_info_label.TabIndex = 7;
            // 
            // to_info_label
            // 
            to_info_label.AutoSize = true;
            to_info_label.Location = new Point(124, 402);
            to_info_label.Name = "to_info_label";
            to_info_label.Size = new Size(0, 32);
            to_info_label.TabIndex = 8;
            // 
            // size_label
            // 
            size_label.AutoSize = true;
            size_label.Location = new Point(74, 466);
            size_label.Name = "size_label";
            size_label.Size = new Size(62, 32);
            size_label.TabIndex = 9;
            size_label.Tag = "";
            size_label.Text = "Size:";
            // 
            // size_inf_label
            // 
            size_inf_label.AutoSize = true;
            size_inf_label.Location = new Point(142, 466);
            size_inf_label.Name = "size_inf_label";
            size_inf_label.Size = new Size(46, 32);
            size_inf_label.TabIndex = 10;
            size_inf_label.Text = "lab";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(277, 505);
            label1.Name = "label1";
            label1.Size = new Size(146, 32);
            label1.TabIndex = 11;
            label1.Text = "00:00:00:127";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(911, 673);
            Controls.Add(label1);
            Controls.Add(size_inf_label);
            Controls.Add(size_label);
            Controls.Add(to_info_label);
            Controls.Add(from_info_label);
            Controls.Add(To_label);
            Controls.Add(from_label);
            Controls.Add(descript_file_btn);
            Controls.Add(progressBar1);
            Controls.Add(KeyInput);
            Controls.Add(type_key_label);
            Controls.Add(EncryptBtn);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button EncryptBtn;
        private Label type_key_label;
        private TextBox KeyInput;
        private ProgressBar progressBar1;
        private Button descript_file_btn;
        private Label from_label;
        private Label To_label;
        private Label from_info_label;
        private Label to_info_label;
        private Label size_label;
        private Label size_inf_label;
        private Label label1;
    }
}