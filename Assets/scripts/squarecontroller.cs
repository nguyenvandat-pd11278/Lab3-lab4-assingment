using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class squarecontroller : MonoBehaviour
{
    public float movespeed = 5f;
    public float timeRemaining = 60;
    public Text countdowText;
    public Transform spawnPlace;
    public GameObject bulletprefab;
    public float bulletspeed = 15f;
    private Rigidbody2D rb;
    public PlayerData playerData;

    private Vector2 shootDirection;
    void Start()
    {
        shootDirection = Vector2.right;
        StartCoroutine(Countdown());
        rb = GetComponent<Rigidbody2D>();
    }
    IEnumerator Countdown()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            countdowText.text = "Time :" + timeRemaining.ToString();
        }
        countdowText.text = "Time's up!";
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (moveHorizontal < 0)
        {
            shootDirection = Vector2.left;
        }
        else if (moveHorizontal > 0)
        {
            shootDirection = Vector2.right;
        }
        else if (moveVertical > 0)
        {
            shootDirection = Vector2.up;
        }
        else if (moveVertical < 0)
        {
            shootDirection = Vector2.down;
        }
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.Translate(moveDirection * movespeed * Time.fixedDeltaTime);

    }
    public void LoadNextScene()
    {
        //khi chuyen sang screen tiep theo thi tang 1 level 
         playerData.playerLevel++;
        PlayerPrefs.SetInt("PlayerLevel", playerData.playerLevel);
        PlayerPrefs.SetInt("PlayerScore", playerData.playerScore);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("circle"))
        {
            transform.position = spawnPlace.transform.position;
            rb.velocity = Vector3.zero;
        }
        if (collision.gameObject.tag.Equals("box"))
        {
            Debug.Log("win");
            LoadNextScene();
        }
        if (collision.gameObject.tag.Equals("Pinwheel"))
        {
            transform.position = spawnPlace.position;
        }

    }
}
