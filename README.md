# Achievement System Guide

Here you will see how to use the achievement system package

---

## Table of Contents
1. [Set-Up](#set-up)
2. [Pop-Up Visuals](#pop-up-visuals)
3. [Profiles](#profiles)
4. [Achievements](#achievements)
5. [Saving](#saving)
6. [Alternative Achievement Pop Ups](#alternative-achievement-pop-ups)

---

## Set Up
You need to add this component to your Packages/manifest file

    "ie.itcarlow.achievementsystem":"https://github.com/itcOnlineGaming/Achievement_System.git?path=/Achievement System/Packages/ie.itcarlow.achievementsystem"

---

## Pop-Up Visuals

### Overview

Here you can customize various parts of the achievement pop up by calling a singelton class, which will globablly effect all achievements by default. This can be changed to swap between this singeltons global setting to use alternatice settings here : .

### Use

1. **Call the singeleton instance `AchievementPopUpGlobalSettings.settings`**.
2. **THen customise any of the following aspects of the achievement pop:

   ```csharp
   AchievementPopUpGlobalSettings.settings.timeToLive; // how long it will stay on screen for
   
   AchievementPopUpGlobalSettings.settings.postion; // position on screen
   
   AchievementPopUpGlobalSettings.settings.textFont; // font
   
   AchievementPopUpGlobalSettings.settings.textColor; // color of text
   
   AchievementPopUpGlobalSettings.settings.textPadding; // space between the text and the edge of the pop up background
   
   AchievementPopUpGlobalSettings.settings.backgroundSize; // size of background size
   
   AchievementPopUpGlobalSettings.settings.backgroundColor; // color of background


## Profiles

### Overview:

Here you can see how to add a profile to the achievement system.

### Use:

1. **Call the singeleton instances function to add a profile to the system**
   ```csharp
      AchievementSystem.Instance.addProfile( t_username, t_displayNameOnPopUp )
   ```
- `t_username` will assign a name to the user.
- `t_displayNameOnPopUp` boolean willdetermine whether you want that name to be displayed on the achievement pop up.
- This function will return an integer which will correspond to the profile you added to the system and is used to retrieve said profile from the system.
  
2. **To get a players profile call:**
   ```csharp
      AchievementSystem.getProfile( playerIndex )
   ```
  - The players are kept in a list, to retrieve them you must keep track of the index.
  - Used the previously return integer to access the profile.

3. The profile constains also contains a list of completed achievements and uncompleted achievements to keep track of progress.

4. **If you want to directly add to the lists of completed achievements of a specific profile, call:**
   ```csharp
      AchievementSystem.Instance.addCompletedAchievement( int t_playerIndex, string t_achievement)
   ```
- This could be used if you want to fill the list of completed achievements from sonme save data before the games starts from a file or player prefs.


## Achievements

### Overview:

Achievements are tracked with strings, the string will also be the title of the achievement on the Pop Up.

### Use:

1. **T o add an achievemnt to all existing profiles in the system, Call:**
   ```csharp
      AchievementSystem.Instance.AddAchievementToProfiles( string t_achievement)
   ```
- This function will not add an achievement to a profile that has it listed as a completed achievement.

2. ** To complete an achievemnt, Call: .
   ```csharp
      AchievementSystem.Instance.CompletedAchievement(int playerIndex, string t_achievement)
   ```
- this will remove the achievement from the uncompleted achievment list to the completed achievment list of the passed in profile index.
- this will also create a pop up in game, the settings for which are specified [Pop-Up Visuals](#pop-up-visuals)
- if more than 1 achievement is called at once they will be staggered so they don't obscure each other.

## Saving

### Overview:
The system saves achievements evertime they are completed to the profile automaitically, but the below line will save all uncompleted and completed achievemetsachievements in case you want both saved at the end of the game. 
### Use:
1. **To save data at the end of the game simply call the below functiom, this will save each player profiles data to the username**
 ```csharp
      AchievementSystem.Instance.savePlayersAchievements();
   ```

## Alternative Achievement Pop Ups

### Overview:
The user can also specify whether to use settings that are not the global ones, if for some reason you wanted to use a different background for a specific achievement. This must be done on a case by case basis.

### Use:

```csharp

// create yoru new settings ( doesnt need to be done multiple times, as is stored)
AchievementPopUpSetting newsettings;
newSettings.timeToLive = 5;
newSettings.postion = new Vector2( 200, 200);
newSettings.textFont = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
newSettings.textColor = Color.White;
newSettings.textPadding = new Vector2( 10, 10);
newSettings.backgroundSize = new Vector2( 200, 200);

// assign to the system
AchievementSystem.Instance.userDefinedSettings = newsettings;

// tell system to use the stored settings ( this will have to be switched if you want to go back to using global settings) 
AchievementSystem.Instance.useGlobalDefaults = false;

// complete achievement which will creat pop up with the above alternative setting to global
AchievementSystem.Instance.CompletedAchievement( index, achievement.string );

// If you want settings goiong forward to be be back to global settings
AchievementSystem.Instance.useGlobalDefaults = true;


```
