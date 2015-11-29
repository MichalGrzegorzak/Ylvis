
Feature: Cookie Consent Module

######################################## Cookie constent logic ###################################################################

Scenario Outline: Cookie popup is displayed
Given I am on the <site> site
And Cookie consent is enabled and configured for <page>
When I go to the <page> page
Then Cookie prompt is displayed

Examples: 
| site    | page                          |
| SANDBOX | /en/dev-sandbox/BRI-Homepage/ |
| SANDBOX | /en/dev-sandbox/BRI-Homepage/ |


Scenario Outline: Cookie popup is not displayed when configuration is not set
Given I am on the <site> site
And Cookie consent is disabled for <page>
When I go to the <page> page
Then No cookie prompt is displayed

Examples: 
| site    | page                          |
| SANDBOX | /en/dev-sandbox/BRI-Homepage/ |

######################################## SocialSharing ###################################################################
Scenario Outline: SocialSharing icons are disabled by default (cookies are not set)
  Given I am on the <site> site
  When I go to the <page> page
  Then I should see <disabled_icons> image
  And There is no cookie set in domain like <domain>

  Examples: 
  | site  | page                  | disabled_icons          | domain      |
  | AEGON | en/Home/About/History | notactive-img-container | addthis.com |

Scenario Outline: SocialSharing icons are visible after accept directly on them
  Given I am on the <site> site
  When I go to the <page> page
  And I hover over <disabled_icons> image
  And I click accept social cookies selector
  Then I should see social sharing icons

  Examples: 
  | site  | page                  | disabled_icons          | 
  | AEGON | en/Home/About/History | notactive-img-container | 

#Scenario Outline: SocialSharing icons are visible by default after accept in cookie consent (cookies are set)

######################################## CMS - Configuration ###################################################################
Scenario Outline: After accept cookie cofiguration has changed so prompt me again
  Given I am on the <site> site
  When I go to the <page> page
  And I accept all cookies
  Then Configuraion has changed
  And I go again to the <page> page
  And Cookie prompt is displayed

  Examples: 
  | site  | page                  | 
  | AEGON | en/Home/About/History | 

Scenario Outline: After accept cookie cofiguration prompt is not visible again
  Given I am on the <site> site
  When I go to the <page> page
  And I accept all cookies
  Then I go again to the <page> page
  And No cookie prompt is displayed

  Examples: 
  | site  | page                  | 
  | AEGON | en/Home/About/History | 