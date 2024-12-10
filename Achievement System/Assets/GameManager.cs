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
        demoSettign1();
        demoSettign2();
        addPlayers();   




        AchievementSystem.Instance.useGlobalDefaults = true;

        AchievementSystem.Instance.AddAchievementToProfiles(Achievements.PressedV);
        AchievementSystem.Instance.AddAchievementToProfiles(Achievements.PressedB);
        AchievementSystem.Instance.AddAchievementToProfiles(Achievements.PressedC);

    }

    void setUpGlobals()
    {
        AchievementPopUpGlobalSettings.settings.timeToLive = 5f;
        AchievementPopUpGlobalSettings.settings.position = new Vector2(0, 0);
        AchievementPopUpGlobalSettings.settings.textFont = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        AchievementPopUpGlobalSettings.settings.textColor = Color.white;
        AchievementPopUpGlobalSettings.settings.backgroundSize = new Vector2(400, 200);
        AchievementPopUpGlobalSettings.settings.backgroundColor = Color.black;
    }

    void demoSettign1()
    {
        setting1.timeToLive = 5f;
        setting1.position = new Vector2(0, 0);
        setting1.textFont = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        setting1.textColor = Color.red;
        setting1.backgroundSpirte = Resources.Load<Texture2D>("box2");
        setting1.backgroundSize = new Vector2(600, 200);
        setting1.backgroundColor = Color.white;
    }

    void demoSettign2()
    {
        setting2.timeToLive = 5f;
        setting2.position = new Vector2(0, 0);
        setting2.textFont = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        setting2.textColor = Color.yellow;
        setting2.backgroundSpirte = Resources.Load<Texture2D>("star");
        setting2.backgroundSize = new Vector2(200, 200);
        setting2.backgroundColor = Color.white;
        setting2.textPadding = new Vector2(225, 225);
    }

    void addPlayers()
    {
        player1 = AchievementSystem.Instance.addProfile("Joe", true);
        player2 = AchievementSystem.Instance.addProfile("john", false);
    }

    // Update is called once per frame
    void Update()
    {
        PressedButtton();
    }

    bool PressedButtton()
    {
        if( Input.GetKeyDown(KeyCode.C))
        {

            AchievementSystem.Instance.useGlobalDefaults = true;
            if (player1Turn)
            {
                AchievementSystem.Instance.CompletedAchievement(player1, Achievements.PressedC);
                player1Turn = !player1Turn;
            }
            else
            {
                AchievementSystem.Instance.CompletedAchievement(player2, Achievements.PressedC);
                player1Turn = !player1Turn;
            }

            return true;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            AchievementSystem.Instance.useGlobalDefaults = false;
            AchievementSystem.Instance.userDefinedSettings = setting1;

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

        if (Input.GetKeyDown(KeyCode.B))
        {
            AchievementSystem.Instance.useGlobalDefaults = false;
            AchievementSystem.Instance.userDefinedSettings = setting2;

            if (player1Turn)
            {
                AchievementSystem.Instance.CompletedAchievement(player1, Achievements.PressedB);
                player1Turn = !player1Turn;
            }
            else
            {
                AchievementSystem.Instance.CompletedAchievement(player2, Achievements.PressedB);
                player1Turn = !player1Turn;
            }

            return true;
        }



        return false;
    }

}
