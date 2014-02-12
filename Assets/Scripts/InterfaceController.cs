using UnityEngine;
using System.Collections;

public class InterfaceController : MonoBehaviour {

	
	public TextMesh timerText;
	public TextMesh filesText;

	public Renderer wifiSymbol; //the wifi bar
	public Transform downloadBar;

	Vector3 savedTransf;

	void Start(){
		savedTransf = downloadBar.localScale;
	}

	public void UpdateTimer(float timeRemaining){
		timeRemaining = Mathf.Ceil(timeRemaining);

		if(timeRemaining<1f){
			timeRemaining = 0f;
			return;
		}

		string txt = "00:"+((timeRemaining<10)?"0"+timeRemaining:""+timeRemaining);

		timerText.text = txt;
	}

	public void UpdateWifiSymbol(float currentDistance, float maxDistance){
		float wifiPercent = Mathf.Clamp01(currentDistance/maxDistance);

		wifiSymbol.material.SetFloat("_Cutoff", wifiPercent);
		//TODO: change shader here
	}

	public void UpdateDownloadBar(float currentUpload, float totalUpload){
		float percent = currentUpload/totalUpload;

		downloadBar.localScale = new Vector3(percent, savedTransf.y, savedTransf.z);
	}

	public void UploadFilesSent(int filesSent, int filesTotal){
		filesText.text = ""+filesSent+"/"+filesTotal;
	}
}
