using System;
using System.Collections;
using System.Collections.Generic; // Agregar esta línea
using UnityEngine;
using UnityEngine.UI;

public class gameFlow : MonoBehaviour
{
    public Transform tile1Obj;
    private Vector3 nextTileSpawn = new Vector3(0, 0, 16); // Initialize nextTileSpawn
    public Transform piedraObj;
    private Vector3 nextPiedraSpawn = new Vector3(0, 0, 16);//Cada que regenera un trozo de camino surge una piedra en una posici�n aleatoria
    private int randX;
    private int randXX;
    private int randx;
    private int randxX;
    private int randZ;
    private int contador;
    private int rueda;
    private int contar;
    private int objeto;
    private int cont;
    public Transform doorObj;
    private Vector3 nextDoorSpawn = new Vector3(0, 0, 16);
    public Transform cuadObj;
    private Vector3 nextCuadSpawn = new Vector3(0, 0, 16);
    public Transform wheelObj;
    private Vector3 nextWheelSpawn = new Vector3(0, 0, 16);
    public cameraChange cameraChanger;
    public Seleccionar seleccionarScript;
    private int count;
    public Transform character;
    private Vector3 characterMiddleLanePosition = new Vector3(0, 0, 0); // Posición en el carril central
    private List<GameObject> spawnedTiles = new List<GameObject>();
    public Transform coinObj;
    private Vector3 nextCoinSpawn = new Vector3(0, 0, 16);
    public Transform coindObj;
    private Vector3 nextCoindSpawn = new Vector3(0, 0, 16);
    private float timer = 0f;
    private bool timerStarted = false;
    private const float resetTime = 60f;

    void Start()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Llama al m�todo SwitchCameras del script cameraChange
            cameraChanger.SwitchCameras();
        }

        StartCoroutine(spawnTile());
    }

    void Update()
    {

    
        // Check if any spawned tiles are out of view
        for (int i = 0; i < spawnedTiles.Count; i++)
        {
            if (spawnedTiles[i].transform.position.z < character.position.z - 20) // Assuming the character can see 20 units ahead
            {
                Destroy(spawnedTiles[i]);
                spawnedTiles.RemoveAt(i);
                i--; // Adjust index after removing item
            }
        }
    }
    
    IEnumerator spawnTile()
    {
        if (!timerStarted)
        {
            timerStarted = true;
            StartCoroutine(TimerCoroutine());
        }
        timer += Time.deltaTime;
        if (timer >= resetTime)
        {
            ClearMiddleLane();
            timer = 0f; // Reinicia el temporizador
        }

        count = 0;
        while (true)
        {
        
            if (seleccionarScript.correcto == 1)
            {
                count += 1;
                if (count == 1)
                {
                    
  
                    ClearMiddleLane();
                }
                else
                {
                    objeto = UnityEngine.Random.Range(1, 7);
                    GameObject newTile = Instantiate(tile1Obj, nextTileSpawn, Quaternion.identity).gameObject;
                    spawnedTiles.Add(newTile);
                    yield return new WaitForSeconds(2);

                    // Generar posici�n para la piedra
                    nextPiedraSpawn = nextTileSpawn;
                    contador = (int)nextTileSpawn.z; // Convertir a int
                    randZ = UnityEngine.Random.Range(contador, contador + 4);
                    nextPiedraSpawn.y = .18f;
                    nextPiedraSpawn.x = -1;
                    nextPiedraSpawn.z = randZ;

                    // Generar posici�n para la puerta
                    nextDoorSpawn = nextTileSpawn;
                    contar = (int)nextTileSpawn.z; // Convertir a int
                    randZ = UnityEngine.Random.Range(contar, contar + 4);
                    nextDoorSpawn.z = randZ;
                    nextDoorSpawn.y = 0;
                    nextDoorSpawn.x = -0.5f;

                    // Generar posici�n para la moneda
                    nextCoinSpawn = nextTileSpawn;
                    cont = (int)nextTileSpawn.z; // Convertir a int
                    randZ = UnityEngine.Random.Range(cont, cont + 4);
                    nextCoinSpawn.z = randZ;
                    nextCoinSpawn.y = 0.5f;
                    nextCoinSpawn.x = 0f;
                    if (nextDoorSpawn.z == nextPiedraSpawn.z)
                    {
                        nextDoorSpawn.z += 4;
                    }
                    else if (nextCoinSpawn.z == nextPiedraSpawn.z || nextCoinSpawn.z == nextDoorSpawn.z)
                    {
                        nextCoinSpawn.z += 2;
                    }

                    if (objeto == 1 || objeto==4)
                    {
                        Instantiate(piedraObj, nextPiedraSpawn, piedraObj.rotation);
                    }
                    else if (objeto == 2 || objeto == 5)
                    {
                        Instantiate(doorObj, nextDoorSpawn, doorObj.rotation);
                    }
                    else if (objeto == 3)
                    {
                        Instantiate(coinObj, nextCoinSpawn, coinObj.rotation);
                    }
                    // Instanciar los objetos
                    nextTileSpawn.z += 4;
                }
            }
            else
            {
                rueda += 1;
                objeto = UnityEngine.Random.Range(1, 8);
                GameObject newTile = Instantiate(tile1Obj, nextTileSpawn, Quaternion.identity).gameObject;
                spawnedTiles.Add(newTile);
                yield return new WaitForSeconds(2);

                // Generar posici�n para la piedra
                nextPiedraSpawn = nextTileSpawn;
                randx = UnityEngine.Random.Range(-2, 1);
                contador = (int)nextTileSpawn.z; // Convertir a int
                randZ = UnityEngine.Random.Range(contador, contador + 4);
                nextPiedraSpawn.y = .18f;
                nextPiedraSpawn.x = randx;
                nextPiedraSpawn.z = randZ;

                // Generar posici�n para la puerta
                nextDoorSpawn = nextTileSpawn;
                contar = (int)nextTileSpawn.z; // Convertir a int
                randZ = UnityEngine.Random.Range(contar, contar + 4);
                nextDoorSpawn.z = randZ;
                nextDoorSpawn.y = 0;
                randX = UnityEngine.Random.Range(-1, 2);

                // Verificar si la posici�n de la puerta coincide con la de la piedra o el cuadro
                if (nextDoorSpawn.z == nextPiedraSpawn.z || nextDoorSpawn == nextCuadSpawn)
                {
                    // Ajustar posici�n de la puerta seg�n el caso
                    if (randx == 0 || randxX == 1)
                    {
                        randX = 0;
                    }
                    else if (randx == -1 || randxX == 0)
                    {
                        randX = -1;
                    }
                    else if (randx == -2 || randxX == -1)
                    {
                        randX = 1;
                    }
                }
                // Asignar posici�n final para la puerta
                if (randX == -1)
                {
                    nextDoorSpawn.x = -1.5f;
                }
                else if (randX == 0)
                {
                    nextDoorSpawn.x = -0.5f;
                }
                else if (randX == 1)
                {
                    nextDoorSpawn.x = 0.5f;
                }

                if (rueda == 5 || rueda == 10 || rueda == 15 || rueda == 20)
                {
                    nextWheelSpawn.z = nextTileSpawn.z;
                    nextWheelSpawn.y = .27f;
                    nextWheelSpawn.x = randX;
                    Instantiate(wheelObj, nextWheelSpawn, wheelObj.rotation);
                }

                // Generar posici�n para el cuadro
                nextCuadSpawn = nextTileSpawn;
                contar = (int)nextTileSpawn.z; // Convertir a int
                randZ = UnityEngine.Random.Range(contar, contar + 4);
                nextCuadSpawn.z = randZ;
                nextCuadSpawn.y = 0.4f;
                randxX = UnityEngine.Random.Range(-1, 2);

                randX = UnityEngine.Random.Range(-1, 2);
                nextCoindSpawn = nextTileSpawn;
                cont = (int)nextTileSpawn.z; // Convertir a int
                randZ = UnityEngine.Random.Range(cont, cont + 4);
                nextCoindSpawn.z = randZ;
                nextCoindSpawn.y = 0.5f;
                nextCoindSpawn.x = randXX;
                // Verificar si la posici�n del cuadro coincide con la de la piedra o la puerta
                if (nextCuadSpawn.z == nextPiedraSpawn.z || nextCuadSpawn.z == nextDoorSpawn.z)
                {
                    // Ajustar posici�n del cuadro seg�n el caso
                    if (randx == 0 || randX == 1)
                    {
                        randxX = -1;
                        nextCuadSpawn.x = randxX;
                    }
                    else if (randx == -1 || randX == 0)
                    {
                        randxX = 1;
                        nextCuadSpawn.x = randxX;
                    }
                    else if (randx == -2 || randX == -1)
                    {
                        randxX = 0;
                        nextCuadSpawn.x = randxX;
                    }
                }

                if (nextCoindSpawn.z == nextPiedraSpawn.z || nextCoindSpawn.z == nextDoorSpawn.z || nextCoindSpawn.z == nextCuadSpawn.z ) 
                {
                    // Ajustar posici�n de la moneda seg�n el caso
                    if (nextCoindSpawn.x == nextPiedraSpawn.x || nextCoindSpawn.x == nextDoorSpawn.x || nextCoindSpawn.x == nextCuadSpawn.x)
                    {
                        nextCoindSpawn.z += 1;
                    }

                }

                if (objeto == 1 || objeto==6)
                {
                    Instantiate(piedraObj, nextPiedraSpawn, piedraObj.rotation);
                    Instantiate(doorObj, nextDoorSpawn, doorObj.rotation);
                }
                else if (objeto == 2 || objeto==5)
                {
                    Instantiate(piedraObj, nextPiedraSpawn, piedraObj.rotation);
                    Instantiate(cuadObj, nextCuadSpawn, cuadObj.rotation);
                }
                else if (objeto == 3)
                {
                    Instantiate(coindObj, nextCoindSpawn, coindObj.rotation);
                }
                else
                {
                    Instantiate(doorObj, nextDoorSpawn, doorObj.rotation);
                    Instantiate(cuadObj, nextCuadSpawn, cuadObj.rotation);
                }

                // Instanciar los objetos
                nextTileSpawn.z += 4;
            }
        }
    }

    void ClearMiddleLane()
    {
        GameObject[] middleLaneObstacles = GameObject.FindGameObjectsWithTag("obstacle");
        foreach (GameObject obstacle in middleLaneObstacles)
        { 
        if (obstacle.CompareTag("obstacle"))
        {
            Destroy(obstacle);
        }
        }
        GameObject[] middleObstacles = GameObject.FindGameObjectsWithTag("dood");
        foreach (GameObject dood in middleObstacles)
        {
            if (dood.CompareTag("dood"))
            {
                Destroy(dood);
            }
        }
    }
    IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(resetTime);
        ClearMiddleLane();
        timer = 0f; // Reinicia el temporizador
    }


}
