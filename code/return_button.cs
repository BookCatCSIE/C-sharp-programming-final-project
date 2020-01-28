using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class return_button : MonoBehaviour, IPointerClickHandler
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    } 

    public void OnPointerClick(PointerEventData e)
    {
        Scene cur_scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(0);
    }
}
