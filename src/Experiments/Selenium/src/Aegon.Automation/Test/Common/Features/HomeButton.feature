Feature: Home button checks

Scenario Outline: Clicking on the logo in the header should bring you to the appropriate home page
  Given I am on the <site> site
  When I go to the <page> page
  And I click on the logo in the header
  Then I should be redirected to the <homePageUrl> page

  Examples:
    | site    | page                                                          | homePageUrl          |
    | AEGONRO | /RO-Homepage-Pensia/                                          | /RO-Homepage-Pensia/ |
    | AEGONRO | /RO-Homepage-Pensia/VITAL/                                    | /RO-Homepage-Pensia/ |
    | AEGONRO | /RO-Homepage-Pensia/Despre-noi/Datele_noastre_de_contact/     | /RO-Homepage-Pensia/ |
    | AEGONRO | /RO-Homepage-Pensia/Aegon_Esential/Prospectul-Aegon-Esential/ | /RO-Homepage-Pensia/ |
    | AEGONRO | /RO-Homepage-Viata/                                           | /RO-Homepage-Viata/  |
    | AEGONRO | /RO-Homepage-Viata/Zona-clienti/Dictionar/                    | /RO-Homepage-Viata/  |
    | AEGONRO | /RO-Homepage-Viata/Zona-clienti/Despagubiri/                  | /RO-Homepage-Viata/  |
    | AEGON   | /Home/                                                        | /Home/               |
    | AEGON   | /Home/Products/Product-Overview/Product-Matrix-Non-European/  | /Home/               |
