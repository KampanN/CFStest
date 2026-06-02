Feature: Amazon Test Scenarios

Launching Amazon website and validate Home page, Search functionality and Category navigation

	Scenario Outline: Search Functionality
	Given open the browser and enter url
	When user search for <product> in search box
	Then I verify the searched product is displayed
	Then I capture the screenshot
	Examples:
	| product|  
	| iPhone Air |

	Scenario Outline: Category Navigation
	Given open the browser and enter url
	When I Click on All Menu icon
	Then I Select Best Sellers category
	Then I verify user is navigated to Best Sellers page
	Then I capture the screenshot
	

	Scenario Outline: Amazon Home page verification
	Given open the browser and enter url
	When User is navigated to Amazon home page
	Then I Verify Key navigation elements are present
	Then I capture the screenshot


