@CsvTests
Feature: CsvBuildTesting

Scenario: CsvTesting Basic
	Given String For Csv 'a'
	Then Safe Csv String 'a'

Scenario: CsvTesting With Quotes
	Given String For Csv '"a"'
	Then Safe Csv String '"""a"""'

Scenario: CsvTesting With Comma
	Given String For Csv ','
	Then Safe Csv String '","'

Scenario: CsvTesting Single Quote
	Given String For Csv '"'
	Then Safe Csv String '""""'

Scenario: CsvTesting Quote Comma Mix
	Given String For Csv ',",'
	Then Safe Csv String '","","'
