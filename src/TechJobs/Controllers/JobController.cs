using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.Models;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {
        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            Job job = jobData.Find(id);
            NewJobViewModel newJobViewModel = new NewJobViewModel();

            job.Name = newJobViewModel.Name;
            job.Employer = jobData.Employers.Find(newJobViewModel.EmployerID);
            job.Location = jobData.Locations.Find(newJobViewModel.LocationID);
            job.CoreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.CoreCompetencyID);
            job.PositionType = jobData.PositionTypes.Find(newJobViewModel.PositionTypesID);


            return View(job);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            if (ModelState.IsValid)
            {
                Job newJob = new Job

                {
                    Name = newJobViewModel.Name,
                    Employer = jobData.Employers.Find(newJobViewModel.EmployerID),
                    Location = jobData.Locations.Find(newJobViewModel.LocationID),
                    CoreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.CoreCompetencyID),
                    PositionType = jobData.PositionTypes.Find(newJobViewModel.PositionTypesID)
                };
                jobData.Jobs.Add(new Job());
                return Redirect(string.Format("/Job?id={0}", newJob.ID));
            }

            // TODO #6 - Validate the ViewModel and if valid, create a
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.

            return View(newJobViewModel);
        }
    }
}