using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static AstroLibrary.AstroProcessorLib;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Malin_SSS_AT2
{
    public class AstroProcessor
    {
        public List<double> velocityList = new List<double>();
        public List<double> distanceList = new List<double>();
        public List<double> temperatureList = new List<double>();
        public List<double> eventHorList = new List<double>();

        // Method: Adding input velocity to the velocity list, checking input first
        public void AddVelocity(string observedWavelengthInput, string restWavelengthInput)
        {
            if (Double.TryParse(observedWavelengthInput, out double resultObs))
            {
                if (Double.TryParse(restWavelengthInput, out double resultRest))
                {

                    // create an instance of the astro math library to use its calculation methods
                    var temp = new AstroMath.AstroMath();

                    // perform the star velocity calculation and add it to the velocity list
                    this.velocityList.Add(temp.CalcStarVelocity(resultObs, resultRest));
                }
                else
                {
                    MessageBox.Show("Rest wave length input is not a valid number", "Input Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Observed wave length input is not a valid number", "Input Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        // Method: Adding distance input to the distance list, checking input first
        public void AddDistance(string arcSecondsInput)
        {
            if (Double.TryParse(arcSecondsInput, out double resultArcSec))
            {
                var temp = new AstroMath.AstroMath();
                this.distanceList.Add(temp.CalcStarDistance(resultArcSec));
            }
            else
            {
                MessageBox.Show("Parallax Arc Seconds input is not a valid number", "Input Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        // Method: Adding temperature to the temperature list, , checking input first
        public void AddTemperature(string celsiusInput)
        {
            if (Double.TryParse(celsiusInput, out double resultTemp))
            {
                var temp = new AstroMath.AstroMath();

                this.temperatureList.Add(temp.CalcTemp(resultTemp)); 
            }
            else
            {
                MessageBox.Show("Celsius input is not a valid number", "Input Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        // Method: Adding horizon to the horizon list, checking input first
        public void AddEventHorizon(string massInput)
        {
            if (Double.TryParse(massInput, out double resultHor))
            {
                var temp = new AstroMath.AstroMath();
                
                this.eventHorList.Add(temp.CalcEventHorizon(resultHor));
            }
            else
            {
                MessageBox.Show("Mass input is not a valid number", "Input Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
