using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int dotsNumber;
    [SerializeField] GameObject dotsParents;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] float dotSpacing;

    Transform[] dotsList;
    Vector2 pos; 
    //dot pos
    float timeStamp;

    void Start()
    {
        //hide trajectory at start
        Hide();
        //prepare dots
        PrepareDots();
    }

    void PrepareDots()
    {
        dotsList = new Transform[dotsNumber];

        for (int i = 0; i <dotsNumber; i++)
        {
            dotsList[i] = Instantiate(dotPrefab, null).transform;
            dotsList[i].parent = dotsParents.transform;
        }
    }

    public void UpdateDots(Vector3 glopPos, Vector2 forceApplied)
    {
        timeStamp = dotSpacing;
        for (int i =0; i < dotsNumber; i++)
        {
            pos.x = (glopPos.x + forceApplied.x * timeStamp);
            pos.y = (glopPos.y + forceApplied.y * timeStamp)-(Physics2D.gravity.magnitude*timeStamp*timeStamp)/ 2f;

            dotsList[i].position = pos;
            timeStamp += dotSpacing;
        }
    }

    public void Show()
    {
        dotsParents.SetActive(true);
    }
    public void Hide()
    {
        dotsParents.SetActive(false);
    }
}
