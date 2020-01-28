using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        i += Time.deltaTime;
        if(i>0.7)
        {
            Destroy(gameObject);
        }
		
	}
    float i = 0;
}
