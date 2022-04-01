using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject bone1;
    public GameObject bone2;
    public GameObject bone3;
    public GameObject spawnBlock;
    GameObject newbone;

    public void SpawnBone()
    {
        int whichBone = Random.Range(1, 3);

        if(whichBone == 1)
        {
            //Instantiate(bone1);
            newbone = Instantiate(bone1, spawnBlock.transform.position, Quaternion.identity);
        }
        else if (whichBone == 2)
        {
            //Instantiate(bone2);
            newbone = Instantiate(bone2, spawnBlock.transform.position, Quaternion.identity);
        }
        else if (whichBone == 3)
        {
            //Instantiate(bone3);
            newbone = Instantiate(bone3, spawnBlock.transform.position, Quaternion.identity);
        }
    }

}
