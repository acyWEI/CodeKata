using System;
using System.Collections.Generic;
using System.Text;

namespace CodeKata
{
    public class Trip
    {
        // get all the data of time and miles
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public float Miles { get; set; }


        // calculate the time interval of the trip
        public float TripTime()
        {
            float time = 0;
            TimeSpan diff = End.Subtract(Start);
            time = (float)diff.TotalMinutes / 60;
            return time;
        }

        //check the average speed >=5 and <= 100
        public bool DiscardTrip()
        {
            float check = this.Miles / this.TripTime();

            return (check >= 5 && check <= 100);
        }
    }
}
