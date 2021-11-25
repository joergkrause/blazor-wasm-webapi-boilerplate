using Workshop.Blazor.DataAccessLayer;

namespace Workshop.Blazor.BusinessLogicLayer
{
    public abstract class Manager {

        public Manager(EventDatabaseContext context) {
            Context = context;
        }

        protected EventDatabaseContext Context { get; }

    }
}