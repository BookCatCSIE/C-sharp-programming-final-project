using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_red : MonoBehaviour {

    public GameObject red;

    void spawn()
    {
        for (int i = 0; i < 2; i++)
        {
            Vector3 red_pos = new Vector3(this.transform.position.x + Random.Range(-100, 100), this.transform.position.y, this.transform.position.z + Random.Range(-100, 100));
            Instantiate(red, red_pos, Quaternion.identity);
        }
    }

    // Use this for initialization
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
