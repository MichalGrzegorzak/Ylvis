Feature: Microdata tagging
    Checks whether the microdata has been correctly applied to BRI templates
	As described here: http://schema.org/WebPage
    Currently only body and breadcrumbs are supported

Scenario Outline: Check BRI microdata tags
	Given I am on the <site> site
    When I go to the <page> page
	Then The body microdata tag is present
    And The <breadcrumbs> BRI microdata tags are present

    Examples:
    | site  | page                                           | breadcrumbs            |
    | AEGON | /en/Home/About/                                | Home                   |
    | AEGON | /en/Home/Products/                             | Home                   |
    | AEGON | /en/Home/Research/                             | Home                   |
    | AEGON | /en/Home/About/At-a-glance/                    | Home;About             |
    | AEGON | /en/Home/About/Performance/                    | Home;About             |
    | AEGON | /en/Home/About/Performance/Performance-Update/ | Home;About;Performance |


Scenario Outline: Check non-BRI microdata tag
	Given I am on the <site> site
    When I go to the <page> page
	Then The body microdata tag is present
    And The <breadcrumbs> non-BRI microdata tags are present

    Examples:
    | site    | page                                                                     | breadcrumbs                                                      |
    | AEGON   | /en/Home/Investors/Shareholders--AGM/Annual-General-Meeting/AGM-Archive/ | Home;Investors & Media;Shareholders & AGM;Annual General Meeting |
    | AEGONPL | /pl/Strona-glowna/Inwestycje/Notowania-funduszy/                         | Strona główna;Inwestycje                                         |
    | AEGONES | /es/Inicio/Productos/Tus-ahorros-Inversiones/TU-AHORRO/                  | Inicio;Productos;Tus Ahorros / Inversiones                       |
