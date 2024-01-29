using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.Presentation_Layer
{
    public partial class Confirmation : MaterialForm
    {
        readonly MaterialSkinManager materialSkinManager;
        public Confirmation()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Teal600, Primary.Teal600, Primary.Teal50, Accent.DeepPurple100, TextShade.BLACK);
        }
    }
}
