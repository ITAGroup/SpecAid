SpecAid Readme

Notes
	TableAid
		Used for Creating, Updating and Comparing Lists with Specflow tables
  
	RecallAid
		Wrapper for ScenrioContext.Current (case insensitive)

TableAid Samples
	# Create a MessageLedger

		Given I have MessageLedger
		| !Notes | PersonId        | SentDT                  | MessageLedgerType               |
		|        | <<PersonId001>> | 2012-01-28 00:00:00.000 | STARAwardsEnrolledReminderEmail |
  
		[Given(@"I have MessageLedger")]
		public void GivenIHaveMessageLedger(Table table)
		{
			TableAid.ObjectCreator<MessageLedger>(table,(r,m) => messageLedgerRepo.Save(m));
		}

	# Update a Person

		Given I have updated PersonDTO
		| !Notes                | !Key <<PersonId>> | Taxid     | TaxIdType |
		| DA - Has TaxId        | <<PersonId001>>   | 999993015 | SSN       |
		| EA - Has TaxId        | <<PersonId002>>   | 999993015 | SSN       |

		[Given(@"I have updated PersonDTO")]
		public void GivenIHaveUpdatedPersonDTO(Table table)
		{
			TableAid.ObjectUpdater(table, FindPerson, (tr,p) => personService.Save(p));
		}

		private PersonDTO FindPerson(TableRow tr)
		{
			if (tr.ContainsKey("!Key <<PersonId>>"))
			{
				var personIdTag = tr["!Key <<PersonId>>"];
				var personId = (int)RecallAid.It[personIdTag];

				return personService.GetBy(personId);
			}
			return null;
		}

	# Compare Database table to Specflow table

		Then 'SV' will see
		| !Notes | CategoryType         | Content                                                |
		|        | ToolboxService       | <a href="http://www.KPC.com/">Link 1</a> |

		[Then(@"'(.*)' will see")]
		public void ThenRoleWillSee(string roles, Table table)
		{
			var theRoles = roles.Split(',');

			var theList = dynamicContentRepo.GetByRolesAndInclusionDate(DynamicContentCategoryType.ToolBoxBestPractices , theRoles, DateTime.Now).ToList();

			SpecAid.TableAid.ObjectComparer(table, theList);
		}


RecallAid Samples
	# Setup Constant Tags
		#region Tag Literals
		public const string MessageFilterStart = "MessageCommonSteps.MessageFilterStart";
		public const string MessageFilterEnd = "MessageCommonSteps.MessageFilterEnd";
		#endregion

	# Remember
		RecallAid.It[MessageCommonSteps.MessageFilterStart] = DateTime.Now;
		// Do somethine
		RecallAid.It[MessageCommonSteps.MessageFilterEnd] = DateTime.Now;

	# Retreive
		var MessageFilterStart = (DateTime)RecallAid.It[MessageCommonSteps.MessageFilterStart];
		var MessageFilterEnd = (DateTime)RecallAid.It[MessageCommonSteps.MessageFilterEnd];












