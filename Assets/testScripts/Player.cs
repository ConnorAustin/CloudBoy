using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Flameable {

    float water;

	void Start () {
        water = 100.0f;
        Time.timeScale = 1.0f;
    }

	public override void touchFire() {
		AddWater (-1.0f);
	}

    public void AddWater(float w)
    {
        water += w;
        if(water < 0)
        {
            water = 0;
            Canvas.self.GameOver();
            GetComponent<PlayerController>().enabled = false;
            Time.timeScale = 0.0f;
            Invoke("Restart", 2.0f);
        }
        if(water > 100)
        {
            water = 100.0f;
        }
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public float GetWater()
    {
        return water;
    }
	
	void Update () {
        Canvas.self.SetWater(water);
    }
}
