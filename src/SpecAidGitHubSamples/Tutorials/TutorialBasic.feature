@TutorialSteps
Feature: Tutorial Basic
	In order to have good examples
	I want some feature files

@TutorialGivenBasicSteps
Scenario: Making People Example Basic
	Given I have People
      | Emp Id | First Name | Last Name |
      | 1      | Fox        | Smith     |

	Then Assert True

@TutorialGivenForeachSteps
Scenario: Making People Example Foreach
	Given I have People
      | Emp Id | First Name | Last Name |
      | 1      | Fox        | Smith     |

	Then Assert True

@TutorialGivenUseAnActionSteps
Scenario: Making People Example Use An Action
	Given I have People
      | Emp Id | First Name | Last Name |
      | 1      | Fox        | Smith     |

	Then Assert True

@TutorialGivenUseAnActionSteps
@TutorialUpdatingPeopleSteps
Scenario: Updating People Example
	Given I have People
      | Emp Id | First Name | Last Name |
      | 1      | Fox        | Smith     |

	Given I update People
      | !Emp Id | Last Name | 
      | 1       | Jones     | 

	Then Assert True

@TutorialGivenUseAnActionSteps
@TutorialUpdatingPeopleReSaveSteps
Scenario: Updating People Example ReSave
	Given I have People
      | Emp Id | First Name | Last Name |
      | 1      | Fox        | Smith     |

	Given I update People
      | !Emp Id | Last Name | 
      | 1       | Jones     | 

	Then Assert True

@TutorialGivenUseAnActionSteps
@TutorialComparePeopleGoodSteps
Scenario: Compare People Example Good
	Given I have People
      | Emp Id | First Name | Last Name |
      | 1      | Fox        | Smith     |

	Then There are People
		| !Notes | Emp Id | First Name | Last Name | 
		|        | 1      | Fox        | Smith     | 

	Then Assert True


@TutorialGivenUseAnActionSteps
@TutorialComparePeopleBadSteps
@TutorialUpdatingPeopleReSaveSteps
Scenario: Compare People Example Bad
	Given I have People
      | Emp Id | First Name | Last Name |
      | 1      | Fox        | Smith     |

 	Given I update People
      | !Emp Id | Last Name | 
      | 1       | Jones     | 

	Then There are People
		| !Notes | Emp Id | First Name | Last Name | 
		|        | 1      | Fox        | Smith     | 

	Then Assert True

@TutorialGivenUseAnActionSteps
@TutorialFieldAidExampleSteps
Scenario: FieldAid Example
	Given I have People
      | Tag It  | Emp Id | First Name | Last Name |
      | <<Fox>> | 1      | Fox        | Smith     |

	Then Verify '<<Fox>>.FirstName' is 'Fox'

	Then Assert True

