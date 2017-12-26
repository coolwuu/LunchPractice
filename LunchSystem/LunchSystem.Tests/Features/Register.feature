Feature: Register
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Register
Scenario: Click on Register tab can see register form
	Given Entered to Login Page for Register
	When click on register tab
	Then can see register form

