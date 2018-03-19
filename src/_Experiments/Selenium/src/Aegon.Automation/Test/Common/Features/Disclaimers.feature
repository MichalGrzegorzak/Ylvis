Feature: Disclaimers tests

Scenario Outline: Disclaimer overlay should be displayed after clicking on the link
    Given I am on the <site> site
    When I go to the <page> page
    And I click link by <link_selector> selector
    Then I should see a disclaimer overlay

Examples:
         | site  | page                                                              | link_selector       |
         | AEGON | /Home/Investors/News-presentations/Image-Gallery/Executive-Board/ | .ov-links-wrapper a |

Scenario Outline: Disclaimer overlay should not contain social media links
    Given I am on the <site> site
    When I go to the <page> page
    And I click link by <link_selector> selector
    Then The disclaimer overlay should not contain social media links

Examples:
        | site  | page                                                             | link_selector       |
        | AEGON | /Home/Investors/News-presentations/Image-Gallery/Executive-Board/ | .ov-links-wrapper a |


         