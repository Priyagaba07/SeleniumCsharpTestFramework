Feature: BookListPage
	Check If First Book from ,list Detail page is open when I clicked on it 


Scenario: Click on first Searched Book
	Given I have navigated to Amazon Home Page
	And  I see application opened
	When I selected the Book Filter Option
	And I entered the BookName
	And I clicked the Go Button
	Then List of searched Book is visible
	When I get the BookTitle of First Book
	And I click the first Book In List
	Then First Book detail page is open
