using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class occupied_point : MonoBehaviour {
    Light light;
    int  point = 0;
    public int occupy;
    int my_number,enemy_number;
    GameObject[] my_tank;
    GameObject[] enemy_tank;
	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        my_tank = GameObject.FindGameObjectsWithTag("my_tank");
        enemy_tank = GameObject.FindGameObjectsWithTag("enemy_tank");
    }
	
	// Update is called once per frame
	void Update () {
        my_number = 0;
        enemy_number = 0;
        for(int i=0;i<3;i++)
        {
            if (Vector3.Distance(my_tank[i].transform.localPosition, transform.localPosition) <=range)
            {
                my_number++;
            }
            if (Vector3.Distance(enemy_tank[i].transform.localPosition, transform.localPosition) <=range)
            {
                enemy_number++;
            }

        }

        if(point>=0)
        {
            light.intensity = point;
        }
        else
        {
            light.intensity = -point;
        }


        point += my_number - enemy_number;
        if(point>=1000)
        {
            point=1000;
            
        }
        else if(point<=-1000)
        {
            point = -1000;
        }

        if (point <= -500)
        {
            light.color =Color.red;
            occupy = 0;
        }
        else if(point>=500)
        {
            light.color = Color.blue;
            occupy = 1;
        }
        else
        {
            light.color = Color.white;
            occupy = 2;
        }
    }
    [SerializeField]
    public int range;
}
