using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] public static float[,] coordinates;
    void Start()
    {
        coordinates = new float[,] { { -2, -2 }, { -2, -1 }, { -2, 0 }, { -2, 1 }, { -1, 1 } };
    }
}
