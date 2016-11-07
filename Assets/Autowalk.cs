using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Autowalk : MonoBehaviour {
	private FirstPersonController controller;
	private mind neuroSky;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindObjectOfType<FirstPersonController> ();
		neuroSky = GameObject.Find ("Mind").GetComponent<mind> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (neuroSky.poorSignal != 0 && neuroSky.atten > 50) {
			// Speed Up
			if(controller.M_WalkSpeed <= 20) {
				controller.M_WalkSpeed++;	
			}
		} else if(neuroSky.poorSignal != 0 && neuroSky.atten <= 50){
			// Slow Down
			if (controller.M_WalkSpeed >= 0) {
				controller.M_WalkSpeed--;
			}
		}
	}

	void OnGUI(){
		GUILayout.BeginVertical();
		GUILayout.Space(Screen.height / 2);
		GUILayout.Label("Speed:" + controller.M_WalkSpeed);

		GUILayout.EndVertical();
	}
}
