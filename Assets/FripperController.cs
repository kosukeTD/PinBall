using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
	//HingiJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	//Q.これだと一気に動くけど、徐々に動く方法ってあるの？？→調べよう
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		//Q.SetAngleって関数じゃないの？？→解決。後ろにあった。
		SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {

		//左矢印キーを押した時左フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		//右矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		//矢印キー離された時フリッパーを元に戻す
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}
	}

	//フリッパーの傾きを設定
	//Q.どうして先に設定しないの？？→どこかにあれば良い
		public void SetAngle(float angle){
			//Q.jointSprが勝手に変換される。いい方法はない？？→escキー
			JointSpring jointSpr = this.myHingeJoint.spring;
			jointSpr.targetPosition = angle;
			this.myHingeJoint.spring = jointSpr;
}

}