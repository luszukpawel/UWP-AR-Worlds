using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private GameObject g;
    void Start()
    {
        g = GameObject.FindGameObjectWithTag("Text");
        g.SetActive(false);
        Debug.Log("Start");
       // ShowText();
    }
    public void ShowText()
    { 
        g.transform.gameObject.SetActive(true);
    }

    

}
