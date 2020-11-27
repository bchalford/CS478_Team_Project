using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spike : MonoBehaviour
{
    public int spikeindex;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("glop"))
        {
            SceneManager.LoadScene(spikeindex);
        }
    }
}
