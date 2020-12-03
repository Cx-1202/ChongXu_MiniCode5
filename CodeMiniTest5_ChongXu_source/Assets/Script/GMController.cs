using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GMController : MonoBehaviour
{
    int timeleft;
    public static GMController gmInstance;

    public GameObject PlayerGO;
    public GameObject addEnergyPrefab;
    public GameObject minusEnergyPrefab;
    public Text TimerText;

    public int numberofSpawn;
    public float levelTime;

    // Start is called before the first frame update
    void Start()
    {
        if ( gmInstance == null)
        {
            gmInstance = this;
        }

        //instance addEnergyPrefab At Random Position
            for (int i = 0; i < numberofSpawn; i++)
            {
                Vector3 randomPos = new Vector3(Random.Range(-15, 15), 0.4f, Random.Range(-15, 15));

                if (Random.Range(0, 2) < 1)
                {
                    Instantiate(addEnergyPrefab, randomPos, Quaternion.identity);
                }
                else
                {
                    Instantiate(minusEnergyPrefab, randomPos, Quaternion.identity);
                }
            }
    }

    // Update is called once per frame
    void Update()
    {
        if ( levelTime > 0)
        {
            levelTime -= Time.deltaTime;
            timeleft = (int)levelTime;
            TimerText.text = ("Timer : ") + timeleft.ToString();
        }
        else
        {
            levelTime = 0;
            TimerText.text = ("Times up ! ");
            SceneManager.LoadScene("EndScene");
        }
        
    }

    public string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time - 60 * minutes;
        int milliseconds = (int)(1000 * (time - minutes * 60 - seconds));
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
    
     public void AddTime()
     {
        levelTime += 5;
            for (int i = 0; i < 1; i++)
            {
                Vector3 randomPos = new Vector3(Random.Range(-15, 15), 0.4f, Random.Range(-15, 15));

                if (Random.Range(0, 2) < 1)
                {
                    Instantiate(addEnergyPrefab, randomPos, Quaternion.identity);
                }
                else
                {
                    Instantiate(minusEnergyPrefab, randomPos, Quaternion.identity);
                }
            }
     }


}
