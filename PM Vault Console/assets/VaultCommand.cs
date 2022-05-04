using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_Vault_Console
{
    class VaultCommand
    {
        public string AddNote => "addnote";
        public string AddAccount => "addaccount";
        public string ReadAll => "readall";
        public string ReadList => "readlist";
        public string Remove => "remove";
        public string Find => "find";
        public string Update => "update";
        public string Generate => "generate";
        public string Exit => "exit";
        public string Help => "help";
    }
}
