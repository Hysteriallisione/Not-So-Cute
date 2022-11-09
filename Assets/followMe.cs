using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMe : MonoBehaviour
{
    public GameObject player;
    private Vector3 camPlayer = new Vector3(0, 0, -10);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position + camPlayer;
    }
}
