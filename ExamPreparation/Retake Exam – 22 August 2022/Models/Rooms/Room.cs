﻿using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private int badCapacity;
        private double pricePerNight;

        protected Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
            PricePerNight = 0;
   
        }

        public int BedCapacity {  get; private set; }

        public double PricePerNight
        {
            get => pricePerNight;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }
                pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            PricePerNight = price;
        }
    }
}
