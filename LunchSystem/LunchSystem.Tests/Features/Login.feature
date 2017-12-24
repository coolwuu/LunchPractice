Feature: Login
		Login and Register
@Login
Scenario: Login Failed With Need Register Message
	Given Entered to Login Page
	And see the login form
	And key in login id 'LoginFail'
	And key in Password 'Wuu1234'
	When press login
	Then Should show need Register message

	Scenario: Login Success With Redirect to Home Index
	Given Entered to Login Page
	And see the login form
	And key in login id 'Wuu'
	And key in Password 'Wuu12345'
	When press login
	Then Should redirect to Home Index

