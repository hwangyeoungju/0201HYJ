using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class Spinning : MonoBehaviour 
{	
	public Player Player;
	public Line Line;
	public Bait Bait; //미끼

	public Fish CatchedFish; //잡힌 물고기 객체

	public Transform LineStart;

	public bool Casted = false; // 낚싯줄이 던져진 상태

	public bool Catching = false; //낚고 있는 상태

	public float CastSpeed = 5f; //낚싯줄을 던질때의 속도

	[Header("SpinningSettings")]
	public float power;
	public Test SpinningPhysics;


	private float ScreenWidth;
	private float CursorWidth;
	private float NormalizedWidth;
	[Header("SpinningContol")]
	public float MaxXValue;
	public float MinXValue;


	private float ScreenHeight;
	private float CursorHeight;
	private float NormalizedHeight;

	public float MaxYValue;
	public float MinYValue;

	public void Cast( Vector3 point )
	{
		Bait.transform.position = point; //미끼의 위치를 point로 설정 = 낚싯줄이 던져질 위치로 미끼를 이동
		Line.Regenerate();
		Casted = true;
		Bait.BaitActive = true;
		Bait.maxDeep = point.y; //최대깊이
		Bait.minDeep = point.y - 10; //최소깊이
	}

	void Start ()
	{
		ScreenHeight = Screen.height;
		ScreenWidth = Screen.width;
	}
	float time = 0;
	void Update()
	{
		if(Casted)
		{
			Line.Regenerate(); //낚싯줄 재생성
			//낚싯줄 끝과 미끼 간의 거리를 계산
			float Distance = Vector3.Distance(new Vector3(LineStart.position.x,Bait.transform.position.y,LineStart.position.z),Bait.transform.position);

			//거리가 1보다 작으면 Casted 상태 false
			if(Distance<1)
			{
				Player.UpdateStage(PlayStage.Cast);
				Casted = false;
			}

			Bait.Cast(OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch)); //마우스 버튼 누르면 동작
			if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
			{
				//미끼가 낚싯줄 방향으로 바라보도록 설정
				Bait.transform.LookAt(new Vector3(LineStart.position.x,Bait.transform.position.y,LineStart.position.z));

				Bait.transform.Translate(Vector3.forward * Time.deltaTime * CastSpeed);
			
			}
		}
		if(Catching)
		{
			//Bait.Cast(false);
			Line.Regenerate();
			Debug.Log("Catching");
			SpinningPhysics.Cast(OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch), power);
			if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
			{
				if(time<1)
					time += Time.deltaTime * 3;
				CatchedFish.cathcing = true;
			}
			else
			{
				if(time>0)
					time -= Time.deltaTime * 3;
				
				CatchedFish.cathcing = false;
			}
			//선의 길이를 보간함수를 통해110에서 400으로 설정
			Line.wireCatenary = Mathf.Lerp(110, 400, time);

		}
		else
		{
			SpinningPhysics.Cast(false,power);
		}
		RotateSpinning();
	}

	public void RotateSpinning()
	{
		CursorHeight = Mathf.Clamp(Input.mousePosition.y, 0, ScreenHeight); 
		CursorWidth = Mathf.Clamp(Input.mousePosition.x, 0, ScreenWidth);

		NormalizedHeight = CursorHeight / ScreenHeight;
		NormalizedWidth = CursorWidth / ScreenWidth;

		transform.localRotation = Quaternion.Euler(Mathf.Lerp(MinYValue, MaxYValue, NormalizedHeight), Mathf.Lerp(MinXValue, MaxXValue, NormalizedWidth), 0);
	}




}
