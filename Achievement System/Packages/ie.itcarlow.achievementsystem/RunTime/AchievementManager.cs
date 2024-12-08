using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager
{

    public string userName;
    public bool displayName;

    public List<string> uncompletedAchievements = new List<string>();

    /// <summary>
    /// List of achievements that have been completed
    /// </summary>
    public List<string> completedAchievements = new List<string> ();


    /// <summary>
    /// Bool which desices whether you use the the user defined global pop ups or a specified one for this 
    /// user
    /// </summary>
    public bool useGlobalDefaults = true;

    /// <summary>
    /// Will default to the user defined defaults in AchievementPopUpGlobalSettings
    /// Can also be specifically modified if a single achievement needs a different look to the rest
    /// </summary>
    public AchievementPopUpSetting userDefinedSettings = new AchievementPopUpSetting();

    public AchievementManager()
    {
        Debug.Log("Achievement Tracker created");
        userName = string.Empty;
        displayName = false;
  
    }
    public AchievementManager(string t_userName, bool t_displayName)
    {
        Debug.Log("Achievement Tracker created");
        userName = t_userName;
        displayName = t_displayName;
    }


    public void setUserData(string t_userName, bool t_displayName)
    {
        userName = t_userName;
        displayName = t_displayName;
    }

    public void AddAchievement(string t_achievement )
    {
        Debug.Log("Achievement Added");
        uncompletedAchievements.Add(t_achievement);
    }

    public void CompletedAchievement( string t_achievement)
    {
        Debug.Log("Achievement Completed");
        if ( uncompletedAchievements.Contains( t_achievement))
        {
            uncompletedAchievements.Remove(t_achievement);    
            completedAchievements.Add (t_achievement);  
            CreateAchievementPopUp(t_achievement);  
        }
    }

    public void CreateAchievementPopUp(string t_achievementName)
    {
        string achievementTitle = string.Empty;

        AchievementPopUpSetting currentForTHisAchievement;

        if( useGlobalDefaults)
        {
            currentForTHisAchievement = AchievementPopUpGlobalSettings.settings;
        }
        else
        {
            currentForTHisAchievement = userDefinedSettings;
        }

        if (displayName)
        {
            achievementTitle = userName + "\n" + t_achievementName;
        }
        else
        {
            achievementTitle = t_achievementName;
        }

        Canvas canvas = GameObject.FindAnyObjectByType<Canvas>();

        if (canvas == null)
        {
            GameObject canvasObject = new GameObject("Canvas");
            canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        }

        GameObject achievementPopUp = new GameObject(t_achievementName + " AchievementPopUp");

        achievementPopUp.transform.parent = canvas.transform;

        RectTransform achievementRect = achievementPopUp.AddComponent<RectTransform>();
        achievementRect.anchoredPosition = currentForTHisAchievement.achievmentPosition;
        achievementRect.sizeDelta = currentForTHisAchievement.achievementImageSize;

        Debug.Log("Pos: " + currentForTHisAchievement.achievmentPosition);

        Image popUpImage = achievementPopUp.AddComponent<Image>();
        popUpImage.color = currentForTHisAchievement.achievementBackroundColor;


        GameObject textObject = new GameObject("Achievement Title");

        textObject.transform.parent = achievementPopUp.transform;
        Text achievmentTitle = textObject.AddComponent<Text>();

        achievmentTitle.transform.position = achievementPopUp.transform.position;
        achievmentTitle.text = achievementTitle;
        achievmentTitle.color = Color.black;
        achievmentTitle.font = currentForTHisAchievement.achievementFont;

        // making the text fit the pop up box
        RectTransform titleRect = textObject.GetComponent<RectTransform>();
        titleRect.sizeDelta = achievementRect.rect.size;
        achievmentTitle.resizeTextForBestFit = true;
        achievmentTitle.alignment = TextAnchor.MiddleCenter;



    }


}
