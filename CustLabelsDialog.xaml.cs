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
    /// <summary>
    /// Interaction logic for CustLabelsDialog.xaml
    /// </summary>
    public partial class CustLabelsDialog : Window
    {
        public System.Windows.Media.Color SelectedColor { get; set; }
        public FontFamily SelectedFont { get; set; } 
        public double SelectedSize { get; private set; }
        public CustLabelsDialog()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (Picker.SelectedColor.HasValue)
            {
                SelectedColor = Picker.SelectedColor.Value;
            }
            // if the input can be parsed as a double, is greater than 0 or is left empty, set the size
            if (double.TryParse(txtFontSize.Text, out double size) && size > 0 || txtFontSize.Text == "")
            {
                SelectedSize = size;
                SelectedFont = (FontFamily)cbFonts.SelectedItem;
            }
            else
            {
                MessageBox.Show("Enter a valid font size.", "Invalid Size Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            DialogResult = true;
        }
    }
}
