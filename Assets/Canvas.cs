﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour {
    public static Canvas self;
    public Color maxWater;
    public Color noWater;

    GameObject gameover;
    Text water;
    Text message;
    GameObject win;

	void Start () {
        self = this;
        water = transform.Find("WaterHealth").GetComponent<Text>();
        water.color = maxWater;
        gameover = transform.Find("GameOver").gameObject;
        gameover.SetActive(false);

        message = transform.Find("Message").GetComponent<Text>();
        win = transform.Find("Win").gameObject;
        win.SetActive(false);
    }

    public void SetWater(float w) {
        water.text = Mathf.Ceil(w).ToString() + "%";
        water.color = Color.Lerp(noWater, maxWater, w / 100.0f);
    }

    public void GameOver() {
        gameover.SetActive(true);
    }

    public void ShowMessage(string msg) {
        message.text = msg;
    }

    public void Win()
    {
        win.SetActive(true);
    }

    void Update () {
		
	}
}
