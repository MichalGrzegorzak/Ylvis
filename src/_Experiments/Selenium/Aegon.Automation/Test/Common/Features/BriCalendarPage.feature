Feature: Bri Calendar Page Checks

Scenario Outline: I should be able to see localized timezone drop down list
  Given I am on the <site> site
  When I go to the <page> page
  Then I should see localized timezone <timezoneid> label <timezonename>

  Examples:
    | site  | page                         | timezoneid              | timezonename                                                 |
    | AEGON | /en/Home/Investors/Calendar/ | W. Europe Standard Time | (UTC+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna |
    | AEGON | /nl/Home/Investors/Calendar/ | W. Europe Standard Time | (UTC+01:00) Amsterdam, Berlijn, Bern, Rome, Stockholm, Wenen |

Scenario Outline: I should be able to change display timezone
  Given I am on the <site> site
  When I go to the <page> page
  Then I select <timezonename> timezone
  Then I should see timezone name <timezonename> in disclaimer text

  Examples:
    | site  | page                         | timezoneid            | timezonename                           |
    | AEGON | /en/Home/Investors/Calendar/ | Central Standard Time | (UTC-06:00) Central Time (US & Canada) |
