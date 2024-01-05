using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ALPOGalleryTool.DataAccess.MongoDto;
using ALPOGalleryTool.Interfaces;

namespace ALPOGalleryTool
{
    public partial class ModalAddTelescope : Form
    {
        private IDataSrvc _dataSrvc;

        public ModalAddTelescope(IDataSrvc dataSrvc, string obsrvInit)
        {
            InitializeComponent();
            _dataSrvc = dataSrvc;
            txtInitials.Text = obsrvInit;
            LoadScopeTypes();
        }

        private void LoadScopeTypes()
        {
            List<string> scopeTypes = new List<string>()
            {
                "DKT",
                "MCT",
                "RFL",
                "RFR",
                "SCP",
                "SCT"
            };
            cmbScopeType.DataSource = scopeTypes;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MongoTelescope scope = new MongoTelescope()
            {
                Aperture = int.Parse(txtAperture.Text),
                FocalLength = Double.Parse(txtFocalLen.Text),
                FocalRatio = Double.Parse(txtFocalRatio.Text),
                Initials = txtInitials.Text,
                Notes = txtNotes.Text,
                ScopeType = cmbScopeType.Text
            };
            if (_dataSrvc.AddTelescope(scope) == 1)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show(@"DataService indicates no record was added."
                    , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
