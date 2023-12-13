using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    public int xx = 800, yy = 500;

    void Start()
    {
        Screen.SetResolution(xx, yy, true);
        this.gameObject.GetComponent<Camera>().aspect = 16f / 9f;
    }

}
