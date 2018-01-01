Feature: Login
		Login and Register
@Login
Scenario: Login Failed With Need Register Message
	Given Entered to Login Page
	And see the login form
	And key in Unregistered login id
	And key in Password
	When press login
	Then Should show need Register message

	Scenario: Login Success With Redirect to Home Index
	Given Entered to Login Page
	And see the login form
	And key in login id
	And key in Correct Password
	When press login
	Then Should redirect to Home Index
	
	Scenario: Login fail With Wrong password message
	Given Entered to Login Page
	And see the login form
	And key in login id
	And key in Wrong Password
	When press login
	Then Should show wrong password message

	


