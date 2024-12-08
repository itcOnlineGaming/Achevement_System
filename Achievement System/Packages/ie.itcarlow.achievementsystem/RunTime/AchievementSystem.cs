using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSystem : MonoBehaviour 
{

    public static AchievementSystem _instance;

    List<AchievementProfile> players = new List<AchievementProfile>();

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


    public static AchievementSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                // Check if an existing GameManager is present in the scene
                _instance = FindObjectOfType<AchievementSystem>();

                if (_instance == null)
                {
                    // No existing GameManager found, so create a new GameObject and add this script
                    GameObject em = new GameObject("EventManager");
                    _instance = em.AddComponent<AchievementSystem>();

                    // Optionally, make this object persistent
                    DontDestroyOnLoad(em);
                }
            }
            return _instance;
        }
    }

    public void addProfile(string t_username, bool t_displayNameOnPopUp)
    {
        players.Add(new AchievementProfile(t_username, t_displayNameOnPopUp));
    }

    public void AddAchievementToProfiles(string t_achievement )
    {
        for(int i = 0; i < players.Count; i++) 
        { 
            // if it hasnt been competeted already
            if(!players[i].completedAchievements.Contains(t_achievement))
            {
                players[i].uncompletedAchievements.Add(t_achievement);
            }
        }
    }

    public void CompletedAchievement(int playerIndex,  string t_achievement)
    {
        // if it hasnt been competeted already
        if (!players[playerIndex].completedAchievements.Contains(t_achievement))
        {
            players[playerIndex].uncompletedAchievements.Remove(t_achievement);
            players[playerIndex].completedAchievements.Add(t_achievement);
            CreateAchievementPopUp(playerIndex, t_achievement);
        }
       
    }

    public void CreateAchievementPopUp(int playerIndex, string t_achievementName)
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

        if (players[playerIndex].displayName)
        {
            achievementTitle = players[playerIndex].userName + "\n" + t_achievementName;
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
