using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecAidGitHubSamples.Common;
using SpecAidGitHubSamples.Vaporware.Repos;

namespace SpecAidGitHubSamples.Vaporware.Reports
{
    public interface IPersonReport
    {
        IList<PersonReportDto> PersonReportDtos { get; set; }
    }

    public class PersonReportDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StoreName { get; set; }
        public int YearsOfService { get; set; }
        public string Tenured { get; set; }
    }

    //Initializing PersonReport Operations
    public class PersonReportData
    {
        public static IList<PersonReportDto> GetDataForPersonReport()
        {
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();
            var persons = peopleRepo.GetAll();
            var storeRepo = RecallAidHelper.GetReal<StoreRepo>();
            var stores = storeRepo.GetAll();

            var data = (from person in persons
                        join store in stores on person.Store.StoreId equals store.StoreId
                        select new PersonReportDto
                        {
                            FirstName = person.FirstName,
                            LastName = person.LastName,
                            StoreName = store.Name,
                            YearsOfService = person.YearsOfService,
                            Tenured = person.YearsOfService >= 5 ? "Yes" : "No"
                        }).ToList();

            return data;

        }
    }


}
