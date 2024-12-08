using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AchievementSystem achievementTracker = new AchievementSystem();
    // Start is called before the first frame update
    void Start()
    {
        AchievementPopUpGlobalSettings.settings.achievementTTL = 5f;
        AchievementPopUpGlobalSettings.settings.achievmentPosition = new Vector2 (0, 0);
        AchievementPopUpGlobalSettings.settings.achievementFont = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        AchievementPopUpGlobalSettings.settings.achievementImageSize = new Vector2(600, 200);
        AchievementPopUpGlobalSettings.settings.achievementBackroundColor = Color.white;

        AchievementSystem.Instance.addProfile("Josh", true);

        achievementTracker.useGlobalDefaults = true;    
        achievementTracker.AddAchievementToProfiles(Achievements.PressedV);

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
            AchievementSystem.Instance.CompletedAchievement(0, Achievements.PressedV);
            return true;
        }

        return false;
    }
}
