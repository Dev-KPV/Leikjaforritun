using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kassi : MonoBehaviour //klasi
{
  
    private void Update()
    {
        if (transform.position.y < -10) //ef kassin fer undir -10
        {
            Destroy(gameObject); //eyðillegur kassan
            gameObject.SetActive(false); //unloadar kassan
        }
    }
    
}
