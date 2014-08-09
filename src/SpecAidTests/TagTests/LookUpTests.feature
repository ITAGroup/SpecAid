@CommonSteps
@LookupTestsSteps
Feature: LookUpTests

Scenario: LookUpTests - Normal
	Given SpecAid Setting UseHashTag is 'true'

	Given There are EveryThing Objects
	    | Tag It      | anInt |
	    | #Everything | 12    |

	Then There are EveryThing Objects via Lookup
	    | !LookUp     | anInt |
	    | #Everything | 12    |

Scenario: LookUpTests - HashTag
	Given SpecAid Setting UseHashTag is 'true'

	Given There are EveryThing Objects
	    | Tag It      | anInt |
	    | #Everything | 12    |

	Then There are EveryThing Objects via Recall
	    | Recall      | anInt |
	    | #Everything | 12    |

Scenario: LookUpTests - HashTagCompatibleToBracketTag
	Given SpecAid Setting UseHashTag is 'true'

	Given There are EveryThing Objects
	    | Tag It      | anInt |
	    | #Everything | 12    |

	Then There are EveryThing Objects via Recall
	    | Recall         | anInt |
	    | <<Everything>> | 12    |


Scenario: LookUpTests - BracketTagCompatibleToHashTag
	Given SpecAid Setting UseHashTag is 'true'

	Given There are EveryThing Objects
	    | Tag It         | anInt |
	    | <<Everything>> | 12    |

	Then There are EveryThing Objects via Recall
	    | Recall      | anInt |
	    | #Everything | 12    |

Scenario: LookUpTests - HashTag Works with Deeplink
	Given SpecAid Setting UseHashTag is 'true'

	Given There are EveryThing Objects
	    | Tag It       | anInt              | innerEveryThingObject |
	    | #Everything1 | 12                 | null                  |
	    | #Everything2 | #Everything1.anInt | #Everything1          |

	Then There are EveryThing Objects via Recall
	    | Recall       | anInt | innerEveryThingObject.anInt |
	    | #Everything2 | 12    | 12                          |

Scenario: LookUpTests - HashTag Works BracketTags With Periods
	Given SpecAid Setting UseHashTag is 'true'

	# Protection against backwards compatibility issues.
	Given There are EveryThing Objects
	    | Tag It          | anInt |
	    | <<Every.Thing>> | 12    |

	Then There are EveryThing Objects via Recall
	    | Recall      | anInt |
	    | #Everything | 12    |


Scenario: LookUpTests - DeepLink With Angle Brackets
	Given SpecAid Setting UseHashTag is 'true'

	Given There are EveryThing Objects
	    | Tag It         | anInt |
	    | <<Everything>> | 12    |

	Then There are EveryThing Objects via Recall
	    | Recall         | anInt                |
	    | <<Everything>> | <<Everything>>.anInt |


Scenario: LookUpTests - DeepLink With Hash Tag
	Given SpecAid Setting UseHashTag is 'true'

	Given There are EveryThing Objects
	    | Tag It      | anInt |
	    | #Everything | 12    |

	Then There are EveryThing Objects via Recall
	    | Recall      | anInt             |
	    | #Everything | #Everything.anInt |
