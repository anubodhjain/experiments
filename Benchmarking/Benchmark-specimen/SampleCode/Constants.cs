using System;
using System.Collections.Generic;
using System.Text;

namespace SampleCode
{
    public static class Constants
    {
        //public delegate IFmsApis ServiceResolver(string key);

        public const string Holland = "HOLLAND";
        public const string Reddaway = "REDDAWAY";
        public const string NewPenn = "NEWPENN";
        public const string Yrc = "YRC";
        public const string Hon = "HONEYWELL";
        public const string DEFAULT_RETRIES = "3";
        public const string DEFAULT_RETRY_INTERVAL = "1";

        public static readonly List<string> CUSTOMER_LIST = new List<string>
        {
            Holland,
            Reddaway,
            NewPenn,
            Yrc,
            Hon
        };

        public enum ResiliencyStrategy
        {
            RPC_RETRY_POLICY,
            RPC_RETRY_POLICY_ASYNC,
            MDB_CONN_RETRY_POLICY,
            MDB_CONN_RETRY_POLICY_ASYNC
        }
    }
}
