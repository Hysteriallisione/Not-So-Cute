using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class playerControl : MonoBehaviour
{
    public Rigidbody2D rigidB;
    private Vector2 playerVect;
    public float rapide;
    public Animator animaP;
    public float Horizontal;
    public float Vertical;
    private bool moove;
    private bool colliderP;
    private Collider2D target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moove = false;
        Vector2 movingP = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerVect = movingP.normalized * rapide;
        Horizontal = transform.position.x;
        Vertical = transform.position.y;
       
       

        if (movingP.magnitude > 0)
        {
            moove=true;
            animaP.SetFloat("Horizontal", movingP.x);
            animaP.SetFloat("Vertical", movingP.y);
            animaP.SetBool("playerMove", true);
            animaP.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
            animaP.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
        }
        else
        {
            moove = false;
            animaP.SetBool("playerMove", false);
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton1) && colliderP)
        {
            animaP.SetBool("attack", true);
        }
        else
        {
            animaP.SetBool("attack", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cute"))
        {
            colliderP = true;
            target = collision;
            Debug.Log("trigger has been touched");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cute"))
        {
            colliderP = false;
            target = null;
        }
    }
        void FixedUpdate()
    {

        rigidB.MovePosition(rigidB.position + playerVect * Time.fixedDeltaTime * rapide);
    }
}
