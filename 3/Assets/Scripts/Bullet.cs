using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed=20f;
    public Rigidbody rb;
    public int damage = 5;
    public GameObject sprengjan;
    public static int count;//klasabreyta
    public Text countText;
    void Start()
    {
        rb.velocity = transform.forward * speed;
        countText = GameObject.Find("text1").GetComponent<Text>(); //finnur component sem heitir text1
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "hlutur")
        {
            collision.collider.gameObject.SetActive(false);
            count = count + 1;//bætir í teljara
            SetCountText();//kallar á fallið
        }
    }
    void SetCountText()
    {
        countText.text = "Stig: " + count.ToString();//segir hvað á að prenta

        if (count <= 7)//ef playerinn er með 7 eða meira vinnur þú leikinn
        {
            this.enabled = false;//kemur í veg fyrir að playerinn geti hreyfst áfram eftir dauðan
            SceneManager.LoadScene(0);//loadar GameOver senuni

        }

    }
}
