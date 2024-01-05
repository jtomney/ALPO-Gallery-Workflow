using ALPOGalleryTool.DataAccess;
using ALPOGalleryTool.DataAccess.SqlSrvDto;
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
    public partial class FrmActvRgnInsrt : Form
    {
        public FrmActvRgnInsrt()
        {
            InitializeComponent();
        }

        private void LoadAR()
        {
            DateTime priorDay = dtActvRgn.Value.AddDays(-1);
            string cnnStr = Properties.Settings.Default.SqlSrvCnnStr;
            SqlSrvDataSrv sqlSrv = new SqlSrvDataSrv(cnnStr);
            var l = sqlSrv.GetActvRgnByDate(priorDay.Date);

            List<string> lst = l.Select(x => x.ActvRgn).ToList();
            lst.Sort();
            lstCurAR.Items.Clear();
            lstCurAR.Items.AddRange(lst.ToArray());

        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            DateTime dt = dtActvRgn.Value.Date;
            if (lstCurAR.SelectedItems.Count > 0)
            {
                foreach (var item in lstCurAR.SelectedItems)
                {
                    list.Add((string)item);
                }
            }
            if (txtNewAR.Text.Length > 0)
            {
                string[] ars = txtNewAR.Text.Split(',');
                foreach (string ar in ars)
                {
                    list.Add(ar);
                }
            }
            string cnnStr = Properties.Settings.Default.SqlSrvCnnStr;
            SqlSrvDataSrv sqlSrv = new SqlSrvDataSrv(cnnStr);
            foreach (string ar in list)
            {
                ActvRgnDateDto tmp = new ActvRgnDateDto()
                {
                    ActvRgn = ar,
                    ArDt = dt
                };
                if (sqlSrv.InsertActvRgn(tmp) != 1)
                {
                    MessageBox.Show($"Failed adding {ar} to database");
                }
            }
            MessageBox.Show("Posted!");
            lstCurAR.Items.Clear();
            txtNewAR.Text = string.Empty;
        }

        private void lstCurAR_DoubleClick(object sender, EventArgs e)
        {
            lstCurAR.Items.Clear();
            LoadAR();
        }
    }
}
