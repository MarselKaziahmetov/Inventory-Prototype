using System;
using UnityEngine;
using Zenject;

namespace Core.Behaviours
{
	public class BehaviourEnabler : ITickable
	{
		private readonly IBehaviour[] _behaviours;
		private bool _initialized = false;

		public BehaviourEnabler(IBehaviour[] behaviours)
        {
			_behaviours = behaviours;
		}

		public void Tick()
		{
			if (_initialized)
				return;

			foreach (var beh in _behaviours)
			{
				try
				{

					beh.Enable();
				}catch(Exception ex)
				{
					Debug.LogError($"Failed for enable bahaviour \"{beh.GetType().Name}\". \r\nException: {ex}");
					continue;
				}
			}

			_initialized = true;
		}
	}
}
