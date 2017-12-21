Feature: Menu
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Order
Scenario: Order
	Given I have entered Website
	And I see the menu
	And I Key in my name 'Wuu'
	And I Key in 'Big Mac'
	And I Key the money '90'
	When I press Ok
	Then I should able to see my order list
