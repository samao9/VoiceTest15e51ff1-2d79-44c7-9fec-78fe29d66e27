Feature: Check if palindrome
	In order to verify if a string is palindrome
	As a tester
	I want to be told true/false if a string [a-z] is/not a palindrome

@palindromeTests
Scenario: If a palindrome
	Given I have entered "<word>" as the input
	Then I got a true as result

	Examples: 
	| word   |
	| a       |
	| aa      |
	| racecar |

Scenario: If not a palindrome
	Given I have entered "<word>" as the input
	Then I got a false as result

	Examples: 
	| word   |
	| baba       |
	| ab      |
	| raceciar |