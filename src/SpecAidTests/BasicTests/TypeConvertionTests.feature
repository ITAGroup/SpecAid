@TypeConvertionTestsSteps
Feature: TypeConvertionTests

Scenario: TypeConvertionTests - Int
	Given I have EveryThing Objects
	    | aInt |
	    | 12   |

	Then There are EveryThing Objects
	    | aInt |
	    | 12   |


Scenario: TypeConvertionTests - Guid
	Given I have EveryThing Objects
	    | aGuid                                |
	    | 11ab0769-41cb-4655-b05d-621cc17585d4 |

	Then There are EveryThing Objects
	    | aGuid                                |
	    | 11ab0769-41cb-4655-b05d-621cc17585d4 |
