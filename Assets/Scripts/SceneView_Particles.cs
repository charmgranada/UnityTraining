using UnityEngine;
using System.Collections;


public class SceneView_Particles : SceneView
{
	void Start ()
	{
		//new Rect(
		setBox(new Rect(200,200,420,200));
		
		SceneModel.InitParticles();
		setArrCount();
		
		ResetView();
	}
	
	
	public override void OnGUI ()
	{
		base.OnGUI();
		
		
		// Text Area
		GUI.Box(boxRect, new GUIContent(codeText));
		
		
		// List Actions as GUI Buttons
		for(int i = 0; i < arrCount; i++)
		{
			string buttonText = SceneModel.arrList[i];
				
			GUI.SetNextControlName(buttonText);
				
			buttonCustom(buttonText, 15.0f, yHeight * i + ySpace);
		}
	}
	
	
	string buttonCustom (string buttonText, float xPos, float yPos)
	{
		if(GUI.Button(new Rect(xPos, yPos, 130, 50), buttonText))
		{
			GUI.FocusControl(buttonText);
			
			if(buttonText == SceneModel.reset)
			{
				codeText = "RESET";
			}
			else if(buttonText == SceneModel.legacy)
			{
				codeText = "LEGACY\n\n" +
					"- Unity's Particle System Engine\n" +
					"(prior to 3.5 release)\n\n" +
					"- Components: Emitter,Animator,Renderer,\n" +
					"World Particle Collider";
			}
			else if(buttonText == SceneModel.l_thruster)
			{
				codeText = "THRUSTER (legacy)\n\n" +
					"- Animation Color\n" +
					"- Size Grow by -0.5\n" +
					"- Min-Max Emission & Energy";
			}
			else if(buttonText == SceneModel.l_hazyGlow)
			{
				codeText = "HAZY GLOW (legacy)\n\n" +
					"- Custom Material (glow)\n" +
					"- RND Velocity (random movement along the axis)";
			}
			else if(buttonText == SceneModel.l_explosion)
			{
				codeText = "EXPLOSION (legacy)\n\n" +
					"One Shot (enabled)\n" +
					"AutoDestruct (disabled temporarily)\n" +
					"       -> will render only ONCE if enabled";
			}
			else if(buttonText == SceneModel.shuriken)
			{
				codeText = "SHURIKEN\n\n" +
					"- Modules\n" +
					"- Particle Editor\n" +
					"- Partice Effect Preview\n" +
					"- Curve/Gradient Editor";
			}
			else if(buttonText == SceneModel.s_flare)
			{
				codeText = "FLARE (shuriken)\n\n" +
					"- texture sheet animation\n" +
					"- assign Material to Renderer\n" +
					"- collision on plane";
			}
			else if(buttonText == SceneModel.s_dustdevil)
			{
				codeText = "DUST DEVIL (shuriken)\n\n" +
					"- rotating particles\n" +
					"- emission velocity";
			}
			else if(buttonText == SceneModel.s_fireworks)
			{
				codeText = "FIREWORKS (shuriken)\n\n" +
					"- subemitter particles";
			}
			
			
			// Set Active Function
			SceneModel.activeFunction = buttonText;
		}
			
		
		return buttonText;
	}
}
