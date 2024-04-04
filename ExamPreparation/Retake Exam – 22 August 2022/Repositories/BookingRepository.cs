using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> _books;
        public BookingRepository()
        {
            
            _books = new List<IBooking>();
        }
        public void AddNew(IBooking model)
        {
            _books.Add(model);
        }

        public IReadOnlyCollection<IBooking> All() => _books;

        public IBooking Select(string criteria)
        {
          return _books.FirstOrDefault(x=> x.BookingNumber.ToString() == criteria);
        }
    }
}
