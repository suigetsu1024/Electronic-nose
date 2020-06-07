using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    public GameObject obj;
    public GameObject obj2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Onlclick() { obj.SetActive(false); obj2.SetActive(false); }
}
