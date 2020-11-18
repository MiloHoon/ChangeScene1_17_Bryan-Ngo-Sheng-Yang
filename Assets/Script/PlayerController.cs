using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Player Speed
    float speed = 10;
    //Collected Coin Amount
    int coinCount;
    //Total Coin Ingame
    int totalCoin;

    public Text CoinCollected;

    // Start is called before the first frame update
    void Start()
    {
       totalCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        //Player Move Forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        //Player Move Backward
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        //Player Move Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //Player Move Right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (coinCount == totalCoin)
        {
            SceneManager.LoadScene("WinScene");
        }

        if (transform.position.y < -5)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount ++;
            CoinCollected.GetComponent<Text>().text = "Coin Collected: " + coinCount;

            Destroy(other.gameObject);
        }
    }
}
