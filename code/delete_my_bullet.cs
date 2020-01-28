using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_my_bullet : MonoBehaviour
{



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "my_tank")
        {
            Destroy(gameObject);
            Object obj = Resources.Load("Pyroclastic Puff");
            GameObject gobj = new GameObject();
            gobj = Instantiate(obj) as GameObject;
            gobj.transform.localPosition = transform.localPosition;
        }

    }
}
