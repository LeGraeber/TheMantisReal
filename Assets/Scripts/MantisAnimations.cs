using UnityEngine;
using System.Collections;
using Spine.Unity;

public class MantisAnimations : MonoBehaviour {

	[SpineAnimation]
	public string jumpAni;
	[SpineAnimation]
	public string walkAni;
	[SpineAnimation]
	public string slideAni;

	SkeletonAnimation skeletonAnimation; 


	// Use this for initialization
	void Start () {

		skeletonAnimation = GetComponent<SkeletonAnimation> ();

		//skeletonAnimation.state.Complete += delegate {
		//	skeletonAnimation.skeleton.SetToSetupPose ();
		//}; 


	}

	
	// Update is called once per frame
	void Update () {

	

		if (Input.GetButtonDown ("Jump")) {



			skeletonAnimation.state.SetAnimation (0, jumpAni, false);
			skeletonAnimation.state.AddAnimation (0, walkAni, true, 0f);

		} else if (Input.GetKeyDown ("s")) {

			skeletonAnimation.state.SetAnimation (0, slideAni, false);
			skeletonAnimation.state.AddAnimation (0, walkAni, true, 0f);

		}



	}
}
