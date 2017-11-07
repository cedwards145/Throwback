using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3;
    public float groundClearance = 0.5f;

    // Use this for initialization
    void Start()
    {
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.left * moveSpeed * -x * Time.fixedDeltaTime);
        OrientToGround();
    }
    
    public void OrientToGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up * -1, Mathf.Infinity, LayerMask.GetMask("Walls"));
        if (hit)
        {
            Quaternion normalShift = Quaternion.FromToRotation(transform.up, hit.normal);
            transform.rotation = transform.rotation * normalShift;
            
            transform.position = hit.point + (hit.normal * groundClearance);
        }
    }
}