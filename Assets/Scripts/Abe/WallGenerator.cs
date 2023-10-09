using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WallGenerator : MonoBehaviour
{
    private float interval;

    private float time = 0f;

    void Start()
    {
        interval = 2f;

        //GameObject obj = (GameObject)Resources.Load("Wall1");
        //Instantiate(obj, new Vector3(8.0f, 5.0f, 0.0f), Quaternion.identity);
    }

   
    void Update()
    {
        time += Time.deltaTime;

        if (time > interval)
        {
            float y1 = Random.Range(5.0f,7.0f);
            float y2 = Random.Range(-5.0f, -8.0f);

            GameObject obj = (GameObject)Resources.Load("Wall1");
            Instantiate(obj, new Vector3(8.0f,y1, 0.0f), Quaternion.identity);
            Instantiate(obj, new Vector3(8.0f,y2, 0.0f), Quaternion.identity);
            time = 0f;
        }
    }
}
