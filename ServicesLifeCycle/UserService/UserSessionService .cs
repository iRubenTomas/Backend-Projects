using ExploreTheProgramCsFile.InMemeoryStore;

namespace ExploreTheProgramCsFile.NewFolder
{
    public class UserSessionService : IUserSessionService
    {
        private readonly List<string> _activities = new();

        public void LogActivity(string activity)
        {
            InMemoryActivityStore.LogActivity(activity);
        }

        public IEnumerable<string> GetActivities()
        {
            return InMemoryActivityStore.GetActivities();
        }
    }
}
