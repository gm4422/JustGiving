Feature: SearchFeature
     As a user, I need a way to search for a charity, friend to project to find what I am looking for
	 Background: 
	 Given I am on the homepage

@Chrome
Scenario: Search_Chrome_Searching on main page
	When I enter "testtest testtest" in the search bar
	Then I expect more than 1 result to come back on the Search result page

@Chrome
Scenario: Search_Chrome_Search returns nothing 
	When I enter "xdlkfj" in the search bar 
	Then I expect No results to be displayed on the Search result page