using System.Windows.Forms;
using QPharma.Properties;

namespace QPharma.GUI
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            //InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            UpdateStyles();
            Icon = Resources.appicon;
        }
    }
}