using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public float hradi = 2.0f;
    public float hlidarhradi = 2.0f;

    private int count;
    public Text countText;

    public Vector3 jump;
    public float jumpForce = 5.0f;
    public bool isGrounded;
    private Rigidbody leikmadur;




    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Byrja");
        leikmadur = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }


    // Update fixed
    void FixedUpdate()
    {
        //Left Right
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * hradi;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += -transform.forward * hradi;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * hlidarhradi;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += -transform.right * hlidarhradi;
        }

        // ef grounded allow jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            leikmadur.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // rotation
        if (Input.GetKey("f"))
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }
        if (Input.GetKey("g"))//snúa leikmanni
        {
            transform.Rotate(new Vector3(0, -5, 0));
        }
        // ef dettir undir y=1 restart level
        if (transform.position.y <= -1)
        {
            Endurraesa();
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "hlutur") // ef player snertir tag = hlutur
        {
            collision.collider.gameObject.SetActive(false);
            count = count + 1; // teljarinn
            Debug.Log("Nú er ég komin með " + count); // skrifar í console stig
            SetCountText(); // kallar á fallið
      
        }

        if (collision.collider.tag == "enemy")
        {
            collision.collider.gameObject.SetActive(false);
            count = count - 1;
            SetCountText();

        }
    }
    void SetCountText()
    {
        countText.text = "Stig: " + count.ToString();

        if (count <= 0)
        {
            this.enabled = false;//kemur í veg fyrir að playerinn geti hreyfst áfram eftir dauðan
            countText.text = "DEAD " + count.ToString() + " stig";
            StartCoroutine(Bida());

        }

    }
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(1);
        Endurraesa();
    }


    public void Byrja()
    {
        SceneManager.LoadScene(1);
    }
    public void Endurraesa()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Level_1
        SceneManager.LoadScene(1);
    }

}





