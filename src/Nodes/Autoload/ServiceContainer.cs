using Godot;
using System;
using System.Collections.Generic;

namespace Cards.Nodes.Autoload; 

public partial class ServiceContainer : Node
{
    public Dictionary<string, object> Services { get; } = new ();

    public void Register(string key, object value)
    {
        Services[key] = value;
    }

    public T Get<T>()
    {
        return Get<T>(typeof(T).Name);
    }
	
    public T Get<T>(string key)
    {

        try
        {
            return (T) Services[key];
        } catch (KeyNotFoundException)
        {
            throw new Exception($"Service {key} not found");
        }
    }
}