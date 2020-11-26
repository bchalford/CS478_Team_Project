using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public int index;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("glop"))
        {
            //Loading level with build index
            SceneManager.LoadScene(index);
        }
    }
}
