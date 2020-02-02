using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject[] items = new GameObject[3];
    public bool treeDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LateUpdate()
    {
        if (treeDestroyed)
        {
            Vector3 position = transform.position;
            position.y = -5.8f;

            foreach (GameObject item in items)
            {
                if (item != null)
                {
                    Instantiate(item, position, Quaternion.identity);
                }
            }

            Destroy(gameObject);
        }
    }

}
