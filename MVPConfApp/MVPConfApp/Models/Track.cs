using System;
using System.Collections.Generic;
using System.Text;

namespace MVPConfApp.Models
{
    public class Track
    {
        public Track(TrackId id)
        {
            Id = id;
        }
       public TrackId Id { get; set; }
       public string Title
        {
            get
            {
                if (Id == Models.TrackId.Desenvolvimento)
                    return "Desenvolvimento de Software";
                else if (Id == Models.TrackId.AzureBlockchain)
                    return "Azure | Blockchain";
                else if (Id == Models.TrackId.Banco)
                    return "Banco de Dados";
                else if (Id == Models.TrackId.DevOpsContainers)
                    return "DevOps | Containers";
                else if (Id == Models.TrackId.GerenciamentoProjeto)
                    return "Gerenciamento de Projetos";
                else if (Id == Models.TrackId.IaMachineLearningChatBots)
                    return "IA | Machine Learning | Computação Cognitiva | ChatBots";
                else if (Id == Models.TrackId.IoT)
                    return "IoT";
                else if (Id == Models.TrackId.ItInfraestrutura)
                    return "IT Pro | Infraestrutura";
                else if (Id == Models.TrackId.Lgpd)
                    return "LGPD";
                else if (Id == Models.TrackId.Office)
                    return "Office & Produtividade";
                else if (Id == Models.TrackId.PowerBi)
                    return "Power BI";
                else if (Id == Models.TrackId.Seguranca)
                    return "Segurança da Informação";
                else if (Id == Models.TrackId.Espanhol)
                    return "Espanhol";
                else if (Id == Models.TrackId.BigData)
                    return "Big Data";
                else if (Id == Models.TrackId.Cases)
                    return "Casos de Sucesso";
                else if (Id == Models.TrackId.Mobile)
                    return "Mobile";

                return "";
            }
        }
    }
}
