using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Player : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Trap"))
        {
            GameManager.instance.KillPlayer();
        }
        else if (other.transform.CompareTag("Finish"))
        {
            GameManager.instance.Win();
        }
    }
}
