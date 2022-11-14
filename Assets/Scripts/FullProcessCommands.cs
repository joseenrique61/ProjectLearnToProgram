using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullProcessCommands : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Destroy(contact.otherCollider.gameObject);
    }
}
