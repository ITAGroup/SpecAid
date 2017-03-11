@JackAndJillBptStyleSteps
Feature: Jack And Jill Bpt Style

Scenario: Jack and Jill Go Up the Hill
      Given I have people
          | Tag It   | First Name | Address        |
          | <<Jack>> | Jack       | Bottom of Hill |
          | <<Jill>> | Jill       | Bottom of Hill |

      When '<<Jack>>' goes up the hill
      When '<<Jill>>' goes up the hill

      Then There are people
          | First Name | Address     |
          | Jack       | Top of Hill |
          | Jill       | Top of Hill |