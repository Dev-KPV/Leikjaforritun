using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AI;
public class Ovinur : MonoBehaviour
{
    public static int health = 30;
    public NavMeshAgent enemy;
    public Transform player;
    Text texti;
    private Rigidbody rb;
    private Vector3 movement;
    public float hradi = 10f;
    // Start is called before the first frame update
    void Start()
    {
        texti = GameObject.Find("text2").GetComponent<Text>(); //finnur component sem heitir text2
        rb = this.GetComponent<Rigidbody>(); 
        texti.text = "Líf " + health.ToString(); //segir hvað á að prenta
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position); //segir enemy að labba að player
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player") //ef ovinur klessir í player
        {
            TakeDamage(5); //tekur 5 líf
            gameObject.SetActive(false); //eyðir ovininum eftir að hann klessir í player
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage; //mínusar damage af heildarLífunum
        texti.text = "Líf: " + health.ToString(); //prentar
        if (health <= 0) //ef health er 0 eða minna
        {
            SceneManager.LoadScene(0); //loadar byrjunarsenu s.s. game over
            health = 30; //segir hve mikið líf playerinn á að vera með
            Bullet.count = 0;//núll stilli stigin 
            texti.text = "Líf " + health.ToString(); //prentar
        }

    }


}