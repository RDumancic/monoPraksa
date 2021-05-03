using System;
using System.Collections.Generic;
using System.Text;

namespace day1App
{
    class MiG
    {
        private PlaneClass mig;

        public MiG()
        {
            this.mig = new PlaneClass();
        }

        public void Patrol()
        {
            mig.Travel();
        }
    }
}
