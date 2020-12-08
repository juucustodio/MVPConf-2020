using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MVPConfApp.Models
{
    public enum TrackId
    {

        [Description("Desenvolvimento de Software")]
        Desenvolvimento = 0,
        [Description("Azure | Blockchain")]
        AzureBlockchain = 1,
        [Description("Banco de Dados")]
        Banco = 2,
        [Description("DevOps | Containers")]
        DevOpsContainers = 3,
        [Description("Gerenciamento de Projetos")]
        GerenciamentoProjeto = 4,
        [Description("IA | Machine Learning | Computação Cognitiva | ChatBots")]
        IaMachineLearningChatBots = 5,
        [Description("IoT")]
        IoT = 6,
        [Description("IT Pro | Infraestrutura")]
        ItInfraestrutura = 7,
        [Description("LGPD")]
        Lgpd = 8,
        [Description("Office & Produtividade")]
        Office = 9,
        [Description("Power BI")]
        PowerBi = 10,
        [Description("Segurança da Informação")]
        Seguranca = 11,
        [Description("Espanhol")]
        Espanhol = 12,
        [Description("Big Data")]
        BigData = 13,
        [Description("Casos de Sucesso")]
        Cases = 14,
        [Description("Mobile")]
        Mobile = 15

    }
}
