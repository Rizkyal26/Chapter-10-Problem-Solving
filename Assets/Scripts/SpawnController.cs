using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
	public Transform[] Positions;
	public GameObject Object;

	public Transform Location;

	public bool ToSpawn = true;

	// Start is called before the first frame update
	void Update()
	{
		// perintah untuk mengatur posisi kotak secara random dimunculkan di tiap area
		Location = Positions[Random.Range(0, Positions.Length)];

		if (ToSpawn == true)
		{
			Instantiate(Object, Location);
			ToSpawn = false;
			StartCoroutine(ToSpawnTrue());
		}
	}

	// Perintah untuk mengatur waktu muncul nya kotak selama beberapa detik

	IEnumerator ToSpawnTrue()
	{
		yield return new WaitForSeconds(3f);
		ToSpawn = true;
	}
}