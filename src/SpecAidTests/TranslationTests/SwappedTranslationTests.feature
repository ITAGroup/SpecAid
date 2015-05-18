@CommonSteps
@LookupTestsSteps
@SpecAidTests
Feature: SwappedTranslationTests

Background: 
	Given SpecAid Setting UseHashTag is 'true'

Scenario: SwappedTranslationTests - UseHashTag True Hash Changes
	Given Tag This 'Some' as '#Some'
	Given Tag This 'big' as '#Big'
	Given Tag This 'string' as '#String'

	Given There are EveryThing Objects
		| Tag It      | AString         |
		| #Everything | Some big string |

	Then There are EveryThing Objects via Lookup
		| !LookUp     | AString                  |
		| #Everything | {#Some} {#Big} {#String} |

Scenario: SwappedTranslationTests String Building
	Given Tag This 'Some' as '#Some'
	Given Tag This 'big' as '#Big'
	Given Tag This 'string' as '#String'

	Given There are EveryThing Objects
		| Tag It      | AString         |
		| #Everything | Some big string |

	Then There are EveryThing Objects via Lookup
		| !LookUp     | AString                  |
		| #Everything | {#Some} {#Big} {#String} |

Scenario: SwappedTranslationTests Generated Keys
	Given There are EveryThing Objects
		| Tag It      | AString |
		| #Everything | AString |

	Then There are EveryThing Objects via Lookup
		| !LookUp     | MyErrorMessage                                      |
		| #Everything | Everything Object with Id {#Everything.Id} message. |

Scenario: SwappedTranslationTests Nested String Building
	Given Tag This 'SomeBigString' as '#SomeBigString'
	Given Tag This 'BigString' as '#BigString'
	Given Tag This 'String' as '#String'

	Given There are EveryThing Objects
		| Tag It      | AString       |
		| #Everything | SomeBigString |

	Then There are EveryThing Objects via Lookup
		| !LookUp     | AString              |
		| #Everything | #Some{#Big{#String}} |

Scenario: SwappedTranslationTests Swap Linq
	Given Tag This 'do(5 + 5)' as '#linq'

	Given There are EveryThing Objects
		| Tag It      | AString |
		| #Everything | 10      |

	Then There are EveryThing Objects via Lookup
		| !LookUp     | AString |
		| #Everything | {#linq} |

Scenario: SwappedTranslationTests Text Does not Have to Swap
	Given There are EveryThing Objects
		| Tag It      | AString     |
		| #Everything | "{AString}" |

	Then There are EveryThing Objects via Lookup
		| !LookUp     | AString   |
		| #Everything | {AString} |

