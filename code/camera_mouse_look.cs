using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_mouse_look : MonoBehaviour {

    Vector2 mouselook;  //記錄total mousemovemevt
    Vector2 smoothv;  //smooth down the movement
    public float sensitivity = 10.0f;
    public float smoothing = 1.0f;

    GameObject charac;

    // Use this for initialization
    void Start () {
        charac = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));  //change of mousemovement
        //"Mouse X" and "Mouse Y" in Edit -> Project Setting -> Input
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothv.x = Mathf.Lerp(smoothv.x, md.x, 1f / smoothing)/8;
        smoothv.y = Mathf.Lerp(smoothv.y, md.y, 1f / smoothing)/8;
        mouselook += smoothv;

        //transform.localRotation = Quaternion.AngleAxis(-mouselook.y, Vector3.right);  //rotate right axis (rotate x axis)
        charac.transform.localRotation=Quaternion.AngleAxis(mouselook.x , charac.transform.up);  //rotate up axis (rotate y axis)
        
        
    }
}
