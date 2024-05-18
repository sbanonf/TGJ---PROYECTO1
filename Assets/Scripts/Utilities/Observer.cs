using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Observer interface, use it when the subject sends a notify
/// to all observers
/// </summary>
public interface Observer {
	public void OnNotify(Subject subject, params object[] args);
}

/// <summary>
/// Subject abstract class, implements basic use of the observer pattern
/// </summary>
public abstract class Subject : MonoBehaviour {
	private List<Observer> observers = new List<Observer>();
	
	public void AddObserver(Observer observer) {
		if (!observers.Contains(observer)) observers.Add(observer);
	}

	public void RemoveObserver(Observer observer) {
		if (observers.Contains(observer)) observers.Remove(observer);
	}

	public void Notify() {
		foreach (Observer observer in observers) observer.OnNotify(this);
	}
	
	protected virtual void OnDestroy() {
		observers.Clear();
	}
}