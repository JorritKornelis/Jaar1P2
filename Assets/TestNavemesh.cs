using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestNavemesh : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;
	// Use this for initialization
	void Start ()
    {
        agent = this.GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        agent.SetDestination(target.position);
	}
}
