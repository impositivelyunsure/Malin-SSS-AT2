using AstroLibrary;
using System.Diagnostics;
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
        AstroFrontendProcessor frontProcessorObj = new AstroFrontendProcessor();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalcVelocity_Click(object sender, RoutedEventArgs e)
        {
            processorObj.AddVelocity(txtBoxObserved.Text, txtBoxRest.Text);
            frontProcessorObj.DisplayVelocity((MainWindow)MainWindow.GetWindow(this), processorObj);
            frontProcessorObj.ClearTextBoxes((MainWindow)MainWindow.GetWindow(this));
        }

        private void btnCalcDistance_Click(object sender, RoutedEventArgs e)
        {
            processorObj.AddDistance(txtBoxParallaxArcSec.Text);
            frontProcessorObj.DisplayDistance((MainWindow)MainWindow.GetWindow(this), processorObj);
            frontProcessorObj.ClearTextBoxes((MainWindow)MainWindow.GetWindow(this));
        }

        private void btnCalcTemp_Click(object sender, RoutedEventArgs e)
        {
            processorObj.AddTemperature(txtBoxCelsius.Text);
            frontProcessorObj.DisplayTemperature((MainWindow)MainWindow.GetWindow(this), processorObj);
            frontProcessorObj.ClearTextBoxes((MainWindow)MainWindow.GetWindow(this));
        }

        private void btnCalcEventHorizon_Click(object sender, RoutedEventArgs e)
        {
            processorObj.AddEventHorizon(txtBoxMass.Text);
            frontProcessorObj.DisplayEventHorizon((MainWindow)MainWindow.GetWindow(this), processorObj);
            frontProcessorObj.ClearTextBoxes((MainWindow)MainWindow.GetWindow(this));
        }

        private void CustTextBoxes_Click(object sender, RoutedEventArgs e)
        {
            frontProcessorObj.CustomiseTextBoxes();
        }

        private void CustButtons_Click(object sender, RoutedEventArgs e)
        {
            frontProcessorObj.CustomiseButtons();
        }

        private void CustBackground_Click(object sender, RoutedEventArgs e)
        {
            frontProcessorObj.CustomiseBackground((MainWindow)MainWindow.GetWindow(this));
        }

        private void CustLabels_Click(object sender, RoutedEventArgs e)
        {
            frontProcessorObj.CustomiseLabels();
        }
        private void CustLanguageEnglish_Click(object sender, RoutedEventArgs e)
        {
            frontProcessorObj.SetLanguage("Resources/Strings.en.xaml");
        }

        private void CustLanguageFrench_Click(object sender, RoutedEventArgs e)
        {
            frontProcessorObj.SetLanguage("Resources/Strings.fr.xaml");
        }

        private void CustLanguageGerman_Click(object sender, RoutedEventArgs e)
        {
            frontProcessorObj.SetLanguage("Resources/Strings.de.xaml");
        }
    }
}