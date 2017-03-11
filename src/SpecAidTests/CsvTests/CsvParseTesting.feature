@CsvTests
Feature: CsvParseTesting

Scenario: CsvTesting Basic
	Given String 'a,b,c'
	Then List
	    | This |
	    | a    |
	    | b    |
	    | c    |

Scenario: CsvTesting Wider
	Given String 'aa,bb,cc'
	Then List
	    | This |
	    | aa   |
	    | bb   |
	    | cc   |

Scenario: CsvTesting Trim Spaces
	Given String ' a , b , c '
	Then List
	    | This |
	    | "a"  |
	    | "b"  |
	    | "c"  |

Scenario: CsvTesting Don't Trim Spaces
	Given String '" a "," b "," c "'
	Then List
	    | This    |
	    | "" a "" |
	    | "" b "" |
	    | "" c "" |

Scenario: CsvTesting Time Some Leave Some
	Given String ' " a " , " b " , " c " '
	Then List
	    | This    |
	    | "" a "" |
	    | "" b "" |
	    | "" c "" |

Scenario: CsvTesting First Quoted
	Given String '"a",b,c'
	Then List
	    | This  |
	    | ""a"" |
	    | b     |
	    | c     |

Scenario: CsvTesting Middle Quoted
	Given String 'a,"b",c'
	Then List
	    | This  |
	    | a     |
	    | ""b"" |
	    | c     |

Scenario: CsvTesting Last Quoted
	Given String 'a,b,"c"'
	Then List
	    | This  |
	    | a     |
	    | b     |
	    | ""c"" |

Scenario: CsvTesting One
	Given String 'a'
	Then List
	    | This |
	    | a    |

Scenario: CsvTesting None
	Given String ''
	Then List
	    | This |

Scenario: CsvTesting Comma
	Given String ','
	Then List
	    | This |
	    |      |
	    |      |

Scenario: CsvTesting Commas
	Given String ','
	Then List
	    | This |
	    |      |
	    |      |

Scenario: CsvTesting Starting Comma
	Given String ',a'
	Then List
	    | This |
	    |      |
	    | a    |

Scenario: CsvTesting Ending Comma
	Given String 'a,'
	Then List
	    | This |
	    | a    |
	    |      |

Scenario: CsvTesting Middle Comma
	Given String 'a,,b'
	Then List
	    | This |
	    | a    |
	    |      |
	    | b    |


Scenario: CsvTesting Spaces
	Given String '" "," "," "'
	Then List
	    | This  |
	    | "" "" |
	    | "" "" |
	    | "" "" |

Scenario: CsvTesting Spaces Ending Comma
	Given String '" "," ",'
	Then List
	    | This  |
	    | "" "" |
	    | "" "" |
	    | ""    |

Scenario: CsvTesting Spaces Ending Comma With Space
	Given String '" "," ", '
	Then List
	    | This  |
	    | "" "" |
	    | "" "" |
	    | ""    |

Scenario: CsvTesting Spaces Beginning Comma
	Given String '," "," "'
	Then List
	    | This  |
	    | ""    |
	    | "" "" |
	    | "" "" |

Scenario: CsvTesting Spaces Beginning Comma With Space
	Given String ' ," "," "'
	Then List
	    | This  |
	    | ""    |
	    | "" "" |
	    | "" "" |
