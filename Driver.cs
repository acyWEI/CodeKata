using System;
using System.Collections.Generic;
using System.Text;

namespace CodeKata
{
    public class Driver
    {
        public String Name { get; set; }
        List<Trip> Trips { get; set; }

        //calculate the total distance
        public double DriverMile()
        {
            float mileSum = 0;
            for (int i = 0; i < Trips.Count; i++ ) 
            {
                mileSum += Trips[i].Miles;
            }

            if (this.Trips == null) 
            {
                mileSum = 0; 
            }

            return Math.Round(mileSum);
        }

       // calculate the AverageSpeed
        public double AverageSpeed()
        {
            double total = 0;
            double totalMiles = this.DriverMile();
            float totalTime = 0;
            for (int i = 0; i < Trips.Count; i++)
            {
                totalTime += Trips[i].TripTime();
            }
            total = totalMiles / (double)totalTime;

            if (this.Trips == null)
            {
                total = 0;
            }

            return Math.Round(total);
        }

        // add the new trip 
        public void AddTrip(Trip trip)
        {
            if (this.Trips == null)
            {
                this.Trips = new List<Trip>();
            }
            this.Trips.Add(trip);
        }
    }
}
