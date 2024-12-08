using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {


        AchievementPopUpGlobalSettings.settings.timeToLive = 5f;
        AchievementPopUpGlobalSettings.settings.position = new Vector2 (0, 0);
        AchievementPopUpGlobalSettings.settings.textFont = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        AchievementPopUpGlobalSettings.settings.textColor = Color.white;
        AchievementPopUpGlobalSettings.settings.backgroundSpirte = Resources.Load<Texture2D>("box");
        AchievementPopUpGlobalSettings.settings.backgroundSize = new Vector2(600, 200);
        AchievementPopUpGlobalSettings.settings.backgroundColor = Color.black;

        AchievementSystem.Instance.addProfile("Josh", true);

        AchievementSystem.Instance.useGlobalDefaults = true;
        AchievementSystem.Instance.AddAchievementToProfiles(Achievements.PressedV);

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
