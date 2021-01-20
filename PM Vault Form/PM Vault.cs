using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM_Vault_Form
{
    public partial class PMVault : Form
    {
        public PMVault()
        {
            InitializeComponent();
        }

        //objects
        VaultHelper h = new VaultHelper();
        VaultManagement m = new VaultManagement();

        private void PMVault_Load(object sender, EventArgs e)
        {
            // buttons
            btn_vault.Visible = false;
            btn_generate.Visible = false;
            myVault1.Visible = false;
        }

        // import dll to move form without
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;

            h.LoadingInfo();

            bool UserPermission = false;

            if (!h.ConfigFileExists(h.localFileName))
                UserPermission = h.UserControl(username, password, true);
            else UserPermission = h.UserControl(username, password);

            if (!UserPermission)
            {
                lbl_message.Text = "User is not authenticated.";
            }
            else
            {
                btn_generate.Visible = true;
                btn_vault.Visible = true;
                panelLogin.Visible = false;
            }
        }

        private void btn_vault_Click(object sender, EventArgs e)
        {
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
        }
    }
}
