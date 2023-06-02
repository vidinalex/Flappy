using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppsFlyerManager : MonoBehaviour
{
    public TextMeshProUGUI conversionDataText;

	void Start()
	{
		//DontDestroyOnLoad(this);
		AppsFlyer.setIsDebug(true);

#if UNITY_ANDROID

		AppsFlyer.init("WdpTVAcYwmxsaQ4WeTspmh");

		AppsFlyer.loadConversionData(transform.name);

#endif
	}

	public void didReceiveConversionData(string conversionData)
	{
		print("AppsFlyerTrackerCallbacks:: got conversion data = " + conversionData);
		conversionDataText.text = conversionData;

		MenuManager.Default.ShowButton();
	}
	public void didReceiveConversionDataWithError(string error)
	{
		print("AppsFlyerTrackerCallbacks:: got conversion data error = " + error);
	}
}
