Feature: Editing CMS page
    Intended to perform load tests with it, thus no assertions
	
Scenario Outline: Edit Content page
	# Given I am a unique instance
    Given On <site> site I have prepared <page> test page with content from <file> file
    When I open this page in Edit mode
    And I enter <text> into <input>
    And I save and publish the page
    Then Nevermind
Examples: 
    | site    | page                | file                            | input                                                       | text        |
    | SANDBOX | /cms-editing/simple | TestCaseData/oEmbed/flickr.html | ctl00_FullRegion_PC_38_1_EditForm_Introduction_Introduction | Sample Text |

