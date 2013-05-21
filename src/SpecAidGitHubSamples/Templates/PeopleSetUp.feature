@ignore
Feature: PeopleSetUp

Scenario: Setting up people
	Given I have People
      | Emp Id | First Name | Middle Name | Last Name  | Store   | YearsOfService |
      | 1      | "Fox"      | "C"         | "Smith   " | <<Red>> | 1              |
      | 2      | "Jayne"    |             | "Cobb    " | <<Red>> | 0              |
