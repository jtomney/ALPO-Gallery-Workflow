using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace ALPOGalleryTool
{
    public partial class FrmResize : Form
    {
        private string _revisedFile = string.Empty;

        public string RevisedFile { get => _revisedFile; set => _revisedFile = value; }

        public FrmResize(byte[] ms)
        {
            InitializeComponent();
            LoadImage(ms);
        }

        private void LoadImage(byte[] ms)
        {
            string fileName = Path.GetFileName(_revisedFile);
            string tmp = Path.Combine(Path.GetTempPath(), fileName);
            File.WriteAllBytes(tmp, ms);
            Bitmap originalBitmap = new Bitmap(tmp);
            using (Graphics gr = Graphics.FromImage(originalBitmap))
            {
                txtDpi.Text = gr.DpiX.ToString(CultureInfo.InvariantCulture);
            }

            txtWidth.Text = originalBitmap.Width.ToString();
            txtHeight.Text = originalBitmap.Height.ToString();

            //using (Bitmap bm = new Bitmap(newWidth, newHeight))
            //{
            //    Point[] points =
            //    {
            //        new Point(0, 0),
            //        new Point(newWidth, 0),
            //        new Point(0, newHeight),
            //    };
            //    using (Graphics gr = Graphics.FromImage(bm))
            //    {
            //        gr.DrawImage(originalBitmap, points);
            //    }

            //    float dpix = dpi;
            //    float dpiy = dpi;
            //    bm.SetResolution(dpix, dpiy);
            //    SaveImage(bm, tmpFileName);
            //}
        }

        protected void btnAdjustSize_Click(object sender, EventArgs e)
        {

        }
    }
}
