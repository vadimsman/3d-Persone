using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Public
    public List<Transform> PatrolPoint;

    public PlayerController Player;

    public float ViewAngle;

    // Private
    private NavMeshAgent _navMeshAgent;

    private bool _isPlayerNoticed;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        PickNewPatrolPoint();
    }

    // Update is called once per frame
    private void Update()
    {
        NoticePlayerUpdate();
        PursiutPlayerUpdate();
        PatrolUpdate();
    }

    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = PatrolPoint[Random.Range(0, PatrolPoint.Count)].position;
    }
    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance == 0 && !_isPlayerNoticed)
        {
            PickNewPatrolPoint();
        }
    }
    private void NoticePlayerUpdate()
    {
        var direction = Player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < ViewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == Player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }
    private void PursiutPlayerUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = Player.transform.position;
        }
    }
}