Feature: Custom scripts tests

Scenario Outline: Sitewide header script checks
    Given On the <site> homepage I set the value of <headerScriptProperty> to <headerScript>
    Given On the <site> homepage I set the value of <footerScriptProperty> to <footerScript>
    Given On <site> site I have prepared <page> content page
    Given On <site> <page> I set the value of <pageScriptProperty> property to <pageScript>
    When I go to that page
    Then The JavaScript code <verificationScript> should return string value: <verificationValue>

Examples:
         | site    | headerScriptProperty            | headerScript                                                 | footerScriptProperty            | footerScript | pageScriptProperty | pageScript | page                         | verificationScript                  | verificationValue |
         | SANDBOX | SitewideHeaderScriptPlaceholder | <script>window.customScriptVariable = 'testHeader';</script> | SitewideFooterScriptPlaceholder |              | ScriptPlaceholder  |            | /custom-scripts/content-page | return window.customScriptVariable; | testHeader        |

Scenario Outline: Sitewide footer script checks
    Given On the <site> homepage I set the value of <headerScriptProperty> to <headerScript>
    Given On the <site> homepage I set the value of <footerScriptProperty> to <footerScript>
    Given On <site> site I have prepared <page> content page
    Given On <site> <page> I set the value of <pageScriptProperty> property to <pageScript>
    When I go to that page
    Then The JavaScript code <verificationScript> should return string value: <verificationValue>

Examples:
         | site    | headerScriptProperty            | headerScript | footerScriptProperty            | footerScript                                                 | pageScriptProperty | pageScript | page                         | verificationScript                  | verificationValue |
         | SANDBOX | SitewideHeaderScriptPlaceholder |              | SitewideFooterScriptPlaceholder | <script>window.customScriptVariable = 'testFooter';</script> | ScriptPlaceholder  |            | /custom-scripts/content-page | return window.customScriptVariable; | testFooter        |

Scenario Outline: Page script checks
    Given On the <site> homepage I set the value of <headerScriptProperty> to <headerScript>
    Given On the <site> homepage I set the value of <footerScriptProperty> to <footerScript>
    Given On <site> site I have prepared <page> content page
    Given On <site> <page> I set the value of <pageScriptProperty> property to <pageScript>
    When I go to that page
    Then The JavaScript code <verificationScript> should return string value: <verificationValue>

Examples:
         | site    | headerScriptProperty            | headerScript | footerScriptProperty            | footerScript | pageScriptProperty | pageScript                                                 | page                         | verificationScript                  | verificationValue |
         | SANDBOX | SitewideHeaderScriptPlaceholder |              | SitewideFooterScriptPlaceholder |              | ScriptPlaceholder  | <script>window.customScriptVariable = 'testPage';</script> | /custom-scripts/content-page | return window.customScriptVariable; | testPage          |

Scenario Outline: Mixed scripts checks
    Given On the <site> homepage I set the value of <headerScriptProperty> to <headerScript>
    Given On the <site> homepage I set the value of <footerScriptProperty> to <footerScript>
    Given On <site> site I have prepared <page> content page
    Given On <site> <page> I set the value of <pageScriptProperty> property to <pageScript>
    When I go to that page
    Then The JavaScript code <verificationScript> should return string value: <verificationValue>

Examples:
         | site    | headerScriptProperty            | headerScript                                      | footerScriptProperty            | footerScript                                    | pageScriptProperty | pageScript                                      | page                         | verificationScript                             | verificationValue |
         | SANDBOX | SitewideHeaderScriptPlaceholder | <script>window.customScriptVariable = 1;</script> | SitewideFooterScriptPlaceholder | <script>window.customScriptVariable++;</script> | ScriptPlaceholder  | <script>window.customScriptVariable++;</script> | /custom-scripts/content-page | return window.customScriptVariable.toString(); | 3                 |
