Feature: SpecAid Vs Base Tagless
	In order to have good examples
	I want some feature files

@VersusTableAidStepsTagLess
Scenario: Versus Table Aid Style Tag Less
    Given I have Stores
        | Store Id | Name                        |
        | 42       | Red's Brick and Landscaping |

    Given I have People
        | Emp Id | First Name | Middle Name | Last Name | Years Of Service | Store Id |
        | 1      | Fox        | C           | Smith     | 1                | 42       |

    Then There are People
        | Emp Id | First Name | Middle Name | Last Name | Years Of Service | Store.Name                  |
        | 1      | Fox        | C           | Smith     | 1                | Red's Brick and Landscaping |

