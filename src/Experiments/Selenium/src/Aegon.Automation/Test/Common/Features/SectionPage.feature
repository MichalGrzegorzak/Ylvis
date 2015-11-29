@legacy
@Ignore
Feature: Section Page 
	
Scenario Outline: Various checks on Section page
	Given I am on Section page of Aegon <site>
	Then I see the page title <title>
	And I see the first teaser panel with text <first teaser text>
	And I see the second teaser panel with text <second teaser text>
	And I see the third teaesr panel with text <third teaser text>
	And I see the fourth teaser panel with text <fourth teaser text>

	Examples: 
	| site     | title      | first teaser text     | second teaser text  | third teaser text  | fourth teaser text    |
	| Aegon    | About      | Transamerica          | Markets             | Sponsoring         | Aegon on Social Media |
	| Aegon PL | Inwestycje | Programy inwestycyjne | Dla Klientów banków | Notowania funduszy | Poradnik inwestycyjny |

