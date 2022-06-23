using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelectionInstanceScript : MonoBehaviour
{
    int selector;
    public GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
        selector = Random.Range(0, objects.Length);
        objects[selector].SetActive(true); 
    }

}
