using Moq;
using SpecAid;
using SpecAidGitHubSamples.Vaporware.Reports;
using TechTalk.SpecFlow;

namespace SpecAidGitHubSamples.ReportExample
{
    [Binding]
    public class PersonReportSteps
    {
        #region Whens
        [When(@"I view the Person Report")]
        public void WhenIViewThePersonReport()
        {
            var personreport = new Mock<IPersonReport>();
            personreport.SetupAllProperties();
            personreport.Object.PersonReportDtos = PersonReportData.GetDataForPersonReport();

            RecallAid.It["personreportIntreface"] = personreport;
        }

        #endregion

        #region Thens

        [Then(@"I have Person Report")]
        public void ThenIHavePersonReport(Table table)
        {
            var personreport = (Mock<IPersonReport>) RecallAid.It["personreportIntreface"];
            TableAid.ObjectComparer(table, personreport.Object.PersonReportDtos);
        }

        #endregion
    }
}
