#pragma strict

private var controlsShown : boolean = false;
private var jumpMessageShown : boolean = false;
private var poundMessageShown : boolean = false;
private var winMessageShown : boolean = false;

function Update () {
	if (!controlsShown) {
		GetComponent(UI.Text).text = "WASD to move \n<Space> to Jump";
		controlsShown = true;
		Invoke ("clearText", 4f);
	}
	if (JS_playerController.doubleJumpUnlocked && !jumpMessageShown) {
		GetComponent(UI.Text).text = "You got Double Jump! \nPress <Space> in air to jump again!";
		jumpMessageShown = true;
		Invoke ("clearText", 4f);
	}
	if (JS_playerController.groundPoundUnlocked && !poundMessageShown) {
		GetComponent(UI.Text).text = "You got Ground Pound! \nPress <S> in air to plummet and \nbreak red ground!";
		poundMessageShown = true;
		Invoke ("clearText", 4f);
	}
	if (JS_playerController.playerWin && !winMessageShown) {
		GetComponent(UI.Text).text = "You Win! \nAlt-F4 to Quit";
		winMessageShown = true;
		Invoke ("clearText", 4f);
	}
}

function clearText(){
	GetComponent(UI.Text).text = "";
}