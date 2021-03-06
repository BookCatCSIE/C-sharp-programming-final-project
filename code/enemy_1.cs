﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy_1 : MonoBehaviour {

    Collider collider;
    GameObject[] my_tank;

    Quaternion targetRotation;
    Rigidbody body;
    Vector3 walk;
    int mode = 0,x, z,occupy;
    int range;
    public GameObject enemy_bullet;
    public float bullet_speed = 300f;
    int j;
    public GameObject enemy_shoot_pos;
    GameObject[] occupied_point;
    //bool shooted;
    float nextShoot,reborn;
    Vector3 reborn_point;
    // Use this for initialization
    void Start () {
        collider = GetComponent<Collider>();
        my_tank = GameObject.FindGameObjectsWithTag("my_tank");
        //enemy_shoot_pos = GameObject.FindGameObjectWithTag("enemy_shoot_pos");
        body = GetComponent<Rigidbody>();
        //InvokeRepeating("random_walk", 1, 3);
        occupied_point = GameObject.FindGameObjectsWithTag ("area");
        occupy = UnityEngine.Random.Range(0, 5);
        reborn_point = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        range = occupied_point[occupy].GetComponent<occupied_point>().range;
        var delay = 3;
        var reborn_time = 20;
        if (mode != 3)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Vector3.Distance(my_tank[i].transform.localPosition, transform.localPosition) < detect_range)
                {
                    mode = 1;
                    enemy_speed = 20;
                    j = i;
                    break;
                }
                else
                {
                    mode = 0;
                    enemy_speed = 20;
                }
            }
        }
        if (hp > 0)
        {
            if (mode == 1)
            {
                Vector3 vector, vector1;
                vector = my_tank[j].transform.localPosition - transform.localPosition;
                vector = vector - new Vector3(0, vector.y, 0);
                vector1 = my_tank[j].transform.position - transform.position;
                vector1 = vector1 - new Vector3(0, vector1.y, 0);
                targetRotation = Quaternion.LookRotation(vector1, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed);
                if (Vector3.Distance(my_tank[j].transform.localPosition, transform.localPosition) > 20)
                {

                    transform.position += enemy_speed * vector.normalized * Time.deltaTime;
                }
                else
                {
                    transform.position -= enemy_speed * vector.normalized * Time.deltaTime;
                }
                if (Time.time > nextShoot)
                {
                    nextShoot = Time.time + delay;
                    Invoke("enemy_shoot", 3);
                }
            }
            else if (mode == 0)
            {
                go_occupy();
            }
            else if(mode==3)
            {
                targetRotation = Quaternion.LookRotation(walk, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed);
                transform.position += enemy_speed * walk.normalized * Time.deltaTime;
            }
        }
        
            //InvokeRepeating("enemy_shoot", 1, 2);
       
        
        if(transform.position.y<-100)
        {
            transform.position = reborn_point;
        }
       
        if (hp <= 0)
        {
            if (hp > -100)
            {
                hp = -200;
                reborn = Time.time + reborn_time;
            }
            if (Time.time > reborn)
            {
                
                hp = 100;
            }
            else
            {
                transform.position = reborn_point;
            }
        }
    }
    void go_occupy()
    {
        if (Vector3.Distance(transform.localPosition, occupied_point[occupy].transform.localPosition) > 20)
        {
            Vector3 vector, vector1;
            vector = occupied_point[occupy].transform.localPosition - transform.localPosition;
            vector = vector - new Vector3(0, vector.y, 0);
            transform.position += enemy_speed * vector.normalized * Time.deltaTime;
            vector1 = occupied_point[occupy].transform.position - transform.position;
            vector1 = vector1 - new Vector3(0, vector1.y, 0);
            targetRotation = Quaternion.LookRotation(vector1, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed);
        }
        if((occupied_point[occupy].GetComponent<occupied_point>().occupy == 0)&& (Vector3.Distance(transform.localPosition, occupied_point[occupy].transform.localPosition) <40))
        {
            occupy = UnityEngine.Random.Range(0, 5);
        }
        
       
    }

    void OnCollisionEnter(Collision collision)
    {
        random_walk();
        if (collision.gameObject.tag == "my_tank")
        {
           
        }
        if (collision.gameObject.tag == "my_bullet")
        {

            hp -= 10;
        }
    }

    void random_walk()
    {
        x = UnityEngine.Random.Range(-10, 10);
        z = UnityEngine.Random.Range(-10, 10);
        walk = new Vector3(x, 0, z).normalized;
        mode = 3;
        Invoke("reset_mode", 1);
    }

    void reset_mode()
    {
        mode = 1;
    }

    void enemy_shoot()  //void enemy_shoot()  //IEnumerator
    {
        //yield return new WaitForSeconds(5);
        //yield new WaitForSeconds(5);
        GameObject bullet = Instantiate(enemy_bullet, enemy_shoot_pos.transform.position, enemy_shoot_pos.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce((-enemy_shoot_pos.transform.forward) * bullet_speed, ForceMode.Impulse);
    }

    [SerializeField]
    public float enemy_speed, turnSpeed;
    [SerializeField]
    int detect_range, hp = 100;
}
