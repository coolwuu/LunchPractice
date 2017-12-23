Feature: Menu
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Order
Scenario: Order
	Given enter Lunch Website
	And can see the menu
	And Key in 'Wuu' in Name
	And Key in 'Big Mac' in Meal
	And Key the money '90' in Cost
	When press Ok
	Then able to see order list
