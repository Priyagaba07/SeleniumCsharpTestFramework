Feature: SearchBookFilter
	Check if List of searched book is shown when book is searched using filter


 Scenario: Search Book using filter
	Given I have navigated to Amazon Home Page
	And  I see application opened
	When I selected the Book Filter Option
	And I entered the BookName
	And I clicked the Go Button
	Then List of searched Book is visible
