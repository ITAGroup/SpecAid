@TypeConvertionTestsSteps
Feature: OutputTests

Scenario: OutputTests - List
	Given I have EveryThing Objects
	    | ListStrings   |
	    | ["""a""",b,c] |

	Then There are EveryThing Objects
	    | ListStrings   |
	    | ["""a""",b,c] |
