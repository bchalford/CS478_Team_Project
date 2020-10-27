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

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("CollisionStay");
        if (collision.transform.tag != "Player")
        {
            //body.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            //rigidbody2D.v = new Vector2 (0, 0);
            //print ("Stay");
        }
    }

    IEnumerator Constrain (GameObject glop)
    {
        glopBody.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;

        yield return new WaitForSeconds(1);

        glopBody.constraints = RigidbodyConstraints2D.None;
    }

        // Update is called once per frame
        void Update()
    {

    }
}
