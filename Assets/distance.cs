using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public GameObject Object1;
    public GameObject Objetc2;
   
    private float distance;
    public Text distancetxt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetDistance();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Object1.transform.position, Objetc2.transform.position);
        SetDistance();
    }
    void SetDistance()
    {
        distancetxt.text = "Distancia: " + distance.ToString();


    }

}
