﻿using System;
using System.Windows.Forms;

namespace QPharma.GUI.Dialog
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}