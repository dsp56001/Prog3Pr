using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPFlyingVehicle
{
    public class ToyPlane : Airplane
    {
        protected bool isWoundUP;

        public ToyPlane()
        {
            this.MaxAltitude = 50;
        }

        public override void StartEngine()
        {
            if (this.isWoundUP)
            {
                base.StartEngine();
            }
        }

        public override string TakeOff()
        {
            if(this.isWoundUP)
                return base.TakeOff();

            return string.Format("{0} can't take of it is not wound up. ", this) + base.TakeOff();
        }

        public void WindUp()
        {
            this.isWoundUP = true;
        }

        public void UnWind()
        {
            this.isWoundUP = false;
        }

        protected string getWindUpString()
        {
            string woundUp = "It's not wound up.";
            if(isWoundUP) woundUp = woundUp.Replace("not ", "");
            return woundUp;
        }

        public override string About()
        {
            return base.About() + "\n" + this.getWindUpString();
        }
    }
}
