using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Csharp_powerupDisplay : MonoBehaviour {

	private bool controlsShown = false;
	private bool jumpMessageShown = false;
	private bool poundMessageShown = false;
	private bool winMessageShown = false;
	
	// Update is called once per frame
	void Update () {
		if (!controlsShown) {
			GetComponent<Text>().text = "WASD to move \n<Space> to Jump";
			controlsShown = true;
			Invoke ("clearText", 4f);
		}
		if (Csharp_playerController.doubleJumpUnlocked && !jumpMessageShown) {
			GetComponent<Text>().text = "You got Double Jump! \nPress <Space> in air to jump again!";
			jumpMessageShown = true;
			Invoke ("clearText", 4f);
		}
		if (Csharp_playerController.groundPoundUnlocked && !poundMessageShown) {
			GetComponent<Text>().text = "You got Ground Pound! \nPress <S> in air to plummet and \nbreak red ground!";
			poundMessageShown = true;
			Invoke ("clearText", 4f);
		}
		if (Csharp_playerController.playerWin && !winMessageShown) {
			GetComponent<Text>().text = "You Win! \nAlt-F4 to Quit";
			winMessageShown = true;
			Invoke ("clearText", 4f);
		}
	}

	void clearText(){
		GetComponent<Text>().text = "";
	}
}
