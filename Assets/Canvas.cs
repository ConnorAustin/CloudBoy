using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour {
    public static Canvas self;
    public Color maxWater;
    public Color noWater;

    GameObject gameover;
    Text water;

	void Start () {
        self = this;
        water = transform.Find("WaterHealth").GetComponent<Text>();
        water.color = maxWater;
        gameover = transform.Find("GameOver").gameObject;
        gameover.SetActive(false);
    }

    public void SetWater(float w) {
        water.text = Mathf.Ceil(w).ToString() + "%";
        water.color = Color.Lerp(noWater, maxWater, w / 100.0f);
    }

    public void GameOver() {
        gameover.SetActive(true);
    }
	
	void Update () {
		
	}
}
