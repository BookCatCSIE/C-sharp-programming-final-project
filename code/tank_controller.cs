using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tank_controller : MonoBehaviour {

    public float speed = 10.0F;
    Rigidbody rb;
    GameObject hp_image;
    GameObject[] tank_body;
    bool lose=false;
    public Slider hp_bar;
    Vector3 reborn_point;

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;  //游標鎖定在畫面中，不顯示
        rb = GetComponent<Rigidbody>();
        //hp_image = GameObject.FindGameObjectWithTag("hp");
        tank_body = GameObject.FindGameObjectsWithTag("tank_body");
        reborn_point = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float tr = Input.GetAxis("Vertical") * speed;     //前後
        //float str = Input.GetAxis("Horizontal") * speed;  //左右
        //"Vertical" and "Horizontal" in Edit -> Project Setting -> Input
        tr *= Time.deltaTime;
        //str *= Time.deltaTime;

        transform.Translate(0, 0, -tr);  //move in x anis and z axis

        if (Input.GetKeyDown(KeyCode.B))
        {
            Cursor.lockState = CursorLockMode.None;//按esc游標脫離畫面，顯示
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
           Cursor.lockState = CursorLockMode.Locked;
        }
        
        if (Input.GetKeyDown("escape"))
        {
            Scene cur_scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
        }

        if (hp <= 0)
        {
            transform.position = reborn_point;
            hp = 100;
        }
        else if (hp >= 100)
        {
            //hp_image.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 15);
            hp_bar.value = 100;
        }
        else
        {
            //hp_image.GetComponent<RectTransform>().sizeDelta = new Vector2(hp, 15);
            hp_bar.value = hp;
        }

        /*if (transform.position.y < -27)
        {
            //this.transform.position.y = -26;
            //transform.position.Set(transform.position.x,-25, transform.position.z);
            Vector3 pos = new Vector3(transform.position.x, -25, transform.position.z);
            transform.position = pos;
        }*/

        if (Input.GetKeyDown(KeyCode.V))
        {
            Vector3 pos = new Vector3(transform.position.x, -25, transform.position.z);
            transform.position = pos;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy_bullet")
        {
            hp = hp - 5;
        }
        else if (collision.gameObject.tag == "red_hp" && !lose)
        {
            hp = hp + 10;
            collision.gameObject.GetComponent<SphereCollider>().enabled = false;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        
    }

    void lose_scene()
    {
        Scene cur_scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(2);
    }
    
    [SerializeField]
    public int hp=100;
}
