using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using static System.Console;
using System.Xml.Schema;
using System.Linq;

namespace PM_Vault_Form
{
    class VaultManagement
    {
        Cryptography crypto = new Cryptography();
        VaultHelper h = new VaultHelper();
        User user = new User();

        public void ShowHelp()
        {
            WriteLine(Environment.NewLine + "addnote : add new note");
            WriteLine("addaccount : add new account");
            WriteLine("readnote : read all notes");
            WriteLine("remove %NAME% : remove an account");
            WriteLine("find %NAME% : find a specific account");
            WriteLine("update %NAME% : update a specific account");
            WriteLine("generate %LENGTH% : generate a random password with specific length");
            WriteLine("exit : close terminal");
        }

        private (JArray, JObject) GetVaultJson(string path, string password)
        {
            // read json and decrypt
            string jsonCrypted = JsonConvert.SerializeObject(user);
            jsonCrypted = File.ReadAllText(path);
            string jsonContent = crypto.DecryptText(jsonCrypted, password);
            JObject resultJson = JObject.Parse(jsonContent);
            JArray vault = (JArray)resultJson["Vault"];

            return (vault, resultJson);
        }

        public void GeneratePwd(int length)
        {
            Random random = new Random();
            const string chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-=[];',./_+{}:";
            var stringChars = new char[length];
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            WriteLine($"Password: {finalString}");
        }

        public void ReadNote(string path, string password)
        {
            try
            {   
                // load json and decrypt
                h.LoadingInfo();
                var vault = GetVaultJson(path, password);

                // check result
                if (vault.Item1.Count < 1)
                {
                    WriteLine("List is empty.");
                }
                else
                {
                    // write result
                    WriteLine($"_____________ LIST BELOW _____________ ");
                    foreach (string data in vault.Item1)
                    {
                        var item = JObject.Parse(data);
                        
                        WriteLine($"Title: {item["Title"]}");
                        WriteLine($"Username: {item["Username"]}");
                        WriteLine($"Password: {item["Password"]}");
                        WriteLine($"Note: {item["Note"]}");
                        WriteLine($"______________________________________");
                    }
                }
            }
            catch(Exception ex)
            {
                h.LogWriter(ex.Message, ex.StackTrace);
            }
        }

        public void AddNote(string path, string password, string vaultContent)
        {
            try
            {
                // split input
                var content = vaultContent.Split(',', ';');

                if (content.Length == 2)
                {
                    // load json and decryt
                    h.LoadingInfo();
                    string jsonCrypted = JsonConvert.SerializeObject(user);
                    jsonCrypted = File.ReadAllText(path);
                    string jsonContent = crypto.DecryptText(jsonCrypted, password);

                    // create new vault obj
                    Vault vault = new Vault()
                    {
                        Title = content[0].Trim(),
                        Note = content[1].Trim()
                    };

                    // insert new vault into Vault Array
                    var newVault = JsonConvert.SerializeObject(vault);
                    JObject jVault = JObject.Parse(jsonContent);
                    JArray item = (JArray)jVault["Vault"];
                    item.Add(newVault);

                    // enrypted and append text
                    jsonCrypted = crypto.EncryptText(jVault.ToString(), password);
                    File.WriteAllText(path, jsonCrypted);
                    WriteLine($"{vaultContent} added successfully.");
                }
                else WriteLine("Syntax error.");
            }
            catch (Exception ex)
            {
                h.LogWriter(ex.Message, ex.StackTrace);
            }
        }

        public void AddAccount(string path, string password, string vaultContent)
        {
            try
            {
                // split input
                var content = vaultContent.Split(',' ,';');

                if (content.Length >= 3)
                {
                    // load json and decryt
                    h.LoadingInfo();
                    string jsonCrypted = JsonConvert.SerializeObject(user);
                    jsonCrypted = File.ReadAllText(path);
                    string jsonContent = crypto.DecryptText(jsonCrypted, password);

                    // create new vault obj
                    Vault vault = new Vault()
                    {
                        Title = content[0].Trim(),
                        Username = content[1].Trim(),
                        Password = content[2].Trim(),
                    };

                    // insert new vault into Vault Array
                    var newVault = JsonConvert.SerializeObject(vault);
                    JObject jVault = JObject.Parse(jsonContent);
                    JArray item = (JArray)jVault["Vault"];
                    item.Add(newVault);

                    // enrypted and append text
                    jsonCrypted = crypto.EncryptText(jVault.ToString(), password);
                    File.WriteAllText(path, jsonCrypted);
                    WriteLine($"{vaultContent} added successfully.");
                }
                else WriteLine("Syntax error.");
            }
            catch(Exception ex)
            {
                h.LogWriter(ex.Message, ex.StackTrace);
            }
        }

        public void Remove(string path, string password, string title)
        {
            try
            {
                // load json and decrypt
                h.LoadingInfo();
                var vault = GetVaultJson(path, password);

                if (vault.Item1.Count > 0)
                {
                    int i = 0;
                    bool removed = false;
                    foreach (string data in vault.Item1)
                    {
                        var item = JObject.Parse(data);
                        if (item["Title"].ToString() == title)
                        {
                            // remove a title
                            vault.Item1.RemoveAt(i);
                            removed = true;

                            // rewrite new json file
                            string jsonCrypted = crypto.EncryptText(vault.Item2.ToString(), password);
                            File.WriteAllText(path, jsonCrypted);
                            WriteLine($"{title} removed successfully.");
                            break;
                        }
                        i++;
                    }

                    if (!removed) WriteLine($"{title} is not exist");
                }
                else WriteLine("List is empty.");
            }
            catch(Exception ex)
            {
                h.LogWriter(ex.Message, ex.StackTrace);
            }
        }

        public void Find(string path, string password, string title)
        {
            try
            {
                // load json and decrypt
                h.LoadingInfo();
                var vault = GetVaultJson(path, password);

                if(vault.Item1.Count > 0)
                {
                    foreach (string data in vault.Item1)
                    {
                        var item = JObject.Parse(data);
                        if (item["Title"].ToString() == title)
                        {
                            WriteLine(Environment.NewLine + $"Title: {item["Title"]}");
                            WriteLine($"Username: {item["Username"]}");
                            WriteLine($"Password: {item["Password"]}");
                            WriteLine($"Note: {item["Note"]}");
                            break;
                        }
                    }
                }
                else WriteLine("List is empty.");
            }
            catch (Exception ex)
            {
                h.LogWriter(ex.Message, ex.StackTrace);
            }
        }

        public void Update(string path, string password, string title)
        {
            try
            {
                // load json and decrypt
                h.LoadingInfo();
                var vault = GetVaultJson(path, password);

                if (vault.Item1.Count > 0)
                {
                    int i = 0;
                    bool updated = false;
                    foreach (string data in vault.Item1)
                    {
                        var item = JObject.Parse(data);
                        if (item["Title"].ToString() == title)
                        {
                            
                            WriteLine(Environment.NewLine + $"Title: {item["Title"]}");
                            WriteLine($"Username: {item["Username"]}");
                            WriteLine($"Password: {item["Password"]}");
                            WriteLine($"Note: {item["Note"]}" + Environment.NewLine);

                            // new data
                            WriteLine("$(Write an empty space to remove the key)");
                            Write("Username: ");
                            string _user = ReadLine();
                            Write("Password: ");
                            string _pass = ReadLine();
                            Write("Node: ");
                            string _note = ReadLine();

                            if (!string.IsNullOrEmpty(_user))
                            {
                                item["Username"] = _user;
                            }

                            if (!string.IsNullOrEmpty(_pass))
                            {
                                item["Password"] = _pass;
                            }

                            if (!string.IsNullOrEmpty(_note))
                            {
                                item["Note"] = _note;
                            }

                            // update a title
                            vault.Item1[i] = $"{item}";
                            updated = true;

                            // rewrite new json file
                            string jsonCrypted = crypto.EncryptText(vault.Item2.ToString(), password);
                            File.WriteAllText(path, jsonCrypted);
                            WriteLine($"{title} updated successfully.");
                            break;
                        }
                        i++;
                    }

                    if (!updated) WriteLine($"{title} is not exist");
                }
                else WriteLine("List is empty.");
            }
            catch(Exception ex)
            {
                h.LogWriter(ex.Message, ex.StackTrace);
            }
        }
    }
}
