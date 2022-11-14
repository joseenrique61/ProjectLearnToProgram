using UnityEngine;

public class SetInicioCollider : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            Vector3 size = GetComponent<MeshRenderer>().bounds.size;
            boxCollider.size = new Vector3(size.x + 1, size.y + 1, size.z + 1);
            boxCollider.center = new Vector3(0, size.y / 2, 0);
        }
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.detectCollisions = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
