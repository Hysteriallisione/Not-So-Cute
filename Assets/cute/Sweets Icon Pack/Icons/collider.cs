using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class collider : MonoBehaviour
{
    public GameObject player;
    public GameObject[] darkBox;
    public Transform darkGroup;
    public int countDark;
    private bool occupied;
    public Vector2 cutePos;

    // Start is called before the first frame update
    void Start()
    {
     //   countDark = 0;
     //   occupied = new bool[borders.Length];
     //   for (int i = 0; i < occupied.Length; i++)
     //   {
     //       occupied[i] = false;
     //   
    }

    // Update is called once per frame
    void Update()
    {
        int randomDarkBindex = Random.Range(0, darkBox.Length);
        if (gameObject == null)
        {
           Instantiate(darkBox[randomDarkBindex], cutePos, Quaternion.identity, darkGroup);
           
        }
    }
}
