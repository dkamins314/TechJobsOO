﻿using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.Models;
using TechJobs.ViewModels;


namespace TechJobs.Controllers
{
    public class JobController : Controller
    {
        // Our reference to the data store
        private static JobData jobData;

        static JobController() => jobData = JobData.GetInstance();

       

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            Job ajob = jobData.Find(id);
            NewJobViewModel newjob = new NewJobViewModel
            {
                Name = ajob.Name,
                EmployerID = ajob.Employer.ID,
                LocationID = ajob.Location.ID,
                CoreCompetencyID = ajob.CoreCompetency.ID,
                PositionTypesID = ajob.PositionType.ID
            };

            return View(ajob);
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

                jobData.Jobs.Add(newJob);
                return Redirect(string.Format("/job?id={0}", newJob.ID));
            }

       

            return View(newJobViewModel);
        }
    }
}
// TODO #6 - Validate the ViewModel and if valid, create a
// new Job and add it to the JobData data store. Then
// redirect to the Job detail (Index) action/view for the new Job.