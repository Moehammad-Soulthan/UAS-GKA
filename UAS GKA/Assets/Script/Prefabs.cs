using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine("fordestroy");
    }

    // Update is called once per frame
    IEnumerator fordestroy(){
        yield return new WaitForSeconds(9f);
        Destroy(this.gameObject);
    }
}
