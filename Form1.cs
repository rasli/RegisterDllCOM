using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterCOM
{
    public partial class RegisterUI :MaterialForm
    {
        MaterialSkinManager skinManager;
        public RegisterUI()
        {
            InitializeComponent();

            skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue400, Accent.Blue400, TextShade.WHITE);

        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                if (sFileName != "")
                {
                    pathField.Text = sFileName;
                }
            }
            
        }
        


        [STAThread]
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            //args = (
            //    from x in args
            //    select x.ToLower()).ToArray<string>();
            string dllsToRegister = pathField.Text;
           
                Assembly assembly = Assembly.LoadFrom(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), dllsToRegister));
                RegistrationServices registrationService = new RegistrationServices();
               
                registrationService.RegisterAssembly(assembly, AssemblyRegistrationFlags.SetCodeBase);
                
                
            
        }
    }
}
