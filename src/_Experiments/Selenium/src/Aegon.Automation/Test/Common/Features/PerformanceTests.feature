@ignore
@performance
Feature: PerformanceTests
	Monitoring site perfoemance using firefox net panel (net export tool), and yslow/page speed tools (ff extensions, with beacon option - saving result to remote url - harlog.exe as a tool that act remote server)


Scenario Outline: Save net panel results
	Given I am on the <site> site
	When I go to the <page> page	
	Then net panel results are saved

Examples: 
	| site    | page                               |
	| AEGON   | /Home                              |
	| AEGON   | /en/Home/About/                    |
	| AEGON   | /en/Home/Products/                 |
	| AEGON   | /en/Home/About/At-a-glance/        |
	| AEGON   | /en/Home/About/Contact-Us/         |
	| AEGON   | /en/Home/Careers/Job-Seekers-FAQs/ |


	Scenario Outline: Save yslow results
	Given I am on the <site> site
	When I go to the <page> page		
	Then YSlow results are saved

Examples: 
	| site    | page                               |
	| AEGON   | /Home                              |
	| AEGON   | /en/Home/About/                    |
	| AEGON   | /en/Home/Products/                 |
	| AEGON   | /en/Home/About/At-a-glance/        |
	| AEGON   | /en/Home/About/Contact-Us/         |
	| AEGON   | /en/Home/Careers/Job-Seekers-FAQs/ |