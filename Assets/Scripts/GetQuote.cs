using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetQuote : MonoBehaviour 
{

	[System.Serializable]
  public class Quotes
  {
    public Quote[] values;
  }

  [System.Serializable]
  public class Quote
  {
    public string package_name;
    public string sum_assured;
    public int base_premium;
    public string suggested_premium;
    public string created_at;
    public string quote_package_id;
    public QuoteModule module;
  }

   [System.Serializable]
  public class QuoteModule
  {
    public string type;
    public string make;
    public string model;
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
		Debug.Log("Starting...");
	}

	public void CreateQuote(){
    	List<Param> parameters = new List<Param>();
    	parameters.Add(new Param("type", "root_pac"));
    	parameters.Add(new Param("age", "30"));
    	parameters.Add(new Param("gender", "male"));
    	parameters.Add(new Param("term", string.Format("{'unit': 'month','value': 1}")));
    	
    	parameters.Add(new Param("sum_assuared", "5000000"));
    	// parameters.Add(new Param("benefits", new Param("death", "true")));
    	// parameters.Add(new Param("benefits", new Param("disability", "true")));
    	// parameters.Add(new Param("benefits", new Param("hospitalisation", "daily")));

		StartCoroutine(CallAPICoroutine("https://sandbox.root.co.za/v1/insurance/quotes", parameters));
	}

	
		
	IEnumerator CallAPICoroutine(String url, List<Param> parameters)
	{
		string auth = "sandbox_YTFmMGU5YTMtYjZmZC00OGQ2LTk5MTYtMTM2MTRhZThhODEzLmNoZGJtMllKTFdMQnc0Vzc4SWxTWkVRSWFoOUhMUlJ3:";
		auth = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
		auth = "Bearer " + auth;

		WWWForm form = new WWWForm();

		foreach (var param in parameters) {
		form.AddField(param.key, param.value);
		}

		UnityWebRequest www = UnityWebRequest.Post(url, form);
		www.SetRequestHeader("AUTHORIZATION", auth);
		yield return www.Send();

		if (www.isNetworkError || www.isHttpError)
		{
		Debug.Log(www.downloadHandler.text);
		}
		else
		{
		Quotes json = JsonUtility.FromJson<Quotes>("{\"values\":" + www.downloadHandler.text + "}");

		String text = "Covered for: R" + json.values[0].sum_assured + "\nPremium: R" + (json.values[0].suggested_premium);
		Debug.Log("Form upload complete!");
		Debug.Log(text);
		//text_mesh.text = text;
		}
		yield return true;
	}
}
