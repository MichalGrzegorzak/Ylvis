Feature: Glossary Page Checks
	
Scenario Outline: Checks for Glossary items
	Given I am on the <site> site
	When I go to the <page> page
	And I click the link <link-text>
	Then I should see the description <description-text>

	Examples: 
	| site  | page                 | link-text           | description-text                                                                                                                  |
	| AEGON | Home/About/Glossary/ | ACCRUAL RATE        | The rate at which pension benefits builds up as member service is completed in a defined benefit plan.                            |
	| AEGON | Home/About/Glossary/ | FINAL SALARY SCHEME | A type of defined benefit plan, whereby the pension benefit is typically based on the last few years’ earnings before retirement. |
	| AEGON | Home/About/Glossary/ | SAVING DEPOSITS     | These are interest paying accounts.                                                                                               |
