using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Level[] scenes;

    public GameObject player;
    public GameObject finish;

    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 finishPosition;

    private int number;

    void Awake()
    {
        number = Random.Range(0, 10);

        var _currentScene = Instantiate(scenes[number], Vector3.zero, this.transform.rotation);

        _currentScene.player = Instantiate(player, startPosition, this.transform.rotation);

        Instantiate(finish, finishPosition, this.transform.rotation);

    }

    //void OnTriggerEnter(Collider other)
    //{

    //}

}
