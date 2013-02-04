@SpecAidTests
Feature: SpecAid Testings


Background: 
	Given I have BrandNames
	| !BrandName    | Name            | EmployeeCount |
	| <<BenJerrys>> | Ben and Jerry's | 10            |
	| <<Generic>>   | Generic         | 1             |
	| <<Homemade>>  | Homemade        | 0             |

	Given I have IceCreams
	| !IceCream            | Flavor    | BrandName     | 
	| <<BJVanilla>>        | Vanilla   | <<BenJerrys>> |      
	| <<BJChocolate>>      | Chocolate | <<BenJerrys>> |      
	| <<GenericVanilla>>   | Vanilla   | <<Generic>>   |      
	| <<GenericChocolate>> | Chocolate | <<Generic>>   |      

	Given I have Bananas
	| !Banana    | Color  |
	| <<Banana>> | Yellow |

	Given I have Toppings
	| !Topping                  | Name            |
	| <<ToppingNuts>>           | Nuts            |
	| <<ToppingChocolateSyrup>> | Chocolate Syrup |
	| <<ToppingStrawberries>>   | Strawberries    |
	| <<ToppingWhipCreamp>>     | Whip cream      |

	Given I have BananaSplits
	| !BananaSplit     | Banana     | IceCream             | Toppings                                    |
	| <<BananaSplit1>> | <<Banana>> | <<BJVanilla>>        | [<<ToppingNuts>>,<<ToppingChocolateSyrup>>] |
	| <<BananaSplit2>> | <<Banana>> | <<BJChocolate>>      | null                                        |
	| <<BananaSplit3>> | <<Banana>> | <<GenericChocolate>> | null                                        |
	| <<BananaSplit4>> | <<Banana>> | <<GenericVanilla>>   | null                                        |

	Given a ice cream shop has a list of BananaSplits

Scenario: Verify column deep setting works

	# Change Generic Chocolate into Vanilla
	Given I update BananaSplits
	| !BananaSplit     | IceCream.Flavor | IceCream.BrandName |
	| <<BananaSplit3>> | Vanilla         | <<Homemade>>       |

	Then There are 'Vanilla' BananaSplits are available to order
	| Banana.Color | IceCream.Flavor | IceCream.BrandName.Name |
	| Yellow       | Vanilla         | Ben and Jerry's         |
	| Yellow       | Vanilla         | Generic                 |
	| Yellow       | Vanilla         | Homemade                |

Scenario: Verify column deep linking works

	Then There are 'Vanilla' BananaSplits are available to order
	| Banana.Color | IceCream.Flavor | IceCream.BrandName.Name |
	| Yellow       | Vanilla         | Ben and Jerry's         |
	| Yellow       | Vanilla         | Generic                 |

Scenario: Verify field deep linking works
	Then There are 'Vanilla' BananaSplits are available to order
	| Banana.Color                  | IceCream.Flavor                  | IceCream.BrandName.Name                  |
	| <<BananaSplit1>>.Banana.Color | <<BananaSplit1>>.IceCream.Flavor | <<BananaSplit1>>.IceCream.BrandName.Name |
	| <<BananaSplit4>>.Banana.Color | <<BananaSplit4>>.IceCream.Flavor | <<BananaSplit4>>.IceCream.BrandName.Name |

Scenario: Verify Column Error

	# The Right Record
	Then There are 'Vanilla' BananaSplits are available to order WILL ASSERT 'Non-Match on Row E2'
	| Banana.Color | IceCream.Flavor | IceCream.BrandName.Name |
	| Yellow       | Vanilla         | Ben and Jerry's         |
	| Yellow       | Vanilla2        | Generic                 |

	# The Right Data
	Then There are 'Vanilla' BananaSplits are available to order WILL ASSERT 'Expected 'Vanilla2', Actual 'Vanilla''
	| Banana.Color | IceCream.Flavor | IceCream.BrandName.Name |
	| Yellow       | Vanilla         | Ben and Jerry's         |
	| Yellow       | Vanilla2        | Generic                 |

	# The Right Property
	Then There are 'Vanilla' BananaSplits are available to order WILL ASSERT 'Flavor'
	| Banana.Color | IceCream.Flavor | IceCream.BrandName.Name |
	| Yellow       | Vanilla         | Ben and Jerry's         |
	| Yellow       | Vanilla2        | Generic                 |

Scenario: Verify Missing Row
	# The Right Record
	Then There are 'Vanilla' BananaSplits are available to order WILL ASSERT 'Not Enough Table Rows'
	| Banana.Color | IceCream.Flavor | IceCream.BrandName.Name |
	| Yellow       | Vanilla         | Ben and Jerry's         |

Scenario: Verify Missing Data
	# The Right Record
	Then There are 'Waffles' BananaSplits are available to order WILL ASSERT 'Not Enough Data'
	| Banana.Color | IceCream.Flavor | IceCream.BrandName.Name |
	| Yellow       | Vanilla         | Ben and Jerry's         |

Scenario: Verify Missing Deap Link Null

	Given All the IceCeam goes bad

	Then There are BananaSplits are available to order WILL ASSERT 'Property is null'
	| Banana.Color                  | IceCream.Flavor                  | IceCream.BrandName.Name                  |
	| <<BananaSplit1>>.Banana.Color | <<BananaSplit1>>.IceCream.Flavor | <<BananaSplit1>>.IceCream.BrandName.Name |
	| <<BananaSplit2>>.Banana.Color | <<BananaSplit2>>.IceCream.Flavor | <<BananaSplit2>>.IceCream.BrandName.Name |
	| <<BananaSplit3>>.Banana.Color | <<BananaSplit3>>.IceCream.Flavor | <<BananaSplit3>>.IceCream.BrandName.Name |
	| <<BananaSplit4>>.Banana.Color | <<BananaSplit4>>.IceCream.Flavor | <<BananaSplit4>>.IceCream.BrandName.Name |

Scenario: Verify listing works

	Then There are 'Vanilla' BananaSplits are available to order
	| Banana.Color | IceCream.Flavor | IceCream.BrandName.Name | Toppings                                    |
	| Yellow       | Vanilla         | Ben and Jerry's         | [<<ToppingNuts>>,<<ToppingChocolateSyrup>>] |
	| Yellow       | Vanilla         | Generic                 | null                                        |

Scenario: Verify ignore works

	Then There are 'Vanilla' BananaSplits are available to order
	| Banana.Color | IceCream.Flavor | IceCream.BrandName.Name | Toppings |
	| Yellow       | Vanilla         | [ignore]                | [ignore] |
	| Yellow       | Vanilla         | Generic                 | null     |

Scenario: Basic Lists

	Then There are Topping Choices '[Nuts,Chocolate Syrup,Strawberries,Whip cream]'

Scenario: Sick Lists

	Then There are Topping Choices '[<<ToppingNuts>>.Name,Chocolate Syrup,Strawberries,Whip cream]'

Scenario: Verify nested interfaces work

	Then There is Interfaced IceCream Available 
	| Name            | EmployeeCount |
	| Ben and Jerry's | 10            |
	| Generic         | 1             |
	| Homemade        | 0             |
