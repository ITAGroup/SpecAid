@IndexerTestsSteps
Feature: IndexerTests

Scenario: IndexerTests - Basic Find Compare
	Given The String String Dictionary
	    | Field 1 | Field 2 | Field 3 | Field 4 | Field 5 | Field 6 |
	    | I       | can     | set     | any     | field   |         |

	Then The String String Dictionary
	    | Field 1 | Field 2 | Field 3 | Field 4 | Field 5 | Field 6 |
	    | I       | can     | set     | any     | field   |         |

Scenario: IndexerTests - Basic Find Compare for Ints
	Given The Int String Dictionary
	    | 1 | 2   | 3   | 4   | 5     |
	    | I | can | set | any | field |

	Then The Int String Dictionary
	    | 1 | 2   | 3   | 4   | 5     |
	    | I | can | set | any | field |

Scenario: IndexerTests - No Object is Null - Not Explode
	Given The String String Dictionary
	    | Field 1 | Field 2 | Field 3 | Field 4 | Field 5 |
	    | I       | can     | set     | any     | field   |

	Then The String String Dictionary
	    | Field 1 | Field 2 | Field 3 | Field 4 | Field 5 | Field6 |
	    | I       | can     | set     | any     | field   | null   |

Scenario: IndexerTests - Match To Indexers to Type
	Given The Complex Indexer Object
	    | 0   | Zero |
	    | One | Zero |

	Then The Complex Indexer Object
	    | 0   | Zero | CountOfIntLookups | CountOfStringLookups |
	    | One | Zero | 1                 | 1                    |

Scenario: IndexerTests - Properly Convert Fields
	Given The String Decimal Dictionary
	    | aField   |
	    | 00012.34 |

	Then The String Decimal Dictionary
	    | aField    |
	    | 12.34000  |

Scenario: IndexerTests - Deep Link Indexer To Item
	Given The String Informant Dictionary
	    | Sanrio | Sanrio.FirstName | Sanrio.LastName |
	    | Sanrio | Hello            | Kitty           |

	Then The String Informant Dictionary
	    | Sanrio.FirstName | Sanrio.LastName |
	    | Hello            | Kitty           |

