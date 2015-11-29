Feature: oEmbed Plugin

Scenario Outline: Display embedded Flickr image
	Given On <site> site I have prepared <page> test page with content from <file> file
    When I go to that page
	Then the Flickr image is displayed
Examples: 
    | site    | page           | file                            |
    | SANDBOX | /oembed/flickr | TestCaseData/oEmbed/flickr.html |


Scenario Outline: Display embedded YouTube video
	Given On <site> site I have prepared <page> test page with content from <file> file
    When I go to that page
	Then the YouTube video is displayed
    And The caption is <caption_text>
Examples: 
    | site    | page                       | file                                        | caption_text |
    | SANDBOX | /oembed/youtube            | TestCaseData/oEmbed/youtube.html            |              |
    | SANDBOX | /oembed/youtubeWithCaption | TestCaseData/oEmbed/youtubeWithCaption.html | test caption |


Scenario Outline: Display embedded Twitter status
	Given On <site> site I have prepared <page> test page with content from <file> file
    When I go to that page
	Then the Twitter status is displayed
Examples: 
    | site    | page            | file                             |
    | SANDBOX | /oembed/twitter | TestCaseData/oEmbed/twitter.html |


Scenario Outline: Display embedded Facebook status
	Given On <site> site I have prepared <page> test page with content from <file> file
    When I go to that page
	Then the Facebook status is displayed
Examples: 
    | site    | page             | file                              |
    | SANDBOX | /oembed/facebook | TestCaseData/oEmbed/facebook.html |


Scenario Outline: Display embedded Google map
	Given On <site> site I have prepared <page> test page with content from <file> file
    When I go to that page
	Then the Google map is displayed
Examples: 
    | site    | page               | file                               |
    | SANDBOX | /oembed/googlemap/ | TestCaseData/oEmbed/googlemap.html |