Feature: Check if palindrome
	In order to verify if a string is palindrome
	As a tester
	I want to be told true/false when a string is/not a palindrome

@palindromeTests
Scenario: If a palindrome
	Given I have entered "<word>" as the input
	When I verfty if the input is palindrome
	Then I should get true as result

	Examples: 
	| word   |
	| a       |
	| aa      |
	| racecar |

Scenario: If not a palindrome
	Given I have entered "<word>" as the input
	When I verfty if the input is palindrome
	Then I should get false as result

	Examples: 
	| word   |
	| baba       |
	| ab      |
	| raceciar |