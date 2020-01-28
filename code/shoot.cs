using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    public GameObject bullet_prefab;
    public float bullet_speed = 1000;
    //public Vector3 forceDirection;
    AudioSource AS;

    // Use this for initialization
    void Start () {
        AS = transform.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponentInParent<tank_controller_occupy>().hp > 0)
        {
            if (i < 3)
            {
                i += Time.deltaTime;
            }
            if (i > 1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    i = 0;
                    Camera c = Camera.main;

                    GameObject bullet = (GameObject)Instantiate(bullet_prefab, transform.position, transform.rotation);
                    //bullet.GetComponent<Rigidbody>().AddForce(c.transform.forward * bullet_speed ,ForceMode.Impulse);
                    //bullet.GetComponent<Rigidbody>().AddForce(-transform.parent.transform.forward * bullet_speed, ForceMode.Impulse);
                    bullet.GetComponent<Rigidbody>().AddForce(-transform.forward * bullet_speed, ForceMode.Impulse);
                    AS.Play();
                }
            }
        }
	}
    float i = 2;
}
