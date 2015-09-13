Feature: AmazonShop
	In order to buy a book in Amazon
	As a consumer I will search for a book 
	And I want to add that book to my basket

Scenario Outline: As a consumer I want to search for a book in Amazon
            Given I am on Amazon home page
            When I enter "<book>" name into the search field
			And I click on search button
            Then I should see my book "<book>" in the results list
		    Examples: 
            | book          |
            | The Fishermen |	

Scenario Outline: consumer add the book to the basket	
		   Given I have nothing in my basket, it displays a total of "0"
		   When I search for a "<book>" in Amazon
		   And I see the details page of the "<book>"
		   And I should see the book is "In stock."
		   And I add the book to the basket
		   Then my basket should dispaly a total of "1"
		   Examples: 
           | book          |
           | The Fishermen |	
