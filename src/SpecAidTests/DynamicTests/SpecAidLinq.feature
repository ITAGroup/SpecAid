@SpecAidTests
Feature: SpecAid Linq Testings

Scenario: Linq Math
    Then Do Expression for Int '{5 + 5}' = '10'

Scenario: Linq Recall Test
    Given Tag This '15' as '<<fifteen>>'

    Then Do Expression for Int '{(Recall["<<fifteen>>"])}' = '15'

Scenario: Linq Recall Add Test
    Given Tag This '15' as '<<fifteen>>' As Int

    Then Do Expression for Int '{Int32(Recall["<<fifteen>>"]) + 5}' = '20'

Scenario: Linq Recall Convert Test
    Given Tag This '15' as '<<fifteen>>'

    Then Do Expression for Int '{Convert.ToInt32(Recall["<<fifteen>>"]) + 5}' = '20'

Scenario: Linq With Old Tag Replace
    Given Tag This '15' as '<<fifteen>>'

    Then Do Expression for Int '{{<<fifteen>>} + 5}' = '20'

Scenario: Linq With New Tag Replace
    Given Tag This '15' as '#fifteen'

    Then Do Expression for Int '{{#fifteen} + 5}' = '20'

Scenario: Linq dont break on a bad lookup
    Then Do Expression for String '{"{#unbroken}" + "5"}' = '{#unbroken}5'

Scenario: Linq Recall Aid Test
    Given Tag This 'Ben' as '<<firstName>>'
    Given Tag This 'Jerry' as '<<lastName>>'
    Given Tag This 'Food' as '#Food'
    Given Tag This 'Truck' as '#Truck'

    Given I have BrandNames
        | !BrandName    | Name            | EmployeeCount |
        | <<BenJerrys>> | Ben and Jerry's | 10            |
        | <<Generic>>   | Generic         | 1             |
        | <<Homemade>>  | Homemade        | 0             |
        | <<FoodTruck>> | FoodTruck       | 3             |

    Then BrandNames Tests
        | Name            | EmployeeCount |
        | Ben and Jerry's | 10            |
        | Generic         | 1             |
        | Homemade        | 0             |
        | FoodTruck       | 3             |
    
    Then BrandNames Tests
        | Name                                                                      | EmployeeCount                            |
        | {StringAid["<<firstName>>"] + " and " + StringAid["<<lastName>>"] + "'s"} | {5 + 5}                                  |
        | Generic                                                                   | {StringAid["<<Generic>>.EmployeeCount"]} |
        | {"{<<Homemade>>.Name}"}                                                   | 0                                        |
        | {"{#Food}{#Truck}"}                                                       | 3                                        |


     
