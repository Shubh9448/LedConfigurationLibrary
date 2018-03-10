using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LedConfigurationLibrary;
using customLed;
using System.IO;
using System.Configuration;
using LedConfigurationLibrary.TextHelpers;
using System.Runtime.InteropServices;

namespace LedConfigurationUI
{
    public partial class MainForm : Form
    {

        private const string filename = "config.txt";
        public int type;
        bool m_bIsOn;
        private string displayType;


        const int WM_DEVICECHANGE = 0x0219; //see msdn site
        const int DBT_DEVICEARRIVAL = 0x8000;
        const int DBT_DEVICEREMOVALCOMPLETE = 0x8004;
        const int DBT_DEVTYPVOLUME = 0x00000002;


        public MainForm()
        {
            InitializeComponent();


            Field_1.Enabled = false;
            SourcePlace.Enabled = false;
            DestinationPlace.Enabled = false;
            RtoNumber.Enabled = false;
            TripCode.Enabled = false;
            Filed_3.Enabled = false;
            BusTime.Enabled = false;
            Field_2.Enabled = false;
            linkLabel1.Enabled = false;
            linkLabel2.Enabled = false;
            linkLabel3.Enabled = false;
            linkLabel4.Enabled = false;
            linkLabel5.Enabled = false;
            linkLabel6.Enabled = false;
            linkLabel7.Enabled = false;
            linkLabel8.Enabled = false;

        }
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Settings0 f = new Settings0())
            {
                
                if (!CheckForm(f))
                {
                    f.MdiParent = this.MdiParent;
                    f.ShowDialog();
                }
                else
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.Activate();
                }
            }

           



        }

        public bool CheckForm(Form form)
        {
            form = Application.OpenForms[form.Text];
            if (form != null)
                return true;
            else
                return false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Settings2 f = new Settings2())
            {

                if (!CheckForm(f))
                {
                    f.MdiParent = this.MdiParent;
                    f.ShowDialog();
                }
                else
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.Activate();
                }
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Settings3 f = new Settings3())
            {

                if (!CheckForm(f))
                {
                    f.MdiParent = this.MdiParent;
                    f.ShowDialog();
                }
                else
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.Activate();
                }
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Settings5 f = new Settings5())
            {

                if (!CheckForm(f))
                {
                    f.MdiParent = this.MdiParent;
                    f.ShowDialog();
                }
                else
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.Activate();
                }
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Settings1 f = new Settings1())
            {

                if (!CheckForm(f))
                {
                    f.MdiParent = this.MdiParent;
                    f.ShowDialog();
                }
                else
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.Activate();
                }
            }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Settings6 f = new Settings6())
            {

                if (!CheckForm(f))
                {
                    f.MdiParent = this.MdiParent;
                    f.ShowDialog();
                }
                else
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.Activate();
                }
            }
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Settings7 f = new Settings7())
            {

                if (!CheckForm(f))
                {
                    f.MdiParent = this.MdiParent;
                    f.ShowDialog();
                }
                else
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.Activate();
                }
            }
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Settings4 f = new Settings4())
            {

                if (!CheckForm(f))
                {
                    f.MdiParent = this.MdiParent;
                    f.ShowDialog();
                }
                else
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.Activate();
                }
            }
        }

        private void FieldsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FieldsComboBox.SelectedItem.ToString().Length > 0)
            {
                type = int.Parse(DisplayType.SelectedItem.ToString());
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            using (DisplayForm f = new DisplayForm())
            {

                if (!CheckForm(f))
                {
                    f.MdiParent = this.MdiParent;
                    f.ShowDialog();
                }
                else
                {
                    f.WindowState = FormWindowState.Normal;
                    f.BringToFront();
                    f.Activate();
                }
            }
        }

        

        private void CL_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DisplayType.Text))
            {
                ShowMessage1();
                CL.Checked = false;
            }

            else if (numberofcheckedboxes() <= type )
            {
                if (CL.Checked)
                {
                    Field_1.Enabled = true;
                    linkLabel7.Enabled = true;
                }

                else
                {
                    Field_1.Enabled = false;
                    linkLabel7.Enabled = false;
                }
            }

            else
            {
                ShowMessage2();
                CL.Checked = false;
            }
        }

        private void AN_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DisplayType.Text))
            {
                ShowMessage1();
                AN.Checked = false;
            }

            else if (numberofcheckedboxes() <= type)
            {
                if (AN.Checked)
                {
                    Field_2.Enabled = true;
                    linkLabel1.Enabled = true;
                }

                else
                {
                    Field_2.Enabled = false;
                    linkLabel1.Enabled = false;
                }
            }

            else
            {
                ShowMessage2();
                AN.Checked = false;
            }
        }

        private void EI_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DisplayType.Text))
            {
                ShowMessage1();
                EI.Checked = false;
            }


            else if (numberofcheckedboxes() <= type)
            {
                if (EI.Checked)
                {
                    Filed_3.Enabled = true;
                    linkLabel2.Enabled = true;
                }

                else
                {
                    Filed_3.Enabled = false;
                    linkLabel2.Enabled = false;
                }
            }

            else
            {
                ShowMessage2();
                EI.Checked = false;
            }
        }

        private void BT_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DisplayType.Text))
            {
                ShowMessage1();
                BT.Checked = false;
            }

            else if (numberofcheckedboxes() <= type)
            {
                if (BT.Checked)
                {
                    BusTime.Enabled = true;
                    linkLabel3.Enabled = true;
                }

                else
                {
                    BusTime.Enabled = false;
                    linkLabel3.Enabled = false;
                }
            }

            else
            {
                ShowMessage2();
                BT.Checked = false;
            }
        }

        private void TC_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DisplayType.Text))
            {
                ShowMessage1();
                TC.Checked = false;
            }

            else if (numberofcheckedboxes() <= type)
            {
                if (TC.Checked)
                {
                    TripCode.Enabled = true;
                    linkLabel8.Enabled = true;
                }

                else
                {
                    TripCode.Enabled = false;
                    linkLabel8.Enabled = false;
                }
            }

            else
            {
                ShowMessage2();
                TC.Checked = false;
            }
        }

        private void SP_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DisplayType.Text))
            {
                ShowMessage1();
                SP.Checked = false;
            }

            else if (numberofcheckedboxes() <= type)
            {
                if (SP.Checked)
                {
                    SourcePlace.Enabled = true;
                    linkLabel4.Enabled = true;
                }

                else
                {
                    SourcePlace.Enabled = false;
                    linkLabel4.Enabled = false;
                }
            }

            else
            {
                ShowMessage2();
                SP.Checked = false;
            }
        }

        private void DP_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DisplayType.Text))
            {
                ShowMessage1();
                DP.Checked = false;
            }

            else if (numberofcheckedboxes() <= type)
            {
                if (DP.Checked)
                {
                    DestinationPlace.Enabled = true;
                    linkLabel5.Enabled = true;
                }

                else
                {
                    DestinationPlace.Enabled = false;
                    linkLabel5.Enabled = false;
                }
            }

            else
            {
                ShowMessage2();
                DP.Checked = false;
            }
        }

        private void RN_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DisplayType.Text))
            {
                ShowMessage1();
                RN.Checked = false;
            }

            else if (numberofcheckedboxes() <= type)
            {
                if (RN.Checked)
                {
                    RtoNumber.Enabled = true;
                    linkLabel6.Enabled = true;
                }

                else
                {
                    RtoNumber.Enabled = false;
                    linkLabel6.Enabled = false;
                }
            }

            else
            {
                ShowMessage2();
                RN.Checked = false;
            }
        }

        private void DisplayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FieldsComboBox.Items.Clear();
            if (DisplayType.SelectedItem.ToString().Length > 0)
            {
                displayType = DisplayType.SelectedItem.ToString();
                int a = int.Parse(DisplayType.SelectedItem.ToString());
                for(int i = 1; i <= a; i++)
                {
                    FieldsComboBox.Items.Add(i);
                }
            }
        }

        private int numberofcheckedboxes()
        {
            var checkedBoxes = groupBox2.Controls.OfType<CheckBox>().Count(c => c.Checked);

            return checkedBoxes;
        }

        public void ShowMessage1()
        {
            MessageBox.Show("Please select number of fields", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowMessage2()
        {
            MessageBox.Show("Your number of fields are increasing ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            if ( m_bIsOn == true)
            {
                // Stop
                
                Apply.Text = "Apply";
                DisplayType.Enabled = true;
                FieldsComboBox.Enabled = true;
                m_bIsOn = false;
            }
            else
            {
                // Start
                Apply.Text = "ReAssign";
                DisplayType.Enabled = false;
                FieldsComboBox.Enabled = false;
                m_bIsOn = true;
            }

             if (  FieldsComboBox.SelectedIndex >= 0 && DisplayType.SelectedIndex >= 0)
             {
                    string[] a = new string[3];

                    a[0] = DisplayType.SelectedItem.ToString();
                    a[1] = " ";
                    a[2] = FieldsComboBox.SelectedItem.ToString();

                    if (!File.Exists(filename.FilePath()))
                    {
                        for(int i = 0; i < a.Length; i++)
                        {
                        File.AppendAllText(filename.FilePath(), a[i]);
                        }
                    }

                    else
                    {
                        for (int i = 0; i < a.Length; i++)
                        {
                            File.AppendAllText(filename.FilePath(), a[i]);
                        }
                    }

                //List<string> lines = new List<string>();
                //List<string> spacing = new List<string>();

                //spacing.Add("\n");

                //List<string> pre = new List<string>();
                //List<string> post = new List<string>();
                //List<PrePostText> t = new List<PrePostText>();
                //pre.Add("Display Area size");
                //pre.Add("Number of Fields");


                //post.Add(DisplayType.SelectedItem.ToString());
                //post.Add(FieldsComboBox.SelectedItem.ToString());

                //int counter = 0;
                //foreach (var p in pre)
                //{



                //    PrePostText newText = new PrePostText();
                //    newText.PreText = pre[counter];
                //    newText.PostText = post[counter];
                //    counter++;
                //    t.Add(newText);



                //}

                //foreach (var line in t)
                //{
                //    lines.Add($"{line.PostText}");
                //}


                //if (!File.Exists(filename.FilePath()))
                //{
                //    File.WriteAllLines(filename.FilePath(), lines);
                //}

                //else
                //{
                //  //  File.AppendAllLines(filename.FilePath(), spacing);
                //    File.AppendAllLines(filename.FilePath(), lines);
                //}

            }
        }

        private void generate_file_Click(object sender, EventArgs e)
        {

        }

        protected override void WndProc(ref Message m)
        {

            if (m.Msg == WM_DEVICECHANGE)
            {
                DEV_BROADCAST_VOLUME vol = (DEV_BROADCAST_VOLUME)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_VOLUME));
                if ((m.WParam.ToInt32() == DBT_DEVICEARRIVAL) && (vol.dbcv_devicetype == DBT_DEVTYPVOLUME))
                {
                    usb_list.Items.Add(DriveMaskToLetter(vol.dbcv_unitmask).ToString());
                }
                if ((m.WParam.ToInt32() == DBT_DEVICEREMOVALCOMPLETE) && (vol.dbcv_devicetype == DBT_DEVTYPVOLUME))
                {
                    usb_list.Items.Clear();
                }
            }
            base.WndProc(ref m);
        }

        [StructLayout(LayoutKind.Sequential)] //Same layout in mem
        public struct DEV_BROADCAST_VOLUME
        {
            public int dbcv_size;
            public int dbcv_devicetype;
            public int dbcv_reserved;
            public int dbcv_unitmask;
        }

        private static char DriveMaskToLetter(int mask)
        {
            char letter;
            string drives = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //1 = A, 2 = B, 3 = C
            int cnt = 0;
            int pom = mask / 2;
            while (pom != 0)    // while there is any bit set in the mask shift it right        
            {
                pom = pom / 2;
                cnt++;
            }
            if (cnt < drives.Length)
                letter = drives[cnt];
            else
                letter = '?';
            return letter;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<string> list_usb = DriveInfo.GetDrives().Where(d => d.DriveType.ToString() == "Removable").Select(d => d.Name).ToList();

            foreach (var i in list_usb)
            {
                usb_list.Items.Add(i);
            }
        }
    }

}
