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


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            leikmadur.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
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
    }
    void SetCountText()
    {
        countText.text = "Stig: " + count.ToString();
        if (count >= 4)
            countText.text = "Þú hefur unnið með" + count.ToString() + " stigum";
            
    }       

    public void Endurraesa()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Upphafsena");
    }
}


