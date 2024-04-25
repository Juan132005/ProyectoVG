using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Running : MonoBehaviour
{
    private string laneChange = "n";
    private string midJump = "n";
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 2);
    }

  
    void Update()
    {
        if((Input.GetKey("a")) && (laneChange=="n") && (transform.position.x>-.9)){
            GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 2);
            laneChange = "y";
            StartCoroutine(stopLaneCh());
        }
        if((Input.GetKey("d")) && (laneChange=="n")&& (transform.position.x< .9)){
            GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 2);
            laneChange = "y";
            StartCoroutine(stopLaneCh());  
        }
        if(Input.GetKey("space") && (transform.position.y> -1.6) && (transform.position.y< 1.6) && (midJump=="n")){
            GetComponent<Rigidbody>().velocity = new Vector3(0, 1.5f, 2);
            midJump = "y";
            StartCoroutine(stopJump());  
        }
    }
    IEnumerator stopJump()
    {
        yield return new WaitForSeconds(.3f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, -1.5f, 2);
        yield return new WaitForSeconds(.3f);
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
            Debug.Log("Has perdido puntos!");
        }
    }
}
