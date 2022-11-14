using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullProcessCommands : MonoBehaviour 
{
    public TMPro.TextMeshProUGUI tmpro;

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        if (contact.otherCollider.gameObject.layer == 9)
        {
            tmpro.text = contact.otherCollider.name + " Collision";
            Destroy(contact.otherCollider.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string contact = other.name;
        if (other.gameObject.layer == 9)
        {
            tmpro.text = contact + " Trigger";
            Destroy(other.gameObject);
        }
    }
}
