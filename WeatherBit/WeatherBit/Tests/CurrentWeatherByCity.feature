Feature: CurrentWeatherByCity


@mytag
Scenario Outline: Get current weather by city postcode.
	Given Endpoint "/current" and method Get 
	Given The query parameter with below details added
	| Postal_Code   |
	| <Postal_Code> |
	When The request is executed
	Then The response code should be "200"
	Then The current weather data result should should contain the below values
	| City_Name | Country_code |
	| <City>    | <Country>    |

Examples: 
	| Id | Postal_Code | City                 | Country |
	| 1  | 110012      | Central Delhi        | IN      |
	| 2  | WC2N 5DU    | Greater London       | GB      |
	| 3  | 20001       | District of Columbia | US      |

