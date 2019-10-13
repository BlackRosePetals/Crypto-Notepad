using System;
using System.Windows.Forms;

namespace Crypto_Notepad
{
    public partial class EnterKeyForm : Form
    {
        public EnterKeyForm()
        {
            PublicVar.okPressed = false;
            InitializeComponent();
        }

        /*Form Events*/
        private void EnterKeyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm main = Owner as MainForm;
            if (main.Visible == false)
            {
                main.trayIcon.Visible = false;
                Environment.Exit(0);
            }
            keyTextBox.Focus();
        }

        private void EnterKeyForm_Load(object sender, EventArgs e)
        {
            fileNameLabel.Text = PublicVar.openFileName;
            Properties.Settings settings = Properties.Settings.Default;
            TopMost = settings.alwaysOnTop;
        }

        private void EnterKeyForm_Shown(object sender, EventArgs e)
        {
            fileNameLabel.Text = PublicVar.openFileName;
        }
        /*Form Events*/


        /*Enter key area*/
        private void KeyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (txtKey.Text.Length > 0)
                btnOk.Enabled = true;
            else
                btnOk.Enabled = false;
        }

        private void KeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && okButton.Enabled)
            {
                OkButton_Click(sender, e);
            }
        }

        private void ShowKeyPictureBox_Click(object sender, EventArgs e)
        {
            if (keyTextBox.UseSystemPasswordChar)
            {
                keyTextBox.UseSystemPasswordChar = false;
                showKeyPictureBox.Image = Properties.Resources.eye;
            }
            else
            {
                keyTextBox.UseSystemPasswordChar = true;
                showKeyPictureBox.Image = Properties.Resources.eye_half;
            }
        }
        /*Enter key area*/


        /*Buttons*/
        private void OkButton_Click(object sender, EventArgs e)
        {
            TypedPassword.Value = keyTextBox.Text;
            keyTextBox.Focus();
            PublicVar.okPressed = true;
            Hide();
            
        }
        /*Buttons*/


    }
}
