@legacy
@Ignore
Feature: Bri Landing Page

Scenario Outline: BRI Landing page elements check
	Given I am on Landing page on Aegon <site>
	Then I see a hero image teaser on the top
	And I see first Image block with title <first image teaser title>
	And I see second Image block with title <second image teaser title>
	And I see thrid Image block with title <third image teaser title> 
	And I see fourth Image block with title <fourth image teaser title>  
	
	Examples: 
	| site     | first image teaser title | second image teaser title | third image teaser title | fourth image teaser title |
	| Aegon Ro | Aegon Privilege          | Aegon Fii Sigur           | Aegon Fii Istet          | Aegon La nevoie           |
