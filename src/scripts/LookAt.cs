using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    Transform maincam;
    void Start()
    {
        maincam = Camera.main.transform;
    }

    void Update()
    {
        transform.LookAt(maincam);
    }
}
