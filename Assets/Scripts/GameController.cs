using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] List<GameObject> MobsTemplate;
    List<Mobs> Mobs;
    float Timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
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
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            Debug.Log("TIME OUT!");
        }
    }

    void TouchCount()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log(Input.touchCount);
        }
    }
}
