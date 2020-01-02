using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WiimoteApi;

public class DrumGame : MonoBehaviour
{
    public Transform drumStick,ir_pointer;

    private Quaternion initial_rotation;

    private Wiimote wiimote;

    private Vector3 wmpOffset = Vector3.zero;

    bool isSwinging;
    float lastPos;
    float speed;

    private void Start()
    {
        InitWiimotes();
        wiimote = WiimoteManager.Wiimotes[0];
        wiimote.SendDataReportMode(InputDataType.REPORT_BUTTONS_ACCEL); // Report Buttons (as above) and accelerometer data
        wiimote.SetupIRCamera(IRDataType.BASIC);
        //wiimote.ActivateWiiMotionPlus();
    }

    private void Update()
    {
        if (!WiimoteManager.HasWiimote()) { return; }

        MotionPlusData data = wiimote.MotionPlus; // data!
        wiimote.SetupIRCamera(IRDataType.BASIC);
        wiimote.ReadWiimoteData();
        //Debug.Log(GetAccelVector());

        if (lastPos != GetAccelVector().y)
        {
            speed = GetAccelVector().y - lastPos;
            speed /= Time.deltaTime;
            lastPos = GetAccelVector().y;
            Debug.Log("speed issssssssss/////" + speed);
        }

        //Debug.Log( Mathf.Sqrt(GetAccelVector().y + lastPos) / Time.deltaTime);
        //if (GetAccelVector().y > .6f) { isSwinging = true; }

        //if (GetAccelVector().y <= -.8f && isSwinging == true)
        //{
        //    isSwinging = false;
        //    drumStick.gameObject.GetComponent<Animator>().Play("DrumHit");
        //}

        if (speed > 30f) { isSwinging = true; }

        if (GetAccelVector().y <= -.8f && isSwinging == true)
        {
            isSwinging = false;
            drumStick.GetComponent<AudioSource>().Play();
            //drumStick.gameObject.GetComponent<Animator>().speed = ;
            drumStick.gameObject.GetComponent<Animator>().Play("DrumHit");
        }
    }

    void InitWiimotes()
    {
        WiimoteManager.FindWiimotes(); // Poll native bluetooth drivers to find Wiimotes
        foreach (Wiimote remote in WiimoteManager.Wiimotes)
        {
            // Do stuff.
        }
    }
    void FinishedWithWiimotes()
    {
        foreach (Wiimote remote in WiimoteManager.Wiimotes)
        {
            WiimoteManager.Cleanup(remote);
        }
    }

    private Vector3 GetAccelVector()
    {
        float accel_x;
        float accel_y;
        float accel_z;

        float[] accel = wiimote.Accel.GetCalibratedAccelData();
        accel_x = accel[0];
        accel_y = -accel[2];
        accel_z = -accel[1];

        return new Vector3(accel_x, accel_y, accel_z).normalized;
    }
    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        for (int x = 0; x < 3; x++)
        {
            AccelCalibrationStep step = (AccelCalibrationStep)x;
            if (GUILayout.Button(step.ToString(), GUILayout.Width(100)))
                wiimote.Accel.CalibrateAccel(step);
        }
        GUILayout.EndHorizontal();
    }

    void OnDrawGizmos()
    {
        if (wiimote == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(drumStick.position, drumStick.position + drumStick.rotation * GetAccelVector() * 2);
    }
}
