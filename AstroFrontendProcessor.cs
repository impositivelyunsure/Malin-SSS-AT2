using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Malin_SSS_AT2
{
    public class AstroFrontendProcessor
    {
        public void CustomiseTextBoxes()
        {
            var txtBoxesDialog = new CustTextBoxesDialog();
            if (txtBoxesDialog.ShowDialog() == true)
            {
                Application.Current.Resources["TextBoxBackgroundBrush"] = new SolidColorBrush(txtBoxesDialog.SelectedColor);
            }
        }

        public void CustomiseButtons()
        {
            var buttonsDialog = new CustButtonsDialog();
            if (buttonsDialog.ShowDialog() == true)
            {
                Application.Current.Resources["ButtonBackgroundBrush"] = new SolidColorBrush(buttonsDialog.SelectedColor);
                Application.Current.Resources["GlobalFamilyFont"] = buttonsDialog.SelectedFont;

                if (buttonsDialog.SelectedSize > 0)
                {
                    Application.Current.Resources["GlobalFamilySize"] = buttonsDialog.SelectedSize;
                }
            }
        }

        public void CustomiseBackground(MainWindow mwindow)
        {
            var colorDialog = new CustBackgroundDialog();
            if (colorDialog.ShowDialog() == true)
            {
                mwindow.Background = new SolidColorBrush(colorDialog.SelectedColor);
            }
        }

        public void CustomiseLabels()
        {
            var labelsDialog = new CustLabelsDialog();
            if (labelsDialog.ShowDialog() == true)
            {
                Application.Current.Resources["LabelBackgroundBrush"] = new SolidColorBrush(labelsDialog.SelectedColor);
                Application.Current.Resources["GlobalFamilyFont"] = labelsDialog.SelectedFont;

                if (labelsDialog.SelectedSize > 0)
                {
                    Application.Current.Resources["GlobalFamilySize"] = labelsDialog.SelectedSize;
                }
            }
        }

        public void DisplayDistance(MainWindow mwindow, AstroProcessor processor)
        {
            if (mwindow.lstBoxDistance.Items.Count > 0)
            {
                mwindow.lstBoxDistance.Items.Clear();
            }

            foreach (var value in processor.distanceList)
            {
                mwindow.lstBoxDistance.Items.Add(value);
            }
        }
        public void DisplayTemperature(MainWindow mwindow, AstroProcessor processor)
        {
            if (mwindow.lstBoxTemperature.Items.Count > 0)
            {
                mwindow.lstBoxTemperature.Items.Clear();
            }

            foreach (var value in processor.temperatureList)
            {
                mwindow.lstBoxTemperature.Items.Add(value);
            }
        }
        public void DisplayEventHorizon(MainWindow mwindow, AstroProcessor processor)
        {
            if (mwindow.lstBoxHorizon.Items.Count > 0)
            {
                mwindow.lstBoxHorizon.Items.Clear();
            }

            foreach (var value in processor.eventHorList)
            {
                mwindow.lstBoxHorizon.Items.Add(value);
            }
        }

        public void DisplayVelocity(MainWindow mwindow, AstroProcessor processor)
        {
            if (mwindow.lstBoxVelocity.Items.Count > 0)
            {
                mwindow.lstBoxVelocity.Items.Clear();
            }

            foreach (var value in processor.velocityList)
            {
                mwindow.lstBoxVelocity.Items.Add(value);
            }
        }

        public void ClearTextBoxes(MainWindow mwindow)
        {
            mwindow.txtBoxObserved.Text = "";
            mwindow.txtBoxRest.Text = "";
            mwindow.txtBoxParallaxArcSec.Text = "";
            mwindow.txtBoxCelsius.Text = "";
            mwindow.txtBoxMass.Text = "";
        }

        public void SetLanguage(string path)
        {
            var md = Application.Current.Resources.MergedDictionaries;
            var existing = md.FirstOrDefault(d => d.Source != null &&
                                                  d.Source.OriginalString.Contains("Resources/Strings."));
            if (existing != null) md.Remove(existing);
            md.Add(new ResourceDictionary { Source = new Uri(path, UriKind.Relative) });
        }


    }
}
