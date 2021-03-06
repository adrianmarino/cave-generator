﻿using System;
using Generator;

namespace Render
{
    public class RenderContext
    {
        public override string ToString()
        {
            return string.Format("Event: {0}, Data: {1}", Event, Data);
        }

        public bool DataIs(Type type)
        {
            return type == Data.GetType();
        }

        public RenderEvent Event { get; private set; }
        public object Data { get; private set; }
        public CaveGenerator Parent { get; private set; }

        public RenderContext(RenderEvent renderEvent, object data, CaveGenerator parent)
        {
            Event = renderEvent;
            Data = data;
            Parent = parent;
        }
    }
}