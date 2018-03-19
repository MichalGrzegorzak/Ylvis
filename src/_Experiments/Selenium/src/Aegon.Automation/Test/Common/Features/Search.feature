@legacy
@Ignore
Feature: Search Test on all Aegon Sites 

Scenario Outline: Search Result page checks foa all sites
	Given I am on Homepage of Aegon <site>
	And I search in top navigation the text Aegon
	Then I am directed to search result page with <title>
	And I see pagination on the search result page 
	And I see Result per page is set to 5 
	And I see link Next for pagination
	And I see only 5 results per page 

	Examples: 
	| site     | title                                                   |
	| Aegon PL | Wyniki wyszukiwania - Aegon Polska                      |
	| Aegon CZ | Výsledky vyhledávání - Vítejte na Aegon Česká republika |
	| Aegon    | Search results - Aegon Group                            |

Scenario Outline: Change results per page for all sites
	Given I am on Homepage of Aegon <site>
	And I search in top navigation the text Aegon 
	And I set Results per page to 10 
	Then I see only 10 results per page 
	Examples: 
	| site     |
	| Aegon PL |
	| Aegon CZ |
	| Aegon    |

Scenario Outline: Search on Search Result page for all sites
	Given I am on Search Result page of Aegon <site>
	And I search the text Aegon
	Then I should see search results for Aegon
	
	Examples: 
	| site     |
	| Aegon PL |
	| Aegon CZ |
	| Aegon    |

Scenario Outline: Seach from any page for all sites
	Given I am on Contact Us page of Aegon <site> 
	And I search in top navigation the text <keyword>
	Then I should see search results for <keyword>
	
	Examples: 
	| site     | keyword |
	| Aegon PL | Aegon   |
	| Aegon CZ | Aegon   |
	| Aegon    | Aegon   |



	