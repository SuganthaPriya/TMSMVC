using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMSMVC.ViewModel
{
    public class CommonView
    {
        public IEnumerable<TaskView> TaskView { get; set; }
        public TaskCreate TaskCreate { get; set; }
        public IEnumerable<StatusList> Status { get; set; }
        public IEnumerable<PriorityList> Priority { get; set; }
        public IEnumerable<Users> Users { get; set; }
    }
}