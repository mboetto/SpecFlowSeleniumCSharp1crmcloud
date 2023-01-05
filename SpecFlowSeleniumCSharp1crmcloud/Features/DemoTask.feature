Feature: DemoTask

Scenario: Create Contact
	Given I navigate to crmcloud
	Then I login as admin
	Then I navigate to Sales & Marketing - Contacts
	And I search the test contact and if found I delete the contact
	Then I create a new contact
	Then I navigate to Sales & Marketing - Contacts
	And I search the test contact
	And I check the contact data are correct
	Then I delete the contact

Scenario: Run Report
	Given I navigate to crmcloud
	Then I login as admin
	Then I navigate to Reports & Settings - Reports
	And I search 'Project Profitability'
	Then I run report and verify that some results were returned

Scenario: Remove events from activity log:
	Given I navigate to crmcloud
	Then I login as admin
	Then I navigate to Reports & Settings - Activity Log
	And I select first 3 items in the table
	And I click Actions - Delete
	Then I verify that items were deleted