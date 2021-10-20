using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientREST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        #region UI Event Handlers
        private void Go_Click(object sender, EventArgs e)
        {
            RestClient client = new RestClient();
            client.endPoint = textBox2.Text;
            debugOutput("REST client created");
            string response = string.Empty;
            response = client.makeRequest();
            debugOutput(response);

        }
        #endregion

        private void debugOutput(string strDebugOutput)
        {
            try
            {
                Debug.Write(strDebugOutput + Environment.NewLine);
                txtResponse.Text = txtResponse.Text + strDebugOutput + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.TextLength;
                txtResponse.ScrollToCaret();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }
    }
}
