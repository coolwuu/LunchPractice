Feature: Register
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Register
Scenario: Click on Register tab can see register form
	Given Entered to Login Page for Register
	When click on register tab
	Then can see register form

Scenario: Register failed with same username exist message
	Given Entered to Login Page for Register
	And click on register tab
	And can see register form
	And key in invalid register information
	When press Register
	Then should show 'Same username exists! Please use a different username.'

Scenario: Register success with redirect to home page
	Given Entered to Login Page for Register
	And click on register tab
	And can see register form
	And key in valid register information
	When press Register
	Then should redirect to home page.
