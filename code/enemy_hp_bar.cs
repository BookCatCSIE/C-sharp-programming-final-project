using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_hp_bar : MonoBehaviour {

    public Slider hp_bar;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        hp_bar.value = GetComponent<enemy>().hp;
	}

    void OnCollisionEnter(Collision collision)
    {
       
    }
}
