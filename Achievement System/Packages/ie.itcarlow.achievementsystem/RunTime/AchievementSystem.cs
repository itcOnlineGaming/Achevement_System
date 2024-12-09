using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSystem : MonoBehaviour 
{

    /// <summary>
    /// Singelotn instance
    /// </summary>
    public static AchievementSystem _instance;

    /// <summary>
    /// Stores the players completed achievements and whether you should display their name on the achievement
    /// </summary>
    List<AchievementProfile> playersProfiles = new List<AchievementProfile>();

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

    private List<GameObject> activeAchievements = new List<GameObject>();

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

    /// <summary>
    /// Adds a profile to the system
    /// </summary>
    /// <param name="t_username">Users name </param>
    /// <param name="t_displayNameOnPopUp">Whether their name should pop up in achievement</param>
    public int addProfile(string t_username, bool t_displayNameOnPopUp)
    {
        playersProfiles.Add(new AchievementProfile(t_username, t_displayNameOnPopUp));

        return playersProfiles.Count - 1;
    }

    public AchievementProfile getProfile( int t_playerIndex )
    {
        return playersProfiles[t_playerIndex];  
    }

    /// <summary>
    /// Adds achievement to user
    /// </summary>
    /// <param name="t_achievement">The Achievements</param>
    public void AddAchievementToProfiles(string t_achievement )
    {
        for(int i = 0; i < playersProfiles.Count; i++) 
        { 
            // if it hasnt been competeted already
            if(!playersProfiles[i].completedAchievements.Contains(t_achievement))
            {
                playersProfiles[i].uncompletedAchievements.Add(t_achievement);
            }
        }
    }

    /// <summary>
    /// Directly adds achievement to certain player
    /// </summary>
    /// <param name="t_playerIndex">Certain player</param>
    /// <param name="t_achievement">Achievment</param>
    public void addCompletedAchievement(int t_playerIndex, string t_achievement)
    {
        if (!playersProfiles[t_playerIndex].completedAchievements.Contains(t_achievement))
        {
            playersProfiles[t_playerIndex].completedAchievements.Add(t_achievement);
        }
    }

    /// <summary>
    /// Creates achievement and creates pop up for achievement
    /// </summary>
    /// <param name="playerIndex">the profile we are adding the achievement to</param>
    /// <param name="t_achievement"> the achievement</param>
    public void CompletedAchievement(int playerIndex,  string t_achievement)
    {
        // if it hasnt been competeted already
        if (!playersProfiles[playerIndex].completedAchievements.Contains(t_achievement))
        {
            playersProfiles[playerIndex].uncompletedAchievements.Remove(t_achievement);
            playersProfiles[playerIndex].completedAchievements.Add(t_achievement);



            AchievementPopUpSetting currentForTHisAchievement;

            if (useGlobalDefaults)
            {
                currentForTHisAchievement = AchievementPopUpGlobalSettings.settings;
            }
            else
            {
                currentForTHisAchievement = userDefinedSettings;
            }

            CreateAchievementPopUp(playerIndex, t_achievement, currentForTHisAchievement);
        }
       
    }

    /// <summary>
    /// Creates an achievement with using the achievment name as the title and applying the achievement setting to it to create a custom achievement
    /// </summary>
    /// <param name="playerIndex">Which player it is relative to</param>
    /// <param name="t_achievementName">Title on achievement</param>
    /// <param name="popUpSettings">Settings which will decide aspects like sprite, size, position etc</param>
    public void CreateAchievementPopUp(int playerIndex, string t_achievementName, AchievementPopUpSetting popUpSettings)
    {

        // if there are more than 0 achievements, we start a couritine that delays the pop up til the current one finished
        if ( activeAchievements.Count == 0)
        {
            string achievementTitle = string.Empty;

            
            if (playersProfiles[playerIndex].displayName)
            {
                achievementTitle = "Achievement Unlocked " + playersProfiles[playerIndex].userName + "!" + "\n" + t_achievementName;
            }
            else
            {
                achievementTitle = "Achievement Unlocked!\n" + t_achievementName;
            }

            Canvas canvas = GameObject.FindAnyObjectByType<Canvas>();

            if (canvas == null)
            {
                GameObject canvasObject = new GameObject("Canvas");
                canvas = canvasObject.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            }

            GameObject achievementPopUp = new GameObject(t_achievementName + "AchievementPopUp");

            achievementPopUp.transform.parent = canvas.transform;

            RectTransform achievementRect = achievementPopUp.AddComponent<RectTransform>();
            achievementRect.anchoredPosition = popUpSettings.position;
            achievementRect.sizeDelta = popUpSettings.backgroundSize;

            Debug.Log("Pos: " + popUpSettings.position);

            Image popUpImage = achievementPopUp.AddComponent<Image>();

            if (popUpSettings.backgroundColor != null)
            {
                popUpImage.color = popUpSettings.backgroundColor;
            }


            if (popUpSettings.backgroundSpirte != null)
            {
                popUpImage.sprite = Sprite.Create(popUpSettings.backgroundSpirte, new Rect(0, 0, popUpSettings.backgroundSpirte.width, popUpSettings.backgroundSpirte.height), new Vector2(0.5f, 0.5f));
            }


            GameObject textObject = new GameObject("Achievement Title");

            textObject.transform.parent = achievementPopUp.transform;
            Text achievmentTitle = textObject.AddComponent<Text>();

            achievmentTitle.transform.position = achievementPopUp.transform.position;
            achievmentTitle.text = achievementTitle;
            achievmentTitle.color = popUpSettings.textColor;
            achievmentTitle.font = popUpSettings.textFont;

            // making the text fit the pop up box
            RectTransform titleRect = textObject.GetComponent<RectTransform>();
            titleRect.sizeDelta = achievementRect.rect.size;
            achievmentTitle.resizeTextForBestFit = true;
            achievmentTitle.alignment = TextAnchor.MiddleCenter;

            achievementRect.sizeDelta = popUpSettings.backgroundSize + popUpSettings.textPadding;

           
            StartCoroutine(destroyAchievement(achievementPopUp, popUpSettings.timeToLive));
     


            activeAchievements.Add(achievementPopUp);
        }
        else
        {
            StartCoroutine(delayedPopUp(t_achievementName, playerIndex, popUpSettings.timeToLive * activeAchievements.Count, popUpSettings));
        }

    }

    /// <summary>
    /// destroys said game object after a certain amoutn of time
    /// </summary>
    /// <param name="t_popUp"></param>
    /// <param name="t_timeToLive"></param>
    /// <returns></returns>
    public  IEnumerator destroyAchievement(GameObject t_popUp, float t_timeToLive)
    {

        yield return new WaitForSeconds( t_timeToLive);

        activeAchievements.Remove(t_popUp);
        Destroy(t_popUp );
    }


    public IEnumerator delayedPopUp(string t_achievemnt,int t_playerIndex,float t_delay , AchievementPopUpSetting currentForTHisAchievement)
    {

        yield return new WaitForSeconds(t_delay);

        CreateAchievementPopUp(t_playerIndex, t_achievemnt, currentForTHisAchievement);

    }
}
