using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawner Script by Samuel, reworked into template by Frieder

public abstract class SpawnerTemplate : MonoBehaviour
{
    private float timer = 0f;

    //Falling Objects
    [SerializeField]
    private GameObject wood;
    [SerializeField]
    private GameObject stone;
    [SerializeField]
    private GameObject waterdrop;
    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private GameObject heart;

    //height from which objects are dropped
    private int height = 80;
    //Timer variable
    private int sec = 0;
    //Width of a row in the spawner
    private const int gridWidth = 21;
    private int[] currentRow = new int[gridWidth];

    //chance in % if - will translate to 1
    private const int rockChance = 0;

    //The Array for the Level design, gridWidth chars('0'-'9') per String!
    public string[] level = {};


    //allowed are 0 to 9, all others will be ignored
    void string2intArray(string levelRow)
    {

        int length = levelRow.Length;
        if (length != gridWidth) Debug.Log("Obtained string of unexpected size");
        if (currentRow.Length != gridWidth) Debug.Log("Obtained int arry of unexpected size");

        char currentLetter;

        for (int i = 0; i < gridWidth; i++)
        {

            currentLetter = char.Parse(levelRow.Substring(i, 1));
            switch (currentLetter)
            {
                case '0':
                case '-':

                    currentRow[i] = 0;

                    if (Random.Range(0, 100) < rockChance)
                        currentRow[i] = 1;
                    break;
                case '1':
                    currentRow[i] = 1;
                    break;
                case '2':
                    currentRow[i] = 2;
                    break;
                case '3':
                    currentRow[i] = 3;
                    break;
                case '4':
                    currentRow[i] = 4;
                    break;
                case '5':
                    currentRow[i] = 5;
                    break;
                case '6':
                    currentRow[i] = 6;
                    break;
                case '7':
                    currentRow[i] = 7;
                    break;
                case '8':
                    currentRow[i] = 8;
                    break;
                case '9':
                    currentRow[i] = 9;
                    break;
                default:
                    break;
            }
        }
    }

    void spawnPrefabAt(GameObject prefab, int xPosition)
    {
        Instantiate(prefab, new Vector3(xPosition, height, 0),
                        Quaternion.identity);
    }


    private void spawnRowOfObjects()
    {
        for (int i = 0; i < gridWidth; i++)
        {
            switch (currentRow[i])
            {
                case 0:
                    break;
                case 1:
                    spawnPrefabAt(waterdrop, i * 5);
                    break;
                case 2:
                    spawnPrefabAt(wood, i * 5);
                    break;
                case 3:
                    spawnPrefabAt(stone, i * 5);
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    spawnPrefabAt(heart, i * 5);
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    spawnPrefabAt(coin, i * 5);
                    break;
                default:
                    Debug.Log("Received unexpected object to spawn");
                    break;
            }
        }
    }

    private void runSpawner()
    {
        if (timer > 1 &&
           sec < level.Length)
        {
            string2intArray(level[sec]);
            spawnRowOfObjects();
            //Debug.Log("sec = " + sec);
            sec++;
            timer -= 1;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        runSpawner();
    }
}
