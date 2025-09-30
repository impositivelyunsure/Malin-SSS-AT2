using AstroLibrary;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Malin_SSS_AT2
{
    public partial class MainWindow : Window
    {
        AstroProcessor processorObj = new AstroProcessor();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalcVelocity_Click(object sender, RoutedEventArgs e)
        {
            if (Double.TryParse(txtBoxObserved.Text, out double resultObs))
            {
                if (Double.TryParse(txtBoxRest.Text, out double resultRest))
                {
                    processorObj.AddVelocity(resultObs, resultRest);
                    DisplayVelocity();
                    ClearTextBoxes();
                }
                else
                {
                    MessageBox.Show("Input Error", "Rest wave length input is not a valid number", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Input Error", "Observed wave length input is not a valid number", MessageBoxButton.OK);
            }
        }

        private void btnCalcDistance_Click(object sender, RoutedEventArgs e)
        {
            if (Double.TryParse(txtBoxParallaxArcSec.Text, out double resultArcSec))
            {
                processorObj.AddDistance(resultArcSec);
                DisplayDistance();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Input Error", "Parallax Arc Seconds input is not a valid number", MessageBoxButton.OK);
            }
        }

        private void btnCalcTemp_Click(object sender, RoutedEventArgs e)
        {
            if (Double.TryParse(txtBoxCelsius.Text, out double resultTemp))
            {
                processorObj.AddTemp(resultTemp);
                DisplayTemperature();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Input Error", "Celsius input is not a valid number", MessageBoxButton.OK);
            }
        }

        private void btnCalcEventHorizon_Click(object sender, RoutedEventArgs e)
        {
            if (Double.TryParse(txtBoxMass.Text, out double resultHor))
            {
                processorObj.AddEventHorizon(resultHor);
                DisplayEventHorizon();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Input Error", "Mass input is not a valid number", MessageBoxButton.OK);
            }
        }

        private void CustTextBoxes_Click(object sender, RoutedEventArgs e)
        {
            var txtBoxesDialog = new CustTextBoxesDialog();
            if (txtBoxesDialog.ShowDialog() == true)
            {
                Application.Current.Resources["TextBoxBackgroundBrush"] = new SolidColorBrush(txtBoxesDialog.SelectedColor);
            }
        }

        private void CustButtons_Click(object sender, RoutedEventArgs e)
        {
            var buttonsDialog = new CustButtonsDialog();
            if (buttonsDialog.ShowDialog() == true)
            {
                Application.Current.Resources["ButtonBackgroundBrush"] = new SolidColorBrush(buttonsDialog.SelectedColor);
            }
        }

        private void CustBackground_Click(object sender, RoutedEventArgs e)
        {
            var colorDialog = new CustBackgroundDialog();
            if (colorDialog.ShowDialog() == true)
            {
                Background = new SolidColorBrush(colorDialog.SelectedColor);
            }
        }

        private void CustLabels_Click(object sender, RoutedEventArgs e)
        {
            var labelsDialog = new CustLabelsDialog();
            if (labelsDialog.ShowDialog() == true)
            {
                Application.Current.Resources["LabelBackgroundBrush"] = new SolidColorBrush(labelsDialog.SelectedColor);
                Application.Current.Resources["GlobalFamilyFont"] = labelsDialog.SelectedFont;
                Application.Current.Resources["GlobalFamilySize"] = labelsDialog.SelectedSize;
            }
        }

        public void DisplayVelocity()
        {
            if (lstBoxVelocity.Items.Count > 0)
            {
                lstBoxVelocity.Items.Clear();
            }

            foreach (var value in processorObj.velocityList)
            {
                lstBoxVelocity.Items.Add(value);
            }
        }
        public void DisplayDistance()
        {
            if (lstBoxDistance.Items.Count > 0)
            {
                lstBoxDistance.Items.Clear();
            }

            foreach (var value in processorObj.distanceList)
            {
                lstBoxDistance.Items.Add(value);
            }
        }
        public void DisplayTemperature()
        {
            if (lstBoxTemperature.Items.Count > 0)
            {
                lstBoxTemperature.Items.Clear();
            }


            foreach (var value in processorObj.temperatureList)
            {
                lstBoxTemperature.Items.Add(value);
            }
        }
        public void DisplayEventHorizon()
        {
            if (lstBoxHorizon.Items.Count > 0)
            {
                lstBoxHorizon.Items.Clear();
            }


            foreach (var value in processorObj.eventHorList)
            {
                lstBoxHorizon.Items.Add(value);
            }
        }

        public void ClearTextBoxes()
        {
            txtBoxObserved.Text = "";
            txtBoxRest.Text = "";
            txtBoxParallaxArcSec.Text = "";
            txtBoxCelsius.Text = "";
            txtBoxMass.Text = "";
        }
    }
}