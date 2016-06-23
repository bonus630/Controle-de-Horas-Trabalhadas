using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace br.corp.bonus630.ControleHorasTrabalhadas.ControleHorasTrabalhadas
{
    public static class SaveLoad
    {
        public static void save(string filename, Period period)
        {
            if (File.Exists(filename))
                File.Delete(filename);
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            BinaryFormatter binFormatter = new BinaryFormatter();
            binFormatter.Serialize(fs, period);
            fs.Close();
        }
        public static Period load(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            BinaryFormatter binFormatter = new BinaryFormatter();
            object obj = binFormatter.Deserialize(fs);
            fs.Close();
            return (Period)obj;
        }
    }
}
