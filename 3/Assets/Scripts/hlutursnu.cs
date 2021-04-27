using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hlutursnu : MonoBehaviour//klasi
{
    void Update()//breyta
    {
        transform.Rotate(new Vector3(0,80,0) * Time.deltaTime);//lætur hlut snúast í hringi
    }
}
