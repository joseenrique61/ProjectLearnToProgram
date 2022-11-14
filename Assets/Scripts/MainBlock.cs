using System.Collections.Generic;
using UnityEngine;

public class MainBlock : MonoBehaviour
{
    private List<GameObject> blocksInOrder = new List<GameObject>();

    public void AddBlock(GameObject block)
    {
        blocksInOrder.Add(block);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject one = collision.gameObject;
        blocksInOrder.Add(collision.gameObject);
        one.transform.position = new Vector3(one.transform.position.x + 0.5f, one.transform.position.y, one.transform.position.z);
        print(blocksInOrder.ToString());
        print(one.transform);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        
    }
}
