﻿using LedConfigurationLibrary;
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
    public partial class Settings2 : Form
    {
        public Settings2()
        {
            InitializeComponent();
            FontType.Items.Add("10X20.bdf");
            //foreach (FontFamily font in FontFamily.Families)
            //{
            //    FontType.Items.Add(font.Name.ToString());
            //}
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            List<string> pre_text = new List<string>();
            pre_text.Add("3_font");
            pre_text.Add("3_scroll");
            pre_text.Add("3_textcolor");
            pre_text.Add("3_backgroundcolor");
            pre_text.Add("3_W_H");
            //pre_text.Add("Special Information size");
            //pre_text.Add("Special Information font type");
            //pre_text.Add("Special Information font type swap");
            //pre_text.Add("Special Information swap font type");
            //pre_text.Add("Special Information font type swap after time");
            //pre_text.Add("Special Information color RGB foreground");
            //pre_text.Add("Special Information color RGB background");
            //pre_text.Add("Special Information Position");
            //pre_text.Add("Special Information static");
            //pre_text.Add("Special Information swap");
            //pre_text.Add("Special Information swap position");
            //pre_text.Add("Special Information swap position after time");
            //pre_text.Add("Special Information scroll frequency");

            if (ValidateForm())
            {
                SettingsModel model = new SettingsModel();

                model.Font = FontType.Text;
                model.FontTypeSwap = FontTypeSwap.Text;
                model.RGBforeground = RGBforeground.Text;
                model.RGBbackground = RGBbackground.Text;
                model.FieldSize = FieldSize.Text;

                //model.FieldSize = FieldSize.Text;
                //model.Font = FontType.Text;
                //model.FontTypeSwap = FontTypeSwap.Text;
                //model.RGBforeground = RGBforeground.Text;
                //model.RGBbackground = RGBbackground.Text;
                //model.TextPosition = TextPosition.Text;
                //model.SwapFontType = SwapFontType.Text;
                //model.SwapAfterTime = SwapAfterTime.Text;
                //model.Swap = Swap.Text;
                //model.Static = Static.Text;
                //model.SwapPositionAfter = SwapPositionAfter.Text;
                //model.SwapPosition = SwapPosition.Text;
                //model.ScrollFrequency = ScrollFrequency.Text;



                foreach (IDataConnection text in GlobalConfig.Connections)
                {
                    text.CreateSettings(model, pre_text);
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

                r = clr.R.ToString("X2");
                g = clr.G.ToString("X2");
                b = clr.B.ToString("X2");

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

                r = clr.R.ToString("X2");
                g = clr.G.ToString("X2");
                b = clr.B.ToString("X2");



                RGBbackground.Text = (r + "" + g + "" + b);

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

        private void Settings2_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
