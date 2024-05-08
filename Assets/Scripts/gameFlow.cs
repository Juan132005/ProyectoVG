using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class gameFlow : MonoBehaviour
{
    public Transform tile1Obj;
    private Vector3 nextTileSpawn = new Vector3(0, 0, 20); // Initialize nextTileSpawn
    public Transform piedraObj;
    private Vector3 nextPiedraSpawn = new Vector3(0, 0, 20);//Cada que regenera un trozo de camino surge una piedra en una posici�n aleatoria
    private int randX;
    private int randx;
    private int randxX;
    private int randZ;
    private int contador;
    private int rueda;
    private int contar;
    private int objeto;
    public Transform doorObj;
    private Vector3 nextDoorSpawn = new Vector3(0, 0, 20);
    public Transform cuadObj;
    private Vector3 nextCuadSpawn = new Vector3(0, 0, 20);
    public Transform wheelObj;
    private Vector3 nextWheelSpawn = new Vector3(0, 0, 20);
    public cameraChange cameraChanger;



    void Start()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Llama al m�todo SwitchCameras del script cameraChange
            cameraChanger.SwitchCameras();
        }
        //bool cameraToEnableEnabled = cameraChanger.IsCameraToEnableEnabled();
        //if (cameraToEnableEnabled)
        //{
          //  StartCoroutine(spawnTile3());
        //}
        //else
        //{
          StartCoroutine(spawnTile());
        //}
        //contador = 0;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Llama al m�todo SwitchCameras del script cameraChange
          cameraChanger.SwitchCameras();
        }
        //bool cameraToEnableEnabled = cameraChanger.IsCameraToEnableEnabled();
        //if (cameraToEnableEnabled)
        //{
        //  StartCoroutine(spawnTile2());
        //}
        //else
        //{
        //  StartCoroutine(spawnTile());
        //}
        //contador = 0;

    }
    
    IEnumerator spawnTile()
    {

            while (true)
            {//aquí pongo un if para destruir todos los objetos y empezar a crear otros
                rueda += 1;
                objeto = UnityEngine.Random.Range(1, 4);
                Instantiate(tile1Obj, nextTileSpawn, Quaternion.identity);
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

                if (objeto == 1)
                {
                    Instantiate(piedraObj, nextPiedraSpawn, piedraObj.rotation);
                    Instantiate(doorObj, nextDoorSpawn, doorObj.rotation);
                }
                else if (objeto == 2)
                {
                    Instantiate(piedraObj, nextPiedraSpawn, piedraObj.rotation);
                    Instantiate(cuadObj, nextCuadSpawn, cuadObj.rotation);
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

