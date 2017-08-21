using UnityEngine;
using System.Collections;

public class testTwoChat : MonoBehaviour {
	//Declare the SimChat variables.
	SimChat sc;
	//GUI Vars
	//scroll view position
	protected Vector2 sp = Vector2.zero;
	//list of fake names
	public string name;
	//selected fake names, temporary chat group
	string chatGroup="default";
	//Timers
	float rt1=-3f,rt2=-3f;
	
	void Start(){
		//initialize the SimChat objects
		sc = new SimChat(chatGroup,gameObject.GetComponent<MonoBehaviour>(),name);
		//tell the SimChat Objects to continuously check for new messages
		sc.continueCheckMessages();
		//set the functions to call when a new message is received
		sc.setReceiveFunction(receiveMessage1);
	}
	
	//functions to call when a new message is received
	void receiveMessage1(SimpleMessage[] sm){
		rt1 = Time.time;
	}

	void OnGUI(){
		//draw the GUI areas to display the information in
		GUI.skin.textField.fontSize = GUI.skin.button.fontSize = GUI.skin.label.fontSize = 17;
		GUI.skin.label.wordWrap = false;
		GUILayout.BeginArea(new Rect(0,0,Screen.width,40));
		GUILayout.BeginHorizontal("box");
		GUILayout.FlexibleSpace();
		GUILayout.Label("Chat Group: "+chatGroup);
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		//show that a new message has been received
		GUILayout.BeginArea(new Rect(0,40,Screen.width,30));
		GUILayout.BeginHorizontal();
		GUILayout.BeginHorizontal("box");
		GUILayout.FlexibleSpace();
		if(Time.time-rt1<3){
			GUILayout.Label("New Message");
		}
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal("box");
		GUILayout.FlexibleSpace();
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		//draw the chat areas
		displayChat(new Rect(0,70,Screen.width/2,Screen.height-70),sc,sp,name);
	}

	//helper function to display the SimChat
	public void displayChat(Rect area,SimChat sc,Vector2 sp,string sender){
		sp.y = Mathf.Infinity;
		GUILayout.BeginArea(area);
		GUILayout.BeginHorizontal("box");
		GUILayout.Label("Name: "+sender);
		GUILayout.EndHorizontal();
		GUILayout.BeginVertical("box");
		sp = GUILayout.BeginScrollView(sp);
		Color c = GUI.contentColor;
		//loop through each of the messages contained in allMessages
		foreach(SimpleMessage sm in sc.allMessages){
			GUILayout.BeginHorizontal();
			//check if the sender had the same name as me, and change the color
			if(sm.sender == sender){
				GUI.contentColor = Color.red;
				GUILayout.FlexibleSpace();
				GUILayout.Label(sm.message);
			}else{
				GUI.contentColor = Color.green;
				GUILayout.Label(sm.sender+": "+sm.message);
				GUILayout.FlexibleSpace();
			}
			GUILayout.EndHorizontal();
		}
		GUI.contentColor = c;
		GUILayout.EndScrollView();
		GUILayout.BeginHorizontal();
		//send a new message
		sc.message = GUILayout.TextField(sc.message);
		if(GUILayout.Button("Send")){
			sc.sendMessage();
			sc.message = "";
		}
		GUILayout.EndHorizontal();
		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}