Feature: GoogleAnalytics
	Tests if the GoogleAnalytics page views and events are being tracked

Scenario Outline: Should track following a link as page view
	Given On <site> site I have prepared <page> test page with content from <file> file
    And Cookie consent is enabled and configured for <homepage>
	When I go to that page
    And I mock GoogleAnalytics
    And I set <cookie_level> Cookie Consent level
    And I terminate the click event of <link_id>
    And I click link by <link_id> id
	Then the page view should <not> be tracked as <text>
Examples:
        | site    | homepage                      | page                    | file                                     | link_id  | text                                                              | cookie_level | not |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/download-jpeg       | TestCaseData/ga/download_jpeg.html       | click-me | /downloads/Aegon-logo.jpg                                         | 4            |     |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/download-zip        | TestCaseData/ga/download_zip.html        | click-me | /downloads/dummy.zip                                              | 4            |     |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/external-link       | TestCaseData/ga/external_link.html       | click-me | /outgoing/external resource [http://google.com]                   | 4            |     |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/external-link-title | TestCaseData/ga/external_link_title.html | click-me | /outgoing/external resource, My external link [http://google.com] | 4            |     |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/mailto              | TestCaseData/ga/mailto.html              | click-me | /mailto/test@test.com                                             | 4            |     |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/download-jpeg       | TestCaseData/ga/download_jpeg.html       | click-me | /downloads/Aegon-logo.jpg                                         | 0            | not |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/download-zip        | TestCaseData/ga/download_zip.html        | click-me | /downloads/dummy.zip                                              | 0            | not |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/external-link       | TestCaseData/ga/external_link.html       | click-me | /outgoing/external resource [http://google.com]                   | 0            | not |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/external-link-title | TestCaseData/ga/external_link_title.html | click-me | /outgoing/external resource, My external link [http://google.com] | 0            | not |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/mailto              | TestCaseData/ga/mailto.html              | click-me | /mailto/test@test.com                                             | 0            | not |

Scenario Outline: Should track following a link as event
	Given On <site> site I have prepared <page> test page with content from <file> file
    And Cookie consent is enabled and configured for <homepage>
	When I go to that page
    And I mock GoogleAnalytics
    And I set <cookie_level> Cookie Consent level
    And I terminate the click event of <link_id>
    And I click link by <link_id> id
	Then the event should <not> be tracked as <area> and <action> and <id>
Examples:
        | site    | homepage                      | page                          | file                                           | link_id  | area    | action    | id                                                      | cookie_level | not |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/download-jpeg-event       | TestCaseData/ga/download_jpeg_event.html       | click-me | default | downloads | Aegon-logo.jpg                                          | 4            |     |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/download-zip-event        | TestCaseData/ga/download_zip_event.html        | click-me | default | downloads | dummy.zip                                               | 4            |     |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/external-link-event       | TestCaseData/ga/external_link_event.html       | click-me | default | outgoing  | external resource [http://google.com]                   | 4            |     |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/external-link-event-title | TestCaseData/ga/external_link_event_title.html | click-me | default | outgoing  | external resource, My external link [http://google.com] | 4            |     |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/mailto-event              | TestCaseData/ga/mailto_event.html              | click-me | default | mailto    | test@test.com                                           | 4            |     |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/download-jpeg-event       | TestCaseData/ga/download_jpeg_event.html       | click-me | default | downloads | Aegon-logo.jpg                                          | 0            | not |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/download-zip-event        | TestCaseData/ga/download_zip_event.html        | click-me | default | downloads | dummy.zip                                               | 0            | not |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/external-link-event       | TestCaseData/ga/external_link_event.html       | click-me | default | outgoing  | external resource [http://google.com]                   | 0            | not |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/external-link-event-title | TestCaseData/ga/external_link_event_title.html | click-me | default | outgoing  | external resource, My external link [http://google.com] | 0            | not |
        | SANDBOX | /en/dev-sandbox/BRI-Homepage/ | /ga/mailto-event              | TestCaseData/ga/mailto_event.html              | click-me | default | mailto    | test@test.com                                           | 0            | not |

Scenario Outline: Should track downloading an image from gallery
	Given I am on the <site> site
	When I go to the <page> page
    And I mock GoogleAnalytics
    And I set <cookie_level> Cookie Consent level
    And I click link by <expand_selector> selector
    And I wait <time> milliseconds
    And I terminate the click event of <link_id>
    And I click link by <link_id> id
	Then the event should <not> be tracked as <area> and <action> and <id>
Examples:
        | site  | page                                                              | expand_selector    | link_id                                                                                                                        | time | area         | action        | id                           | cookie_level | not |
        | AEGON | /Home/Investors/News-presentations/Image-Gallery/Executive-Board/ | a.aeg-downloadLink | ctl00_MainContentPlaceHolder_GalleryContainer_ctl00_ImageItemsGrid_RowsRepeater_ctl00_ctl00_ImageGalleryItem_DownloadLargeLink | 1000 | ImageGallery | DownloadImage | Alex Wynaendts\|26099\|Large | 4            |     |
        | AEGON | /Home/Investors/News-presentations/Image-Gallery/Executive-Board/ | a.aeg-downloadLink | ctl00_MainContentPlaceHolder_GalleryContainer_ctl00_ImageItemsGrid_RowsRepeater_ctl00_ctl00_ImageGalleryItem_DownloadSmallLink | 1000 | ImageGallery | DownloadImage | Alex Wynaendts\|26099\|Small | 4            |     |
        | AEGON | /Home/Investors/News-presentations/Image-Gallery/Executive-Board/ | a.aeg-downloadLink | ctl00_MainContentPlaceHolder_GalleryContainer_ctl00_ImageItemsGrid_RowsRepeater_ctl00_ctl00_ImageGalleryItem_DownloadLargeLink | 1000 | ImageGallery | DownloadImage | Alex Wynaendts\|26099\|Large | 0            | not |
        | AEGON | /Home/Investors/News-presentations/Image-Gallery/Executive-Board/ | a.aeg-downloadLink | ctl00_MainContentPlaceHolder_GalleryContainer_ctl00_ImageItemsGrid_RowsRepeater_ctl00_ctl00_ImageGalleryItem_DownloadSmallLink | 1000 | ImageGallery | DownloadImage | Alex Wynaendts\|26099\|Small | 0            | not |


Scenario Outline: Should track searching by URL event
    Given I am on the <site> site
    When I go to the <page> page
    And I mock GoogleAnalytics
    And I set <cookie_level> Cookie Consent level
    Then the event should <not> be tracked as <area> and <action> and <id>
Examples:
    | site  | page                                           | link_id             | area       | action | id             | cookie_level | not |
    | AEGON | /Home/---/Search-Results/?q=searchTermTest&s=0 | aeg-page-search-btn | BRI Search | search | searchTermTest | 4            |     |
    | AEGON | /Home/---/Search-Results/?q=searchTermTest&s=0 | aeg-page-search-btn | BRI Search | search | searchTermTest | 0            | not |

Scenario Outline: Should track searching event
    Given I am on the <site> site
    When I go to the <page> page
    And I mock GoogleAnalytics
    And I set <cookie_level> Cookie Consent level
    And I enter <id> into <search_field_id>
    And I click link by <link_id> id
    Then the event should <not> be tracked as <area> and <action> and <id>
Examples:
    | site  | page                      | search_field_id                            | link_id             | area       | action | id             | cookie_level | not |
    | AEGON | /Home/---/Search-Results/ | ctl00_MainContentPlaceHolder_SearchTextBox | aeg-page-search-btn | BRI Search | search | searchTermTest | 4            |     |
    | AEGON | /Home/---/Search-Results/ | ctl00_MainContentPlaceHolder_SearchTextBox | aeg-page-search-btn | BRI Search | search | searchTermTest | 0            | not |
