using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class result : MonoBehaviour {

    GameObject[] occupied_point;
    int red = 0, blue = 0;
    public Text time;
	// Use this for initialization
	void Start () {
        occupied_point = GameObject.FindGameObjectsWithTag("area");
        InvokeRepeating("timer", 1,1);

    }
	
	// Update is called once per frame
	void Update () {
        if(second<=0)
        {
            game_result();
        }
    }
    void game_result()
    {
        for(int i=0;i<5;i++)
        {
            if(occupied_point[i].GetComponent<occupied_point>().occupy==1)
            {
                blue++;
            }
            if (occupied_point[i].GetComponent<occupied_point>().occupy == 0)
            {
                red++;
            }

        }

        if(blue>red)
        {
            Scene cur_scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(3);
        }
        else if(red>blue)
        {
            Scene cur_scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(4);
        }
        else
        {
            Scene cur_scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(5);
        }
    }
    void timer()
    {
        second--;
        int a = second / 60,b=second%60;
        time.text = a + ":" + b;
    }
    [SerializeField]
    int second = 300;
}
