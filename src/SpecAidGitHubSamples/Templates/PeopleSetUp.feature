@ignore
@TutorialGivenBasicSteps
Feature: PeopleSetUp

Scenario: Setting up people
	# Everyday People
	Given I have People
      | Emp Id | First Name | Middle Name | Last Name | Store   | YearsOfService |
      | 1      | Fox        | C           | Smith     | <<Red>> | 1              |
      | 2      | Jayne      |             | Cobb      | <<Red>> | 0              |


	# 25 Years and Longer
	Given I have People
      | Emp Id | First Name | Middle Name | Last Name | Store   | YearsOfService |
      | 1      | Sue        |             | Smith     | <<Red>> | 25             |
      | 2      | Jayne      |             | Cobb      | <<Red>> | 26             |
