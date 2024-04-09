namespace ExploreTheProgramCsFile.NewFolder
{
    public interface IUserSessionService
    {
        void LogActivity(string activity);
        IEnumerable<string> GetActivities();
    }
}
