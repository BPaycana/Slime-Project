using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
	[SerializeField] int dotsNumber;
	[SerializeField] GameObject dotsParent;
	[SerializeField] GameObject dotPrefab;
	[SerializeField] float dotSpacing;
	[SerializeField] [Range (0.01f, 0.3f)] float dotMinScale;
	[SerializeField] [Range (0.3f, 1f)] float dotMaxScale;

	Transform[] dotsList;
	
	//Dot position
	Vector2 pos;

	float timeStamp;

	void Start ()
	{
		//Hide trajectory in the start
		Hide ();
		//Prepare dots
		PrepareDots ();
	}

	//Instatiates the dots on the screen.
	void PrepareDots ()
	{
		dotsList = new Transform[dotsNumber];
		dotPrefab.transform.localScale = Vector3.one * dotMaxScale;

		float scale = dotMaxScale;
		float scaleFactor = scale / dotsNumber;

		for (int i = 0; i < dotsNumber; i++) {
			dotsList [i] = Instantiate (dotPrefab, null).transform;
			dotsList [i].parent = dotsParent.transform;

			dotsList [i].localScale = Vector3.one * scale;
			if (scale > dotMinScale)
				scale -= scaleFactor;
		}
	}

	//Updates the dots position on screen depending on player mouse position.
	public void UpdateDots (Vector3 ballPos, Vector2 forceApplied)
	{
		timeStamp = dotSpacing;
		for (int i = 0; i < dotsNumber; i++) {
			pos.x = (ballPos.x + forceApplied.x * timeStamp);
			pos.y = (ballPos.y + forceApplied.y * timeStamp) - ((Physics2D.gravity.magnitude * 10) * timeStamp * timeStamp) / 2f;
		
			dotsList [i].position = pos;
			timeStamp += dotSpacing;
		}
	}

	public void Show ()
	{
		dotsParent.SetActive (true);
	}

	public void Hide ()
	{
		dotsParent.SetActive (false);
	}
}
