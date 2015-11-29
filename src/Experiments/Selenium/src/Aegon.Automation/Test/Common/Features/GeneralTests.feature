@longrunning
Feature: General tests

Scenario Outline: General tests
    Given I am on the <site> site
    When I navigate through <maxPages> <rootPage> descendant pages of type <pageTypes> in language <languageBranch> and perform <testIds> tests
    Then I should not get any error

Examples:
    | site    | rootPage                           | pageTypes | maxPages | languageBranch | testIds      |
    | AEGONRO | /ro/RO-Homepage-pensia/Despre-noi/ | *         | -1       | ro             | STATIC_LINKS |
    | AEGON   | /en/Home/About/                    | *         | -1       | en             | STATIC_LINKS |

@ignore
Scenario Outline: JavaScript tests
    Given I turned off ErrorPage checking
    And I warn on page redirections
    And I am on the <site> site
    When I navigate through <maxPages> <rootPage> descendant pages of type <pageTypes> in language <languageBranch> and perform <testIds> tests
    Then I should not get any error

Examples:
    | site    | rootPage             | pageTypes                                 | maxPages | languageBranch | testIds  |
    | AEGONRO | /RO-Homepage-Pensia/ | *                                         | 2        | ro             | JS_ERROR |
    | AEGONRO | /RO-Homepage-Viata/  | *                                         | 2        | ro             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Newsitem                  | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Content Page              | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Data] Gallery Image                  | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Data] Publicationitem                    | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Templates] Generic Content               | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Data] LinkItem                           | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Templates] Newsitem                      | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Data] Calendar Item                  | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Templates] QuarterlyResult               | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Job Details page          | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Templates] Overviewpage                  | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Templates] QuarterlyResultsOverview      | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Overview                  | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Landing Page              | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Gallery Page              | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Person Gallery Page       | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Templates] Product                       | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Templates] Product Overviewpage          | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Templates] Form Container Page           | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] FAQ Page                  | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Form Container Page       | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Office Overview page      | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Search Page               | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Sitemap                   | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Templates] SiteMap                       | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Calendar Page             | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Glossary Page             | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [CZ Templates] Fund                       | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Templates] Fund                          | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Fund                      | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] CZ Fund                   | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Templates] Pension Fund                  | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Pension Fund              | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Templates] Contact Form                  | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Templates] SearchResultspage             | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [CZ Templates] Lead management            | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Funds overview            | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Templates] Pension Fund overview         | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [CZ Templates] Historic fund performance  | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Historic fund performance | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Templates] Historic fund performance     | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [CZ Templates] Fund overview              | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Templates] Fund overview                 | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Templates] WebPhone                      | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [Templates] Office Overviewpage           | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Homepage                  | 2        | pl             | JS_ERROR |
    | AEGONPL | /                    | [BRI Templates] Entry Page                | 2        | pl             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Newsitem                  | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Content Page              | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Data] Gallery Image                  | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Data] Publicationitem                    | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Templates] Generic Content               | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Data] LinkItem                           | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Templates] Newsitem                      | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Data] Calendar Item                  | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Templates] QuarterlyResult               | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Job Details page          | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Templates] Overviewpage                  | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Templates] QuarterlyResultsOverview      | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Overview                  | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Landing Page              | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Gallery Page              | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Person Gallery Page       | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Templates] Product                       | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Templates] Product Overviewpage          | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Templates] Form Container Page           | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] FAQ Page                  | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Form Container Page       | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Office Overview page      | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Search Page               | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Sitemap                   | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Templates] SiteMap                       | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Calendar Page             | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Glossary Page             | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [CZ Templates] Fund                       | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Templates] Fund                          | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Fund                      | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] CZ Fund                   | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Templates] Pension Fund                  | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Pension Fund              | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Templates] Contact Form                  | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Templates] SearchResultspage             | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [CZ Templates] Lead management            | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Funds overview            | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Templates] Pension Fund overview         | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [CZ Templates] Historic fund performance  | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Historic fund performance | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Templates] Historic fund performance     | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [CZ Templates] Fund overview              | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Templates] Fund overview                 | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Templates] WebPhone                      | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [Templates] Office Overviewpage           | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Homepage                  | 2        | cs             | JS_ERROR |
    | AEGONCZ | /                    | [BRI Templates] Entry Page                | 2        | cs             | JS_ERROR |
    | AEGONES | /                    | *                                         | 2        | es             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Newsitem                  | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Content Page              | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Data] Gallery Image                  | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Data] Publicationitem                    | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Templates] Generic Content               | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Data] LinkItem                           | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Templates] Newsitem                      | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Data] Calendar Item                  | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Templates] QuarterlyResult               | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Job Details page          | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Templates] Overviewpage                  | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Templates] QuarterlyResultsOverview      | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Overview                  | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Landing Page              | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Gallery Page              | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Person Gallery Page       | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Templates] Product                       | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Templates] Product Overviewpage          | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Templates] Form Container Page           | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] FAQ Page                  | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Form Container Page       | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Office Overview page      | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Search Page               | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Sitemap                   | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Templates] SiteMap                       | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Calendar Page             | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Glossary Page             | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [CZ Templates] Fund                       | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Templates] Fund                          | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Fund                      | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] CZ Fund                   | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Templates] Pension Fund                  | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Pension Fund              | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Templates] Contact Form                  | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Templates] SearchResultspage             | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [CZ Templates] Lead management            | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Funds overview            | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Templates] Pension Fund overview         | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [CZ Templates] Historic fund performance  | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Historic fund performance | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Templates] Historic fund performance     | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [CZ Templates] Fund overview              | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Templates] Fund overview                 | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Templates] WebPhone                      | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [Templates] Office Overviewpage           | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Homepage                  | 2        | en             | JS_ERROR |
    | AEGON   | /Home/               | [BRI Templates] Entry Page                | 2        | en             | JS_ERROR |
    | TLBBM   | /en/Homepage/        | *                                         | 10       | en             | JS_ERROR |

# to prove js errors can be detected
Scenario Outline: Force Jsavascript error
	Given On <site> site I have prepared <page> test page with content from <file> file
    When I go to that page
    Then There is <error> js error
Examples:
    | site    | page               | file                                | error                                      |
    | SANDBOX | /javascript/error1 | TestCaseData/JavaScript/error1.html | ReferenceError: dummyObject is not defined |
