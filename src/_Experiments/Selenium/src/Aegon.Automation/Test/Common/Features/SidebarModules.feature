Feature: Sidebar Modules checks

Scenario Outline: Content page RHS modules checks
    Given On <site> site I have prepared <page> content page
    Given On <site> <page> I set the value of <property1> property to <propertyValue1>
    Given On <site> <page> I set the value of <property2> property to <propertyValue2>
    When I go to that page
    Then Right-hand side column should be visible
    And I should see <numberOfModules> modules in right-hand side column
Examples:
         | site    | page                    | property1 | propertyValue1  | property2 | propertyValue2 | numberOfModules |
         | SANDBOX | /modules/rhscontentpage | Content   | RHS column test | RHSModule | 26594          | 3               |

Scenario Outline: Newsitem page RHS modules checks
    Given On <site> site I have prepared <page> newsitem page
    Given On <site> <page> I set the value of <property1> property to <propertyValue1>
    Given On <site> <page> I set the value of <property2> property to <propertyValue2>
    When I go to that page
    Then Right-hand side column should be visible
    And I should see <numberOfModules> modules in right-hand side column
Examples:
         | site    | page                     | property1 | propertyValue1  | property2 | propertyValue2 | numberOfModules |
         | SANDBOX | /modules/rhsnewsitempage | Content   | RHS column test | RHSModule | 26594          | 3               |

Scenario Outline: Overview page RHS modules checks
    Given On <site> site I have prepared <page> overview test page with dummy data source
    Given On <site> <page> I set the value of <property1> property to <propertyValue1>
    When I go to that page
    Then Right-hand side column should be visible
    And I should see <numberOfModules> modules in right-hand side column
Examples:
         | site    | page                     | property1 | propertyValue1 | numberOfModules |
         | SANDBOX | /modules/rhsoverviewpage | RHSModule | 26594          | 3               |
