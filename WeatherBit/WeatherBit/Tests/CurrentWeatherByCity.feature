Feature: CurrentWeatherByCity


@mytag
Scenario Outline: Get current weather by city postcode.
	Given Endpoint "/current" and method Get 
	Given The query parameter with below details added
	| City   | Country   |
	| <City> | <Country> |
	When The request is executed
	Then The response code should be "200"
	Then The current weather data result should should contain the below values
	| City_Name | Country_code |
	| <City>    | <Country>    |

Examples: 
	| Id | City   | Country |
	| 1  | London | GB      |
	| 2  | Sydney | AU      |

