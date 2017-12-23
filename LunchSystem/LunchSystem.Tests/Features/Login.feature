Feature: Login
		Login and Register
@Login
Scenario: Login Failed With Need Register Message
	Given Entered to Login Page
	And see the login form
	And key in login id 'Wuu'
	And key in Password '1234'
	When press login
	Then Should Popout HaventRegister error.

