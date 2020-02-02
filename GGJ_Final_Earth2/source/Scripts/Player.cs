using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;

    public Text seedCounter;
    public Text logCounter;
    public Text oxygenCounter;
    public Text carbonCounter;

    //private Destroy destroyTree;
    private Plant plantTree;
    public bool treeDestroyed = false;
    public GameObject[] items = new GameObject[3];

    private int seedAmount, logAmount, oxygenAmount;
    private int carbonAmount = 100;

    public GameObject objectToSpawn;
    public GameObject buildHouse;
    public GameObject shrooms;
    public Text StartQuote;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //destroyTree = FindObjectOfType<Destroy>();

        //Display Text
        seedCounter.text = "Seed Count: " + seedAmount;
        logCounter.text = "Log Count: " + logAmount;
        oxygenCounter.text = "Oxygen Level: " + oxygenAmount + "%";
        carbonCounter.text = "Carbon Levels: " + carbonAmount + "%";
        StartQuote.text = "''It is the neglect of timely" + "\nrepair that makes" + "\nrebuilding necessary.''";

    }

    // Update is called once per frame
    void Update()
    {
        if (carbonAmount == 0 || oxygenAmount == 100) {
            SceneManager.LoadScene("EndScene");
        }else if (carbonAmount == 50)
        {
            StartQuote.text = "Halfway there!" + "\nIt takes awhile, but the" + "\noutcome is always worth the wait!";
        }else if (carbonAmount < 45)
        {
            shrooms.SetActive(true);
        }

        //Moves left and right
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * speed);

        //Player Jump
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            // then force is applied to Rigidbody2D component to make Player jump
            rb.velocity = Vector2.up * jumpForce;
        }

        seedCounter.text = "Seed Count: " + seedAmount;
        logCounter.text = "Log Count: " + logAmount;
        oxygenCounter.text = "Oxygen Level: " + oxygenAmount + "%";
        carbonCounter.text = "Carbon Levels: " + carbonAmount + "%";

        if (logAmount < 10)
        {
            buildHouse.SetActive(false);
        }
        else
        {
            buildHouse.SetActive(true);
        }

        if (seedAmount > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                spawnPosition.y = -1.6f;
                spawnPosition.z = 25f;

                GameObject treeobject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

                //Descrease seed amount by 1
                seedAmount -= 1;
                oxygenAmount += 10;
                carbonAmount -= 10;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "seed")
        {
            seedAmount += 1;
            Destroy(collision.gameObject);
        }

        //Destroy Wood Drops
        if (collision.tag == "wood")
        {
            logAmount += 1;
            Destroy(collision.gameObject);
        }

        //Destroy Tree
        if (collision.tag == "tree")
        {
            //destroyTree.treeDestroyed = true;
            treeDestroyed = true;
            //destroyTree.LateUpdate();
            //LateUpdate();
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

                Destroy(collision.gameObject);
            }
        }
    }

    /*
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

            Destroy(collision.gameObject);
        }
    }
    */
}
