using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Workshop.Blazor.DataAccessLayer;
using Workshop.Blazor.DataTransferObjects;

namespace Workshop.Blazor.BusinessLogicLayer
{
    public class EventManager : Manager
    {

        private readonly IMapper _mapper;

        public EventManager(EventDatabaseContext context, IMapper mapper) : base(context) {
            _mapper = mapper;
        }

        public EventDto? GetEventById(int id) {
            // var model = Context.Events.Find(id); // ohne Seats
            var model = Context.Events.Include(evt => evt.Seats).SingleOrDefault(evt => evt.Id == id); // Mit Seats
            if (model != null) {
                return _mapper.Map<EventDto>(model);
            }
            // throw new ArgumentOutOfRangeException(nameof(id));
            return null;
        }

        public IEnumerable<EventDto> GetAllEvents() {
            var models = Context.Events.Include(evt => evt.Seats).ToList();
            return _mapper.Map<IEnumerable<EventDto>>(models);
        }

        public bool AddEvent(EventDto evt) {
            return false; // TODO
        }

        public bool RemoveEvent(EventDto evt) {
            return false; // TODO
        }

        // 

    }
}
