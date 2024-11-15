*** Settings ***
Documentation     Common keywords and variables used across test suites
Library           SeleniumLibrary
Library           Process

*** Variables ***
${BROWSER}         chrome
${TIMEOUT}         10s
${RETRY_INTERVAL}  0.5s

*** Keywords ***
Open Browser To Application
    [Documentation]    Opens browser with required configuration
    ${chrome_options}=    Evaluate    sys.modules['selenium.webdriver'].ChromeOptions()    sys, selenium.webdriver
    Call Method    ${chrome_options}    add_argument    --no-sandbox
    Call Method    ${chrome_options}    add_argument    --disable-dev-shm-usage
    Open Browser    ${BASE_URL}    ${BROWSER}    options=${chrome_options}
    Set Selenium Implicit Wait    ${TIMEOUT}
    Maximize Browser Window

Wait Until Element Visible And Click
    [Arguments]    ${locator}
    Wait Until Element Is Visible    ${locator}    ${TIMEOUT}
    Click Element    ${locator}

Input Text And Verify
    [Arguments]    ${locator}    ${text}
    Input Text    ${locator}    ${text}
    ${actual_text}=    Get Value    ${locator}
    Should Be Equal    ${actual_text}    ${text}

Verify Page Contains
    [Arguments]    ${expected_text}
    Wait Until Page Contains    ${expected_text}    ${TIMEOUT}