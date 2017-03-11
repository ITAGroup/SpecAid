@TutorialGivenForeachSteps
@TutorialStoresSteps
Feature: PersonReport
	In order to view a person report
	As a manager
	I want to see who are the people that work for me

	# Acceptance Criteria:

	# Display a people report
	# First Name, Last Name, Store Name, Years of Service, Tenured
	#  The Tenured field will show 'Yes' for anyone with years of service greater than or equal to 5 and 'No' for anyone with years of service less than 5


Scenario: view people

	Given I have Stores
		| Tag It  | StoreId | Name                        |
		| <<Red>> | 42      | Red's Brick and Landscaping |
		| <<Dig>> | 43      | Dig It                      |
	
	Given I have People
		| Emp Id | First Name | Middle Name | Last Name | Store   | YearsOfService |
		| 1      | Fox        | C           | Smith     | <<Red>> | 1              |
		| 2      | Jayne      |             | Cobb      | <<Red>> | 5              |
		| 3      | Sue        |             | Smith     | <<Dig>> | 25             |
		| 4      | Jayne      |             | Cobb      | <<Dig>> | 26             |

	When I view the Person Report

	Then I have Person Report
		| FirstName | LastName | StoreName                   | YearsOfService | Tenured |
		| Fox       | Smith    | Red's Brick and Landscaping | 1              | No      |
		| Jayne     | Cobb     | Red's Brick and Landscaping | 5              | Yes     |
		| Sue       | Smith    | Dig It                      | 25             | Yes     |
		| Jayne     | Cobb     | Dig It                      | 26             | Yes     |