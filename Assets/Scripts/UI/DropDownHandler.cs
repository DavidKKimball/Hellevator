using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DropDownHandler : MonoBehaviour {

	public Dropdown Dropdown;
	public Text Label;
	private Text SelectedLocation;
	public string LocName;

	void Start () {

	    Dropdown.GetComponent<Dropdown> ().options.Add (new Dropdown.OptionData() {text=""});
	    Dropdown.GetComponent<Dropdown>().value = Dropdown.GetComponent<Dropdown>().options.Count - 1;
	    Dropdown.GetComponent<Dropdown>().options.RemoveAt(Dropdown.GetComponent<Dropdown>().options.Count - 1);

		SelectedLocation = Label.GetComponent<Text>();
		SelectedLocation.text = "Tech Demo";
 		LocName = SelectedLocation.text;


		Dropdown.onValueChanged.AddListener(delegate {
		dropdownValueChangedHandler(Dropdown); });
	}

	public void Destroy () {
     	Dropdown.onValueChanged.RemoveAllListeners();
 	}

	private void dropdownValueChangedHandler(Dropdown target) {
     	Debug.Log("Selected: " + target.value);
 	}

	public void SetDropdownIndex(int index) {
     	Dropdown.value = index;
 	}

	public void LoadTechDemo () {

		if (Dropdown.value == 0) {
			SceneManager.LoadScene("TechPrototype");
		} else if (Dropdown.value == 1) {
			SceneManager.LoadScene("TestRoom");
		}
	}
}
