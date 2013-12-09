using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneController_NGUI : MonoBehaviour
{
	private bool checkboxValue;
	private string checkboxString;
	
	private string groupString;
	
	private float sliderValue;
	private string sliderString;
	
	private GameObject label;
	private ChangeLabel changeLabel;
	
	void Start ()
	{
		label = GameObject.Find("Label-Selected");
		changeLabel = label.GetComponentInChildren<ChangeLabel>();
		
		if(gameObject.name == "Grid")
			Debug.Log("GRID");
	}
	
	
	void Update ()
	{
		/*if(gameObject.name == "GroupOption")
		{	
			for(int i=0; i < 3; i++)
			{
				Transform child = gameObject.transform.GetChild(i);
			}
			
			groupString = gameObject.GetComponentInChildren<UILabel>().text;
		}
		else */if(gameObject.name == "Slider")
		{
			sliderValue  = gameObject.GetComponent<UISlider>().sliderValue;
			sliderString = "" + sliderValue;
			
			gameObject.GetComponentInChildren<UILabel>().text = sliderString;
		}
	}
	
	
	
	void OnClick ()
	{
		changeLabel = label.GetComponentInChildren<ChangeLabel>();
		
		switch(gameObject.name)
		{
			case "Label-Name:":
			{
				changeLabel.Change("UILabel script:\n" +
					"	- displays text");
			}
			break;
			
			case "Input":
			{
				changeLabel.Change("UIInput script:\n" +
					"	- type-in area / input fields (editable text)\n" +
					"	- no keyboard(device) on free version of NGUI :(");
			}
			break;
			
			case "Checkbox":
			{
				changeLabel.Change("UICheckbox script:\n" +
					"	- for checkbox/radio buttons\n" +
					"	- toggle (if grouped checkbox)");
			
				checkboxValue  = gameObject.GetComponent<UICheckbox>().isChecked;
				checkboxString = "" + checkboxValue;
				gameObject.GetComponentInChildren<UILabel>().text = checkboxString;
			}
			break;
			
			case "Checkbox1":
			case "Checkbox2":
			case "Checkbox3":
			{
				changeLabel.Change("UICheckbox script:\n" +
					"	- for checkbox/radio buttons\n" +
					"	- toggle (if grouped checkbox)");
			
				OnCheckboxChange();
			}
			break;
			
			case "Popup_Button":
			{
				changeLabel.Change("UIPopupList script:\n" +
					"	- for drop-down list / popup menu" +
					"	- list options on the inspector");
			}
			break;
			
			case "Button-button":
			{
				changeLabel.Change("UIButton script:\n" +
					"	- to trigger functions in click/tap\n" +
					"	  with event-based highlighting");
			}
			break;
			
			case "Button-Home":
			{
				changeLabel.Change("UIAnchor script:\n" +
					"	- to anchor gameobject to side/corner of the screen");
			}
			break;
			
			case "Sprite (CloudB)":
			case "Sprite (CloudB)1":
			{
				changeLabel.Change("UISprite:\n" +
					"	- to draw texture from an atlas\n" +
					"	- ex. Cloud sprite from the UgokuAtlas");
			}
			break;
			
			case "Button-Tween":
			{
				changeLabel.Change("UITweener:\n" +
					"	- inherited by TweenPosition/Tranform/Rotation/Scale\n" +
					"	- specify animation From, To, Animation Curve, Duration");
			}
			break;
			
			case "Panel2":
			{
				changeLabel.Change("UIDragObject:\n" +
					"	- added to UIPanel to enable dragging of Panel");
			}
			break;
			
			default:
			changeLabel.Change("---");
			break;
		}
	}
	
	
	void OnCheckboxChange()
	{
		Transform parent = gameObject.transform.parent;
		bool isChecked = false;
		if(!isChecked)
			groupString = "checked:\n--";
		
		for(int i=0; i < 4; i++)
		{
			Transform child = parent.transform.GetChild(i);
			
			if(child.GetComponent<UICheckbox>() != null)
			{
				isChecked = child.GetComponent<UICheckbox>().isChecked;
				Debug.Log(isChecked);
				if(isChecked)
					groupString = "checked:\n" + child.name;
			}
			else
			{	
				child.GetComponent<UILabel>().text = groupString;
			}
		}
		
	}
	
	
	void OnSliderChange()
	{
		changeLabel.Change("UISlider script:\n" +
			"	- for draggable sliders\n" +
			"	- indicate foreground, background, thumbnail");
	}
	
	
	void OnDrag (Vector2 delta)
	{
		if(gameObject.name == "Slider")
			OnSliderChange();
		else if(gameObject.name == "Panel2")
			changeLabel.Change("UIDragObject:\n" +
				"	- added to UIPanel to enable dragging of Panel");
		else if(gameObject.name == "Sprite (CloudB)")
		{
			changeLabel.Change("UIDraggable Panel: added to UIPanel to enable dragging\n" +
				"UIGrid: to arrange children of Draggable Panel into fixed-size");
		}
	}
}