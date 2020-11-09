using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using System.IO;
using UnityEngine.Android;
using System.Threading;

public class SocketClient : MonoBehaviour
{
    public static SocketClient instance;
    TcpClient clientSocket = new TcpClient();
    NetworkStream stream = default(NetworkStream);
    string message = string.Empty;

    [SerializeField]
    //public string ConnectIP = "172.30.58.79";
    public string ConnectIP = "172.30.58.79";

    [SerializeField]
    public int PortID = 11000;
    public int playerNo = 0;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);


        ConnectToServer();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            sendMessage("SketchPad$TestMessage");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            sendMessage("EventSuccess");
        }
    }

    private void ConnectToServer()
    {
        clientSocket.Connect(ConnectIP, PortID);
        stream = clientSocket.GetStream();

        message = "Connected to Server";

        byte[] buffer = Encoding.Unicode.GetBytes("player" + playerNo + "$" + message);
        stream.Write(buffer, 0, buffer.Length);
        stream.Flush();

        Thread t_handler = new Thread(getMessage);
        t_handler.IsBackground = true;
        t_handler.Start();
    }

    private void getMessage()
    {
        while (true)
        {
            stream = clientSocket.GetStream();
            int BUFFERSIZE = clientSocket.ReceiveBufferSize;
            byte[] buffer = new byte[BUFFERSIZE];
            int bytes = stream.Read(buffer, 0, buffer.Length);

            string message = Encoding.Unicode.GetString(buffer, 0, bytes);
            Debug.Log(message);

            if (message.IndexOf("Ready") >= 0)
            {
                //SketchCharacterBulider.pushSaveCharacter(message);
                //레디 버튼 처리
                //-> 플레이어 게임룸 이동 
            }
            else if (message.IndexOf("FoodCompleted") >= 0)
            {
                //DanceEventKey.pushKey(message);
                //-> 강도 출현 메소드 호출
            }

            //Thread.Sleep(100);
            //Console log
        }
    }




    public void sendMessage(string message)
    {
        byte[] buffer = Encoding.Unicode.GetBytes(message + "$");
        stream.Write(buffer, 0, buffer.Length);
        stream.Flush();
    }
}