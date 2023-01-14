using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

public class UfoController : MonoBehaviour
{
	public float horizontalSpeed;
	public float verticalImpulse;
	float speedX;
	Rigidbody2D rb;
	//public float firstTap;
	public Text text;
	public Text text2;
	private AudioSource audioSource;
	public int pts;
	public int highPts;
	bool isGrounded;
	string hptsConv;
	//public string filename;
	//public string path = @"C:\Flappy UFO Data\HighScore\HighScore.txt";

    // Start is called before the first frame update
    void Start()
    {
    	rb = GetComponent<Rigidbody2D>();
        //firstTap = 0;
        audioSource = GetComponent<AudioSource>(); 
        if(!Directory.Exists("UFO Data"))
        {
            Directory.CreateDirectory("UFO Data");
        }                    
        if(!File.Exists("UFO Data/HighScore.txt"))
        {
            File.Create("UFO Data/HighScore.txt");
        }
        hptsConv = File.ReadAllText("UFO Data/HighScore.txt");
        //Debug.Log("readed" + hptsConv);
        highPts = int.Parse(hptsConv);
        //Debug.Log("Read" + highPts);
         
    }
 	
    // Update is called once per frame
    void Update()
    {
       text.text = pts.ToString();
       text2.text = hptsConv;
	   if (isGrounded)
       {
       		//Debug.Log("Hi" + highPts);
       		//Debug.Log("Pts" + pts);
       		if(pts > highPts)
       		{
       			//Debug.Log("Hi" + hptsConv);
       			//Debug.Log("Pts" + pts);
     			File.WriteAllText("UFO Data/HighScore.txt", pts.ToString());
       		}
       		//string hptsConv = highPts.ToString();
     		//File.WriteAllTextAsync("UFO Data/HighScore.txt", hptsConv);
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

