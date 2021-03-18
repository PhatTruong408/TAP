using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] List<GameObject> MobsTemplate;
    [SerializeField] GameObject text;
    [SerializeField] Slider TimeSlider;
    List<Mobs> Mobs;
    Player player;
    float maxTime = 5f;
    float timeLeft = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        player = new Player();
        GenerateMobs();
    }

    void GenerateMobs()
    {
        Mobs = new List<Mobs>();
        for (int i = 0; i < MobsTemplate.Count; i++)
        {
            GameObject newMob = Instantiate(MobsTemplate[i], GameObject.FindGameObjectWithTag("mobs").transform);
            newMob.transform.position = new Vector2(i * 100, i * 100);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeCountdown();
        TouchCount();     
    }

    void TimeCountdown()
    {
        timeLeft -= Time.deltaTime;
        TimeSlider.value = timeLeft / maxTime;
        if (timeLeft < 0)
        {

        }
    }

    int i = 0;
    void TouchCount()
    {
        if (Input.touchCount > 0)
        {          
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                i++;
                player.TapCounting();
                text.gameObject.GetComponent<Text>().text = $"tap: {i} tapcount: {player.tapCount} mobs: {MobsTemplate.Count}";
                CheckResult();
            }
        }
    }

    void CheckResult()
    {
        if(player.tapCount == MobsTemplate.Count)
        {
            text.gameObject.GetComponent<Text>().text = "Win";
        }    
    }
}
