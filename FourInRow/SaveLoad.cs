using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace FourInRow {
  public class SaveLoad {
    private const string saveFile = "../../FourInRow.xml";

    public static void Serialize(BasePiece[,] board) {
      Stream saveStream = File.Create(saveFile);
      var formatter = new SoapFormatter();

      try {
        formatter.Serialize(saveStream, board);
      }
      catch(SerializationException e) {
        Console.WriteLine("Failed to serialize. Reason: " + e.Message);
        throw;
      }
      finally {
        saveStream.Close();
      }
    }

    public static void Deserialize(out Board obj) {
      obj = null;
      try {
        var loadStream = new FileStream(saveFile, FileMode.Open);
        var deserializer = new SoapFormatter();

        try {
          obj = deserializer.Deserialize(loadStream) as Board;
        }
        catch(SerializationException e) {
          Console.WriteLine(e.Message);
        }

        loadStream.Close();
      }
      catch(FileNotFoundException e) {
        Console.WriteLine(e.Message);
      }
    }
  }
}