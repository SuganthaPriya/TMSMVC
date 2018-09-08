using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMSMVC.ViewModel
{
    public class TaskView
    {
        public int TaskID { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Task Name")]
        public string TaskName { get; set; }


        [Display(Name = "Assigned Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime AssignedDate { get; set; }


        [Display(Name = "DueDate Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime DueDate { get; set; }


        [Display(Name = "CompletedDate Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> CompletedDate { get; set; }


        public int StatusID { get; set; }
        public int PriorityID { get; set; }
        public int AssigneeID { get; set; }
        public int AssignerID { get; set; }


        [Required]
        [Display(Name = "Assignee")]
        public string AssigneeName { get; set; }


        [Required]
        [Display(Name = "Priority")]
        public string PriorityName { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string StatusName { get; set; }
        public string UserName { get; set; }
        //public IEnumerable<SelectListItem> Assignee { get; set; }
        //public IEnumerable<SelectListItem> Assigner { get; set; }
        //public IEnumerable<SelectListItem> Priority { get; set; }
        //public IEnumerable<SelectListItem> Status { get; set; }
        //public string SelectedAssignee { get; set; }
        //public string SelectedAssigner { get; set; }
        //public string SelectedPriority { get; set; }
        //public string SelectedStatus { get; set; }
    }
}