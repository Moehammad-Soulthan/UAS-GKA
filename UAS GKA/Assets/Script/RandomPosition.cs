using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    public Vector3[] positions;
    public GameObject Potion;

    void Start()
    {
        int randomNumber = Random.Range(0, positions.Length);
        Potion.transform.localPosition = new Vector3(positions[randomNumber].x, transform.localPosition.y, transform.localPosition.z);
    }
}
