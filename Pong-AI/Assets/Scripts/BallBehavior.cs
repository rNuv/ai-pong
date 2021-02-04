using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class BallBehavior : MonoBehaviour
{
    private float speed = 5.0f;
    public Agent agent;

    // Start is called before the first frame update
    void Start()
    {
        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sy = Random.Range(0, 2) == 0 ? -1 : 1;

        GetComponent<Rigidbody>().velocity = new Vector3(speed * sx, speed * sy, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Agent"))
        {
            agent.SetReward(+1f);
            agent.EndEpisode();
        }

        if (collision.gameObject.tag.Equals("LeftWall"))
        {
            agent.SetReward(-1f);
            agent.EndEpisode();
        }
    }
}
