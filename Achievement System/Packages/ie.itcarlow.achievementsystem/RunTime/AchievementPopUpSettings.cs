using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class AchievementPopUpSettings 
{

    /// <summary>
    /// Pop up time to live
    /// </summary>
    static public float achievementTTL = 5f;
    /// <summary>
    /// Position of pop up on screen
    /// </summary>
    static public Vector2 achievmentPosition = Vector2.zero;

    /// <summary>
    /// Desired font of the achievement text
    /// </summary>
    static public Font achievementFont = null;

    /// <summary>
    /// Image of the achievement background
    /// </summary>
    static public Sprite achievementImage = null;

    /// <summary>
    /// 
    /// </summary>
    static public Color achievementBackroundColor = new Color(-1f, -1f, -1f );


    static public IEnumerator DestroyGameObject( GameObject t_gameObject)
    {
        yield return new WaitForSeconds(achievementTTL);

        DestroyGameObject(t_gameObject);
    }

}
