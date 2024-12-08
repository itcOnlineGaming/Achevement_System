using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AchievementManager achievementTracker = new AchievementManager();
    // Start is called before the first frame update
    void Start()
    {
        AchievementPopUpGlobalSettings.settings.achievementTTL = 5f;
        AchievementPopUpGlobalSettings.settings.achievmentPosition = new Vector2 (0, 0);
        AchievementPopUpGlobalSettings.settings.achievementFont = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        AchievementPopUpGlobalSettings.settings.achievementImageSize = new Vector2(600, 200);
        AchievementPopUpGlobalSettings.settings.achievementBackroundColor = Color.white;

        achievementTracker.userName = "Josh";
        achievementTracker.displayName = true;
        achievementTracker.useGlobalDefaults = true;    
        achievementTracker.AddAchievement(Achievements.PressedV);

    }

    // Update is called once per frame
    void Update()
    {
        PressedButtton();
    }

    bool PressedButtton()
    {
        if( Input.GetKeyDown(KeyCode.V))
        {
            achievementTracker.CompletedAchievement(Achievements.PressedV);
            return true;
        }

        return false;
    }
}
