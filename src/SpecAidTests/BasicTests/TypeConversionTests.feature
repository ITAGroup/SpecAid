@TypeConversionTestsSteps
Feature: TypeConversionTests

Scenario: TypeConversionTests - Int
	Given There are EveryThing Objects
	    | anInt |
	    | 12    |

	Then There are EveryThing Objects
	    | anInt |
	    | 12    |

Scenario: TypeConversionTests - Enumerable
	Given There are EveryThing Objects
	    | someStrings |
	    | [a,b,c]     |

	Then There are EveryThing Objects
	    | someStrings |
	    | [a,b,c]     |

Scenario: TypeConversionTests - Enumerable No Brackets
	Given There are EveryThing Objects
	    | someStrings |
	    | a,b,c       |

	Then There are EveryThing Objects
	    | someStrings |
	    | a,b,c       |

Scenario: TypeConversionTests - Enumerable Null
	Given There are EveryThing Objects
	    | someStrings |
	    | null        |

	Then There are EveryThing Objects
	    | someStrings |
	    | null        |

Scenario: TypeConversionTests - List
	Given There are EveryThing Objects
	    | ListStrings |
	    | [a,b,c]     |

	Then There are EveryThing Objects
	    | ListStrings |
	    | [a,b,c]     |

Scenario: TypeConversionTests - List Null
	Given There are EveryThing Objects
	    | ListStrings |
	    | null        |

	Then There are EveryThing Objects
	    | ListStrings |
	    | null        |

Scenario: TypeConversionTests - PlainList
	Given There are EveryThing Objects
	    | PlainList |
	    | [a,b,c]   |

	Then There are EveryThing Objects
	    | PlainList |
	    | [a,b,c]   |

Scenario: TypeConversionTests - PlainList Null
	Given There are EveryThing Objects
	    | PlainList |
	    | null      |

	Then There are EveryThing Objects
	    | PlainList |
	    | null      |

Scenario: TypeConversionTests - Array
	Given There are EveryThing Objects
	    | ArrayStrings |
	    | [a,b,c]      |

	Then There are EveryThing Objects
	    | ArrayStrings |
	    | [a,b,c]      |

Scenario: TypeConversionTests - Array Null
	Given There are EveryThing Objects
	    | ArrayStrings |
	    | null         |

	Then There are EveryThing Objects
	    | ArrayStrings |
	    | null         |
