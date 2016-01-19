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
	    | Field 1 | Field 2 | Field 3 | Field 4 | Field 5 | Field 6 |
	    | I       | can     | set     | any     | field   |         |

	Then The Int String Dictionary
	    | Field 1 | Field 2 | Field 3 | Field 4 | Field 5 | Field 6 |
	    | I       | can     | set     | any     | field   |         |

Scenario: IndexerTests - No Object is Null - Not Explode
	Given The String String Dictionary
	    | Field 1 | Field 2 | Field 3 | Field 4 | Field 5 |
	    | I       | can     | set     | any     | field   |

	Then The String String Dictionary
	    | Field 1 | Field 2 | Field 3 | Field 4 | Field 5 | Field6 |
	    | I       | can     | set     | any     | field   | null   |

