﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ControlesAppCross
{
    public class Tarefas
    {
        public int CodPro { get; set; }
        public DateTime DATA_PROGR { get; set; }
        public DateTime CONCLUIDO { get; set; }
        public int CLIENTE { get; set; }
        public int SOLICITANTE { get; set; }
        public int RESPOSAVEL { get; set; }
        public string HISTORICO { get; set; }


        public int TotTarProp { get; set; }
        public int TotTarDeleg { get; set; }
        public int TotRotProp { get; set; }
        public int TotRotDeleg { get; set; }
        public int TotArq { get; set; }
        public int TotalGeral { get; set; }


        public int NLTarProp { get; set; }
        public int NLTarDeleg { get; set; }
        public int NLTotal { get; set; }

        public int AtrTarProp { get; set; }
        public int AtrTarDeleg { get; set; }
        public int AtrRotProp { get; set; }
        public int AtrRotDeleg { get; set; }
        public int AtrArq { get; set; }
        public int AtrArqDeleg { get; set; }
        public int AtrTotal { get; set; }


        public int FhjTarProp { get; set; }
        public int FhjTarDeleg { get; set; }
        public int FhjRotProp { get; set; }
        public int FhjRotDeleg { get; set; }
        public int FhjArq { get; set; }
        public int FhjArqDeleg { get; set; }
        public int FhjTotal { get; set; }

        public int AnotReceb { get; set; }
        public int AnotEnviadas { get; set; }
        public int AnotTotal { get; set; }

        public int VldTarDeleg { get; set; }
        public int VldTotal { get; set; }

        public int FtrTarProp { get; set; }
        public int FtrTarDeleg { get; set; }
        public int FtrRotProp { get; set; }
        public int FtrRotDeleg { get; set; }
        public int FtrArq { get; set; }
        public int FtrArqDeleg { get; set; }
        public int FtrTotal { get; set; }

    }
}
