@TypeConversionTestsSteps
Feature: OutputTests

Scenario: OutputTests - List
	Given There are EveryThing Objects
	    | ListStrings   |
	    | ["""a""",b,c] |

	Then There are EveryThing Objects
	    | ListStrings   |
	    | ["""a""",b,c] |
