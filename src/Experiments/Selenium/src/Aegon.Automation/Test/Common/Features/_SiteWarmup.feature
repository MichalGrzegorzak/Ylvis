Feature: _Site warmup

Scenario Outline: Navigate to site root page
  Given I am on the <site> site

  Examples:
    | site    |
    | AEGON   |
    | AEGONCZ |
    | AEGONES |
    | AEGONPL |
    | AEGONRO |
    | SANDBOX |