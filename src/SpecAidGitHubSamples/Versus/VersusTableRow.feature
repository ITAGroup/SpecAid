
Feature: SpecAid Vs Table Row
	In order to have good examples
	I want some feature files

@VersusTableRowSteps
Scenario: Versus Table Row Style

    Given I have Stores
        | Store Id | Name                        |
        | 42       | Red's Brick and Landscaping |

    Given I have People
        | Emp Id | First Name | Middle Name | Last Name | Years Of Service | Store Id |
        | 1      | Fox        | C           | Smith     | 1                | 42       |

    Then There are People
        | Emp Id | First Name | Middle Name | Last Name | Years Of Service | Store.Name                  |
        | 1      | Fox        | C           | Smith     | 1                | Red's Brick and Landscaping |

