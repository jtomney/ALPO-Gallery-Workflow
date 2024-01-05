using ALPOGalleryTool.DataAccess;
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
    public partial class ModalSelectProfile : Form
    {
        private MongoObsrvProfile _profile = new MongoObsrvProfile();
        private Dictionary<string, MongoObsrvProfile> _profiles = new Dictionary<string, MongoObsrvProfile>();  

        public MongoObsrvProfile Profile { get { return _profile; } }

        public ModalSelectProfile(List<MongoObsrvProfile> profiles)
        {
            InitializeComponent();
            lstAvailProfiles.Items.Clear();
            foreach (MongoObsrvProfile item in profiles)
            {
                lstAvailProfiles.Items.Add(item.ProfileName);
                _profiles.Add(item.ProfileName, item);
            }
        }

        private void btnProfileOk_Click(object sender, EventArgs e)
        {
            _profile = _profiles[lstAvailProfiles.Text];
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnProfileCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lstAvailProfiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _profile = _profiles[lstAvailProfiles.Text];
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
