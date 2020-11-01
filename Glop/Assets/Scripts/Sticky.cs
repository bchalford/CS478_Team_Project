using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour
{
    public Rigidbody2D glopBody;
    bool isSticking;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<BoxCollider2D>();

        glopBody = gameObject.GetComponent<Rigidbody2D>();
        isSticking = false;
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("CollisionEntered");
            isSticking = true;
            StartCoroutine(Constrain(collision.gameObject));
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("CollisionExit");
        glopBody.constraints = RigidbodyConstraints2D.None;
        isSticking = false;
    }


    IEnumerator Constrain (GameObject glop)
    {
        glopBody.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isSticking = false;
                glopBody.constraints = RigidbodyConstraints2D.None;
                yield break;
            }
            yield return null;
        }
    }
    public bool IsSticking
    {
        get;
        set;
    }
    // Update is called once per frame
    void Update()
    {

    }
}