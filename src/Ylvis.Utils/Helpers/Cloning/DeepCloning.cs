﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ExtensionsLib
{
    public static class DeepCloning
    {
        //public static T Clone<T>(this T obj)
        //{
        //    IFormatter formatter = new BinaryFormatter();
        //    formatter.SurrogateSelector = new SurrogateSelector();
        //    formatter.SurrogateSelector.ChainSelector(
        //        new NonSerialiazableTypeSurrogateSelector());
        //    var ms = new MemoryStream();
        //    formatter.Serialize(ms, obj);
        //    ms.Position = 0;
        //    return (T)formatter.Deserialize(ms);
        //}
    }

}
