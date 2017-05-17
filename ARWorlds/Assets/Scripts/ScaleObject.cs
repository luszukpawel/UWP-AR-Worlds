using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    private GameObject[] Models;

    void Start()
    {
        Models = GameObject.FindGameObjectsWithTag("Model");
    }
    public float Scale = 1f;
    void Update()
    {
        Start();
        foreach (GameObject model in Models)
        {
            
            model.transform.localScale = new Vector3(Scale, Scale, Scale);
        }
        
    }
    public void AdjustScale(float newScale)
    {
        Scale = newScale;
    }
}
