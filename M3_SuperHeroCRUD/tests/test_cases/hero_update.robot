*** Settings ***
Documentation     Test cases for updating hero information
Resource          ../resources/common.robot
Resource          ../resources/test_data.robot
Resource          ../pages/hero_page.robot
Test Setup        Open Browser To Application
Test Teardown     Close All Browsers

*** Test Cases ***
Update Hero Power
    [Documentation]    Test updating a hero's power level
    [Tags]    regression    hero-management
    
    Go To List Heroes
    Click Update For Hero    ${TEST_HERO_3.name}
    Update Hero Power    ${TEST_HERO_3.power}
    Sleep    6s
    Go To List Heroes
    Verify Hero Power    ${TEST_HERO_3.name}    ${TEST_HERO_3.power}