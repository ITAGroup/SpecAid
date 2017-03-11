Feature: DateTimeOffsetTranslationTests

Scenario: Verify DateTimeOffset works
	Given I have cities
	    | Tag It        | Name       | CurrentDateTimeOffset | BarClosingTime   |
	    | <<NewYork>>   | New York   | 1/1/2000              | 1/1/2000 4:00 AM |
	    | <<DesMoines>> | Des Moines | 1/1/2000              | 1/1/2000 2:00 AM |
	    | <<LasVegas>>  | Las Vegas  | 1/1/2000              |                  |
	Then '<<NewYork>>' looks like
		 | Name     | CurrentDateTimeOffset | BarClosingTime   |
		 | New York | 1/1/2000              | 1/1/2000 4:00 AM |
	Then '<<LasVegas>>' looks like
		| Name      | CurrentDateTimeOffset | BarClosingTime |
		| Las Vegas | 1/1/2000              |                |
	Then '<<DesMoines>>' looks like
		| Name       | CurrentDateTimeOffset | BarClosingTime   |
		| Des Moines | 1/1/2000              | 1/1/2000 2:00 AM |

	