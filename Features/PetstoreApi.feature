Feature: PetstoreApi

validating the Create,read,Update and Delete operations for Petstore API

@api
  Scenario: Validate CRUD operations for Pet API
    Given User creates dynamic pet payload

    When User sends POST request to create pet
    Then Pet should be created successfully

    When User sends GET request using pet id
    Then Response data should match created pet

    When User updates pet name
    Then Updated response should contain modified name

    When User deletes the pet
    Then Deleted pet should return not found response

