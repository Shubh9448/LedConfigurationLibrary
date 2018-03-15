using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace customLed
{
    public partial class DisplayForm : Form
    {

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcfonts);

        FontFamily ff;
        Font font;


        public static string text1 = "";
        public static string text2 = "";
        public static string text3 = "";
        public static int setTextSize = 50;
        public string font_type = "DS-Digital";

        public static ColorDialog cdLedOnColorDlg = new ColorDialog();
        public static ColorDialog cdLedOffColorDlg = new ColorDialog();

        public static SolidBrush brush;







        public DisplayForm()
        {

            InitializeComponent();


            loadFont();
            //   AllocFont(font, this.str_scroll_text, 16);

            AllocFont(font, this.kannada_textBox1, 16);
            AllocFont(font, this.kannada_textBox2, 16);
            //   AllocFont(font, this.label14, 26);
            AllocFont(font, this.kannada_label, setTextSize);
            AllocFont(font, this.kannada_label1, setTextSize);

            eng_textBox1.Font = new Font("Arial", 16, FontStyle.Regular);
            eng_textBox2.Font = new Font("Arial", 16, FontStyle.Regular);

            eng_textBox1.Visible = false;
            eng_textBox2.Visible = false;

            eng_label.Visible = false;
            eng_label1.Visible = false;

            // setting font type combobox and label to false 
            fontType_Combo.Visible = false;
            fontType_label.Visible = false;

            busNum_label.Text = str_scroll_text.Text;
            kannada_label.Text = kannada_textBox1.Text;
            kannada_label1.Text = kannada_textBox2.Text;

            // Default form component values
            clrButton.BackColor = eng_label.ForeColor;




            kannada_label.Font = new Font("Microsoft Sans Serif", setTextSize, FontStyle.Regular);
            kannada_label1.Font = new Font("Microsoft Sans Serif", setTextSize, FontStyle.Regular);
            eng_label.Font = new Font(font_type, setTextSize, FontStyle.Regular);
            eng_label1.Font = new Font(font_type, setTextSize, FontStyle.Regular);
            busNum_label.Font = new Font(font_type, setTextSize - 10 , FontStyle.Regular);

            foreach (FontFamily font in FontFamily.Families)
            {
                fontType_Combo.Items.Add(font.Name.ToString());
            }

            fontType_Combo.SelectedItem = "DS-Digital";

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void loadFont()
        {
            byte[] fontArray = Properties.Resources.Kannada;
            int dataLength = Properties.Resources.Kannada.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);

            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;

            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();

            pfc.AddMemoryFont(ptrData, dataLength);

            Marshal.FreeCoTaskMem(ptrData);

            ff = pfc.Families[0];
            font = new Font(ff, 12f, FontStyle.Regular);
        }

        private void AllocFont(Font f, Control c, float size)
        {
            FontStyle fontstyle = FontStyle.Regular;

            c.Font = new Font(ff, size, fontstyle);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();

            //   label15.Left += 10;
            kannada_label1.Left += 10;

            if (kannada_label.Width > (this.Width - busNum_label.Width))
            {
                kannada_label.Left += 10;
                if (kannada_label.Left >= this.Width)
                {
                    kannada_label.Left = (kannada_label.Width - busNum_label.Width) * -1;
                }
                //Graphics gra = this.CreateGraphics();
                //gra.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                //gra.
            }
            if (kannada_label1.Left >= this.Width)
            {
                kannada_label1.Left = (kannada_label1.Width - busNum_label.Width) * -1;
            }

        }

        private void scrollbutton_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void str_scroll_text1_TextChanged(object sender, EventArgs e)
        {
            kannada_label.Text = kannada_textBox1.Text;
        }

        private void text_size_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            setTextSize = (int)text_size_numericUpDown.Value;
            kannada_label.Font = new Font(font_type, setTextSize, FontStyle.Regular);
            kannada_label1.Font = new Font(font_type, setTextSize, FontStyle.Regular);
            eng_label.Font = new Font(font_type, setTextSize, FontStyle.Regular);
            eng_label1.Font = new Font(font_type, setTextSize, FontStyle.Regular);
            busNum_label.Font = new Font(font_type, setTextSize - 10, FontStyle.Regular);

        }


        private void refresh_Click(object sender, EventArgs e)
        {
            this.ParentForm.Refresh();
        }
        
        private void lang_combo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lang_combo.SelectedIndex == 0)
            {
                eng_textBox1.Visible = true;
                eng_textBox2.Visible = true;
                eng_label.Visible = true;
                eng_label1.Visible = true;
                fontType_Combo.Visible = true;
                fontType_label.Visible = true;

                kannada_label.Visible = false;
                kannada_label1.Visible = false;
                kannada_textBox1.Visible = false;
                kannada_textBox2.Visible = false;
                eng_label.Text = eng_textBox1.Text;
                eng_label1.Text = eng_textBox2.Text;
                timer2.Start();
            }

            else
            {
                eng_textBox1.Visible = false;
                eng_textBox2.Visible = false;
                eng_label.Visible = false;
                eng_label1.Visible = false;
                fontType_Combo.Visible = false;
                fontType_label.Visible = false;

                kannada_label.Visible = true;
                kannada_label1.Visible = true;
                kannada_textBox1.Visible = true;
                kannada_textBox2.Visible = true;
                kannada_label.Text = kannada_textBox1.Text;
                kannada_label1.Text = kannada_textBox2.Text;



            }
        }

        private void kannada_textBox2_TextChanged(object sender, EventArgs e)
        {
            kannada_label1.Text = kannada_textBox2.Text;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Refresh();

            //   label15.Left += 10;
            eng_label1.Left += 10;

            if (eng_label.Width > (this.Width - busNum_label.Width))
            {
                eng_label.Left += 10;
                if (eng_label.Left >= this.Width)
                {
                    eng_label.Left = (eng_label.Width - busNum_label.Width) * -1;
                }
                //Graphics gra = this.CreateGraphics();
                //gra.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                //gra.
            }
            if (eng_label1.Left >= this.Width)
            {
                eng_label1.Left = (eng_label1.Width - busNum_label.Width) * -1;
            }
        }

        private void eng_textBox1_TextChanged_1(object sender, EventArgs e)
        {
            eng_label.Text = eng_textBox1.Text;
        }

        private void eng_textBox2_TextChanged_1(object sender, EventArgs e)
        {
            eng_label1.Text = eng_textBox2.Text;
        }

        private void fontType_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            font_type = fontType_Combo.SelectedItem.ToString();
            eng_label.Font = new Font(font_type, setTextSize, FontStyle.Regular);
            eng_label1.Font = new Font(font_type, setTextSize, FontStyle.Regular);
            busNum_label.Font = new Font(font_type, setTextSize - 10, FontStyle.Regular);

        }

        private void clrButton_Click(object sender, EventArgs e)
        {
            ColorDialog cdLedOffColorDlg = new ColorDialog();

            if (cdLedOffColorDlg.ShowDialog() == DialogResult.OK)
            {
                clrButton.BackColor = cdLedOffColorDlg.Color;
                eng_label.ForeColor = cdLedOffColorDlg.Color;
                eng_label1.ForeColor = cdLedOffColorDlg.Color;
                busNum_label.ForeColor = cdLedOffColorDlg.Color;
                kannada_label.ForeColor = cdLedOffColorDlg.Color;
                kannada_label1.ForeColor = cdLedOffColorDlg.Color;
            }
        }

        private void ledDisplay_panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            brush = new SolidBrush(Color.Black);

            // Calling the base class OnPaint
            base.OnPaint(e);

            // Antialiasing
            gfx.SmoothingMode = SmoothingMode.AntiAlias;

            for (int i = 3; i < ledDisplay_panel.Height; i += 8)
            {
                for (int j = 3; j < ledDisplay_panel.Width; j += 8)
                {
                    gfx.FillPie(brush, j, i, 4, 4, 0, 360);
                }
            }
        }
        
    }
}
