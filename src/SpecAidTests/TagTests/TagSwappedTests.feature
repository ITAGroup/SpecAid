@CommonSteps
@LookupTestsSteps
@SpecAidTests
Feature: TagSwappedTests

Background: 
    Given SpecAid Setting UseHashTag is 'true'

Scenario: TagSwappedTests - UseHashTag True Hash Changes
    Given Tag This 'Some' as '#Some'
    Given Tag This 'big' as '#Big'
    Given Tag This 'string' as '#String'

	Given There are EveryThing Objects
	    | Tag It      | AString         |
	    | #Everything | Some big string |

	Then There are EveryThing Objects via Lookup
	    | !LookUp     | AString                  |
	    | #Everything | {#Some} {#Big} {#String} |

Scenario: TagSwappedTests String Building
    Given Tag This 'Some' as '#Some'
    Given Tag This 'big' as '#Big'
    Given Tag This 'string' as '#String'

	Given There are EveryThing Objects
	    | Tag It      | AString         |
	    | #Everything | Some big string |

	Then There are EveryThing Objects via Lookup
	    | !LookUp     | AString                  |
	    | #Everything | {#Some} {#Big} {#String} |

Scenario: TagSwappedTests Generated Keys
	Given There are EveryThing Objects
	    | Tag It      | AString |
	    | #Everything | AString |

	Then There are EveryThing Objects via Lookup
	    | !LookUp     | MyErrorMessage                                      |
	    | #Everything | Everything Object with Id {#Everything.Id} message. |
