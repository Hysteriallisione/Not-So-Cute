using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlz : MonoBehaviour
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
    private Transform darkGroup;
    public GameObject[] darkBox;
    public GameManager gameM;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    public void Playing()
    {
        //bool canPause = gameM.canPause;
        bool startZeG = gameM.startZeG;
        moove = false;
        Vector2 movingP = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerVect = movingP.normalized * rapide;
        Horizontal = transform.position.x;
        Vertical = transform.position.y;
        int randomDarBindex = Random.Range(0, darkBox.Length);

        if ( startZeG)
        {
            if (movingP.magnitude > 0)
            {
                moove = true;
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
                // destroy l'empty gameobject ("collider") contenant le collider "target"
                Destroy(target.transform.parent.gameObject);
                Debug.Log("j'essaie de tuer!!!");
                Instantiate(darkBox[randomDarBindex], target.transform.position, Quaternion.identity, darkGroup);
            }
            else
            {
                animaP.SetBool("attack", false);
            }
        }
    }

  /*  public void Playing()
    {
       


       
        // if(Input.GetKeyDown(KeyCode.JoystickButton7))
        //  {
        //    GameM.canPause = true;
        //}
    }*/

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
    private void FixedUpdate()
    {

        rigidB.MovePosition(rigidB.position + playerVect * Time.fixedDeltaTime * rapide);
    }
}
