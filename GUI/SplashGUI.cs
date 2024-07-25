﻿using System;
using System.Windows.Forms;
using QPharma.BUS;
using QPharma.DTO;
using QPharma.Properties;
using QPharma.Util;

namespace QPharma.GUI
{
    public partial class SplashGUI : Form
    {
        private readonly LoginBUS loginBUS = new LoginBUS();
        private readonly LoginGUI loginGUI = new LoginGUI();
        private readonly double opacityIncrement = 0.05;
        private readonly StaffBUS staffBUS = new StaffBUS();
        private readonly UserBUS userBUS = new UserBUS();
        private MainGUI mainGUI;


        public SplashGUI()
        {
            InitializeComponent();
            Icon = Resources.appicon;
        }


        private void StartMainGUI(UserDTO user)
        {
            var staff = staffBUS.GetByUsername(user.username);
            if (staff is null)
            {
                loginGUI.Show();
                return;
            }

            if (mainGUI == null || mainGUI.IsDisposed) mainGUI = new MainGUI(user, null, staff);
            mainGUI.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity < 1)
            {
                Opacity += opacityIncrement;
                return;
            }

            timer1.Stop();
            Hide();
            try
            {
                var log = loginBUS.CheckLoggedIn();
                if (log is null)
                {
                    loginGUI.Show();
                    return;
                }

                var user = userBUS.getUser(log.username);
                user.guid = log.id;
                StartMainGUI(user);
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowError(Resources.Database_connection_error);
                Application.Exit();
            }
        }

        private void SplashGUI_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}