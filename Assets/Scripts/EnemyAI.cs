using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScriptableObject : MonoBehaviour
{
    // Public
    public List<Transform> PatrolPoint;
    public PlayerController Player;
    public float ViewAngle;
    public float Damage = 30;

    // Private
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private PlayerHealth _playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = Player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    private void Update()
    {
        NoticePlayerUpdate();
        PursiutPlayerUpdate();
        AttackUpdate();
        PatrolUpdate();
    }

    public void AttackUpdate()
    {
        if(_isPlayerNoticed && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _playerHealth.DealDamage(Damage * Time.deltaTime);
        }
    }

    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = PatrolPoint[Random.Range(0, PatrolPoint.Count)].position;
    }
    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && !_isPlayerNoticed)
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