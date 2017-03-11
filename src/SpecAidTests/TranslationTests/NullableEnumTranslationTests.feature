@NullableEnumTranslationTestSteps
Feature: NullableEnumTranslationTests

Scenario: Verify nullable enum works
	Given I have celebrities
	    | Tag It         | LastName   | AlmaMater |
	    | <<Brokaw>>     | Brokaw     | Iowa      |
	    | <<Carver>>     | Carver     | IowaState |
	    | <<Zuckerberg>> | Zuckerberg |           |
	    | <<Rose>>       | Rose       | null      |
	Then '<<Brokaw>>' graduated from 'Iowa'
	Then '<<Carver>>' graduated from 'IowaState'
	Then '<<Zuckerberg>>' did not graduate
	Then '<<Rose>>' did not graduate