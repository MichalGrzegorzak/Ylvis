@legacy
@Ignore
Feature: Quarterly Results Test
	When a user is on Quarterly Results page
	Then he  see youtube video for the last quarter
	And he  see Press Release, Presentation, Supplements, etc 

Background: 
	Given I am on Quarterly results page

Scenario: Check page elements - Checks for Page title, Youtube video, LHS navigation, RHS column, English press release html link and pdf link
	Then the page title is Quarterly Results - Aegon Group
	And I see youtube video on the page 
	And I see LHS navigation 
	And I see RHS Column
	And I see English Press releases html link
	And I see English Press releases pdf link

Scenario: Checks on All quarterly results
	When I click All quarterly results
	Then I see the All quarterly results table 
	Then I see current year and four quarterly columns 