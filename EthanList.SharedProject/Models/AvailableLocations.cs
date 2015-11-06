﻿using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace EthanList.SharedProject
{
    public class AvailableLocations
    {
        List<Location> locations = new List<Location>();
        SortedSet<String> states = new SortedSet<String>();

        public AvailableLocations()
        {
            ReadInputFile();
        }

        public List<Location> PotentialLocations
        {
            get { 
                return locations;
            }
        }

        public SortedSet<String> States
        {
            get { 
                return states;
            }
        }


        void ReadInputFile()
        {
            #if __IOS__
            var accountsStream = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("ethanslist.ios.USCraigslistLocations.csv"));
            #elif __ANDROID__
            var accountsStream = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("ethanslist.android.USCraigslistLocations.csv"));
            #endif

            using (accountsStream)
            {
                string line;
                while ((line = accountsStream.ReadLine()) != null)
                {
                    var container = line.Split(',');
                    locations.Add(new Location(container[0],container[1],container[2],container[3],container[4], container[5]));
                    states.Add(container[4]);
                }
            }
        }
    }
}

