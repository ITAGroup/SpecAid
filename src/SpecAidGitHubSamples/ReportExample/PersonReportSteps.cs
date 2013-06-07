using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using SpecAid;
using SpecAidGitHubSamples.Common;
using SpecAidGitHubSamples.Vaporware.Entities;
using SpecAidGitHubSamples.Vaporware.Repos;
using TechTalk.SpecFlow;

namespace SpecAidGitHubSamples.ReportExample
{
    [Binding]
    public class PersonReportSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        #region Givens
        [Given("I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see http://go.specflow.org/doc-sharingdata 
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            ScenarioContext.Current.Pending();
        }
        #endregion

        #region Whens
        [When(@"I view the Person Report")]
        public void WhenIViewThePersonReport()
        {
            var Ipersonreport = new Mock<IPersonReport>();
            Ipersonreport.SetupAllProperties();
            ScenarioContext.Current.Set(Ipersonreport, "personreportIntreface");
            Ipersonreport.Object.PersonReportDtos = PersonReportData.GetDataForPersonReport();
        }

        #endregion

        #region Thens

        [Then(@"I have Person Report")]
        public void ThenIHavePersonReport(Table table)
        {
            var Ipersonreport = ScenarioContext.Current.Get<Mock<IPersonReport>>("personreportIntreface");
            TableAid.ObjectComparer(table, Ipersonreport.Object.PersonReportDtos);
        }

        #endregion
    }

    public interface IPersonReport
    {
        IList<PersonReportDTO> PersonReportDtos { get; set; }
    }
    public class PersonReportDTO
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
        public static IList<PersonReportDTO> GetDataForPersonReport()
        {
            var peopleRepo = RecallAidHelper.GetReal<PeopleRepo>();
            var persons = peopleRepo.GetAll();
            var storeRepo = RecallAidHelper.GetReal<StoreRepo>();
            var stores = storeRepo.GetAll();

            var data = (from person in persons
                        join store in stores on person.Store.StoreId equals store.StoreId
                        select new PersonReportDTO
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
