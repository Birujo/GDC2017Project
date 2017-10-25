using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * DebugReportHandler.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Oct 07
 * 
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Oct 08
 * 
 */
[AddComponentMenu("GDC/Scripts/Debug Report Handler.cs")]
public class DebugReportHandler : MonoBehaviour
{
    /* Public variables */
    public bool reportToUI = false; /* Use to turn on/off debug text at gui level */
    [Range(100, 300)]
    public int maxLineNumber = 100; /* UI Text has text limit; need to truncate debug output. */

    /* Private */
    private Text debugWindow;
    private string[] lines;
    private int lineCount = 0;
    private ScrollRect rect;

    private void Awake()
    {
        rect = GameObject.Find("gui_debug_scrollview").GetComponent<ScrollRect>();
        lines = new string[maxLineNumber];
        lines[lineCount] = "Test String";

        debugWindow = this.gameObject.GetComponent<Text>();
        debugWindow.text = ""; /* Clear text field */
    }

    /* SendLog(string line)
     * Sends debug line with log tag
     */
    public void SendLog(string line)
    {
        Send("Log: " + line);
    }

    /* SendWarning(string line)
     * Sends debug line with warning tag
     */
    public void SendWarning(string line)
    {
        Send("Warning: " + line);
    }

    /* SendError(string line)
     * Sends debug line with error tag
     */
    public void SendError(string line)
    {
        Send("Error: " + line);
    }

    /* Send(string line, bool append = false)
     * Sends a single string line to debug window. If append flag is set to false, a newline flag is sent.
     * If append flag is set to true, debug text will be sent without feeding new line.
     */
    public void Send(string line, bool append = false)
    {
        if (!append)
            AppendText(line + "\n");
        else AppendText(line);

        if(reportToUI)
            UpdateUI();
    }

    /* Hidden functions
     */
    private void AppendText(string line)
    {
        if(lineCount > maxLineNumber - 1)
        {
            for (int i = 1; i < maxLineNumber; i++)
                lines[i - 1] = lines[i];

            lineCount = maxLineNumber - 1;
        }
        else
        {
            lines[lineCount] = line;
            lineCount++;
        }
    }

    private void UpdateUI()
    {
        debugWindow.text = "";

        foreach(string line in lines)
        {
            debugWindow.text += line;
        }

        Canvas.ForceUpdateCanvases();
        rect.verticalNormalizedPosition = 0f;
        Canvas.ForceUpdateCanvases();
    }
}
