using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public float speed = 100f; //hraði kúlunnar

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) //ýtir á z til að skjóta
        {
            Debug.Log("Skot");       
           
            //GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            GameObject instBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidbody.AddForce(transform.forward * speed); //býr til force
            Destroy(instBullet, 1f);//kúl eytt eftir 1sek
           
        }
    }
}
