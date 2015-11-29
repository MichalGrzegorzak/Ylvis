@legacy
@Ignore
Feature: Contact Us Form 
	User should be able to populate and submit contact us form


Scenario: Aegon Cz form submission 
	Given I am on Contact us form page of Aegon CZ
	And I populate the full name as John Smith
	And I populate the email as test@test.com
	And I populate the telefone number as ++34567890
	And I set the profession as Akcionář
	And I set the query as Média
	And I populate the question as This is a dummy question (for testing), please ignore? 
	When I click the submit button for the form
	Then I see the thankyou message as Váš dotaz byl úspěšně odeslán. 


Scenario: Aegon PL form submission 
	Given I am on Contact us form page of Aegon PL
	And I populate the full name as John Smith
	And I populate the email as test@test.com
	And I populate the telefone number as ++34567890
	And I set the region to lubuskie
	And I set the query as Umów się z Przedstawicielem Aegon
	And I populate the question as This is a dummy question (for testing), please ignore?  
	And I tick the disclaimer checkbox 
	When I click the submit button for the form
	Then I see the thankyou message as Potwierdzenie wysłania wiadomości