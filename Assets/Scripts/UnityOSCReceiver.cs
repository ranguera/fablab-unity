using UnityEngine;
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

using OSC.NET;

public class UnityOSCReceiver : MonoBehaviour {
	
	private bool connected = false;
	public int port = 9898;
	private OSCReceiver receiver;
	private Thread thread;
	
	public UnityOSCReceiver() {}
	

	public int getPort() {
		return port;
	}
			
	public void Start() {
		
		try {
			Debug.Log("connected");
			connected = true;
			receiver = new OSCReceiver(port);
			thread = new Thread(new ThreadStart(listen));
			thread.Start();
		} catch (Exception e) {
			Debug.Log("failed to connect to port "+port);
			Debug.Log(e.Message);
		}
	}
	
	public void Update() {
		
		
	}
	
	public void OnApplicationQuit(){
		disconnect();
	}
	
	public void disconnect() {
      	if (receiver!=null){
      		 receiver.Close();
      	}
      	
       	receiver = null;
		connected = false;
	}

	public bool isConnected() { return connected; }

	private void listen() {
		while(connected) {
			try 
			{
				OSCPacket packet = receiver.Receive();
				
				if (packet!=null) 
				{
					Debug.Log(packet.Address + ": " + packet.Values[0]);
				}
				else
				{
					Console.WriteLine("null packet");
				}
			} catch (Exception e) 
			{ 
				Debug.Log( e.Message );
				Console.WriteLine(e.Message); 
			}
		}
	}
}
