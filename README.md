# Achievement System

Here you will see how to use the achievement system package

---

## Table of Contents

1. [Pop-Up Visuals](#pop-up-visuals)
2. [Profiles](#profiles)
3. [Adding Achievements](#adding-achievements)

---

## Pop-Up Visuals

### Overview

Here you can customize various parts of the achievement pop up by calling a singelton class, which will globablly effect all achievements by default. This can be changed.

1. **Call the singeleton instance `AchievementPopUpGlobalSettings.settings`**.
2. **THen customise any of the following aspects of the achievement pop:

   ```csharp
   AchievementPopUpGlobalSettings.settings.timeToLive // how long it will stay on screen for
   
   AchievementPopUpGlobalSettings.settings.postion // position on screen
   
   AchievementPopUpGlobalSettings.settings.textFont // font
   
   AchievementPopUpGlobalSettings.settings.textColor // color of text
   
   AchievementPopUpGlobalSettings.settings.textPadding // space between the text and the edge of the pop up background
   
   AchievementPopUpGlobalSettings.settings.backgroundSize // size of background size
   
   AchievementPopUpGlobalSettings.settings.backgroundColor // color of background


## Profiles

### Overview

Here you can see how to add a profile to the achievement system and wha

1. **Call the singeleton instances function `AchievementSystem.addProfile( string t_username, bool t_displayNameOnPopUp )`**
- `t_username` will assign a name to the user
- `t_displayNameOnPopUp` wil determine whether you want that name to be displayed on the achievement pop up

## Adding Achievements
