namespace ExploreTheProgramCsFile.InMemeoryStore
{
    public static class InMemoryActivityStore
    {
        private static readonly List<string> _activities = new();
        private static readonly object _lock = new();

        public static void LogActivity(string activity)
        {
            lock (_lock)
            {
                _activities.Add(activity);
            }
        }

        public static IEnumerable<string> GetActivities()
        {
            lock (_lock)
            {
                return new List<string>(_activities); // Create a copy to avoid collection modification issues
            }
        }
    }
}
