Feature: SpecAid Vs Assist
	In order to have good examples
	I want some feature files

@VersusAssistSteps
Scenario: Versus Assist Style

    Given I have Stores
        | Store Id | Name                        |
        | 42       | Red's Brick and Landscaping |

    Given I have People
        | Emp Id | First Name | Middle Name | Last Name | Years Of Service | Store Id |
        | 1      | Fox        | C           | Smith     | 1                | 42       |

    # Assist can't do deep anything.
    Then There are People
        | Emp Id | First Name | Middle Name | Last Name | Years Of Service | 
        | 1      | Fox        | C           | Smith     | 1                | 

