using CDTUserControl.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CDTUserControl.Usercontrols
{
    /// <summary>
    /// Interaction logic for TextBoxUserControl.xaml
    /// </summary>
    public partial class TextBoxUserControl : UserControl
    {
        TextBoxViewModel vm;

        public delegate void LockEventHandler(Boolean p_Value);
        public event LockEventHandler LockEvent;

        public static void EnsureApplicationResources()
        {
            if (Application.Current == null)
            {
                new App();
            }
        }

        public TextBoxUserControl()
        {
            EnsureApplicationResources();
            InitializeComponent();
            vm = new TextBoxViewModel();
            base.DataContext = vm;

            vm.LockEvent += Vm_LockEvent;
        }

        public TextBoxViewModel GetVM()
        {
            return vm;
        }

        public void SetText(string p_Value)
        {
            vm.SetText(p_Value);
        }

        public void SetFontSize(int p_Value)
        {
            vm.SetFontSize(p_Value);
        }

        public void Vm_LockEvent(Boolean p_Value)
        {
            LockEvent(p_Value);
        }

    }
}
