using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour {

    Collider collider;
    GameObject my_tank;

    Quaternion targetRotation;
    Rigidbody body;
    Vector3 walk;
    int mode = 0,x, z;

    public GameObject enemy_bullet;
    public float bullet_speed = 70f;

    public GameObject enemy_shoot_pos;
    //bool shooted;
    float nextShoot;
    Vector3 reborn_point;
    Image image;

    // Use this for initialization
    void Start () {
        collider = GetComponent<Collider>();
        my_tank = GameObject.FindGameObjectWithTag("my_tank");
        //enemy_shoot_pos = GameObject.FindGameObjectWithTag("enemy_shoot_pos");
        body = GetComponent<Rigidbody>();
        InvokeRepeating("random_walk", 1, 3);
        image = GetComponent<Make_Radar_Object>().image;
        reborn_point = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        var delay = 1;

        if (Vector3.Distance(my_tank.transform.localPosition, transform.localPosition) < detect_range)
        {
            mode = 1;
            enemy_speed = 20;
            //Radar.RegisterRadarObject(this.gameObject, image);
        }
        else if (Vector3.Distance(my_tank.transform.localPosition, transform.localPosition) < 300)  //////new add
        {
            Radar.RegisterRadarObject(this.gameObject, image);   //////new add
        }
        else
        {
            mode = 0;
            enemy_speed = 15;
            Radar.RemoveRadarObject(this.gameObject); //////new add
        }
        if (mode == 1)
        {
            Vector3 vector, vector1;
            vector = my_tank.transform.localPosition - transform.localPosition;
            vector = vector - new Vector3(0, vector.y, 0);
            vector1 = my_tank.transform.position - transform.position;
            vector1 = vector1 - new Vector3(0, vector1.y, 0);
            targetRotation = Quaternion.LookRotation(vector1, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed);
            if (Vector3.Distance(my_tank.transform.localPosition, transform.localPosition) > 20)
            {

                transform.position += enemy_speed * vector.normalized * Time.deltaTime;
            }
            else
            {
                transform.position -= enemy_speed * vector.normalized * Time.deltaTime;
            }

            //InvokeRepeating("enemy_shoot", 1, 2);
            if (Time.time > nextShoot)
            {
                nextShoot = Time.time + delay;
                Invoke("enemy_shoot", 3);
            }
        }
        else
        {
            transform.position += enemy_speed * walk * Time.deltaTime;
            targetRotation = Quaternion.LookRotation(walk, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed);
        }
        if(transform.position.y<-200)
        {
            hp = 0;
        }

        if (hp <= 0)
        {
            transform.position = reborn_point;
            hp = 100;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "my_tank")
        {
            Vector3 DirectionBack = transform.TransformDirection(Vector3.back);
            body.AddForce(DirectionBack * 500);
        }
        if (collision.gameObject.tag == "my_bullet")
        {

            hp -= 5;
        }
        else
        {
            random_walk();
        }
    }

    void random_walk()
    {
        x = UnityEngine.Random.Range(-10, 10);
        z = UnityEngine.Random.Range(-10, 10);
        walk = new Vector3(x, 0, z).normalized;
    }

    void enemy_shoot()  //void enemy_shoot()  //IEnumerator
    {
        //yield return new WaitForSeconds(5);
        //yield new WaitForSeconds(5);
        GameObject bullet = Instantiate(enemy_bullet, enemy_shoot_pos.transform.position, enemy_shoot_pos.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(-enemy_shoot_pos.transform.forward * bullet_speed, ForceMode.Impulse);
    }

    [SerializeField]
    public float enemy_speed, turnSpeed;
    [SerializeField]
    public int detect_range, hp = 100;
}
