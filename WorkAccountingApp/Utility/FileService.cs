using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace WorkAccountingApp.Utility
{
    public interface IFileService<T>
    {
        public void Save(string filename, T listToSave); 
    }

    public class JsonFileService<T> : IFileService<T>
    {
        public void Save(string filename, T listToSave)
        {
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(T));
            using FileStream fs = new FileStream(filename, FileMode.Create);
            jsonFormatter.WriteObject(fs, listToSave);
        }
    }
 }
