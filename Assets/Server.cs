using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Server : MonoBehaviour
{
    public Canvas DebugWindow;
    public Text DebugText;
    public GameObject Cube;
    Vector3 originalPos;

    int port = 8999;
    int maxConnections = 2;
    bool hasClient = false;

    public static float f, r, u, s;
    public static bool reset;

    // id идентификации сообщений и регистрации handler'a
    short messageID = 1000;
    
    void Start()
    {
        originalPos = new Vector3(0, 0.35f, 0);
        Application.runInBackground = true;
        CreateServer();
        DebugWindow.enabled = false;
    }

    //регистрация хэндлеров и конфигурации
    void CreateServer()
    {
        RegisterHandlers();

        var config = new ConnectionConfig();
        config.AddChannel(QosType.ReliableFragmented);
        config.AddChannel(QosType.UnreliableFragmented);

        var ht = new HostTopology(config, maxConnections);

        if (!NetworkServer.Configure(ht))
        {
            Debug.Log("No server created, error on the configuration definition");
            return;
        }
        else
        {
            if (NetworkServer.Listen(port))
                Debug.Log("Server created, listening on port: " + port);
            else
                Debug.Log("No server created, could not listen to the port: " + port);
        }
    }

    void OnApplicationQuit()
    {
        NetworkServer.Shutdown();
    }

    public static void ServerShutdown()
    {
        NetworkServer.Shutdown();
    }

    private void RegisterHandlers()
    {
        NetworkServer.RegisterHandler(MsgType.Connect, OnClientConnected);
        NetworkServer.RegisterHandler(MsgType.Disconnect, OnClientDisconnected);
        NetworkServer.RegisterHandler(messageID, OnMessageReceived);
        NetworkServer.RegisterHandler(messageID, OnInputRecieved);
    }

    private void RegisterHandler(short t, NetworkMessageDelegate handler)
    {
        NetworkServer.RegisterHandler(t, handler);
    }

    //вызывается при подключении клиента
    void OnClientConnected(NetworkMessage netMessage)
    {
        MyNetworkMessage messageContainer = new MyNetworkMessage();
        messageContainer.message = "Thanks for joining!";
        // отправка сообщения определенному клиенту
        NetworkServer.SendToClient(netMessage.conn.connectionId, messageID, messageContainer);
        hasClient = true;
        DebugWindow.enabled = false;
    }

    //вызывается при отключении клиента
    void OnClientDisconnected(NetworkMessage netMessage)
    {
        Debug.Log("Client disconnected");
        hasClient = false;
    }

    void OnMessageReceived(NetworkMessage netMessage)
    {
        // You can send any object that inherence from MessageBase
        // The client and server can be on different projects, as long as the MyNetworkMessage or the class you are using have the same implementation on both projects
        // The first thing we do is deserialize the message to our custom type
        var objectMessage = netMessage.ReadMessage<MyNetworkMessage>();
        Debug.Log("Message received: " + objectMessage.message);

        if (objectMessage.message == "Reset")
        {
            //Cube.transform.position = originalPos;
            GameObject.Find("Cube").transform.position = originalPos;
            GameObject.Find("Cube").transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnInputRecieved(NetworkMessage netMessage)
    {
        netMessage.reader.SeekZero();

        var inputMessage = netMessage.ReadMessage<InputContainer>();
        f = inputMessage.f;
        r = inputMessage.r;
        u = inputMessage.u;
        s = inputMessage.s;
        reset = inputMessage.reset;
    }

    private void FixedUpdate()
    {
        if (!hasClient)
        {
            if (!DebugWindow.enabled) DebugWindow.enabled = true;
            DebugText.text = "Waiting for a client";
        }
    }
}