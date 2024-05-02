using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : MonoBehaviour
{
    public ScoreManager scoreManager;
    public int numeroAsignado = 0;
    private bool midJump = false;
    private bool laneChange = false;
    private int currentLane = 1; // Empieza en el carril del medio
    private float[] lanes = { -1f, 0f, 1f }; // Posiciones x de los carriles

    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 2);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !laneChange && currentLane > 0)
        {
            StartCoroutine(ChangeLane(-1));
        }
        if (Input.GetKeyDown(KeyCode.D) && !laneChange && currentLane < lanes.Length - 1)
        {
            StartCoroutine(ChangeLane(1));
        }
        if (Input.GetKeyDown(KeyCode.Space) && !midJump)
        {
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump()
    {
        midJump = true;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 1.5f, 2);
        yield return new WaitForSeconds(.7f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, -1.5f, 2);
        yield return new WaitForSeconds(.7f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 2);
        midJump = false;
    }

    IEnumerator ChangeLane(int direction)
    {
        laneChange = true;
        int targetLane = currentLane + direction;
        float targetX = lanes[targetLane];
        while (Mathf.Abs(transform.position.x - targetX) > 0.1f)
        {
            float moveX = Mathf.MoveTowards(transform.position.x, targetX, Time.deltaTime * 5f);
            transform.position = new Vector3(moveX, transform.position.y, transform.position.z);
            yield return null;
        }
        currentLane = targetLane;
        laneChange = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {
            scoreManager.AddPoints(-100);
        }
        if (other.tag == "button1")
        {
            numeroAsignado = 1;
        }
        if (other.tag == "button2")
        {
            numeroAsignado = 2;
        }
    }
}
