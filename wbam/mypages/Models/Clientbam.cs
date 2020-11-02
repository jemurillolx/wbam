using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace wbam.mypages.Models
{
    [DataContract]
    public class Clientbam
    {
        [DataMember(Name = "_id")]
        public string _id { get; set; }

        [DataMember(Name = "documento")]
        public long documento { get; set; }

        [DataMember(Name = "tipo_doc")]
        public int tipo_doc { get; set; }

        [DataMember(Name = "categoria")]
        public string categoria { get; set; }

        [DataMember(Name = "mnt_trx_mm")]
        public double mnt_trx_mm { get; set; }

        [DataMember(Name = "num_trx")]
        public long num_trx { get; set; }

        [DataMember(Name = "pct_mnt_tot")]
        public double pct_mnt_tot { get; set; }

        [DataMember(Name = "pct_num_trx_tot")]
        public double pct_num_trx_tot { get; set; }

    }
}