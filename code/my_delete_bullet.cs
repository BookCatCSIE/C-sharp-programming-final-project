using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class my_delete_bullet : MonoBehaviour {

    public GameObject explosion;
    //AudioSource AS;

    // Use this for initialization
    void Start () {
        //AS = gameObject.transform.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "my_tank")
        {
            //AS.Play();
            GameObject explo = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.transform.gameObject);
            //Destroy(explo, 5);
        }
    }


}
