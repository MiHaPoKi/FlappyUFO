using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;
using System.Text;

public class UfoController : MonoBehaviour
{
	public float horizontalSpeed;
	public float verticalImpulse;
	float speedX;
	Rigidbody2D rb;
	bool isGrounded;
	//public float firstTap;
	public Text text;
	public Text text2;
	private AudioSource audioSource;
	public float pts;
	public float highPts;
	public string filename;
	public string path = @"C:\Flappy UFO Data\HighScore\HighScore.mps";

    // Start is called before the first frame update
    void Start()
    {
    	rb = GetComponent<Rigidbody2D>();
    	using (FileStream fs = File.Create(path));
        //firstTap = 0;
        audioSource = GetComponent<AudioSource>();
        }
    }
 	
    // Update is called once per frame
    void Update()
    {
       text.text = pts.ToString();
       text2.text = highPts.ToString();
       if (isGrounded)
       {
       		if(pts > highPts)
       		{
       			highPts -= highPts;
       			highPts += pts;
       		}
       		SceneManager.LoadScene(1);
       }
       if (Input.GetKeyDown(KeyCode.LeftShift))
       {
			
       }
       if (Input.GetKeyDown(KeyCode.Space))
       {
       		rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
       		horizontalSpeed += 0.0001f;
       		speedX = horizontalSpeed;
       		audioSource.Play();
       		//Debug.Log(horizontalSpeed);
       }
       transform.Translate(speedX, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    	if (collision.gameObject.tag == "Ground")
    	{
    		isGrounded = true;
    	}
	   	if (collision.gameObject.tag == "Finish")
    	{
    		SceneManager.LoadScene(0);
    	}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
    	if (collision.gameObject.tag == "Pointer")
    	{
    		pts += 1;
    	}
    }

}
