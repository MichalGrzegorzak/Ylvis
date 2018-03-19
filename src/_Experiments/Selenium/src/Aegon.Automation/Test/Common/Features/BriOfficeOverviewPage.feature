Feature: Bri OfficeOverview Page Checks

Scenario Outline: I should be able to see offices map
  Given I am on the <site> site
  When I go to the <page> page
  Then I should see a google map on the page
  And I should see a list of offices

  Examples:
    | site  | page                    |
    | AEGON | /en/Home/About/Contact/ |

Scenario Outline: I should be able to find nearest offices
  Given I am on the <site> site
  When I go to the <page> page
  And I try to find the nearest office to <city>
  Then I should see an ordered by distance office list
  And It should be found max <maxOffices> offices

  Examples:
    | site  | page                    | city  | maxOffices |
    | AEGON | /en/Home/About/Contact/ | Hague | 10         |

Scenario Outline: I should be able to see route from my location to desired office
  Given I am on the <site> site
  When I go to the <page> page
  And I try to find the nearest office to <originCity>
  And I click the show route to <destinationOffice>
  Then I should see a popup with a route
  When I click the close route popup button
  Then The route overlay should be hidden

  Examples:
    | site  | page                    | originCity | destinationOffice      |
    | AEGON | /en/Home/About/Contact/ | Hague      | Aegon Asset Management |
