using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface StateMachine {
	protected State ActualState { get; set; }
	protected List<State> States { get; set; }
	protected Dictionary<Enum, State> StateDict { get; set; }
	
	public void ChangeState(State newState){
		if(ActualState != null) ActualState.OnExit();
		ActualState = newState;
		ActualState.OnEnter();
	}
	
	protected void LoadStates(string Path){
		States =  Resources.LoadAll<State>(Path).ToList();
		StateDict = States.ToDictionary(s => s.stateName, s => s);
	}
}

public abstract class State : ScriptableObject {
	[SerializeField] public Enum stateName;
	
	public abstract void OnEnter();
	
	public abstract void OnExit();
	
	public abstract void Update();
}