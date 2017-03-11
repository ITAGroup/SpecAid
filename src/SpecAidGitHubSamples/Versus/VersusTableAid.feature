Feature: SpecAid Vs Base
	In order to have good examples
	I want some feature files


@VersusTableAidSteps
Scenario: Versus Table Aid Style
    Given I have Stores
        | Tag It        | StoreId | Name                        | 
        | <<RedsBrick>> | 42      | Red's Brick and Landscaping |

    Given I have People
        | Emp Id | First Name | Middle Name | Last Name | Years Of Service | Store         |
        | 1      | Fox        | C           | Smith     | 1                | <<RedsBrick>> |

    Then There are People
        | Emp Id | First Name | Middle Name | Last Name | Years Of Service | Store.Name                  |
        | 1      | Fox        | C           | Smith     | 1                | Red's Brick and Landscaping |

