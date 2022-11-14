using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullProcessCommands : MonoBehaviour 
{
    public TMPro.TextMeshProUGUI tmpro;

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        tmpro.text = contact.otherCollider.name;
        Destroy(contact.otherCollider.gameObject);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    string contact = other.name;
    //    tmpro.text = contact;
    //    Destroy(other.gameObject);
    //}
}
