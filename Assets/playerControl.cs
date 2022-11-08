using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public Rigidbody2D rigidB;
    private Vector2 playerVect;
    public float rapide;
    public Animator animaP;
    public float Horizontal;
    public float Vertical;
    private bool moove;

    // Start is called before the first frame update
    void Start()
    {
        animaP = gameObject.GetComponent<Animator>();
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
    }
    void FixedUpdate()
    {

        rigidB.MovePosition(rigidB.position + playerVect * Time.fixedDeltaTime * rapide);
    }
}
