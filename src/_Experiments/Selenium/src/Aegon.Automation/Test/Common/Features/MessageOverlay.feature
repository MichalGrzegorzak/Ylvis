@legacy
@Ignore
Feature: Message Overlay
	
Scenario Outline: Message overlay appears after set time
	Given I am on BRI Homepage of Aegon <site>
	Then the message overlay appears after <time> seconds
	And the text on the overlay should be <text>


	Examples: 
	| site     | time | text                                                                          |
	| Aegon Ro | 2    | Deoarece promovam transparenta in relatia cu clientii si colaboratorii nostri |