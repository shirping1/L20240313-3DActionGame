using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;

    // Start is called before the first frame update
    void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        // 슬라임이 가지고 있는 NavMeshAgent 값에 접근
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(nav.enabled)
        {
            nav.SetDestination(player.position);
        }
    }


}
