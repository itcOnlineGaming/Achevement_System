using Codice.Client.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementTracker : MonoBehaviour
{

    public string userName;
    public bool displayName;

    public List<string> uncompletedAchievements = new List<string>();

    public List<string> completedAchievements = new List<string> ();

    public AchievementTracker()
    {    
        userName = string.Empty;
        displayName = false;
    }
    public AchievementTracker(string t_userName, bool t_displayName)
    {
        userName = t_userName;
        displayName = t_displayName;
    }

    public void setUserData(string t_userName, bool t_displayName)
    {
        userName = t_userName;
        displayName = t_displayName;
    }

    public void setPopUpData()
    {

    }

    public void AddAchievement(string t_achievement )
    {
        uncompletedAchievements.Add(t_achievement);
    }

    public void CompletedAchievement( string t_achievement)
    {
        if( uncompletedAchievements.Contains( t_achievement))
        {
            uncompletedAchievements.Remove(t_achievement);    
            completedAchievements.Add (t_achievement);  
            CreateAchievementPopUp(t_achievement);  
        }
    }

    public void CreateAchievementPopUp(string t_achievementName)
    {
        string achievementTitle = string.Empty;

        if( displayName )
        {
            achievementTitle = userName + " : " + t_achievementName;
        }
        else
        {
            achievementTitle = t_achievementName;
        }

        Canvas canvas = FindAnyObjectByType<Canvas>();

        if (canvas == null)
        {
            GameObject canvasObject = new GameObject("Canvas");
            canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        }

        GameObject achievementPopUp = new GameObject("AchievementPopUp");

        achievementPopUp.transform.parent = canvas.transform;

        RectTransform achievementRect = achievementPopUp.AddComponent<RectTransform>();
        achievementRect.anchoredPosition = new Vector2(0, 0);
       

        Image popUpImage = achievementPopUp.AddComponent<Image>();
        popUpImage.color = Color.white;


        GameObject textObject = new GameObject("Achievement Title");

        textObject.transform.parent = achievementPopUp.transform;
        Text achievmentTitle = textObject.AddComponent<Text>();

        achievmentTitle.transform.position = achievementPopUp.transform.position;
        achievmentTitle.text = achievementTitle;
        achievmentTitle.color = Color.black;
        achievmentTitle.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        achievmentTitle.fontSize = 20;
        
        RectTransform titleDimension = textObject.GetComponent<RectTransform>();
        Vector2 titleSize = titleDimension.sizeDelta;

        achievementRect.sizeDelta = titleSize;
    }
}
