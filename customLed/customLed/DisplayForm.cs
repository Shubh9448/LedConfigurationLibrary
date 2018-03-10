using System;
using System.Drawing;
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
       
        public static ColorDialog cdLedOnColorDlg = new ColorDialog();
        public static ColorDialog cdLedOffColorDlg = new ColorDialog();

        




        public DisplayForm()
        {

            InitializeComponent();
            str_scroll_text1.Visible = false;


            loadFont();
         //   AllocFont(font, this.str_scroll_text, 16);

            AllocFont(font, this.str_scroll_text1, 16);
            AllocFont(font, this.str_scroll_text2, 16);
         //   AllocFont(font, this.label14, 26);
            AllocFont(font, this.label15, setTextSize);
            AllocFont(font, this.label16, setTextSize);

            label14.Text = str_scroll_text.Text;
            label15.Text = str_scroll_text1.Text;
            label16.Text = str_scroll_text2.Text;


            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;


           
            label14.Text = str_scroll_text.Text;
            



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
            label16.Left += 10;

            if (label15.Width > (this.Width - label14.Width))
            {
                label15.Left += 10;
                if (label15.Left >= this.Width)
                {
                    label15.Left = (label15.Width - label14.Width) * -1;
                }
                //Graphics gra = this.CreateGraphics();
                //gra.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                //gra.
            }
            if (label16.Left >= this.Width)
            {
                label16.Left = (label16.Width - label14.Width) * -1;
            }

        }

        private void scrollbutton_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void str_scroll_text1_TextChanged(object sender, EventArgs e)
        {
            label15.Text = str_scroll_text1.Text;
        }

        private void text_size_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            setTextSize = (int)text_size_numericUpDown.Value;
            label15.Font = new Font("Microsoft Sans Serif", (int)text_size_numericUpDown.Value, FontStyle.Regular);
            label16.Font = new Font("Microsoft Sans Serif", (int)text_size_numericUpDown.Value, FontStyle.Regular);
        }


        private void refresh_Click(object sender, EventArgs e)
        {
            this.ParentForm.Refresh();
        }
    }
}
