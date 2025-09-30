using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AstroLibrary.AstroProcessorLib;

namespace Malin_SSS_AT2
{
    public class AstroProcessor
    {
        public List<double> velocityList = new List<double>();
        public List<double> distanceList = new List<double>();
        public List<double> temperatureList = new List<double>();
        public List<double> eventHorList = new List<double>();

        public void AddVelocity(double observedWavelength, double restWavelength)
        {
            var temp = new AstroMath.AstroMath();

            this.velocityList.Add(temp.CalcStarVelocity(observedWavelength, restWavelength));
        }

        public void AddDistance(double arcSeconds)
        {
            var temp = new AstroMath.AstroMath();

            this.distanceList.Add(temp.CalcStarDistance(arcSeconds));
        }

        public void AddTemp(double celsius)
        {
            var temp = new AstroMath.AstroMath();

            this.temperatureList.Add(temp.CalcTemp(celsius));
        }

        public void AddEventHorizon(double mass)
        {
            var temp = new AstroMath.AstroMath();

            this.eventHorList.Add(temp.CalcEventHorizon(mass));
        }
    }
}
