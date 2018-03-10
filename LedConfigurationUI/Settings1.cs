using LedConfigurationLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LedConfigurationUI
{
    public partial class Settings1 : Form
    {
        public Settings1()
        {
            InitializeComponent();
            
            foreach (FontFamily font in FontFamily.Families)
            {
                FontType.Items.Add(font.Name.ToString());
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            List<string> DestinationPlace = new List<string>();
            DestinationPlace.Add("Destination place size");
            DestinationPlace.Add("Destination place font type");
            DestinationPlace.Add("Destination place font type swap");
            DestinationPlace.Add("Destination place swap font type");
            DestinationPlace.Add("Destination place font type swap after time");
            DestinationPlace.Add("Destination place color RGB foreground");
            DestinationPlace.Add("Destination place color RGB background");
            DestinationPlace.Add("Destination place position");
            DestinationPlace.Add("Destination place static");
            DestinationPlace.Add("Destination place swap");
            DestinationPlace.Add("Destination place swap position");
            DestinationPlace.Add("Destination place swap position after time");
            DestinationPlace.Add("Destination place scroll frequency");

            if (ValidateForm())
            {
                SettingsModel model = new SettingsModel();

                model.FieldSize = FieldSize.Text;
                model.Font = FontType.Text;
                model.FontTypeSwap = FontTypeSwap.Text;
                model.RGBforeground = RGBforeground.Text;
                model.RGBbackground = RGBbackground.Text;
                model.TextPosition = TextPosition.Text;
                model.SwapFontType = SwapFontType.Text;
                model.SwapAfterTime = SwapAfterTime.Text;
                model.Swap = Swap.Text;
                model.Static = Static.Text;
                model.SwapPositionAfter = SwapPositionAfter.Text;
                model.SwapPosition = SwapPosition.Text;
                model.ScrollFrequency = ScrollFrequency.Text;



                foreach (IDataConnection text in GlobalConfig.Connections)
                {
                    text.CreateSettings(model, DestinationPlace);
                }
            }

            else
            {
                MessageBox.Show("Please enter the details", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            bool output = true;

            if (FieldSize.Text.Length == 0)
            {
                output = false;
            }

            if (FontType.SelectedItem.ToString() == null)
            {
                output = false;
            }

            if (FontTypeSwap.Text.Length == 0)
            {
                output = false;
            }

            if (SwapFontType.SelectedItem.ToString() == null)
            {
                output = false;
            }

            if (Swap.Text.Length == 0)
            {
                output = false;
            }

            if (SwapPositionAfter.Text.Length == 0)
            {
                output = false;
            }

            if (ScrollFrequency.Text.Length == 0)
            {
                output = false;
            }

            if (RGBforeground.Text.Length == 0)
            {
                output = false;
            }

            if (RGBbackground.Text.Length == 0)
            {
                output = false;
            }

            if (TextPosition.Text.Length == 0)
            {
                output = false;
            }

            if (SwapAfterTime.Text.Length == 0)
            {
                output = false;
            }

            if (Static.Text.Length == 0)
            {
                output = false;
            }

            if (SwapPosition.Text.Length == 0)
            {
                output = false;
            }

            return output;
        }



        private void fgColor_Click(object sender, EventArgs e)
        {
            ColorDialog cdlg = new ColorDialog();
            cdlg.ShowDialog();
            Color clr = cdlg.Color;

            String r = String.Empty;
            String g = String.Empty;
            String b = String.Empty;
            try
            {

                r = clr.R.ToString();
                g = clr.G.ToString();
                b = clr.B.ToString();

                // show the value in message box

                RGBforeground.Text = (r + ", " + g + ", " + b);

                //MessageBox.Show("Red :" + r + ", Green :" + g + ", Blue :" + b);

            }
            catch (Exception ex)
            {
                //doing nothing
            }
        }

        private void bgColor_Click(object sender, EventArgs e)
        {
            ColorDialog cdlg = new ColorDialog();
            cdlg.ShowDialog();
            Color clr = cdlg.Color;

            String r = String.Empty;
            String g = String.Empty;
            String b = String.Empty;
            try
            {

                r = clr.R.ToString();
                g = clr.G.ToString();
                b = clr.B.ToString();



                RGBbackground.Text = (r + ", " + g + ", " + b);

            }
            catch (Exception ex)
            {
                //doing nothing
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
