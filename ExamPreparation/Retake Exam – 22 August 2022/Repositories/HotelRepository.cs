using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> _hotelList;
        public HotelRepository()
        {
                _hotelList = new List<IHotel>();
        }
        public void AddNew(IHotel model)
        {
            _hotelList.Add(model);
        }

        public IReadOnlyCollection<IHotel> All() => _hotelList;

        public IHotel Select(string criteria)
        {
           return _hotelList.FirstOrDefault(x=>x.FullName==criteria);
        }
    }
}
