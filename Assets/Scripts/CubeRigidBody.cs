using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRigidBody : MonoBehaviour
{
    void OnSelect()
    {
        if (!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }
}
