using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public int numOfCute;
    public BoxCollider2D[] borders;
    public float betweenspawns;
    private float lastCute;
    public AnimationCurve curveCute;
    public float timePlaying;
    public Transform cuteGroup;
    public GameObject[] cuteBox;
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float started = Time.timeSinceLevelLoad; 
        betweenspawns = curveCute.Evaluate(started/100f);


         if(Time.time > lastCute + betweenspawns)
         {
       //on random le Vector2
        int zone = Random.Range(0, borders.Length);
        int randomCuBindex = Random.Range(0, cuteBox.Length);
        Vector2 pos = new Vector2(
            Random.Range(borders[zone].bounds.min.x, borders[zone].bounds.max.x),
            Random.Range(borders[zone].bounds.min.y, borders[zone].bounds.max.y));

         Instantiate(cuteBox[randomCuBindex], pos, Quaternion.identity, cuteGroup);
         lastCute = Time.time;

         }
    }
}
