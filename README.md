# Achievement System

Here you will see how to use the achievement system package

---

## Table of Contents

1. [Pop-Up Visuals](#pop-up-visuals)
2. [Profiles](#profiles)
3. [Achievements](#achievements)

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
- This function will return an integer which will correspond to the profile you added to the system
  
2. **To get a player profile call `AchievementSystem.getProfile( int t_playerIndex )`**
  - The players are kept in a list, to retrieve them you must keep track of the index
  - Used the previously return integer to access the profile

3. The profile constains also contains a list of completed achievements and uncompleted achievements to keep track of progress

4. **If you want to directly add to the lists of completed achievements of a specific profile, call  `AchievementSystem.Instance.addCompletedAchievement( int t_playerIndex, string t_achievement)`**
- This could be used if you want to fill the list of completed achievements from sonme save data before the games starts from a file or player prefs


## Achievements

Achievements are tracked with strings, the string will also be the title of the achievement

1. **Call `AchievementSystem.Instance.AddAchievementToProfiles( string t_achievement)` to add an achievemnt to all existing profiles in the system**
- This function will not add an achievement to a profile that has it listed as a completed achievement

2. ** Call `AchievementSystem.Instance.CompletedAchievement(int playerIndex, string t_achievement)` to complete an achievemnt
- this will remove the achievement from the uncompleted achievment list to the completed achievment list of the passed in profile indexe
- this will also create a pop up in game, the settings for which are specified [Pop-Up Visuals](#pop-up-visuals)
- if more than 1 achievement is called at once they will be staggered so they dont obscure each other
