
Feature: Bri Overview Page checks

################ Sections ##############################
Scenario Outline: I should be able to see all sections
    Given On <site> site I have prepared <page> overview test page with dummy data source
    When I go to that page
    Then I should see sections like <sections>

Examples:
    | site    | page       | sections                                                                                             |
    | SANDBOX | /Overview/ | Image Gallery,Presentations,Press Releases,News,Web and Podcasts,Overview & Fast Facts,Events,Videos |


Scenario Outline: I should be able to see selected section
	Given On <site> site I have prepared <page> overview test page with dummy data source
    When I go to that page
    And I click link by <link_id> id
    Then  I should see sections like <sections>

Examples:
    | site    | page       | link_id                                                                                                         | sections      |
    | SANDBOX | /Overview/ | ctl00_ctl00_MainContentPlaceHolder_MiddleColumnContent_ItemsContainer_SectionsRepeater_ctl00_ctl00_ShowMoreLink | Image Gallery |
    | SANDBOX | /Overview/ | ctl00_ctl00_MainContentPlaceHolder_MiddleColumnContent_ItemsContainer_SectionsRepeater_ctl02_ctl00_ShowMoreLink | News          |
   

################ Pager ##############################
Scenario Outline: I should not be able to see pagers
	Given On <site> site I have prepared <page> overview test page with dummy data source
    When I go to that page
    Then I should see <number_of_pagers> pagers

Examples:
    | site    | page       | number_of_pagers |
    | SANDBOX | /Overview/ | 0                |


Scenario Outline: I should be able to see pagers
	Given On <site> site I have prepared <page> overview test page with dummy data source
    When I go to that page
    And I click link by <link_id> id 
    Then I should see <number_of_pagers> pagers

Examples:
    | site    | page       | link_id                                                                                                         | number_of_pagers |
    | SANDBOX | /Overview/ | ctl00_ctl00_MainContentPlaceHolder_MiddleColumnContent_ItemsContainer_SectionsRepeater_ctl00_ctl00_ShowMoreLink | 2                |
    | SANDBOX | /Overview/ | ctl00_ctl00_MainContentPlaceHolder_MiddleColumnContent_ItemsContainer_SectionsRepeater_ctl02_ctl00_ShowMoreLink | 2                |


Scenario Outline: I should be able to see pagers and click through them
	Given On <site> site I have prepared <page> overview test page with dummy data source
    When I go to that page
    And I close cookie prompt
    And I select section filter <filter>
    And I click link by <link_id> id
    Then Page number <page_number> should be selected

Examples:
    | site    | page       | filter        | link_id                                                                                                                                                               | page_number |
    | SANDBOX | /Overview/ | Image Gallery | ctl00_ctl00_MainContentPlaceHolder_MiddleColumnContent_ItemsContainer_SectionsRepeater_ctl00_ctl00_TopPaging_DesktopPaging_PageButtonRepeater_ctl01_PageLinkButton    | 2           |
    | SANDBOX | /Overview/ | Image Gallery | ctl00_ctl00_MainContentPlaceHolder_MiddleColumnContent_ItemsContainer_SectionsRepeater_ctl00_ctl00_TopPaging_DesktopPaging_NextLinkButton                             | 2           |
    | SANDBOX | /Overview/ | Image Gallery | ctl00_ctl00_MainContentPlaceHolder_MiddleColumnContent_ItemsContainer_SectionsRepeater_ctl00_ctl00_BottomPaging_DesktopPaging_PageButtonRepeater_ctl01_PageLinkButton | 2           |
    | SANDBOX | /Overview/ | Image Gallery | ctl00_ctl00_MainContentPlaceHolder_MiddleColumnContent_ItemsContainer_SectionsRepeater_ctl00_ctl00_BottomPaging_DesktopPaging_NextLinkButton                          | 2           |


Scenario Outline: I should not be able to see pages when I slelect all in pager
	Given On <site> site I have prepared <page> overview test page with dummy data source
    When I go to that page
    And I select section filter <filter>
    And I select page size <page_size>
    Then I should see no pages

Examples:
    | site    | page       | filter        | page_size |
    | SANDBOX | /Overview/ | Image Gallery | All       |


################ Sections Content ##############################
Scenario Outline: I should be able to see sections items
	Given On <site> site I have prepared <page> overview test page with dummy data source
    When I go to that page
    And I select section filter <filter>
    Then I should see items in sections like <sections>

Examples:
    | site    | page       | filter         | sections                                                                                             |
    | SANDBOX | /Overview/ | All sections   | Image Gallery,Presentations,Press Releases,News,Web and Podcasts,Overview & Fast Facts,Events,Videos |
    | SANDBOX | /Overview/ | Image Gallery  | Image Gallery                                                                                        |
    | SANDBOX | /Overview/ | Press Releases | Press Releases                                                                                       |


Scenario Outline: I should be able to see sections items with specific css classes inside
	Given On <site> site I have prepared <page> overview test page with dummy data source
    When I go to that page
    And I select section filter <sections>
    Then I should see sections <sections> containing html elements inside with specific css class like <css_classes>

Examples:
    | site    | page       | sections       | css_classes                                                       |
    | SANDBOX | /Overview/ | News           | item-additional-header-info,item-header,item-details              |
    | SANDBOX | /Overview/ | Press Releases | item-additional-header-info,item-header,item-details              |
    | SANDBOX | /Overview/ | Presentations  | item-additional-header-info,item-header,item-details,item-actions |
    | SANDBOX | /Overview/ | Events         | item-additional-header-info,item-header                           |
###Images should always have item-actions (download image) in the feature###
#    | SANDBOX | /Overview/        | Image Gallery  | item-header,item-details,item-actions                             |
    

################ Filters ##############################
Scenario Outline: I should be able select a filter
	Given On <site> site I have prepared <page> overview test page with dummy data source
    When I go to that page
    And I select section filter <filter>
    Then I should see items in sections like <sections>

Examples:
    | site    | page       | filter         | sections       |
    | SANDBOX | /Overview/ | Image Gallery  | Image Gallery  |
    | SANDBOX | /Overview/ | Press Releases | Press Releases |


Scenario Outline: I should be able see first level filters
	Given On <site> site I have prepared <page> overview test page with dummy data source
    When I go to that page
    And I select section filter <sections>
    Then I should see all first level <filters>

Examples:
    | site    | page       | sections     | filters                                                      |
    | SANDBOX | /Overview/ | All sections | All sections,Image Gallery,Press Releases,News,Presentations |
    | SANDBOX | /Overview/ | News         | All sections,Image Gallery,Press Releases,News,Presentations |


################ Embedded Slideshare and Video ##############################
Scenario Outline: I should be able to open oembed overlay
	Given On <site> site I have prepared <page> overview test page with dummy data source
    When I go to that page
    And I select section filter <sections>
    Then I should see items in sections like <sections>
    When I click link by <linkId> id
    Then I should see an overlay titled <overlayTitle>
	When I click link by <titleLinkId> id
	Then I should see an overlay titled <overlayTitle>
Examples:
         | site    | page       | sections | linkId                                                                                                                                        | titleLinkId                                                                                                                            | overlayTitle                          |
         | SANDBOX | /Overview/ | Videos   | ctl00_ctl00_MainContentPlaceHolder_MiddleColumnContent_ItemsContainer_SectionsRepeater_ctl00_ctl00_ItemsRepeater_ctl00_ctl00_ClickthroughLink | ctl00_ctl00_MainContentPlaceHolder_MiddleColumnContent_ItemsContainer_SectionsRepeater_ctl00_ctl00_ItemsRepeater_ctl00_ctl00_TitleLink | Retiready - John McEnroe              |
         | SANDBOX | /Overview/ | Videos   | ctl00_ctl00_MainContentPlaceHolder_MiddleColumnContent_ItemsContainer_SectionsRepeater_ctl00_ctl00_ItemsRepeater_ctl01_ctl00_ClickthroughLink | ctl00_ctl00_MainContentPlaceHolder_MiddleColumnContent_ItemsContainer_SectionsRepeater_ctl00_ctl00_ItemsRepeater_ctl01_ctl00_TitleLink | Introduction to Aegon - December 2014 |

