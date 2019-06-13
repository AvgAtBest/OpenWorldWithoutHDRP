using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
	public Transform target;
	public int health = 100;
	private NavMeshAgent agent;
	// Start is called before the first frame update
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update()
	{
		agent.SetDestination(target.position);
	}
	public void Heal(int heal)
	{
		health += heal;
	}
	public void TakeDamage(int damage)
	{
		health -= damage;
		if(health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
