﻿using UnityEngine;
using Unity.MLAgents;

public class Jumper : Agent
{
    public float force = 15f;
    public Transform reset = null;
    public TextMesh score = null;
    private GameObject thrust;
    private Rigidbody rb = null;
    private float points = 0;

    public override void Initialize()
    {
        rb = this.GetComponent<Rigidbody>();
        ResetMyAgent();
    }
    public override void OnActionReceived(float[] vectorAction)
    {

        if (rb.transform.position.y > 2)
        {
            AddReward(-0.01f);
        
        }
        else if(rb.transform.position.y >= 5)
        {
            AddReward(-0.5f);   
        }
        if (vectorAction[0] == 1)
        {
            UpForce();
        
        }

    }
    public override void OnEpisodeBegin()
    {
        ResetMyAgent();
    }
    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0;
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            actionsOut[0] = 1;
        }
            
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle") == true)
        {
            AddReward(-1f);
            Destroy(collision.gameObject);
            //EndEpisode();
        }
        if (collision.gameObject.CompareTag("walltop") == true)
        {
            AddReward(-1f);
            //EndEpisode();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       
        
        if (other.CompareTag("wallreward") == true && points<10 )
        {
            AddReward(1f);
            points++;
            
        }
        else if(other.CompareTag("wallreward") == true)
        {
            points = 0;
            EndEpisode();
            Debug.Log("Episode ended");
        }
        
    }
    private void UpForce()
    {
        rb.AddForce(Vector3.up * force, ForceMode.Acceleration);
    }
    private void ResetMyAgent()
    {
        this.transform.position = new Vector3(reset.position.x, reset.position.y, reset.position.z);
    }
}
