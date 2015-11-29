@legacy
@Ignore
Feature: Maps and office addresses on Aegon PL site

Scenario: Checks for map and address elements 
	Given I am on office overview page of Aegon PL 
	Then I see a google map on the page 
	And I see a list of addresses under the map


Scenario Outline: Find nearest office to a location 
	Given I am on office overview page of Aegon PL
	When I search for offices near to <location>
	Then I see <office name> on the top of the list
	And the distance is <distance> km 

	Examples: 
	| location | office name         | distance |
	| Gilino   | Płock               | 13,44    |
	| Siedlce  | P.U.H. Jerzy Rogala | 70,54    |


Scenario Outline: Change region
	Given I am on office overview page of Aegon PL
	When I set the region to <region>
	Then I see <office name> on the top of the list

	Examples: 
	| region       | office name               |
	| Lubelskie    | Diament-Doradcy Finansowi |
	| Podkarpackie | EKSPERT Krzysztof Musiał  |
