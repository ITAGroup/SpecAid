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

Scenario: TypeConvertionTests - List
	Given There are EveryThing Objects
	    | ListStrings |
	    | [a,b,c]     |

	Then There are EveryThing Objects
	    | ListStrings |
	    | [a,b,c]     |
