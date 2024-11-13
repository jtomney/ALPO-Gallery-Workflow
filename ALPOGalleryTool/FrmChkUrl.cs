using ALPOGalleryTool.DataAccess.MongoDto;
using ALPOGalleryTool.Interfaces;
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
    public partial class FrmChkUrl : Form
    {
        private readonly IEclipseDataSrvc _dataSrvc;

        public FrmChkUrl(IEclipseDataSrvc eclipseDataSrvc)
        {
            _dataSrvc = eclipseDataSrvc;
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            List<MongoEclipseDto> recs = _dataSrvc.GetAllEclipseObservations().ToList();
            List<MongoEclipseDto> recsToProcess = recs.Where(r => r.Url.EndsWith(txtBadUrlTerminator.Text)).ToList();
            foreach (MongoEclipseDto rec in recsToProcess)
            {
                string url = rec.Url + "/" + rec.FileName;
                rec.Url = url;
                int recsUpdated = _dataSrvc.UpdateEclipseRecord(rec);
                if(recsUpdated != 1)
                {
                    MessageBox.Show("Error updating record: " + rec.FileName);
                }
            }
        }
    }
}
