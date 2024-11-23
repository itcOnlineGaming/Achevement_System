using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        AchievementSystem.instance.addAchievement(PressedButtton, "You Can Press V !");
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    bool PressedButtton()
    {
        if( Input.GetKeyDown(KeyCode.V))
        { 
            return true;
        }

        return false;
    }
}
