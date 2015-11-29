Feature: Accessibility tests

Scenario Outline: Navigation using tab key should not get stuck
  Given I am on the <site> site
  When I go to the <page> page
  Then After max <maxTabs> tabbing I should go to the first footer link

  Examples:
    | site  | page         | maxTabs |
    | AEGON | /Home/       | 200     |
    | AEGON | /Home/About/ | 200     |
