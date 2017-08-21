using UnityEngine;
using System.Collections;

public class player_scrpit : MonoBehaviour {

	public float speed = 10f;
	
	void Update()
	{
		if (GetComponent<NetworkView>().isMine)
		{
			InputMovement();
			InputColorChange();
		}
		else
		{
			SyncedMovement();
		}
	}
	
	void InputMovement()
	{
		if (Input.GetKey(KeyCode.W))
			this.GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.forward * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.S))
			this.GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - Vector3.forward * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.D))
			this.GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.right * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.A))
			this.GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - Vector3.right * speed * Time.deltaTime);
	}

	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;
	
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		Vector3 syncPosition = Vector3.zero;
		if (stream.isWriting)
		{
			syncPosition = this.GetComponent<Rigidbody>().position;
			stream.Serialize(ref syncPosition);
		}
		else
		{
			stream.Serialize(ref syncPosition);
			
			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
			
			syncStartPosition = this.GetComponent<Rigidbody>().position;
			syncEndPosition = syncPosition;
		}
	}

	private void SyncedMovement()
	{
		syncTime += Time.deltaTime;
		this.GetComponent<Rigidbody>().position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
	}

	private void InputColorChange()
	{
		if (Input.GetKeyDown(KeyCode.R))
			ChangeColorTo(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
	}
	
	[PunRPC] void ChangeColorTo(Vector3 color)
	{
		GetComponent<Renderer>().material.color = new Color(color.x, color.y, color.z, 1f);
		GameObject test = GameObject.Find("controlador");
		teste srT = test.GetComponent<teste> ();
		srT.linha = "enviei algo";
		
		if (GetComponent<NetworkView>().isMine)
			GetComponent<NetworkView>().RPC("ChangeColorTo", RPCMode.OthersBuffered, color);
	}
}
