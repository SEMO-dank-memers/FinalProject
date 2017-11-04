using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Fuzzy {
	public static float NOT(float A) {
		return 1.0f - A;
	}
	public static float AND(float A, float B) {
		return Mathf.Min(A, B);
	}
	public static float OR(float A, float B){
		return Mathf.Max(A, B);
	}
	public static float Linear(float value, float x0, float x1){
		float result = 0;
		float x = value;
		if(x <= x0) result = 0;
		else if(x >= x1) result = 1.0f;
		else result = (x/(x1-x0))-(x0/(x1-x0));
		return result;
	}
	public static float ReverseLinear(float value, float x0, float x1){
		float result = 0;
		float x = value;
		if(x <= x0) result = 1.0f;
		else if(x >= x1) result = 0;
		else result = (-x/(x1-x0))+(x1/(x1-x0));
		return result;
	}
	public static float Triangle(float value, float x0, float x1, float x2){
		float result = 0;
		float x = value;
		if(x <= x0) result = 0;
		else if(x == x1) result = 1.0f;
		else if((x>x0) && (x<x1)) result = (x/(x1-x0))-(x0/(x1-x0));
		else result = (-x/(x2-x1))+(x2/(x2-x1));
		return result;
	}
	public static float Trapezoid(float value, float x0, float x1, float x2, float x3){
		float result = 0;
		float x = value;
		if(x <= x0) result = 0;
		else if((x>=x1) && (x<=x2)) result = 1.0f;
		else if((x>x0) && (x<x1)) result = (x/(x1-x0))-(x0/(x1-x0));
		else result = (-x/(x3-x2))+(x3/(x3-x2));
		return result;
	}
}
	