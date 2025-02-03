using ALPOGalleryTool.Interfaces;
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
    public partial class FrmMenu : Form
    {
        private readonly IDataSrvc _dataSrvc;
        private readonly IEclipseDataSrvc _eclipseDataSrvc;
        private FrmActvRgnInsrt _frmActvRgnInsrt;
        private FrmEclipse _frmEclipse;
        private FrmMain _frmMain;
        private FrmSaturn _frmSaturn;
        private FrmSolar _frmSolar;
        private FrmVenus _frmVenus;
        private FrmUploadReport _frmUploadReport;

        public FrmMenu(IDataSrvc dataSrvc, IEclipseDataSrvc eclipseDataSrvc)
        {
            InitializeComponent();
            _dataSrvc = dataSrvc;
            _eclipseDataSrvc = eclipseDataSrvc;
        }

        private void solarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_frmSolar == null)
            {
                _frmSolar = new FrmSolar(_dataSrvc);
                _frmSolar.Disposed += delegate (object o, EventArgs arg)
                 {
                     _frmSolar = null;
                 };
                _frmSolar.MdiParent = this;
                _frmSolar.Show();
            }
        }

        private void anyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_frmMain == null)
            {
                _frmMain = new FrmMain(_dataSrvc);
                _frmMain.Disposed += delegate (object o, EventArgs arg)
                {
                    _frmMain = null;
                };
                _frmMain.MdiParent = this;
                _frmMain.Show();
            }
        }

        private void saturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_frmSaturn == null)
            {
                _frmSaturn = new FrmSaturn(_dataSrvc);
                _frmSaturn.Disposed += delegate (object o, EventArgs arg)
                {
                    _frmSaturn = null;
                };
                _frmSaturn.MdiParent = this;
                _frmSaturn.Show();
            }
        }

        private void eclipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_frmEclipse == null)
            {
                _frmEclipse = new FrmEclipse(_eclipseDataSrvc, _dataSrvc);
                _frmEclipse.Disposed += delegate (object o, EventArgs arg)
                {
                    _frmEclipse = null;
                };
                _frmEclipse.MdiParent = this;
                _frmEclipse.Show();
            }
        }

        private void aREntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_frmActvRgnInsrt == null)
            {
                _frmActvRgnInsrt = new FrmActvRgnInsrt();
                _frmActvRgnInsrt.Disposed += delegate (object o, EventArgs arg)
                {
                    _frmActvRgnInsrt = null;
                };
                _frmActvRgnInsrt.MdiParent = this;
                _frmActvRgnInsrt.Show();
            }
        }

        private void venusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_frmVenus == null)
            {
                _frmVenus = new FrmVenus(_dataSrvc);
                _frmVenus.Disposed += delegate (object o, EventArgs arg)
                {
                    _frmVenus = null;
                };
                _frmVenus.MdiParent = this;
                _frmVenus.Show();
            }
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_frmUploadReport == null)
            {
                _frmUploadReport = new FrmUploadReport();
                _frmUploadReport.Disposed += delegate (object o, EventArgs arg)
                {
                    _frmUploadReport = null;
                };
                _frmUploadReport.MdiParent = this;
                _frmUploadReport.Show();
            }
        }
    }
}
