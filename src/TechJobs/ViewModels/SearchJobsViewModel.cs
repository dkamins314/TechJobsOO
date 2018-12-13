using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class SearchJobsViewModel : BaseViewModel
    {
        // The column to search, defaults to all
        public JobFieldType Column { get; set; } = JobFieldType.All;

        // The search results
        public List<Job> Jobs { get; set; }

        

        // The search value
        [Display(Name = "Keyword:")]
        public string Value { get; set; } = "";
    }

    // TODO #7.1 - Extract members common to JobFieldsViewModel to BaseViewModel
}

// All columns, for display
// public List<JobFieldType> Columns { get; set; }

// View title
// public string Title { get; set; } = "";

//public SearchJobsViewModel()

// Populate the list of all columns

//  Columns = new List<JobFieldType>();

//  foreach (JobFieldType enumVal in Enum.GetValues(typeof(JobFieldType)))

//      Columns.Add(enumVal);