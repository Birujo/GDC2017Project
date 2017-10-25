using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * DebugReportSender.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Oct 07
 * 
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Oct 08
 * 
 * To send debug text to GUI, add this component to game object, then within any script, grab this script and
 * use wrapper functions to send debug lines to handler.
 * 
 */
 [AddComponentMenu("GDC/Scripts/Debug Report Sender.cs")]
public class DebugReportSender : MonoBehaviour
{
    /* Private Variables */
    private DebugReportHandler handler;

    /* Script links Debug Report Handler. Any game object with Debug Report Sender can use wrapper function
     * to send message to debug GUI
     */
    private void Awake()
    {
        handler = GameObject.Find("gui_debug_text").GetComponent<DebugReportHandler>();
    }

    /* Wrapper functions */
    /* Appends Log tag */
    public void SendLog(string line)
    {
        handler.SendLog(line);
    }

    /* Appends Warning tag */
    public void SendWarning(string line)
    {
        handler.SendWarning(line);
    }

    /* Appends Error tag */
    public void SendError(string line)
    {
        handler.SendError(line);
    }

    /* Sends message to debug GUI without any tag */
    public void Send(string line, bool append = false)
    {
        handler.Send(line, append);
    }
}
