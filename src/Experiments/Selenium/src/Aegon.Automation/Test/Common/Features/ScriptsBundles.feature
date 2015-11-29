@longrunning
Feature: Scripts Bundles
	All CSS and Java Scirpt content should be compressed and packed together into bundles.
	Inline js and css should be avoided, if nescessary should be documented. 

Scenario Outline: I should not see any js errors on page	
	Given I am on the <site> site
    And I turned <checkErrorPage> ErrorPage checking
	When I go to the <page> page
	Then there are no js errors

	Examples: 
	| site  | page                               | checkErrorPage |
	| AEGON | /Home                              | on             |
	| AEGON | /en/Home/About/                    | on             |
	| AEGON | /en/Home/About/asdasdas            | off            |
	| AEGON | /en/Home/Products/                 | on             |
	| AEGON | /en/Home/About/At-a-glance/        | on             |
	| AEGON | /en/Home/About/Contact/            | on             |
	| AEGON | /en/Home/Careers/Job-Seekers-FAQs/ | on             |

Scenario Outline: Print css file should be separate and compressed	
	When I go to the <page> page
	Then there are print.css file included
	And print.css file is compressed
	And print.css file doesn't contain any comments

	Examples: 
	| site  | page                               |
	| LOCAL | /Home                              |
	| LOCAL | /en/Home/About/                    |
	| LOCAL | /en/Home/Products/                 |
	| LOCAL | /en/Home/About/At-a-glance/        |
	| LOCAL | /en/Home/About/Contact/            |
	| LOCAL | /en/Home/Careers/Job-Seekers-FAQs/ |

