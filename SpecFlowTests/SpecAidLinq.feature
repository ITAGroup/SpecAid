@SpecAidTests
Feature: SpecAid Linq Testings

Scenario: Linq Math
	Then Do Expression '{5 + 5}' = '10'

Scenario: Linq Recall Test
	
	Given Tag This '15' as '<<fifteen>>'

	Then Do Expression '{(Recall["<<fifteen>>"])}' = '15'

Scenario: Linq Recall Add Test
	
	Given Tag This '15' as '<<fifteen>>' As Int

	Then Do Expression '{Int32(Recall["<<fifteen>>"]) + 5}' = '20'


Scenario: Linq Recall Convert Test
	
	Given Tag This '15' as '<<fifteen>>'

	Then Do Expression '{Convert.ToInt32(Recall["<<fifteen>>"]) + 5}' = '20'

Scenario: Linq Recall Aid Test
	
	Given Tag This 'Ben' as '<<firstName>>'
	Given Tag This 'Jerry' as '<<lastName>>'

	Given I have BrandNames
	| !BrandName    | Name            | EmployeeCount |
	| <<BenJerrys>> | Ben and Jerry's | 10            |
	| <<Generic>>   | Generic         | 1             |
	| <<Homemade>>  | Homemade        | 0             |

	Then BrandNames Tests
	|  Name            | EmployeeCount |
	|  Ben and Jerry's | 10            |
	|  Generic         | 1             |
	|  Homemade        | 0             |
	
	Then BrandNames Tests
	| Name                                                                      | EmployeeCount                            |
	| {StringAid["<<firstName>>"] + " and " + StringAid["<<lastName>>"] + "'s"} | {5 + 5}                                  |
	| Generic                                                                   | {StringAid["<<Generic>>.EmployeeCount"]} |
	| Homemade                                                                  | 0                                        |
	 
