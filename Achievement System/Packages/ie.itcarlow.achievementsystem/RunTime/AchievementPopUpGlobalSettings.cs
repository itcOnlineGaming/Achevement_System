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
    public float timeToLive;
    /// <summary>
    /// Position of pop up on screen
    /// </summary>
    public Vector2 position;

    /// <summary>
    /// Desired font of the achievement text
    /// </summary>
    public Font textFont;

    /// <summary>
    /// Desired font of the achievement text
    /// </summary>
    public Color textColor;

    /// <summary>
    /// Space between text and the edge of the achievement background
    /// </summary>
    public Vector2 textPadding;
    /// <summary>
    /// Image of the achievement background
    /// </summary>
    public Texture2D backgroundSpirte;

    /// <summary>
    /// Image of the achievement background
    /// </summary>
    public Vector2 backgroundSize;

    /// <summary>
    /// Back ground 
    /// </summary>
    public Color backgroundColor;

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
