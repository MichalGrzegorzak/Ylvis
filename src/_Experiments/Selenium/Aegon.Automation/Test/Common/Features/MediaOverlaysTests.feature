Feature: Media overlays tests

Scenario Outline: Media overlays on the overview page should have exact width
	Given On <site> site I have prepared <page> overview test page with dummy data source
    Given On the <site> homepage I set the value of <property> to <propertyValue>
    When I go to that page
    And I select section filter <sections>
    And I click link by <linkId> id
    Then I should see an overlay titled <overlayTitle>
    And width of the overlay should be <propertyValue>px
Examples:
         | site    | property                  | propertyValue | page | sections | linkId | overlayTitle |
         | SANDBOX | EmbeddedMediaOverlayWidth | 300           | /Overview/ | Videos   | ctl00_ctl00_MainContentPlaceHolder_MiddleColumnContent_ItemsContainer_SectionsRepeater_ctl00_ctl00_ItemsRepeater_ctl00_ctl00_ClickthroughLink | Retiready - John McEnroe              |
         | SANDBOX | EmbeddedMediaOverlayWidth | 300           | /Overview/ | Videos   | ctl00_ctl00_MainContentPlaceHolder_MiddleColumnContent_ItemsContainer_SectionsRepeater_ctl00_ctl00_ItemsRepeater_ctl01_ctl00_ClickthroughLink | Introduction to Aegon - December 2014 |
         | SANDBOX | EmbeddedMediaOverlayWidth | 600           | /Overview/ | Videos   | ctl00_ctl00_MainContentPlaceHolder_MiddleColumnContent_ItemsContainer_SectionsRepeater_ctl00_ctl00_ItemsRepeater_ctl00_ctl00_ClickthroughLink | Retiready - John McEnroe              |
         | SANDBOX | EmbeddedMediaOverlayWidth | 600           | /Overview/ | Videos   | ctl00_ctl00_MainContentPlaceHolder_MiddleColumnContent_ItemsContainer_SectionsRepeater_ctl00_ctl00_ItemsRepeater_ctl01_ctl00_ClickthroughLink | Introduction to Aegon - December 2014 |
