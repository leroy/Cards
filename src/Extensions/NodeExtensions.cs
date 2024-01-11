using System;
using System.Collections.Generic;
using Cards.Nodes.Autoload;
using Godot;

namespace Cards.Extensions;

public static class NodeExtensions
{
    public static ServiceContainer Container(this Node node)
    {
        return node.GetNode<ServiceContainer>("/root/ServiceContainer");
    }
}