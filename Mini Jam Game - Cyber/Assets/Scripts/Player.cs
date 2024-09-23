using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerNo;

    public Animator anim;

    public float Speed;
    public float horizontal;
    public float vertical;
    public Rigidbody2D rb;

    private GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("Button");
    }

    // Update is called once per frame
    void Update()
    {

        #region Animation

        if (rb.velocity.y > 0)
        {
            anim.SetBool("RunningUp", true);
        }
        else
        {
            anim.SetBool("RunningUp", false);

        }

        if (rb.velocity.y < 0)
        {
            anim.SetBool("RunningDown", true);
        }
        else
        {
            anim.SetBool("RunningDown", false);

        }

        if (rb.velocity.x != 0)
        {
            anim.SetBool("RunningSide", true);

            if (rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if(rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);

            }
        }
        else
        {
            anim.SetBool("RunningSide", false);

        }

        #endregion

        #region Button Interaction

        if (playerNo == 1)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                buttonInteraction();
            }
        }
        else if (playerNo == 2)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space))
            {
                buttonInteraction();
            }
        }

        #endregion

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }
    private void FixedUpdate()
    {
        #region Movement

        if (playerNo == 1)
        {
            horizontal = Input.GetAxisRaw("Horizontal1");
            vertical = Input.GetAxisRaw("Vertical1");

            rb.velocity = new Vector2(horizontal * Speed * Time.deltaTime, vertical * Speed * Time.deltaTime);
        }
        else if (playerNo == 2)
        {
            horizontal = Input.GetAxisRaw("Horizontal2");
            vertical = Input.GetAxisRaw("Vertical2");

            rb.velocity = new Vector2(horizontal * Speed * Time.deltaTime, vertical * Speed * Time.deltaTime);
        }


        #endregion
    }

    private void buttonInteraction()
    {
        if ((transform.position - button.transform.position).magnitude < 0.3f)
        {
            button.GetComponent<buttonScript>().interaction(playerNo);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Checkpoint")
        {
            collision.GetComponent<checkpoint>().nextLevel();
        }
    }
}
