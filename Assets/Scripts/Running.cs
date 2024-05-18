using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Running : MonoBehaviour
{
    public ScoreManager scoreManager;
    public int numeroAsignado = 0;
    private bool midJump = false;
    private bool laneChange = false;
    private int currentLane = 1; // Empieza en el carril del medio
    private float[] lanes = { -1f, 0f, 1f }; // Posiciones x de los carriles
    public Seleccionar seleccionar;
    public cameraChange cameraChanger;
    public Canvas canvas;
    private int camara;
    private int cambiocamara;
    private int contador;
    private int cuadros;

    void Start()

    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 2);
    }

    void Update()
    {
        if (seleccionar.correcto == 1)
        {
            if (camara == 0) {

                cameraChanger.SwitchCameras();
                camara += 1;
            }
            MoveCharacterToMiddleLane();
            if (Input.GetKeyDown(KeyCode.Space) && !midJump)
            {
                StartCoroutine(Jump());

            }


        }
        else
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
    }

    void MoveCharacterToMiddleLane()
    {
        StartCoroutine(MoveToMiddleLaneCoroutine());
    }

    IEnumerator MoveToMiddleLaneCoroutine()
    {
        yield return new WaitForSeconds(1f); // Esperar 1 segundo

        float targetX = lanes[1]; // Carril del medio (posición x)
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        currentLane = 1; // Actualizar la variable currentLane
    }



    IEnumerator Jump()
    {
        midJump = true;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 3f, 2); // Ajusta la velocidad de ascenso aquí
        yield return new WaitForSeconds(.5f); // Reduce el tiempo de espera para un salto más rápido
        GetComponent<Rigidbody>().velocity = new Vector3(0, -3f, 2); // Ajusta la velocidad de descenso aquí
        yield return new WaitForSeconds(.5f); // Reduce el tiempo de espera para un salto más rápido
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
            Destroy(other.gameObject);
        }
        if (other.tag == "button1")
        {
            contador += 1;
            seleccionar.Boton1();
            if (seleccionar.correcto == 0)
            {
                cuadros += 1;
            }
            if (seleccionar.correcto == 1)
            {
                cuadros += 1;
            }
            cambiocamara = 0;
            // Mover el Canvas
            Vector3 newPosition = canvas.transform.position;
            newPosition.z += 120f;
            canvas.transform.position = newPosition;
            StartCoroutine(WaitAndSwitchCameras());
        }
        if (other.tag == "button2")
        {
            contador += 1;
            seleccionar.Boton2();
            if (seleccionar.correcto == 0)
            {
                cuadros += 1;
            }
            if (seleccionar.correcto == 1)
            {
                cuadros += 1;
            }
            cambiocamara = 0;
            // Mover el Canvas
            Vector3 newPosition = canvas.transform.position;
            newPosition.z += 120f;
            canvas.transform.position = newPosition;
            StartCoroutine(WaitAndSwitchCameras());
        }
        if (other.tag == "dood")
        {
            scoreManager.AddPoints(100);
            Destroy(other.gameObject);
        }
    }
    IEnumerator WaitAndSwitchCameras()
    {
        // Esperar segundos
        yield return new WaitForSeconds(55f);
        if (contador == 5 && cuadros >= 4 && scoreManager.GetCurrentScore() > 2000)
        {
            SceneManager.LoadScene(3);
        }
        else if (contador == 5 && cuadros >= 4 && scoreManager.GetCurrentScore() < 2000)
        {
            SceneManager.LoadScene(2);
        }
        else
        { // Cambiar cámaras
            if (seleccionar.correcto == 1)
            {
                if (cambiocamara == 0)
                {
                    cameraChanger.SwitchCameras();
                    cambiocamara += 1;
                }
                MoveCharacterToMiddleLane();
                if (Input.GetKeyDown(KeyCode.Space) && !midJump)
                {
                    StartCoroutine(Jump());

                }
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
            else
            {

            }
        }
    }
}
