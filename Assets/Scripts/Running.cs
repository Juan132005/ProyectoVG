using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Running : MonoBehaviour
{
    private string laneChange = "n";
    public ScoreManager scoreManager;
    public int numeroAsignado=0;
    private string midJump = "n";
    public cameraChange cameraChanger;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 2);
    }

  
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.A)) && (laneChange=="n") && (transform.position.x>-.9)){
            GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 2);
            laneChange = "y";
            StartCoroutine(stopLaneCh());
        }
        if((Input.GetKeyDown(KeyCode.D)) && (laneChange=="n")&& (transform.position.x< .9)){
            GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 2);
            laneChange = "y";
            StartCoroutine(stopLaneCh());  
        }
        if(Input.GetKeyDown(KeyCode.Space) && (transform.position.y> -1.6) && (transform.position.y< 1.6) && (midJump=="n")){
            GetComponent<Rigidbody>().velocity = new Vector3(0, 1.5f, 2);
            midJump = "y";
            StartCoroutine(stopJump());  
        }
        
    }
    IEnumerator stopJump()
    {
        yield return new WaitForSeconds(.7f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, -1.5f, 2);
        yield return new WaitForSeconds(.7f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 2);
        midJump = "n";
    }
    IEnumerator stopLaneCh()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 2);
        laneChange = "n";
        //Debug.Log(GetComponent<Transform>().position);
    }
    private void OnTriggerEnter(Collider other){
        if (other.tag=="obstacle"){
            scoreManager.AddPoints(-100);
        }
        if (other.tag == "button1")
        {
            numeroAsignado=1;
        }
        if (other.tag == "button2")
        {
           numeroAsignado=2;
        }

    }
}
