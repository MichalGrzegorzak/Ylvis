Feature: Custom Error Page Checks For All Sites	

Scenario Outline: Custom Error Page Checks For All Sites
	Given I am on the <site> site
	And I turned <checkErrorPage> ErrorPage checking
	When I go to the <page> page
	Then I am directed to custom error page with title <text>

	Examples: 
	| site    | checkErrorPage | page         | text                   |
	| AEGON   | off            | /nosuchpage/ | Page not found         |
	| AEGONPL | off            | /nosuchpage/ | Nie odnaleziono strony |
	| AEGONCZ | off            | /nosuchpage/ | Stránka nenalezena     |
