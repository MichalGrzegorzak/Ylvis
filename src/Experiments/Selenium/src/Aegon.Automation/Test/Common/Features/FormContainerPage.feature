Feature: Form Container Page Checks

Scenario Outline: I should be able to see captcha after posting spam data
    Given On <site> site I have prepared <page> <pageKind> form container page which contains <form> XForm
    When I go to that page
    And I click form submit button
    Then I should see a captcha image under the form fields

Examples:
    | site    | page                   | pageKind | form                                 |
    | SANDBOX | /XForms/BriMollom      | BRI      | 54ed3273-5e84-40a5-abdd-0a0e8bac5610 |
    | SANDBOX | /XForms/FaceliftMollom | nonBRI   | 54ed3273-5e84-40a5-abdd-0a0e8bac5610 |