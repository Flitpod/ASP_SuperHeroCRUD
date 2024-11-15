*** Settings ***
Documentation     Page objects for Hero management pages
Library           SeleniumLibrary

*** Variables ***
# URLs
${BASE_URL}         http://localhost:5253/Hero
${LIST_URL}         ${BASE_URL}/Index
${NEW_HERO_URL}     ${BASE_URL}/Create

# Locators
${LIST_HEROES_LINK}    xpath=//*[text()[contains(.,'List Heroes')]]
${BROWSE_HEROES_LINK}  xpath=//*[text()[contains(.,'Browse Heroes')]]
${NEW_HERO_LINK}       xpath=//*[text()[contains(.,'New Hero')]]

# Form elements
${POWER_INPUT}         xpath=//input[@name='Power']
${UPDATE_BUTTON}       xpath=//input[@value='Update']

*** Keywords ***
Go To List Heroes
    Click Element    ${LIST_HEROES_LINK}
    Wait Until Page Contains Element    xpath=//table

Go To Browse Heroes
    Click Element    ${BROWSE_HEROES_LINK}

Go To New Hero
    Click Element    ${NEW_HERO_LINK}

Find Hero Row
    [Arguments]    ${hero_name}
    ${row}=    Get WebElement    xpath=//td[contains(.,'${hero_name}')]//ancestor::tr
    RETURN    ${row}

Click Update For Hero
    [Arguments]    ${hero_name}
    ${row}=    Find Hero Row    ${hero_name}
    Click Element    xpath=//tr[contains(., '${hero_name}')]//a[text()[contains(.,"Update")]]

Update Hero Power
    [Arguments]    ${new_power}
    Clear Element Text    ${POWER_INPUT}
    Input Text    ${POWER_INPUT}    ${new_power}
    Click Button    ${UPDATE_BUTTON}

Verify Hero Power
    [Arguments]    ${hero_name}    ${expected_power}
    Element Should Contain    xpath=//tr[contains(., '${hero_name}')]    ${expected_power}