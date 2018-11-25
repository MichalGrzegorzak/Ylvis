Feature: SiteMap And Footer

Scenario Outline: Sitemap check
	Given I am on the <site> site
	When I click Sitemap
	Then I see sitemap section under footer
	Examples: 
	| site  |
	| AEGON |

Scenario Outline: Footer Dropdown
	Given I am on the <site> site
	When I click Other Aegon Websites
	Then I see Other Aegon Websites list
	Examples: 
	| site  |
	| AEGON |
