using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    public int i;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("glop"))
        {
            SceneManager.LoadScene(i);
        }
    }
}
