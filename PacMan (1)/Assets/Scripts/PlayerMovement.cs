using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private static int scoreValue;
    public Text score;
    private Vector2 direction = Vector2.zero;
    private Vector2 nextDirection;

    public float speed = 4.0f;
    public Vector2 orientation;

    public bool facingRight = true;
    
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Count: " + scoreValue.ToString();
    }


    // Update is called once per frame
    void Update()
    {
       if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu"))
       {
           scoreValue = 0;
       }

       if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Can"))
        {
            scoreValue += 1;
            score.text = "Score: " + scoreValue.ToString();
            other.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (Input.GetAxisRaw("Horizontal") > 0f || Input.GetAxisRaw("Horizontal") < 0f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(h, 0) * speed;
        }
        else if (Input.GetAxisRaw("Vertical") > 0f || Input.GetAxisRaw("Vertical") < 0f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
        }
        
        if(h > 0 && !facingRight)
        {
            Flip();
        }
        else if(h < 0 && facingRight)
        {
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Zombie")
        {
            SceneManager.LoadScene("Lose");
            scoreValue = 0;
        }

        if (collision.collider.tag == "Portal1")
        {
            transform.position = new Vector2(37.345f, 17.388f);
        }

        if (collision.collider.tag == "Portal2")
        {
            transform.position = new Vector2(12.13f, 17.65996f);
        }

        if(scoreValue == 467)
        {
           SceneManager.LoadScene("level2"); 
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("level2"))
        {
            if(scoreValue == 936)
            {
                SceneManager.LoadScene("Win");
            }
        }
    }

    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
