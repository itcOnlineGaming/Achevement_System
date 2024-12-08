using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    int player1;
    int player2;

    bool player1Turn = false;

    AchievementPopUpSetting setting1 = new AchievementPopUpSetting();
    AchievementPopUpSetting setting2 = new AchievementPopUpSetting();
    AchievementPopUpSetting setting3 = new AchievementPopUpSetting();



    // Start is called before the first frame update
    void Start()
    {

        setUpGlobals();
        addPlayers();   




        AchievementSystem.Instance.useGlobalDefaults = true;

        AchievementSystem.Instance.AddAchievementToProfiles(Achievements.PressedV);

    }

    void setUpGlobals()
    {
        AchievementPopUpGlobalSettings.settings.timeToLive = 5f;
        AchievementPopUpGlobalSettings.settings.position = new Vector2(0, 0);
        AchievementPopUpGlobalSettings.settings.textFont = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        AchievementPopUpGlobalSettings.settings.textColor = Color.white;
        AchievementPopUpGlobalSettings.settings.backgroundSpirte = Resources.Load<Texture2D>("box");
        AchievementPopUpGlobalSettings.settings.backgroundSize = new Vector2(600, 200);
        AchievementPopUpGlobalSettings.settings.backgroundColor = Color.white;
    }

    void addPlayers()
    {
        player1 = AchievementSystem.Instance.addProfile("Josh", true);
        player2 = AchievementSystem.Instance.addProfile("Daire", false);
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
            if (player1Turn)
            {
                AchievementSystem.Instance.CompletedAchievement(player1, Achievements.PressedV);
                player1Turn = !player1Turn;
            }
            else
            {
                AchievementSystem.Instance.CompletedAchievement(player2, Achievements.PressedV);
                player1Turn = !player1Turn;
            }

            return true;
        }

        

        return false;
    }
}
