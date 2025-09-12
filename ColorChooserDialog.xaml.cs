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
using System.Windows.Shapes;

namespace Malin_SSS_AT2
{
    public partial class ColorChooserDialog : Window
    {
        public Color SelectedColor { get; set; } = Colors.Aqua;

        public ColorChooserDialog()
        {
            InitializeComponent();
            Picker.SelectedColor = SelectedColor;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (Picker.SelectedColor.HasValue)
                SelectedColor = Picker.SelectedColor.Value;
            DialogResult = true;   // closes as OK
        }
    }
}
