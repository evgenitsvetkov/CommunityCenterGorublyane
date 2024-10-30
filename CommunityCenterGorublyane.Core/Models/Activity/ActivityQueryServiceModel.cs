namespace CommunityCenterGorublyane.Core.Models.Activity
{
    public class ActivityQueryServiceModel
    {
        public int TotalActivitiesCount { get; set; }

        public IEnumerable<ActivityServiceModel> Activities { get; set; } = new List<ActivityServiceModel>();
    }
}
