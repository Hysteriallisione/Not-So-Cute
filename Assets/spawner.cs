using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

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
    public int cuteMax;
    public int countCute;
    public bool[] occupied;

    // Start is called before the first frame update
    void Start()
    {
        countCute = 0;
        occupied = new bool[borders.Length];
        for (int i = 0; i < occupied.Length; i++)
        {
            occupied[i] = false;
        }
        
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

        while (occupied[zone] == true)
        {
                zone = Random.Range(0, borders.Length);
        }

            int randomCuBindex = Random.Range(0, cuteBox.Length);
         Vector2 pos = new Vector2(
            Random.Range(borders[zone].bounds.min.x, borders[zone].bounds.max.x),
            Random.Range(borders[zone].bounds.min.y, borders[zone].bounds.max.y));
              lastCute = Time.time;
           if(countCute < cuteMax)
           {
               Instantiate(cuteBox[randomCuBindex], pos, Quaternion.identity, cuteGroup);
            // mettre une vérification du placement de cute object 
               countCute++;
                occupied[zone] = true;
           }
            //si un gameobject cute créé dans une zone de "borders", zone ne peut plus instantiate un autre object
        }
       
    }
}
