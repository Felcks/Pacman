﻿using UnityEngine;
using System.Collections;

public class MapCode 
{
	public int[][] map;
	private static MapCode mapCode;

	public static MapCode getInstance()
	{
		if(mapCode == null)
			mapCode = new MapCode();

		return mapCode;
	}
	/* Numbers
	 * 0 = normalFood;
	 * 1 = Wall;
	 * 2 = PowerUp;
	 * 3 = Blank;
	 * 4 = DecisionPointWithNormalFood;
	 * 5 = DecisionPoint
	 * 6 = DeciisionPointWithSuperFood;
	 * 7 = ContinuosTileWithNormalFood;
	 * 8 = ContinuotsTile
	 * 9 = ContinuotsTileWithSuperFodd;
	 * 10 = HouseTile;
     * 11 = GroundWithWallTag
	 						* */
	private MapCode()
	{
		this.map = new int[][] 
		{ 				   //0  1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 
			/*0*/new int[] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
			/*1*/new int[] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
			/*2*/new int[] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
			/*3*/new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			/*4*/new int[] { 1, 7, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 7, 1, 1, 7, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 7, 1},
			/*5*/new int[] { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1},
			/*6*/new int[] { 1, 2, 1, 3, 3, 1, 0, 1, 3, 3, 3, 1, 0, 1, 1, 0, 1, 3, 3, 3, 1, 0, 1, 3, 3, 1, 2, 1},
			/*7*/new int[] { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1},
			/*8*/new int[] { 1, 4, 0, 0, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 0, 0, 4, 1},
			/*9*/new int[] { 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1},
		   /*10*/new int[] { 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1},
		   /*11*/new int[] { 1, 7, 0, 0, 0, 0, 4, 1, 1, 7, 0, 0, 7, 1, 1, 7, 0, 0, 7, 1, 1, 4, 0, 0, 0, 0, 7, 1},
		   /*12*/new int[] { 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 3, 1, 1, 3, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1},
		   /*13*/new int[] { 3, 3, 3, 3, 3, 1, 0, 1, 1, 1, 1, 1, 3, 1, 1, 3, 1, 1, 1, 1, 1, 0, 1, 3, 3, 3, 3, 3},
		   /*14*/new int[] { 3, 3, 3, 3, 3, 1, 0, 1, 1, 8, 3, 3, 5, 3, 3, 5, 3, 3, 8, 1, 1, 0, 1, 3, 3, 3, 3, 3},
		   /*15*/new int[] { 3, 3, 3, 3, 3, 1, 0, 1, 1, 3, 1, 1, 1,10,10, 1, 1, 1, 3, 1, 1, 0, 1, 3, 3, 3, 3, 3},
		   /*16*/new int[] { 1, 1, 1, 1, 1, 1, 0, 1, 1, 3, 1,10,10,10,10,10,10, 1, 3, 1, 1, 0, 1, 1, 1, 1, 1, 1},
		   /*17*/new int[] {10,10,10,10,10,10, 4, 3, 3, 5, 1,10,10,10,10,10,10, 1, 5, 3, 3, 4,10,10,10,10,10,10},
		   /*18*/new int[] { 1, 1, 1, 1, 1, 1, 0, 1, 1, 3, 1,10,10,10,10,10,10, 1, 3, 1, 1, 0, 1, 1, 1, 1, 1, 1},
		   /*19*/new int[] { 3, 3, 3, 3, 3, 1, 0, 1, 1, 3, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1, 0, 1, 3, 3, 3, 3, 3},
		   /*20*/new int[] { 3, 3, 3, 3, 3, 1, 0, 1, 1, 5, 3, 3, 3, 3, 3, 3, 3, 3, 5, 1, 1, 0, 1, 3, 3, 3, 3, 3},
		   /*21*/new int[] { 3, 3, 3, 3, 3, 1, 0, 1, 1, 3, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1, 0, 1, 3, 3, 3, 3, 3},
		   /*22*/new int[] { 1, 1, 1, 1, 1, 1, 0, 1, 1, 3, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1, 0, 1, 1, 1, 1, 1, 1},
		   /*23*/new int[] { 1, 7, 0, 0, 0, 0, 4, 0, 0, 4, 0, 0, 7, 1, 1, 7, 0, 0, 4, 0, 0, 4, 0, 0, 0, 0, 7, 1},
		   /*24*/new int[] { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1},
		   /*25*/new int[] { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1},
		   /*26*/new int[] { 1, 9, 0, 7, 1, 1, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 1, 1, 7, 0, 9, 1},
		   /*27*/new int[] { 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1},
		   /*29*/new int[] { 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1},
		   /*30*/new int[] { 1, 7, 0, 4, 0, 0, 7, 1, 1, 7, 0, 0, 7, 1, 1, 7, 0, 0, 7, 1, 1, 7, 0, 0, 4, 0, 7, 1},
	       /*31*/new int[] { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1},
		   /*32*/new int[] { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1},
		   /*33*/new int[] { 1, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 1},
		   /*34*/new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
		   /*35*/new int[] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
		   /*36*/new int[] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},


		};



	}
}
