using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMSMVC.ViewModel
{
    public class TaskCreate
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public System.DateTime AssignedDate { get; set; }
        public System.DateTime DueDate { get; set; }
        public string SelectedPriority { get; set; }
        public string SelectedStatus { get; set; }
        public IEnumerable<SelectListItem> Assignee { get; set; }
        public IEnumerable<SelectListItem> Assigner { get; set; }
        public string SelectedAssignee { get; set; }
        public string SelectedAssigner { get; set; }
        public IEnumerable<SelectListItem> Priority { get; set; }
        public IEnumerable<SelectListItem> Status { get; set; }
        
    }
}