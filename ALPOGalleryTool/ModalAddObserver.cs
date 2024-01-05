using System;
using System.Windows.Forms;

namespace ALPOGalleryTool
{
    public partial class ModalAddObserver : Form
    {
        public ModalAddObserver()
        {
            InitializeComponent();
        }

        public string City { get => txtCity.Text; }
        public string Country { get => txtCountry.Text; }
        public string Email { get => txtEmail.Text; }
        public string EmailName {get => txtEmailName.Text; }
        public string FirstName { get => txtFirstName.Text; }
        public string Initials { get => txtInitials.Text; }
        public string LastName { get => txtLastName.Text; }
        public string PrvncState { get => txtPrnvcState.Text; }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
