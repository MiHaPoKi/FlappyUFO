using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnOffset : MonoBehaviour
{
	public GameObject Cell;
	public Transform Zero;
	public int Width;
	public GameObject Cell2;
	public Transform Zero2;

    // Start is called before the first frame update
    public void Start()
    {
    	Generate();
    }

    public void Generate()
    {
    	for(int x = 0; x < Width; x++)
    	{
    		var cell = Instantiate(Cell, Zero);
    		cell.transform.position = new Vector3(x, Random.Range(-1, 5), 0);
    		x += 10;
    	}
    	for(int x = 0; x < Width; x++)
    	{
    		var cell = Instantiate(Cell2, Zero2);
    		cell.transform.position = new Vector3(x, 0, 0);
    		x += 10;
    	}
    }
}
