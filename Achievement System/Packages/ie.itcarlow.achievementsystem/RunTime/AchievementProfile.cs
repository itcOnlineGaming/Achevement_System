using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementProfile 
{
    public string userName;
    public bool displayName;

    public List<string> uncompletedAchievements = new List<string>();

    /// <summary>
    /// List of achievements that have been completed
    /// </summary>
    public List<string> completedAchievements = new List<string>();


    public AchievementProfile(string t_username, bool t_displayNameOnPopUp)
    {
        userName = t_username;  
        displayName = t_displayNameOnPopUp; 
    }
}
