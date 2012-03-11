Feature: Anagrams
	In order to have statistics abou how many words uses the same characters
	As a curious guy
	I want to see the partitions of words in group of anagrams 


Scenario: no words
	Given no words
	When I ask for the anagrams
	Then I get an empty set


Scenario: a single word
	Given the words: foo
	When I ask for the anagrams
	Then I get a set containing a set containing the words: foo


Scenario: two words that are anagrams
	Given the words: dear, read
	When I ask for the anagrams
	Then I get a set containing a set containing the words: dear, read


Scenario: two words that are not anagrams
	Given the words: ready, doing
	When I ask for the anagrams
	Then I get a set containing the words: ready
	And I get a set containing the words: doing
	 

Scenario: tab spec words that are anagrams
	Given the words: dear, read
	When I ask for the anagrams
	Then I get sets containing the following sets of words:
	| anagrams   |
	| dear, read |


Scenario: tab spec words that are not anagrams 
	Given the words: read, go, dear
	When I ask for the anagrams
	Then I get sets containing the following sets of words:
	| anagrams   |
	| dear, read |
	| go |
