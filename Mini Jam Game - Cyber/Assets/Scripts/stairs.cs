using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairs : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    
    private LayerMask lm;

    public bool up;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        if (up)
        {
            lm &= ~(0x1 << 6);
            lm &= ~(0x1 << 7);
            if (player1.transform.position.y < transform.position.y)
            {
                if (player2.transform.position.y < transform.position.y)
                {
                    lm |= 0x1 << 6;
                    lm |= 0x1 << 7;
                }
                lm |= 0x1 << 6;
            }
            else if (player2.transform.position.y < transform.position.y)
            {
                lm |= 0x1 << 7;
            }
        }
        else if (!up)
        {
            lm |= 0x1 << 6;
            lm |= 0x1 << 7;
            if (player1.transform.position.y < transform.position.y)
            {
                if (player2.transform.position.y < transform.position.y)
                {
                    lm &= ~(0x1 << 6);
                    lm &= ~(0x1 << 7);
                }
                lm &= ~(0x1 << 6);
            }
            else if (player2.transform.position.y < transform.position.y)
            {
                lm &= ~(0x1 << 7);
            }
        }

        transform.GetComponent<BoxCollider2D>().excludeLayers = lm;
    }
}
