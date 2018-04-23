using System.Collections;

namespace SchedulerBindXPOMvc {
    public class SchedulerDataObject {
        public IEnumerable Appointments { get; set; }
        public IEnumerable Resources { get; set; }
    }
}