using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customLed
{
    public class LedProperty
    {
        public Point m_ptLocation;///<!-- Position of the led in the matrix (center of the led)-->
        public int m_iRadius;   ///<!-- Radius of the led                                    -->

        /// <summary>
        /// Constructor
        /// </summary>
        public LedProperty()
        {
            // Initialisations
            m_ptLocation.X = 0;
            m_ptLocation.Y = 0;
            m_iRadius = 0;
        }
    }
}
