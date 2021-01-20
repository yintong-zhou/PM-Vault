using System.Collections.Generic;

namespace PM_Vault_Console
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MasterPassword { get; set; }
        public List<Vault> Vault { get; set; }
    }
}
