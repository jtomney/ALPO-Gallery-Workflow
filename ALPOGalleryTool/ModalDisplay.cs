using System.Windows.Forms;

namespace ALPOGalleryTool
{
    public partial class ModalDisplay : Form
    {
        public ModalDisplay(string txtForDisplay)
        {
            InitializeComponent();
            txtDisplay.Text = txtForDisplay;
        }
    }
}
