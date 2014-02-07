using UnityEngine;
using System.Collections;

public class InterfaceController : MonoBehaviour {

	
	public TextMesh timerText;
	public TextMesh filesText;

	public Renderer wifiSymbol; //the wifi bar
	public Transform downloadBar;

	public void UpdateTimer(float timeRemaining){
		timeRemaining = Mathf.Ceil(timeRemaining);

		string txt = "00:"+timeRemaining;

		timerText.text = txt;
	}

	public void UpdateWifiSymbol(float currentDistance, float maxDistance){
		float wifiPercent = 1-Mathf.Clamp01(currentDistance/maxDistance);

		//TODO: change shader here
	}

	public void UpdateDownloadBar(float currentUpload, float totalUpload){
		float percent = currentUpload/totalUpload;

		downloadBar.localScale = new Vector3(percent, 1f, 1f);
	}

	public void UploadFilesSent(int filesSent, int filesTotal){
		filesText.text = ""+filesSent+"/"+filesTotal;
	}
}
