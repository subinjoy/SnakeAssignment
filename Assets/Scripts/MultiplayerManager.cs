using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{
	public PhotonView playerPrefab;
	public SnakeClass snakeClass;
	[SerializeField] GameController gameController;


	// Start is called before the first frame update
	void Start()
	{
		PhotonNetwork.ConnectUsingSettings();
	}

	public override void OnConnectedToMaster()
	{
		Debug.Log("Connected to Master");
		PhotonNetwork.JoinRandomOrCreateRoom();
	}

	public override void OnJoinedRoom()
	{
		Debug.Log("Joined a room.");
		var Player=PhotonNetwork.Instantiate(playerPrefab.name, playerPrefab.transform.position, Quaternion.identity);
		snakeClass = Player.GetComponent<SnakeClass>();
		//snakeClass.InitilaliseSnake();
		gameController.enabled = true;
		gameController.SetSnakeClass(snakeClass);
	}
	

}
