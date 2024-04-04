using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> _rooms;
        public RoomRepository()
        {
             _rooms = new List<IRoom>();
        }
        public void AddNew(IRoom model)
        {
            _rooms.Add(model);
        }

        public IReadOnlyCollection<IRoom> All() => _rooms;

        public IRoom Select(string criteria)
        {
          return  _rooms.FirstOrDefault(x=>x.GetType().Name==criteria);
        }
    }
}
