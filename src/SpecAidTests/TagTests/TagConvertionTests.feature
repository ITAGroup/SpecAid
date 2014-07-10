@CommonSteps
@TagConvertionTestSteps
Feature: TagConvertionTests

Scenario: TagConvertionTests - UseHashTag True Hash Changes
	Given Tag '<<Tag>>'
	Given SpecAid Setting UseHashTag is 'true'
	When Tag Is Normalized
	Then Tag is '#Tag'

Scenario: TagConvertionTests - UseHashTag True No Hash Change.
	Given Tag '#Tag'
	Given SpecAid Setting UseHashTag is 'true'
	When Tag Is Normalized
	Then Tag is '#Tag'

Scenario: TagConvertionTests - UseHashTag False No Bracket Change.
	Given Tag '<<Tag>>'
	Given SpecAid Setting UseHashTag is 'false'
	When Tag Is Normalized
	Then Tag is '<<Tag>>'

Scenario: TagConvertionTests - UseHashTag False No Hash Change.
	Given Tag '#Tag'
	Given SpecAid Setting UseHashTag is 'false'
	When Tag Is Normalized
	Then Tag is '#Tag'
