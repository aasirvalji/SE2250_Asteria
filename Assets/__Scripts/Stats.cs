using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stats
{
	private static int points = 0;
    private static int enemies = 0;

    public static int Points
	{
		get
		{
			return points;
		}
		set
		{
			points = value;
		}
	}

    public static int EnemiesRemaining
    {
        get
        {
            return enemies;
        }
        set
        {
            enemies = value;
        }
    }
}




