using DnsClient.Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALPOGalleryTool
{
    public partial class ModalInput : Form
    {
        private string _answer;

        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }

        public ModalInput(string title)
        {
            InitializeComponent();
            this.Text = title;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            _answer = txtInput.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _answer = "";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
