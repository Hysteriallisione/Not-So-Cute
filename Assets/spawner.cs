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
    private Transform cuteGroup;
    public GameObject[] cuteBox;
    public int cuteMax;
    public int countCute;
    public bool[] occupied;
    public GameManager gameM;

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
  
    public void SpawnLollies()
    {
        //bool canPause = gameM.canPause;
        bool startZeG = gameM.startZeG;
        float started = Time.timeSinceLevelLoad;
        betweenspawns = curveCute.Evaluate(started / 100f);
        if(startZeG)
        {

        if (Time.time > lastCute + betweenspawns)
        {
            //on random le Vector2

            int zone = Random.Range(0, borders.Length);
            // check si zone du collider occupée
            while (occupied[zone] == true)
            {
                zone = Random.Range(0, borders.Length);
            }

            int randomCuBindex = Random.Range(0, cuteBox.Length);
            Vector2 pos = new Vector2(
               Random.Range(borders[zone].bounds.min.x, borders[zone].bounds.max.x),
               Random.Range(borders[zone].bounds.min.y, borders[zone].bounds.max.y));
            lastCute = Time.time;
            // ne pas dépasser le nombre d'object Cute prédifini dans interface
            if (countCute < cuteMax)
            {
                Instantiate(cuteBox[randomCuBindex], pos, Quaternion.identity, cuteGroup);
                // mettre une vérification du placement de cute object 
                countCute++;
                occupied[zone] = true;
            }

            }
        }
    }
}
