using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_enemy_bullet : MonoBehaviour {


    public GameObject explosion;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "enemy_tank")
        {
            GameObject explo = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.transform.gameObject); 
        }
        
    }
}
