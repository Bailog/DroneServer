using System;
using UnityEngine.Networking;

public class MyNetworkMessage : MessageBase
{
    public string message;
}

public class InputContainer : MessageBase
{
    public float f;
    public float r;
    public float u;
    public float s;
    public bool reset;
}