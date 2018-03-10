namespace LedConfigurationUI
{
    partial class LedPanel
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
            this.TripCode = new System.Windows.Forms.Label();
            this.SourcePlace = new System.Windows.Forms.Label();
            this.DestinationPlace = new System.Windows.Forms.Label();
            this.BusTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TripCode
            // 
            this.TripCode.AutoSize = true;
            this.TripCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TripCode.Location = new System.Drawing.Point(0, 0);
            this.TripCode.Name = "TripCode";
            this.TripCode.Size = new System.Drawing.Size(171, 91);
            this.TripCode.TabIndex = 0;
            this.TripCode.Text = "100";
            // 
            // SourcePlace
            // 
            this.SourcePlace.AutoSize = true;
            this.SourcePlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SourcePlace.Location = new System.Drawing.Point(293, 5);
            this.SourcePlace.Name = "SourcePlace";
            this.SourcePlace.Size = new System.Drawing.Size(80, 25);
            this.SourcePlace.TabIndex = 1;
            this.SourcePlace.Text = "Source";
            // 
            // DestinationPlace
            // 
            this.DestinationPlace.AutoSize = true;
            this.DestinationPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DestinationPlace.Location = new System.Drawing.Point(293, 49);
            this.DestinationPlace.Name = "DestinationPlace";
            this.DestinationPlace.Size = new System.Drawing.Size(120, 25);
            this.DestinationPlace.TabIndex = 2;
            this.DestinationPlace.Text = "Destination";
            // 
            // BusTime
            // 
            this.BusTime.AutoSize = true;
            this.BusTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusTime.Location = new System.Drawing.Point(1, 100);
            this.BusTime.Name = "BusTime";
            this.BusTime.Size = new System.Drawing.Size(89, 25);
            this.BusTime.TabIndex = 3;
            this.BusTime.Text = "2:03 pm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(178, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "FROM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(178, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "TO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(528, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // LedPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(668, 128);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BusTime);
            this.Controls.Add(this.DestinationPlace);
            this.Controls.Add(this.SourcePlace);
            this.Controls.Add(this.TripCode);
            this.ForeColor = System.Drawing.Color.DarkOrange;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LedPanel";
            this.Text = "LedPanel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TripCode;
        private System.Windows.Forms.Label SourcePlace;
        private System.Windows.Forms.Label DestinationPlace;
        private System.Windows.Forms.Label BusTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}