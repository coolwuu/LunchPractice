Feature: Login
		Login and Register
@Login
Scenario: Login
	Given I have entered Website
	And I see the login form
	And I key in my login id 'Wuu'
	And I key in my Password '1234'
	When I press login
	Then Should Popout HaventRegister error.

