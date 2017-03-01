using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;

    public float maxSpeed;

    public static GameObject player;

    public GameObject pivot;

    public Rigidbody playerRb;

    public MeshRenderer playerMesh;

    public static int coins = 0;

    public int coinsScore;

    public Vector3 newPosition;

    private Quaternion localRotation;


    void Start()
    {
        playerRb = player.GetComponent<Rigidbody>();
        playerMesh = player.GetComponent<MeshRenderer>();

        localRotation = transform.rotation;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //playerRb.AddForce(0, 5, 0, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //playerRb.AddForce(0, 5, 0, ForceMode.Impulse);
        }

    }

    public void OnTriggerEnter(Collider other)

    {
        if (other.tag == "hazard")

        {
            SceneManager.LoadScene("ReplayMenu");

            Destroy(player);
        }

        if (other.tag == "spring")

        {
            playerRb.AddForce(0, 5, 0, ForceMode.Impulse);
            other.transform.Translate(0, (float)0.1, 0 * Time.deltaTime);
        }


        if (other.tag == "Gems")

        {

            coins = coins + 1;

            Destroy(other.gameObject);

            coinsScore = coins;
        }
    }
}


