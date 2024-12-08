using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Variables that will be used to change the settings visuals
/// </summary>
public struct AchievementPopUpSetting
{
    /// <summary>
    /// Pop up time to live
    /// </summary>
    public float achievementTTL;
    /// <summary>
    /// Position of pop up on screen
    /// </summary>
    public Vector2 achievmentPosition;

    /// <summary>
    /// Desired font of the achievement text
    /// </summary>
    public Font achievementFont;

    /// <summary>
    /// Image of the achievement background
    /// </summary>
    public Sprite achievementImage;

    /// <summary>
    /// Image of the achievement background
    /// </summary>
    public Vector2 achievementImageSize;

    /// <summary>
    /// Back ground 
    /// </summary>
    public Color achievementBackroundColor;

}

/// <summary>
/// This singleton will allow the user of the package to set the settings of the pop once 
/// and then have every achievement pop adhere to these settings, instead of the parameters 
/// being passed in each time
/// </summary>
public static class AchievementPopUpGlobalSettings 
{

    static public AchievementPopUpSetting settings = new AchievementPopUpSetting();


}
