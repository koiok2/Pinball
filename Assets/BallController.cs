using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
	public Text ScoreText;
	private int Score;
    
	// (追加)
	int Sstar;
	int Lstar;
	int SCloud;
	int LCloud;


	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");

		//シーン中のscoreTextオブジェクトを取得（追加）
		this.ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();

	}

	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}


	//衝突時に呼ばれる関数（得点合計）
	void OnCollisionEnter(Collision other) {

		// タグ毎に得点を設定
		if (other.gameObject.tag == "SmallStarTag") {
			Sstar += 5;
		} else if (other.gameObject.tag == "LargeStarTag") {
			Lstar += 10;
		} else if(other.gameObject.tag == "SmallCloudTag") {
			SCloud += 15;
		} else if(other.gameObject.tag == "LargeCloudTag") {
			LCloud += 20;
		}

		//点数表示
		this.ScoreText.text = (Sstar + Lstar + SCloud + LCloud).ToString();
	}
}