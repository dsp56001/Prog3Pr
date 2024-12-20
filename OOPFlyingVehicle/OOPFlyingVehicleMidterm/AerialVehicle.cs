﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPFlyingVehicle
{
    public abstract class AerialVehicle
    {
        public Engine Engine { get; protected set; }
        public bool IsFlying { get; protected set; }
        public int MaxAltitude { get; protected set; }
        public int CurrentAltitude { get; protected set; }

        public AerialVehicle()
        {
            this.Engine = new Engine();
            this.IsFlying = false;
            this.CurrentAltitude = 0;
        }

        public virtual void StartEngine()
        {
            this.Engine.Start();
        }

        public virtual void StopEngine()
        {
            this.Engine.Stop();
        }

        public void FlyUp()
        {
            this.FlyUp(1000);
        }

        public void FlyUp(int HowManyFeet)
        {
            if (this.IsFlying)
            {
                if (this.CurrentAltitude + HowManyFeet <= this.MaxAltitude)
                    this.CurrentAltitude += HowManyFeet;
            }
        }

        public void FlyDown()
        {
            this.FlyDown(1000);
        }

        public void FlyDown(int HowManyFeet)
        {
            if (this.IsFlying)
            {
                if (this.CurrentAltitude - HowManyFeet >= 0)
                    this.CurrentAltitude -= HowManyFeet;
                if (this.CurrentAltitude <= 0)
                {
                    this.CurrentAltitude = 0;
                    this.IsFlying = false;
                }
            }
            
        }

        public virtual string TakeOff()
        {
            if (Engine.IsStarted)
            {
                this.IsFlying = true;
                return string.Format("{0} is flying", this);
            }
            return string.Format("{0} can't fly it's engine is not started.", this);
        }

        /// <summary>
        /// Returns a string that describes if an engine is started
        /// </summary>
        /// <returns></returns>
        protected string getEngineStartedString()
        {
            return this.Engine.About();
        }

        public virtual string About()
        {
            string about = string.Format("This {0} has a max altitude of {1} ft. \nIt's current altitude is {2} ft. \n{3}", 
                this.ToString(), this.MaxAltitude.ToString(), this.CurrentAltitude, this.getEngineStartedString());
            return about;
            
        }
    }
}
