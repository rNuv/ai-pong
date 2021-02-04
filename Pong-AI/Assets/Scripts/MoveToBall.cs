using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class MoveToBall : Agent
{

    [SerializeField] private Rigidbody ball;

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(-9.0f, Random.Range(-3.5f, 3.5f), 0f);
        ball.transform.localPosition = new Vector3(0f, Random.Range(-3.5f, 3.5f), 0f);

        float sx = Random.Range(0, 2) == 0 ? -1 : 1;
        float sy = Random.Range(0, 2) == 0 ? -1 : 1;
        float speed = 5.0f;
        ball.velocity = new Vector3(speed * sx, speed * sy, 0f);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(ball.transform.localPosition);
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        float moveY = vectorAction[0];
        float moveSpeed = 5.0f;
        transform.localPosition += new Vector3(0, moveY, 0) * Time.deltaTime * moveSpeed;
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y, -4.0f, 4.0f), transform.localPosition.z);
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Input.GetAxisRaw("Vertical");
    }
}
