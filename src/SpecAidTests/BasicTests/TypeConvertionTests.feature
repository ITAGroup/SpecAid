@TypeConvertionTestsSteps
Feature: TypeConvertionTests

Scenario: TypeConvertionTests - Int
	Given There are EveryThing Objects
	    | anInt |
	    | 12    |

	Then There are EveryThing Objects
	    | anInt |
	    | 12    |

Scenario: TypeConvertionTests - Guid
	Given There are EveryThing Objects
	    | aGuid                                |
	    | 11ab0769-41cb-4655-b05d-621cc17585d4 |

	Then There are EveryThing Objects
	    | aGuid                                |
	    | 11ab0769-41cb-4655-b05d-621cc17585d4 |

Scenario: TypeConvertionTests - Nullable Guid
	Given There are EveryThing Objects
	    | aNullableGuid                        |
	    | 11ab0769-41cb-4655-b05d-621cc17585d4 |
	    | null                                 |

	Then There are EveryThing Objects
	    | aNullableGuid                        |
	    | 11ab0769-41cb-4655-b05d-621cc17585d4 |
	    | null                                 |

Scenario: TypeConvertionTests - Enumerable
	Given There are EveryThing Objects
	    | someStrings |
	    | [a,b,c]     |

	Then There are EveryThing Objects
	    | someStrings |
	    | [a,b,c]     |

Scenario: TypeConvertionTests - Enumerable No Brackets
	Given There are EveryThing Objects
	    | someStrings |
	    | a,b,c       |

	Then There are EveryThing Objects
	    | someStrings |
	    | a,b,c       |

Scenario: TypeConvertionTests - Enumerable Null
	Given There are EveryThing Objects
	    | someStrings |
	    | null        |

	Then There are EveryThing Objects
	    | someStrings |
	    | null        |

Scenario: TypeConvertionTests - List
	Given There are EveryThing Objects
	    | ListStrings |
	    | [a,b,c]     |

	Then There are EveryThing Objects
	    | ListStrings |
	    | [a,b,c]     |

Scenario: TypeConvertionTests - List Null
	Given There are EveryThing Objects
	    | ListStrings |
	    | null        |

	Then There are EveryThing Objects
	    | ListStrings |
	    | null        |

Scenario: TypeConvertionTests - PlainList
	Given There are EveryThing Objects
	    | PlainList |
	    | [a,b,c]   |

	Then There are EveryThing Objects
	    | PlainList |
	    | [a,b,c]   |

Scenario: TypeConvertionTests - PlainList Null
	Given There are EveryThing Objects
	    | PlainList |
	    | null      |

	Then There are EveryThing Objects
	    | PlainList |
	    | null      |

Scenario: TypeConvertionTests - Array
	Given There are EveryThing Objects
	    | ArrayStrings |
	    | [a,b,c]      |

	Then There are EveryThing Objects
	    | ArrayStrings |
	    | [a,b,c]      |

Scenario: TypeConvertionTests - Array Null
	Given There are EveryThing Objects
	    | ArrayStrings |
	    | null         |

	Then There are EveryThing Objects
	    | ArrayStrings |
	    | null         |
