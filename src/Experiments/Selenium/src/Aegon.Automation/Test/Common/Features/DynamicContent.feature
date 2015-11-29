Feature: Dynamic Content Plugins

Scenario Outline: Display Quote plugin
	Given On <site> site I have prepared <page> test page with content from <file> file
    When I go to that page
	Then the quote is displayed

Examples: 
    | site    | page                   | file                                   |
    | SANDBOX | /dynamic_content/quote | TestCaseData/DynamicContent/quote.html |

Scenario Outline: Display Lightbox plugin
	Given On <site> site I have prepared <page> test page with content from <file> file
    When I go to that page
	Then the lightbox link is displayed

Examples: 
    | site    | page                      | file                                      |
    | SANDBOX | /dynamic_content/lightbox | TestCaseData/DynamicContent/lightbox.html |


Scenario Outline: Display Lightbox content popup
	Given On <site> site I have prepared <page> test page with content from <file> file
    When I go to that page
	And click on the dynamic content lightbox link
	Then I should see the dynamic content lightbox popup

Examples: 
    | site    | page                      | file                                      |
    | SANDBOX | /dynamic_content/lightbox | TestCaseData/DynamicContent/lightbox.html |






