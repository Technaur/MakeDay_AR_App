using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

// using System.Web.Extensions;
// using System.Web;
// using System.Web.Script.Serialization;

public class Crash : MonoBehaviour {

[System.Serializable]
  public class Claims
  {
    public Claim[] values;
  }

  [System.Serializable]
  public class Claim
  {
    public string claim_id;
    public string created_at;
    public string approval_status;
    public string policy_id;
    public string member_id;
    public string claim_status;
    public AppData app_data;
    public int requested_amount;
    public CreatedBy created_by;
  }

    [System.Serializable]
  public class ClaimSubmit
  {
    public string policy_id;
    public string incident_type;
    public string incident_cause;
    public string incident_date;    
    public AppData app_data;
    public int requested_amount;
    
  }

   [System.Serializable]
  public class CreatedBy
  {
    public string id;
    public string type;
    
  }

	[Serializable]
	public class Param
	{
		public Param (string _key, string _value) {
		key = _key;
		value = _value;
		}
		
		public string key;
		public string value;
	}

	// Use this for initialization
	void Start () {
		Debug.Log("Starting Crash");
		
	}

	[Serializable]
	public class AppData{
		public string key1;
		public string key2;
	}

	public void OnCollisionEnter(Collision collision)
    {
		Debug.Log("Crash!!!");
        
		var obj = new ClaimSubmit{
			policy_id =  "fcc1bf31-dc60-4ae4-90d6-17bc410d2f93",
			incident_type = "Crash with planet",
			incident_cause = "Drunk driver",
			incident_date = "2018-10-16T10:12:02.872Z",
			app_data = new AppData{key1 = "", key2 = ""} ,
			requested_amount = 4800000			
		};
    	// parameters.Add(new Param("policy_id", "fcc1bf31-dc60-4ae4-90d6-17bc410d2f93"));
    	// parameters.Add(new Param("incident_type", "Crash with planet"));
    	// parameters.Add(new Param("incident_cause", "Drunk driver"));
    	// parameters.Add(new Param("incident_date", "2018-10-16T10:12:02.872Z"));
    	//parameters.Add(new Param("app_data", JsonUtiliy.ToJson(null)));
    	// parameters.Add(new Param("requested_amount", "1000000"));

		 var json = JsonUtility.ToJson(obj);
		Debug.Log(json);
		//StartCoroutine(CallAPICoroutine("https://sandbox.root.co.za/v1/insurance/claims", json));

    }

	IEnumerator CallAPICoroutine(String url, String parameters)
	{
		string auth = "sandbox_YTFmMGU5YTMtYjZmZC00OGQ2LTk5MTYtMTM2MTRhZThhODEzLmNoZGJtMllKTFdMQnc0Vzc4SWxTWkVRSWFoOUhMUlJ3:";
		auth = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
		auth = "Basic " + auth;


		// var request = new UnityWebRequest (url, "POST");
		// byte[] bodyRaw = Encoding.UTF8.GetBytes(logindataJsonString);
		// request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
		// request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
		// request.SetRequestHeader("Content-Type", "application/json");
		// yield return request.Send();

		// if (www.error != null)
		// {
		// 	Debug.Log("Erro: " + www.error);
		// }
		// else
		// {
		// 	Debug.Log("All OK");
		// 	Debug.Log("Status Code: " + request.responseCode);
		// }



		// WWWForm form = new WWWForm();

		// foreach (var param in parameters) {
		// 	form.AddField(param.key, param.value);
		// }

		// UnityWebRequest www = UnityWebRequest.Post(url, form);
		// www.SetRequestHeader("AUTHORIZATION", auth);
		// yield return www.Send();

		// if (www.isNetworkError || www.isHttpError)
		// {
		// Debug.Log(www.downloadHandler.text);
		// }
		// else
		// {
		// Claims json = JsonUtility.FromJson<Claims>("{\"values\":" + www.downloadHandler.text + "}");

		// String text = "Requested amount: R" + json.values[0].requested_amount;
		// Debug.Log("Form upload complete!");
		// Debug.Log(text);
		// //text_mesh.text = text;
		// }
		yield return true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
