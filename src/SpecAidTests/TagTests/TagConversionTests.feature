@CommonSteps
@TagConversionTestSteps
Feature: TagConversionTests

Scenario: TagConversionTests - UseHashTag True Hash Changes
	Given Tag '<<Tag>>'
	Given SpecAid Setting UseHashTag is 'true'
	When Tag Is Normalized
	Then Tag is '#Tag'

Scenario: TagConversionTests - UseHashTag True No Hash Change.
	Given Tag '#Tag'
	Given SpecAid Setting UseHashTag is 'true'
	When Tag Is Normalized
	Then Tag is '#Tag'

Scenario: TagConversionTests - UseHashTag False No Bracket Change.
	Given Tag '<<Tag>>'
	Given SpecAid Setting UseHashTag is 'false'
	When Tag Is Normalized
	Then Tag is '<<Tag>>'

Scenario: TagConversionTests - UseHashTag False No Hash Change.
	Given Tag '#Tag'
	Given SpecAid Setting UseHashTag is 'false'
	When Tag Is Normalized
	Then Tag is '#Tag'
