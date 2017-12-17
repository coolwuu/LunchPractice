Feature: Menu
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Order
Scenario: Order
	Given I have entered Website
	And I see the menu
	And I Key in my name 'Wuu'
	And I Key in '滷肉飯'
	And I Key the money '60'
	When I press Ok
	Then I should able to see my order list
