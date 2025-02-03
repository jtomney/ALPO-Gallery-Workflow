using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALPOGalleryTool
{
    public partial class FrmUploadReport : Form
    {
        private const string urlRoot= @"https://alpo-astronomy.org/Gallery/Home/Detail/";
        private List<RptRecord> _rptRecords = new List<RptRecord>();

        private class RptRecord
        {
            public string AlbumName { get; set; }
            public string ImageFileName { get; set; }
            public string Observer { get; set; }
            public string Url { get; set; }

            public override string ToString()
            {
                return AlbumName + "," + Observer + "," + ImageFileName + "," + Url;
            }
        }

        public FrmUploadReport()
        {
            InitializeComponent();
        }

        private void btnGenerateRpt_Click(object sender, EventArgs e)
        {
            _rptRecords.Clear();
            string[] lines = System.IO.File.ReadAllLines(txtDataExtract.Text);
            int cnt = 0;
            foreach (string line in lines)
            {
                cnt++;
                if (cnt == 1) continue;
                string[] fields = line.Split(',');
                RptRecord rptRecord = new RptRecord()
                {
                    AlbumName = fields[0],
                    ImageFileName = fields[2]
                };
                rptRecord.Observer = ParseObserverName(rptRecord.ImageFileName);
                rptRecord.Url = urlRoot + fields[1] + "?file=" + rptRecord.ImageFileName;
                _rptRecords.Add(rptRecord);
            }
            CreateReport();
            MessageBox.Show("Report created");
        }

        private void CreateReport()
        {
            string outputFileName = Path.Combine(Path.GetDirectoryName(txtDataExtract.Text),DateTime.Today.ToString("yyyyMMdd") + "_UploadReport.csv");
            using (StreamWriter sw = new StreamWriter(outputFileName))
            {
                sw.WriteLine("Album Name,Observer,Image,Url");
                foreach (RptRecord rptRecord in _rptRecords)
                {
                    sw.WriteLine(rptRecord.ToString());
                }
            }
        }

        private string ParseObserverName(string imageFileName)
        {
            string[] parts = imageFileName.Split('-');
            return parts[4];
        }
    }
}
