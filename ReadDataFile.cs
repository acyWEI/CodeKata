using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace CodeKata
{
    public class ReadDataFile
    {
        
        public static void ReadData()
        {
            List<Driver> driverList = new List<Driver>();
            String[] readLine = new string[] { };
            string path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "C:/Users/AcyWE/source/repos/CodeKata/CodeKataData.txt");
            try
            {
                readLine = File.ReadAllLines(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error file");
            }

            int command = 0, driverName = 1, start = 2, end = 3, miles = 4;

            foreach (String line in readLine)
            {
                String[] getData = line.Split(' ');
                // check the 2 possible commands
                string checkCommand = getData[command].ToUpper();
                if (checkCommand == "DRIVER")
                {
                    Driver driver = new Driver();
                    driver.Name = getData[driverName];
                    driverList.Add(driver);
                }
                else if (checkCommand == "TRIP")
                {
                    Driver driver = driverList.Find(d => d.Name.Equals(getData[driverName]));
                    Trip trip = new Trip();
                    trip.Start = DateTime.Parse(getData[start]);
                    trip.End = DateTime.Parse(getData[end]);
                    trip.Miles = float.Parse(getData[miles]);

                
                    if (trip.DiscardTrip())
                    {
                        driver.AddTrip(trip);
                    }
                }
            }
            driverList.ForEach(delegate (Driver driver)
            {
                Console.WriteLine(driver.Name + ": " + driver.DriverMile() + " miles @ " + driver.AverageSpeed() + " mph");
            });
        }
       
        
        
    }
}
