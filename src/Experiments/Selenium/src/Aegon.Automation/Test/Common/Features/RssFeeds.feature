Feature: Rss Feeds tests

Scenario Outline: I should be able to read RSS feeds
  Given I am on the <site> site
  When I go to the <page> page
  Then I should be able to read RSS feeds

  Examples:
    | site  | page                            |
    | AEGON | /en/Home/RSS/Calendar/          |
    | AEGON | /en/Home/RSS/Quarterly-Results/ |
    | AEGON | /en/Home/RSS/Press-Releases/    |
    | AEGON | /en/Home/RSS/Publications/      |
    | AEGON | /en/Home/RSS/Web-and-podcasts/  |
    | AEGON | /en/Home/RSS/Presentations/     |
