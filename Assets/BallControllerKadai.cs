using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControllerKadai : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;



	//スコアを初期化
	private int score = 0;
	//スコアを表示するテキスト
	private GameObject scoreText;




	// Use this for initialization
	void Start () {

		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find ("GameOverText");


		//シーン中のScoreTextオブジェクトの取得
		this.scoreText = GameObject.Find("ScoreText");


	}


	
	// Update is called once per frame
	void Update () {
	
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}

		//scoreに現在の点数を表示
		this.scoreText.GetComponent<Text>().text = score.ToString();

	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "SmallStarTag"){
			this.score += 10;
		}if(col.gameObject.tag == "SmallCloudTag"){
			this.score += 10;
		}if(col.gameObject.tag == "LargeStarTag"){
			this.score += 20;
		}if(col.gameObject.tag == "LargeCloudTag"){
			this.score += 20;
		}



		Debug.Log (score);

	}



		

}
