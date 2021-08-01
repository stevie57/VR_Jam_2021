using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimController : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private Transform target;
    void Start()
    {
        MoveToPos();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void MoveToPos()
    {
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        while(Vector3.Distance(target.transform.position ,transform.position) > 0.5f)
        {
            Vector3 lookAtPos = target.position - transform.position;
            Quaternion newRotation = Quaternion.LookRotation(lookAtPos, transform.up);
            Quaternion targetRotation = new Quaternion(0, -newRotation.y, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
            yield return null;
        }
    }
}
