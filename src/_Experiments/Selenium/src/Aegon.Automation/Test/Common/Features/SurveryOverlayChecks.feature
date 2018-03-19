@ignore
Feature: Survery Overlay Checks
	User should see survey overlay after set period of time on the site 
	TODO: test survey badge, test 'next time' option, test if cookies are saved, test captions, etc (need to take data for automation helper webservice), ability to enable/disable survey, test boc position, test if in reposnive moed survey is hidden

Scenario Outline: Overlay should appear after 60 seconds 
	Given I am on the <site> site
	When I go to the <page> page
	Then I see survey overlay after 15 seconds
	And I see survery title 
	And I see Yes, please button
	And I see No, thanks button
	
  Examples:
    | site  | page         |
    | AEGON | /Home/       |
    | AEGON | /Home/About/ |


Scenario Outline:  Survery overlay should disappears on clicking No, thanks button
	Given I am on the <site> site
	When I go to the <page> page
	Then I see survey overlay after 15 seconds
	And I see No, thanks button
	When I click No, thanks on survey overlay 
	Then the survery overlay disappears 

  Examples:
    | site  | page         |
    | AEGON | /Home/       |
    | AEGON | /Home/About/ |
