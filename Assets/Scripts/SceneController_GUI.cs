using UnityEngine;
using System.Collections;

public class SceneController_GUI : MonoBehaviour
{
	public Texture2D icon;
	private string textFieldString = " textfield (enter text)";
	private string textAreaString = " text area";
	private bool toggleBool = true;
	
	private int toolbarInt = 0;
	private string[] toolbarStrings = {"Toolbar1", "Toolbar2", "Toolbar3"};
	
	private int selectionGridInt = 0;
	private string[] selectionStrings = {"Grid 1", "Grid 2", "Grid 3", "Grid 4"};
	
	private float hSliderValue = 0.0f;
	private float vSliderValue = 0.0f;
	
	private float hScrollbarValue;
	private float vScrollbarValue;
	
	private Vector2 scrollViewVector = Vector2.zero;
	private string innerText = "I am inside the ScrollView";
	
	private Rect windowRect = new Rect (600, 450, 150, 50);
	private Rect windowRect1 = new Rect (600, 520, 220, 70);
	
	public GUIStyle customButton;
	public GUISkin mySkin;
	
	private float leftPos1 = 10.0f;
	private float leftPos2 = 450.0f;
	private float width = 100.0f;
	private float height1 = 40.0f;
	
	private string buttonText;
	private string repeatButtonText;
	private string customButtonText;
	private string windowText;
	
	/*---- Type, Position, Content ----*/
	
	//new Rect(left, top, width, height);
	
	void OnGUI()
	{	
		// Corners
		//CornerPositions();
		
		// text
		GUI.Label (new Rect (leftPos1,40,300,50), "This is the text for a Label");
		
		// texture2D
		//GUI.Label (new Rect (leftPos1,0,50,50), icon);
		
		// Content
		GUI.Box (new Rect (leftPos1,80,250,50), new GUIContent("This is BOX with text & icon", icon));
		
		ToolTip();
		
		Button();
		
		repeatButtonText = "";
		RepeatButton();
		
		// toggle button
		toggleBool = GUI.Toggle (new Rect (370, 130, 200, height1), toggleBool, " Toggle Button");
		
		// toolbar
		toolbarInt = GUI.Toolbar (new Rect (leftPos1, 320, 300, height1), toolbarInt, toolbarStrings);
		
		// selection grid
		selectionGridInt = GUI.SelectionGrid (new Rect (leftPos1, 370, 300, 60), selectionGridInt, selectionStrings, 2);
		
		Sliders();
		
		ScrollBars();
		
		// textfield (input)
		textFieldString = GUI.TextField (new Rect (280, 450, 300, height1), textFieldString);
		
		// text area
		textAreaString = GUI.TextArea (new Rect (280, 500, 300, height1), textAreaString);
		
		ScrollView();
	
		// Window
		windowRect = GUI.Window (1, windowRect, WindowFunction, "First Window");
		windowRect1 = GUI.Window (0, windowRect1, WindowFunction, "Other Window");
		
		
		// GUI.Changed (uncomment toolbar...)
		// If the user clicked a new Toolbar button this frame, we'll process their input
		if (GUI.changed)
			ChangesInGUI();
		
		
		// GUI Style
		// Make a button. We pass in the GUIStyle defined above as the style to use
		//if(GUI.Button (new Rect (330,406,200,30), "I am a Custom Button", mySkin.button))
		if(GUI.Button (new Rect (330,406,200,30), "I am a Custom Button", customButton))
		{
			customButtonText = "Clicked Custom Button";
			
			StartCoroutine(Reset());
			Debug.Log("Clicked Custom Button");
		}
		
		Changes();
		
		// GUI Skin
		// Assign the skin to be the one currently used.
		GUI.skin = mySkin;
	}
	
	void Changes()
	{
		string slider = "hSlider = " + Round(hSliderValue, 2) + ", vSlider = " +  Round(vSliderValue, 2);
		string scrollbar = "hScrollBar = " +  Round(hScrollbarValue, 2) + 
							", vScrollBar = " +  Round(vScrollbarValue, 2);
		//string scrollbar = "hScrollBar = " +  hScrollbarValue + 
							//", vScrollBar = " +  vScrollbarValue;
		 
		SceneView_GUI.codeText = slider + "\n"
								+ scrollbar + "\n\n"
								+ "Toggle: " + toggleBool + "\n\n"
								+ "ToolBar: " + (toolbarInt+1) + "\n"
								+ "Grid: " + (selectionGridInt+1) + "\n\n"
				
								+ "TextField: " + textFieldString + "\n"
								+ "TextArea: " + textAreaString + "\n\n"
								+ "WindowID: " + windowText + "\n\n"
				
								+ buttonText + "\n"
								+ repeatButtonText + "\n"
								+ customButtonText + "\n";
		
	}
	
	float Round(float v, int digits)
	{
		float mult = Mathf.Pow(10.0f, (float)digits);
		return Mathf.Round(v * mult)/mult;
	}
	
	void CornerPositions ()
	{
		GUI.Box (new Rect (0,0,100,50), "Top-left");
		GUI.Box (new Rect (Screen.width - 100,0,100,50), "Top-right");
		GUI.Box (new Rect (0,Screen.height - 50,100,50), "Bottom-left");
		GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom-right");
	}

	void ToolTip ()
	{
		// This line feeds "This is the tooltip" into GUI.tooltip
		GUI.Button (new Rect (leftPos1,140,150,height1), new GUIContent ("View ToolTip", "This is the tooltip"));

		// This line reads and displays the contents of GUI.tooltip
		GUI.Label (new Rect (leftPos1,180,300,height1), GUI.tooltip);
	}
	
	void Button ()
	{
		// Button
		if (GUI.Button (new Rect (leftPos1, 210, 150, height1), "Button")) {
			// This code is executed when the Button is clicked
			buttonText = "Button is clicked!";
			
			StartCoroutine(Reset());
			Debug.Log("Button is clicked!");
		}
	}
	
	void RepeatButton ()
	{
		// RepeatButton
		if (GUI.RepeatButton (new Rect (leftPos1, 260, 150, height1), "RepeatButton")) {
			// This code is executed every frame that the RepeatButton remains clicked
			repeatButtonText = "Repeat Button is still clicked!";
			Debug.Log("Repeat Button is still clicked!");
		}
	}

	void Sliders ()
	{
		// slider (horizontal/vertical)
		hSliderValue = GUI.HorizontalSlider (new Rect (280, 40, 200, height1), hSliderValue, 0.0f, 10.0f);
		
		vSliderValue = GUI.VerticalSlider (new Rect (280, 65, height1, 200), vSliderValue, 10.0f, 0.0f);
		
		
		Debug.Log("hSlider = " + hSliderValue + ", vSlider = " + vSliderValue);
	}

	void ScrollBars ()
	{
		// HorizontalScrollbar
		hScrollbarValue = GUI.HorizontalScrollbar (new Rect (310, 80, 200, height1), hScrollbarValue, 1.0f, 0.0f, 11.0f);
	
		// VerticalScrollbar
		vScrollbarValue = GUI. VerticalScrollbar (new Rect (310, 105, height1, 200), vScrollbarValue, 1.0f, 11.0f, 0.0f);
	
		
		Debug.Log("hScrollBar = " + hScrollbarValue + ", vScrollBar = " + vScrollbarValue);
	}
	
	void ScrollView ()
	{
		Rect scrollRect = new Rect (0,0,500,300);
		// Begin the ScrollView
		// ---1st: location and size of the viewable ScrollView area on the screen
		// ---2nd: the size of the space contained inside the viewable area
		scrollViewVector = GUI.BeginScrollView 
			(new Rect (leftPos1, 450, 250, 110), scrollViewVector,scrollRect);

		// Put something inside the ScrollView
		innerText = GUI.TextArea (scrollRect, innerText);

		// End the ScrollView
		GUI.EndScrollView();
	}
	
	void WindowFunction (int windowID) {
		// Draw any Controls inside the window here
		GUI.Label (new Rect (400,height1,leftPos1,50), "WindowID: "+windowID);
		
		windowText = ""+windowID;
	}
	
	
	void ChangesInGUI ()
	{	
		Debug.Log("GUI CHANGED! The toolbar #" + (toolbarInt+1) + " was clicked");
		Debug.Log("GUI CHANGED! The toggle value is now: " + toggleBool);
	}
	
	IEnumerator Reset ()
	{
		yield return new WaitForSeconds(0.5f);
		
		buttonText = "";
		customButtonText = "";
	}
	
	//* GUI *//
	void Method_GUI ()
	{		
		// Reset
		if(SceneModel.activeFunction != SceneModel.reset && SceneModel.activeFunction != null)
		{
			Debug.Log("Method_Particles: " + SceneModel.activeFunction);
		}
		
		// Legacy
		if(SceneModel.activeFunction == SceneModel.legacy)
		{
			
		}
		
		// Legacy - Thruster
		else if(SceneModel.activeFunction == SceneModel.l_thruster)
		{
		}
	}
}
