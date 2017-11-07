using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 0.1f;
    
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, player.rotation, rotationSpeed * Time.deltaTime);
    }
}