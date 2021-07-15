﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementApplication
{
    class Airline
    {
        private int _ID;
        private string _name;
        private string _airplane;
        private int _seatsAvailable;
        private string _mealAvailable;

        public int ID { get => _ID; set => _ID = value; }
        public string Name { get => _name; set => _name = value; }
        public string Airplane { get => _airplane; set => _airplane = value; }
        public int SeatsAvailable { get => _seatsAvailable; set => _seatsAvailable = value; }
        public string MealAvailable { get => _mealAvailable; set => _mealAvailable = value; }

        public Airline(int iD, string name, string airplane, int seatsAvailable, string mealAvailable)
        {
            ID = iD;
            Name = name;
            Airplane = airplane;
            SeatsAvailable = seatsAvailable;
            MealAvailable = mealAvailable;
        }
    }
}
