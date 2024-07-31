using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudHandler : MonoBehaviour
{

    public List<GameObject> clouds;
    public float cloudSpeed = 0.009f;
    private Vector3 startPosition;
    private Vector3 endPosition;

    // Update is called once per frame
    void Update()
    {
        MoveClouds();
    }

    public void MoveClouds(){
        foreach (var cloud in clouds)
        {
            cloud.transform.position = new Vector3(cloud.transform.position.x + cloudSpeed, cloud.transform.position.y, cloud.transform.position.z);

            if (cloud.transform.position.x > 40)
            {
                cloud.transform.position = new Vector3(-32f, GetRandomFloat(34f, 70f), cloud.transform.position.z);
            }
        }
    }

    public float GetRandomFloat(float min, float max)
    {
        return Random.Range(min, max);
    }
}
