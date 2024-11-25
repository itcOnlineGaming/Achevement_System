using PlasticGui.Help;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Time 2.30hrs
public class AchievementSystem : MonoBehaviour
{
    public delegate bool condition();
  
    public static AchievementSystem instance { get; private set; }   

    private List<string> titles = new List<string>();
    private List<condition> conditions = new List<condition>();

    private void Awake()
    {
        // Singeleton management
        if( instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;    
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="title"></param>
    public void addAchievement(condition condition, string title )
    {
        conditions.Add( condition);
        titles.Add(title);  
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < conditions.Count; i++)
        {

            if (conditions[i]())
            {
                createAchievementPopUp(titles[i] ); 

                conditions.RemoveAt(i);
                titles.RemoveAt(i);   
            }
        }   
    }


    private void createAchievementPopUp(string title)
    {
        //Canvas canvas = FindAnyObjectByType<Canvas>();

        //if( canvas == null ) 
        //{
        //    GameObject canvasObject = new GameObject("Canvas");
        //    canvas = canvasObject.AddComponent<Canvas>();
        //    canvas.renderMode = RenderMode.ScreenSpaceOverlay;
       
        //}

        //GameObject achievementPopUp = new GameObject("AchievementPopUp");
        
        //achievementPopUp.transform.parent = canvas.transform;  

        //RectTransform achievementRect = achievementPopUp.AddComponent<RectTransform>();
        //achievementRect.anchoredPosition = new Vector2(0, 0);
        //achievementRect.sizeDelta = new Vector2(200, 200);

        //Image popUpImage = achievementPopUp.AddComponent<Image>();  
        //popUpImage.color = Color.white;

        
        //GameObject textObject = new GameObject("Achievement Title");

        //textObject.transform.parent = achievementPopUp.transform;
        //Text achievmentTitle = textObject.AddComponent<Text>();

        //achievmentTitle.transform.position = achievementPopUp.transform.position; 
        //achievmentTitle.text = title;
        //achievmentTitle.color = Color.black;
        //achievmentTitle.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        //achievmentTitle.fontSize = 20;

        //Instantiate(achievementPopUp);
    }
}
