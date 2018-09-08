using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using TMSMVC.ViewModel;

namespace TMSMVC.Controllers
{
    public class TaskController : Controller
    {
        HttpClient httpClient = new HttpClient();
        string result = null;
        IEnumerable<TaskView> tasks = null;
        IEnumerable<StatusSummary> statusSummaries = null;
        IEnumerable<StatusList> statusLists = null;
        IEnumerable<PriorityList> priorityLists = null;
        IEnumerable<Users> AssigneeLists = null;

        // GET: Task
        public ActionResult TaskList()
        {
            httpClient.BaseAddress = new Uri("http://localhost:49982");
            httpClient.DefaultRequestHeaders.Accept.
                Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync("api/Tasks/GetTasks").Result;
            if (response.IsSuccessStatusCode)
            {
                tasks = response.Content.ReadAsAsync<IEnumerable<TaskView>>().Result;
            }
            HttpResponseMessage Status = httpClient.GetAsync("api/Tasks/GetStatusList").Result;
            if (Status.IsSuccessStatusCode)
            {
                statusLists = Status.Content.ReadAsAsync<IEnumerable<StatusList>>().Result;
            }
            HttpResponseMessage Priority = httpClient.GetAsync("api/Tasks/GetPriorityList").Result;
            if (Priority.IsSuccessStatusCode)
            {
                priorityLists = Priority.Content.ReadAsAsync<IEnumerable<PriorityList>>().Result;
            }

            HttpResponseMessage Assignee = httpClient.GetAsync("api/Tasks/GetAssigneeList").Result;
            if (Assignee.IsSuccessStatusCode)
            {
                AssigneeLists = Assignee.Content.ReadAsAsync<IEnumerable<Users>>().Result;
            }
            CommonView commonView = new CommonView();
            commonView.Status = statusLists.ToList();
            commonView.Priority = priorityLists.ToList();
            commonView.TaskView = tasks.ToList();
            commonView.Users = AssigneeLists.ToList();
            return View(commonView);

        }
        [HttpPost]
        public ActionResult AddNewTask(TaskCreate taskCreate)
        {

            httpClient.BaseAddress = new Uri("http://localhost:49982");
            httpClient.DefaultRequestHeaders.Accept.
            Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            result = httpClient.PostAsJsonAsync("api/Tasks/AddNewTask", taskCreate).
                                Result.Content.ReadAsStringAsync().Result;

            if (result == "\"success\"")
            {
                return RedirectToAction("TaskList", "Task");
            }

            else
            {
                return View("");
            }
        }

        public ActionResult DeleteTask(int Taskid)
        {
            TaskView taskView = new TaskView();
            taskView.TaskID = Taskid;
            httpClient.BaseAddress = new Uri("http://localhost:49982");
            httpClient.DefaultRequestHeaders.Accept.
            Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            result = httpClient.PostAsJsonAsync("api/Tasks/RemoveTask", taskView).
                               Result.Content.ReadAsStringAsync().Result;


            if (result == "\"success\"")
            {
                return RedirectToAction("TaskList", "Task");
            }

            else
            {
                return View("");
            }

        }
        public ActionResult EditTask(int TaskID, string TaskName, string AssignerName, string AssigneeName, string AssignedDate, string DueDate, string StatusName, string PriorityName)
        {
            TaskCreate taskCreate = new TaskCreate();
            taskCreate.TaskID = TaskID;
            taskCreate.TaskName = TaskName;
            taskCreate.SelectedAssigner = AssignerName;
            taskCreate.SelectedAssignee = AssigneeName;
            taskCreate.AssignedDate = Convert.ToDateTime(AssignedDate);
            taskCreate.DueDate = Convert.ToDateTime(DueDate);
            taskCreate.SelectedStatus = StatusName;
            taskCreate.SelectedPriority = PriorityName;
            httpClient.BaseAddress = new Uri("http://localhost:49982");
            httpClient.DefaultRequestHeaders.Accept.
            Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            result = httpClient.PostAsJsonAsync("api/Tasks/EditTask", taskCreate).
                                Result.Content.ReadAsStringAsync().Result;

            if (result == "\"success\"")
            {
                return RedirectToAction("TaskList", "Task");
            }

            else
            {
                return View("");
            }
        }
        public ActionResult GetMyTask()
        {
            string UserName = Session["UserName"].ToString();
            httpClient.BaseAddress = new Uri("http://localhost:49982");
            httpClient.DefaultRequestHeaders.Accept.
                Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = httpClient.GetAsync("api/Tasks/GetTasks").Result;
            if (response.IsSuccessStatusCode)
            {
                tasks = response.Content.ReadAsAsync<IEnumerable<TaskView>>().Result;
            }
            tasks = tasks.Select(x => x).Where(x => x.UserName == UserName).ToList();
            return View(tasks);
        }
        public ActionResult Summary()
        {
            httpClient.BaseAddress = new Uri("http://localhost:49982");
            httpClient.DefaultRequestHeaders.Accept.
                Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync("api/Tasks/GetStatusReport").Result;
            if (response.IsSuccessStatusCode)
            {
                statusSummaries = response.Content.ReadAsAsync<IEnumerable<StatusSummary>>().Result;
            }
            return View();

        }
    }
}