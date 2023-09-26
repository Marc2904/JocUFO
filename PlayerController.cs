using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    TextMeshProUGUI punts;

    [SerializeField]
    TextMeshProUGUI Victoria;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Sortir");
            Application.Quit();
        }
            

    }

    int point = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Pickup"))
        {
            point = point + 1;
            Debug.Log("Punts" + point);
            Destroy(collision.gameObject);
            punts.text = point.ToString();
        }
        if (point == 5)
        {
            Victoria.text = "Has Acabat. Fet per Marc Solé Rico";
        }
    }

    
}
