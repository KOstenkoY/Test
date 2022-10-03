using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trap : MonoBehaviour
{
    void Start()
    {
        transform.DOScale(new Vector3(0.07f, 0, 0.07f), 5);
    }
}
