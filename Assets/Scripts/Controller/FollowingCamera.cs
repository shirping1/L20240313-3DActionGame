using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 카메라가 일정 거리를 유지한 채로 플레이어를 추적하는 기능
/// </summary>
class FollowingCamera : MonoBehaviour
{
    public float distacdeAway = 6.0f;
    public float distaceneUp = 4.0f;

    public Transform follow;

    // 업데이트가 끝나고 호출
    private void LateUpdate()
    {
        //카메라 위치를 distanceUp만큼 위로 distanceAway만큼 앞에 위치
        transform.position = follow.position + Vector3.up * distaceneUp - Vector3.forward * distacdeAway;
    }
}

