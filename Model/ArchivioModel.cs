using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RAR_Miner.Model
{
    internal class ArchivioModel
    {
        string? nomeArchivio;
        int numeroFile;
        DateTime dataEstrazione;

        public ArchivioModel(string nomeArchivio, int numeroFile, DateTime dataEstrazione)
        {
            this.nomeArchivio = nomeArchivio;
            this.numeroFile = numeroFile;
            this.dataEstrazione = dataEstrazione;
        }

        public string toJson() => $"{{ \"nomeArchivio\": \"{nomeArchivio}\", \"numeroFile\": {numeroFile}, \"dataEstrazione\": \"{dataEstrazione:yyyy-MM-ddTHH:mm:ss}\" }}";

        public ArchivioModel fromJson(string json)
        {
            try
            {
                var jsonObject = System.Text.Json.JsonDocument.Parse(json).RootElement;

                nomeArchivio = jsonObject.GetProperty("nomeArchivio").GetString();
                numeroFile = jsonObject.GetProperty("numeroFile").GetInt32();
                dataEstrazione = DateTime.Parse(jsonObject.GetProperty("dataEstrazione").GetString());
                return this;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la deserializzazione del JSON: " + ex.Message);
            }
        }

        #region Sezione funzioni



        #endregion
    }
}
