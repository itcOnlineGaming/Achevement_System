using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AchievementTracker achievementTracker = new AchievementTracker();
    // Start is called before the first frame update
    void Start()
    {
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
