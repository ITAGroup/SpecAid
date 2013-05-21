@TutorialSteps
Feature: Tutorial What If
	In order to have good examples
	I want some feature files

@TutorialNoSpoonSteps
Scenario: What If There Is No Spoon

	Given I have a Person
		| First Name | Last Name |
		| Fox        | Smith     |

	Then There is a Person
	  | First Name | Last Name |
	  | Fox        | Smith     |

@TutorialGivenUseAnActionSteps
@TutorialStoresSteps
@TutorialSpacesForAllSteps
Scenario: Making People With Spaces
	Given I have Stores
	  | Tag It   | StoreId | Name                         |
	  | <<Red>>  | 42      | Red's Brick and Landscaping  |

	Given I have People
      | Emp Id | First Name | Middle Name | Last Name  | Store   | YearsOfService |
      | 1      | "Fox"      | "C"         | "Smith   " | <<Red>> | 1              |
      | 2      | "Jayne"    |             | "Cobb    " | <<Red>> | 0              |

	When I Build the Store Employee Report

	Then The Store Employee Report Shows
	| !Notes | LineNumber | Line                                       |
	|        | 0          | "Store                                   " |
	|        | 1          | "  Employee              Years of Service" |
	|        | 2          | "                                        " |
	|        | 3          | "Red's Brick and Landscaping             " |
	|        | 4          | "  Fox Smith                            1" |
	|        | 5          | "  Jayne Cobb                           0" |
