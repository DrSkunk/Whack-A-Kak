using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using static PlayerPorts;
using UnityEngine;

public class ComPortPicker: MonoBehaviour {
    string[] ports = SerialPort.GetPortNames();

    void OnGUI() {
      if (PlayerPorts.player1ComPort == "" || PlayerPorts.player2ComPort == "") {
        GUILayout.BeginVertical();
          if (player1ComPort == "") {
            GUILayout.Label("Player 1:");
          } else {
            GUILayout.Label("Player 2:");
          }
          foreach(var port in this.ports) {
            if (GUILayout.Button(port)) {
                if (PlayerPorts.player1ComPort == "") {
                    PlayerPorts.player1ComPort = port;
                } else {
                    PlayerPorts.player2ComPort = port;
                }
                Debug.Log(port);
            }
          }
        GUILayout.EndVertical();
      }
    }
}
