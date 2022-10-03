using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Level[] scenes;

    private int number;

    void Start()
    {
        number = Random.Range(0, 10);
        Instantiate(scenes[number], Vector3.zero, this.transform.rotation);
    }
}
