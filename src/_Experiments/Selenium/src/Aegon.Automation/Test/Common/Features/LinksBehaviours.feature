@ignore

Feature: LinksBehaviours
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Scenario Outline: External links should have <span class='screenreder'>.. inside
	Given I am on the <site> site
	When I go to the <page> page
	Then External Links Are Mareked



Examples:
    | site    | page               |
    | AEGONPL | /pl/Strona-glowna/ |