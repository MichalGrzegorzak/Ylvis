@legacy
@Ignore
Feature: Cookie Widget Checks
	Cookie widget should be displayed on fist visit 


Scenario Outline: User should see a cookie widget 
	Given I am on Homepage of Aegon <site>
	Then I see cookie widget with <title>
	And I see I agree button 

	Examples: 
	| site     | title                  |
	| Aegon    | A note to our visitors |
	| Aegon PL | Uwaga!                 |
	
Scenario Outline: The cookie widget should disappear on clicking I agree
	Given I am on Homepage of Aegon <site>
	And I see cookie widget
	When I click I agree button 
	Then the cookie widget disappears 

	Examples: 
	| site     |
	| Aegon    |
	| Aegon PL |
