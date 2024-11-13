using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ALPOGalleryTool.DataAccess;
using ALPOGalleryTool.Interfaces;
using MongoDB.Driver;

namespace ALPOGalleryTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IDataSrvc dataSrvc = new MongoDataSrvc(ALPOGalleryTool.Properties.Settings.Default.MongoCnnStr);
            IEclipseDataSrvc eclipseDataSrvc = new MongoEclipseDataSrvc(ALPOGalleryTool.Properties.Settings.Default.MongoCnnStr);
            //Application.Run(new FrmMain(dataSrvc));
            //Application.Run(new FrmSolar(dataSrvc));
            //Application.Run(new FrmSaturn(dataSrvc));
            //Application.Run(new FrmChkUrl(eclipseDataSrvc));
            Application.Run(new FrmMenu(dataSrvc, eclipseDataSrvc));
        }
    }
}
