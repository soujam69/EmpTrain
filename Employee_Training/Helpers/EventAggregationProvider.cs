using Caliburn.Micro;

namespace Employee_Training.Helpers
{
    public static class EventAggregationProvider
    {
        public static EventAggregator OutTurnEventAggregator { get; set; } = new EventAggregator();
    }
}
