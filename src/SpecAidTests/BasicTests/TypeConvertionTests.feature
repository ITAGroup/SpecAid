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

Scenario: TypeConvertionTests - Nullable Guid
	Given I have EveryThing Objects
	    | aNullableGuid                        |
	    | 11ab0769-41cb-4655-b05d-621cc17585d4 |
	    | null                                 |

	Then There are EveryThing Objects
	    | aNullableGuid                        |
	    | 11ab0769-41cb-4655-b05d-621cc17585d4 |
	    | null                                 |


Scenario: TypeConvertionTests - Enumerable
	Given I have EveryThing Objects
	    | someStrings |
	    | [a,b,c]     |

	Then There are EveryThing Objects
	    | someStrings |
	    | [a,b,c]     |

Scenario: TypeConvertionTests - Enumerable No Brackets
	Given I have EveryThing Objects
	    | someStrings |
	    | a,b,c       |

	Then There are EveryThing Objects
	    | someStrings |
	    | a,b,c       |

Scenario: TypeConvertionTests - List
	Given I have EveryThing Objects
	    | ListStrings |
	    | [a,b,c]     |

	Then There are EveryThing Objects
	    | ListStrings |
	    | [a,b,c]     |
