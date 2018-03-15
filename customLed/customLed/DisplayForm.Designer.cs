namespace customLed
{
    partial class DisplayForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayForm));
            this.busNum_label = new System.Windows.Forms.Label();
            this.ledDisplay_panel = new System.Windows.Forms.Panel();
            this.eng_label1 = new System.Windows.Forms.Label();
            this.kannada_label = new System.Windows.Forms.Label();
            this.eng_label = new System.Windows.Forms.Label();
            this.kannada_label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.scrollbutton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.str_scroll_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.eng_textBox1 = new System.Windows.Forms.TextBox();
            this.kannada_textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.eng_textBox2 = new System.Windows.Forms.TextBox();
            this.kannada_textBox2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.clrButton = new System.Windows.Forms.Button();
            this.fontType_label = new System.Windows.Forms.Label();
            this.fontType_Combo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lang_combo = new System.Windows.Forms.ComboBox();
            this.refresh = new System.Windows.Forms.Button();
            this.text_size_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.ledDisplay_panel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.text_size_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // busNum_label
            // 
            resources.ApplyResources(this.busNum_label, "busNum_label");
            this.busNum_label.BackColor = System.Drawing.Color.Transparent;
            this.busNum_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.busNum_label.Name = "busNum_label";
            // 
            // ledDisplay_panel
            // 
            this.ledDisplay_panel.BackColor = System.Drawing.Color.White;
            this.ledDisplay_panel.Controls.Add(this.busNum_label);
            this.ledDisplay_panel.Controls.Add(this.eng_label1);
            this.ledDisplay_panel.Controls.Add(this.kannada_label);
            this.ledDisplay_panel.Controls.Add(this.eng_label);
            this.ledDisplay_panel.Controls.Add(this.kannada_label1);
            resources.ApplyResources(this.ledDisplay_panel, "ledDisplay_panel");
            this.ledDisplay_panel.Name = "ledDisplay_panel";
            this.ledDisplay_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.ledDisplay_panel_Paint);
            // 
            // eng_label1
            // 
            resources.ApplyResources(this.eng_label1, "eng_label1");
            this.eng_label1.BackColor = System.Drawing.Color.Transparent;
            this.eng_label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.eng_label1.Name = "eng_label1";
            this.eng_label1.UseCompatibleTextRendering = true;
            // 
            // kannada_label
            // 
            resources.ApplyResources(this.kannada_label, "kannada_label");
            this.kannada_label.BackColor = System.Drawing.Color.Transparent;
            this.kannada_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.kannada_label.Name = "kannada_label";
            this.kannada_label.UseCompatibleTextRendering = true;
            // 
            // eng_label
            // 
            resources.ApplyResources(this.eng_label, "eng_label");
            this.eng_label.BackColor = System.Drawing.Color.Transparent;
            this.eng_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.eng_label.Name = "eng_label";
            this.eng_label.UseCompatibleTextRendering = true;
            // 
            // kannada_label1
            // 
            resources.ApplyResources(this.kannada_label1, "kannada_label1");
            this.kannada_label1.BackColor = System.Drawing.Color.Transparent;
            this.kannada_label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.kannada_label1.Name = "kannada_label1";
            this.kannada_label1.UseCompatibleTextRendering = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // scrollbutton
            // 
            resources.ApplyResources(this.scrollbutton, "scrollbutton");
            this.scrollbutton.Name = "scrollbutton";
            this.scrollbutton.UseVisualStyleBackColor = true;
            this.scrollbutton.Click += new System.EventHandler(this.scrollbutton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Controls.Add(this.str_scroll_text);
            this.groupBox2.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // str_scroll_text
            // 
            resources.ApplyResources(this.str_scroll_text, "str_scroll_text");
            this.str_scroll_text.Name = "str_scroll_text";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Name = "label1";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox3.Controls.Add(this.eng_textBox1);
            this.groupBox3.Controls.Add(this.kannada_textBox1);
            this.groupBox3.Controls.Add(this.label10);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // eng_textBox1
            // 
            resources.ApplyResources(this.eng_textBox1, "eng_textBox1");
            this.eng_textBox1.Name = "eng_textBox1";
            this.eng_textBox1.TextChanged += new System.EventHandler(this.eng_textBox1_TextChanged_1);
            // 
            // kannada_textBox1
            // 
            resources.ApplyResources(this.kannada_textBox1, "kannada_textBox1");
            this.kannada_textBox1.Name = "kannada_textBox1";
            this.kannada_textBox1.TextChanged += new System.EventHandler(this.str_scroll_text1_TextChanged);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.BackColor = System.Drawing.Color.Gainsboro;
            this.label10.Name = "label10";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox4.Controls.Add(this.eng_textBox2);
            this.groupBox4.Controls.Add(this.kannada_textBox2);
            this.groupBox4.Controls.Add(this.label13);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // eng_textBox2
            // 
            resources.ApplyResources(this.eng_textBox2, "eng_textBox2");
            this.eng_textBox2.Name = "eng_textBox2";
            this.eng_textBox2.TextChanged += new System.EventHandler(this.eng_textBox2_TextChanged_1);
            // 
            // kannada_textBox2
            // 
            resources.ApplyResources(this.kannada_textBox2, "kannada_textBox2");
            this.kannada_textBox2.Name = "kannada_textBox2";
            this.kannada_textBox2.TextChanged += new System.EventHandler(this.kannada_textBox2_TextChanged);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.BackColor = System.Drawing.Color.Gainsboro;
            this.label13.Name = "label13";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.clrButton);
            this.panel1.Controls.Add(this.fontType_label);
            this.panel1.Controls.Add(this.fontType_Combo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lang_combo);
            this.panel1.Controls.Add(this.refresh);
            this.panel1.Controls.Add(this.text_size_numericUpDown);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.scrollbutton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // clrButton
            // 
            resources.ApplyResources(this.clrButton, "clrButton");
            this.clrButton.Name = "clrButton";
            this.clrButton.UseVisualStyleBackColor = true;
            this.clrButton.Click += new System.EventHandler(this.clrButton_Click);
            // 
            // fontType_label
            // 
            resources.ApplyResources(this.fontType_label, "fontType_label");
            this.fontType_label.Name = "fontType_label";
            // 
            // fontType_Combo
            // 
            this.fontType_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fontType_Combo.FormattingEnabled = true;
            resources.ApplyResources(this.fontType_Combo, "fontType_Combo");
            this.fontType_Combo.Name = "fontType_Combo";
            this.fontType_Combo.SelectedIndexChanged += new System.EventHandler(this.fontType_Combo_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // lang_combo
            // 
            this.lang_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lang_combo.FormattingEnabled = true;
            this.lang_combo.Items.AddRange(new object[] {
            resources.GetString("lang_combo.Items"),
            resources.GetString("lang_combo.Items1")});
            resources.ApplyResources(this.lang_combo, "lang_combo");
            this.lang_combo.Name = "lang_combo";
            this.lang_combo.SelectedIndexChanged += new System.EventHandler(this.lang_combo_SelectedIndexChanged_1);
            // 
            // refresh
            // 
            resources.ApplyResources(this.refresh, "refresh");
            this.refresh.Name = "refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // text_size_numericUpDown
            // 
            resources.ApplyResources(this.text_size_numericUpDown, "text_size_numericUpDown");
            this.text_size_numericUpDown.Name = "text_size_numericUpDown";
            this.text_size_numericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.text_size_numericUpDown.ValueChanged += new System.EventHandler(this.text_size_numericUpDown_ValueChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // DisplayForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.ledDisplay_panel);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "DisplayForm";
            this.ledDisplay_panel.ResumeLayout(false);
            this.ledDisplay_panel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.text_size_numericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label busNum_label;
        private System.Windows.Forms.Panel ledDisplay_panel;
        private System.Windows.Forms.Label kannada_label;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label kannada_label1;
        private System.Windows.Forms.Button scrollbutton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox str_scroll_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox kannada_textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox kannada_textBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown text_size_numericUpDown;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.TextBox eng_textBox1;
        private System.Windows.Forms.TextBox eng_textBox2;
        private System.Windows.Forms.Label eng_label1;
        private System.Windows.Forms.Label eng_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox lang_combo;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label fontType_label;
        private System.Windows.Forms.ComboBox fontType_Combo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button clrButton;
        private CustomLedControl customLedControl1;
    }
}

