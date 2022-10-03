using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level : MonoBehaviour
{
    public Vector3[] path;
    public GameObject player;
    public bool isActive;

    void Start()
    {
        if (isActive)
        {
            player.transform.DOPath(path, 10f, PathType.Linear);
        }
    }
}
