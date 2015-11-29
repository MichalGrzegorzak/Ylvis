@legacy
@Ignore
Feature: Funds And FundOverview
	
Scenario: Filter by product - Aegon PL
	Given I am on Fund overview page of Aegon PL
	And I set the product to Aegon Pro
	When I click the filter button 
	Then I see the fund UFK - Aegon Gwarantowany (PLN) 
	And I see the fund UFK - BPH Obligacji 1 (PLN)


Scenario: Filter by currency - Aegon PL
	Given I am on Fund overview page of Aegon PL
	And I set the currency to PLN
	When I click the filter button
	Then I see the fund UFK - Aegon Gwarantowany (PLN) 
	And I see the fund UFK - Investor Gotówkowy (PLN)

Scenario: Filter by Product and Currency - Aegon PL
	Given I am on Fund overview page of Aegon PL
	And I set the product to Multi PIN Aegon
	And I set the currency to EUR
	When I click the filter button 
	Then I see the fund UFK - JPMorgan Series II (EUR) 
	And I see the fund UFK - UniEURIBOR (EUR)

Scenario: Check fund from fundover view page - Aegon PL
	Given I am on Fund overview page of Aegon PL
	And I click the fund UFK - Aegon Gwarantowany (PLN)
	Then I am directed to fund UFK - Aegon Gwarantowany (PLN) page 
	And I see the pichart for the fund
	And I can change the historic fund period to 6 miesięcy
	

Scenario: Fund overiview on Aegon Cz
	Given I am on Fund overview page of Aegon CZ
	Then I see the fund AE23 CONSEQ INVEST DLUHOPISOVÝ
	And I see the fund AE02 Aegon Fond dluhopisový

Scenario: Check fund from fundover view page - Aegon CZ
	Given I am on Fund overview page of Aegon CZ
	And I click the fund AE23 CONSEQ INVEST DLUHOPISOVÝ
	Then I am directed to fund AE23 CONSEQ INVEST DLUHOPISOVÝ page 
	And I see the pichart for the fund
	And I can change the historic fund period to 6 měsíců
