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
    public partial class ModalResize : Form
    {
        private float _curResolution;
        private float _curWidth;
        private float _curHeight;
        private MemoryStream _msImg;
        private long _maxSize = 350000;

        public MemoryStream ImageStream { get => _msImg; set => _msImg = value; }

        public ModalResize()
        {
            InitializeComponent();
        }

        private void ModalResize_Load(object sender, EventArgs e)
        {
            Image image = Image.FromStream(_msImg);
            GraphicsUnit unit = GraphicsUnit.Point;
            RectangleF rect = image.GetBounds(ref unit);
            _curHeight = rect.Height;
            _curWidth = rect.Width;
            lblCurHeight.Text = _curHeight.ToString();
            lblCurWidth.Text = _curWidth.ToString();
            float hres = image.HorizontalResolution;
            _curResolution = hres;
            lblCurResolution.Text = _curResolution.ToString();
            float vres = image.VerticalResolution;
            lblCurSize.Text = _msImg.Length.ToString("N0");
            trkResolution.Maximum = Convert.ToInt32(hres) + 100;
            trkResolution.Value = Convert.ToInt32(hres);
            lblNewResolution.Text = trkResolution.Value.ToString();
        }

        private void trkResolution_Scroll(object sender, EventArgs e)
        {
            lblNewResolution.Text = trkResolution.Value.ToString();
        }
    }
}
