#define DEBUG_BUILD

using System;
using UnityEngine;

namespace DevCommon
{
    public enum DebugCategory
    {
        ALL = 0,
        USER1 = 1,
        USER2 = 2,
        USER3 = 3,
        USER4 = 4,
        CRITICAL = 5,
        USER5,
        USER6,
        USER7,
        EVENTS,
    }

#if DEBUG_BUILD

    public class DebugUtils
    {
        public static string[] colors = new string[] {
        "000000",
        "C0C0C0",
        "FF0000",//red(0)
		"FF9933",//orange (1)
		"669999",//dull green/blue  (2)
		"52CC29",//green (3)
		"99CCFF",//bright blue (4)
		"FFFF00",//yellow (5)
		"CC6699",//dull red/purple (6)
		"D96EBF",//purple (7)
		"66FFCC",//greenish (8)
		"FFFFFF",//white; (9)
		"666699",//dark purple; (10)
		"AC5930", //brown-ish	(11)
		"BAC74A", //dirty green
		"E38B81" //washed up red
	};

        public static DebugCategory Category = DebugCategory.ALL;

        public static bool BIsDebugBuild
        {
            get { return true; }
        }

        public static void Assert(bool condition, string message)
        {
            if (!condition)
                throw (new Exception(message));
        }

        public static void Assert(bool condition)
        {
            Assert(condition, "");
        }

        //private string BuildLog = "";

        public static void Log(object a_objLog, int a_iColor = 0, DebugCategory a_eCategory = DebugCategory.ALL)
        {
            //if (CDebugSettings.Instance != null && CDebugSettings.Instance.RunningForPCBuild == true)
            //{
            //    System.IO.File.AppendAllText("BUILDLOG.txt", a_objLog.ToString() + " ==> \n");
            //}

            if (Category != DebugCategory.ALL && Category != a_eCategory) //
                return;

            if (a_iColor < 0 || a_iColor > colors.Length)
                a_iColor = 0;
            string myColor = colors[a_iColor];
            a_objLog = "<color=#" + myColor + ">" +
                "<b>" + a_objLog + "</b>" +
                "</color>";
            Debug.Log(a_objLog);
        }

        public static void Warning(object a_objWarning)
        {
            Debug.LogWarning(a_objWarning);
        }

        public static void Error(object a_objError)
        {
            Debug.LogError(a_objError);
        }

        public static void LogError(object a_objError)
        {
            Debug.LogError(a_objError);
        }

        public static void DrawLine(Vector3 a_vecStart, Vector3 a_vecEnd, Color a_Color, float a_fDuration)
        {
            Debug.DrawLine(a_vecStart, a_vecEnd, a_Color, a_fDuration);
        }
    }

#else

public class 	DebugUtils
{
	public static bool BIsDebugBuild
	{
		get { return false; }
	}

	public static void Assert(bool condition, string message ) {
		if( !condition )
			throw( new Exception(message) );
	}
	public static void Assert(bool condition ) {
		Assert(condition, "");
	}

	public static void Warning( object a_objWarning )
	{
	}

	public static void Error( object a_objError )
	{
	}

	public static void LogError (string str)
	{
	}

	public static void Log(object a_objLog, int a_iColor = 0, DebugCategory a_eCategory = DebugCategory.ALL)
	{
	}

	public static void DrawLine( Vector3 a_vecStart, Vector3 a_vecEnd, Color a_Color, float a_fDuration )
	{
	}
}

#endif
}

