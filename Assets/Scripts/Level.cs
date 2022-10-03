using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level : MonoBehaviour
{
    public Vector3[] path;

    public GameObject player;

    private float _delay = 2;

    void Start()
    {
        StartCoroutine(PlayDelay());
    }

    IEnumerator PlayDelay()
    {
        yield return new WaitForSeconds(_delay);
        player.transform.DOPath(this.path, 10f, PathType.Linear);
    }
}
