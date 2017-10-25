using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PropProperties.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Oct 08
 * 
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Oct 19
 * 
 * To send debug text to UI, add this component to game object, then within any script, grab this script and
 * use handler to send debug lines to handler.
 * 
 */
[AddComponentMenu("GDC/Scripts/Prop Properties.cs")]
public class PropProperties : MonoBehaviour
{
    /* Public variables (Subject to change often based on game functions */
    public bool isDestructible = false; /* Is this prop can be called via Destroy()? */
    public bool reportPosition = false; /* Report this prop's position to debug window? */

    /* Private variables */
    private DebugReportSender debug;
    private float maxRefreshRate = .5f;
    private float counter = 0.0f;

    private void Awake()
    {
        this.gameObject.AddComponent<DebugReportSender>(); /* Add debug report sender to parent object */
        debug = this.gameObject.GetComponent<DebugReportSender>();

        /* Any children in this parent prop will have debug report sender as well. */
        for (int i = 0; i < this.transform.childCount; i++)
            this.transform.GetChild(i).gameObject.AddComponent<DebugReportSender>();
    }

    private void Update()
    {
        /* Simple test by counting one second and send log to debug UI.
         */
        if (counter > maxRefreshRate)
        {
            if (reportPosition)
                StartCoroutine("ReportPosition");

            counter = 0;
        }
        else counter += Time.deltaTime;
    }

    IEnumerator ReportPosition()
    {
        debug.SendLog("Name: " + this.gameObject.name); /* Report object's name first */
        debug.Send("Pos X: " + this.transform.position.x); /* Report X position */
        debug.Send("Pos Y: " + this.transform.position.y); /* Report Y position */

        yield return null; /* Nothing to return after this coroutine; return null*/
    }
}
