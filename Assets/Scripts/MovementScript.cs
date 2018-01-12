using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour {
    private Rigidbody rigidbody;
    private Collider collider;
    
    public GameObject[] Collidables;
    int winCount;

    public Canvas canvas;
    int count = 0;

	void Start () {
        winCount = Collidables.Length;
        this.transform.position = new Vector3(0,0.5f,0);

        rigidbody = this.transform.GetComponent<Rigidbody>();
        collider = this.transform.GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup")) { other.gameObject.SetActive(false); count++;
            UpdatePoints();
            if(count >= winCount)
            {
                DisaplayWinMessage();
            }
        }
        
    }
    private void DisaplayWinMessage()
    {
        var text = canvas.transform.Find("WinText").GetComponent<Text>();
        text.text = "Congratulations, you are to win!";
    }
	private void UpdatePoints()
    {
        var text = canvas.transform.Find("PointValues").GetComponent<Text>();
        text.text = count.ToString();
              
    }
    private void ResetGame()
    {
        Debug.Log("Reseting board");
        this.transform.position = new Vector3(0, 0.5f, 0);
        count = 0;
        var text = canvas.transform.Find("WinText").GetComponent<Text>();
        text.text = "";

        text = canvas.transform.Find("PointValues").GetComponent<Text>();
        text.text = "";

        Collidables.ToList().ForEach(x=>x.gameObject.SetActive(true));

    }

	void FixedUpdate () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetGame();
        }


        var forceDirection = new Vector3(0, 0, 0);
        if(Input.GetKey(KeyCode.DownArrow)){
            forceDirection += Vector3.back;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            forceDirection += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            forceDirection += Vector3.left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            forceDirection += Vector3.right;
        }
        rigidbody.AddForce(forceDirection.normalized*10, ForceMode.Acceleration);
    }
}
