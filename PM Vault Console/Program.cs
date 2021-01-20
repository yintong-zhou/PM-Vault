using System;
using static System.Console;
using System.IO;

namespace PM_Vault_Console
{
    class Program
    {
       
        static void Main(string[] args)
        {
            VaultHelper h = new VaultHelper();
            VaultManagement m = new VaultManagement();
            HiddenPassword p = new HiddenPassword();
            string nL = Environment.NewLine;

            // title
            h.ShowTitle();

            LOGIN:
            Write(nL + "Username: ");
            string username = ReadLine();
            Write("Password: ");
            string password = p.Password();

            h.LoadingInfo();

            bool UserPermission = false;

            if (!h.ConfigFileExists(h.localFileName))
                UserPermission = h.UserControl(username, password, true);
            else UserPermission = h.UserControl(username, password);

            if (!UserPermission)
            {
                WriteLine("User is not authenticated.");
                goto LOGIN;
            }
            else
            {
                START:
                Write(Environment.NewLine + "Enter comand: ");
                string cmd = ReadLine();
                if(cmd == "addaccount")
                {
                    WriteLine("$(Write in this order: title, username, password, comment)");
                    Write("> ");
                    string title = ReadLine();
                    m.AddAccount($"{h.programPath}\\{h.localFileName}", password, title);
                    goto START;
                }
                if (cmd == "addnote")
                {
                    WriteLine("$(Write in this order: title, comment)");
                    Write("> ");
                    string title = ReadLine();
                    m.AddNote($"{h.programPath}\\{h.localFileName}", password, title);
                    goto START;
                }
                else if(cmd == "readall")
                {
                    m.ReadAll($"{h.programPath}\\{h.localFileName}", password);
                }
                else if (cmd == "readlist")
                {
                    m.ReadList($"{h.programPath}\\{h.localFileName}", password);
                }
                else if(cmd.StartsWith("remove"))
                {
                    var name = cmd.Split(' ');
                    if (name.Length > 1)
                    {
                        string removeName = name[1];
                        m.Remove($"{h.programPath}\\{h.localFileName}", password, removeName);
                    }
                    else 
                    {
                        WriteLine("Write like: remove %NAME%");
                        goto START;
                    }
                }
                else if (cmd.StartsWith("find"))
                {
                    var name = cmd.Split(' ');
                    if (name.Length > 1)
                    {
                        string findName = name[1];
                        m.Find($"{h.programPath}\\{h.localFileName}", password, findName);
                    }
                    else
                    {
                        WriteLine("Write like: find %NAME%");
                        goto START;
                    }
                }
                else if (cmd.StartsWith("update"))
                {
                    var name = cmd.Split(' ');
                    if (name.Length > 1)
                    {
                        string updateName = name[1];
                        m.Update($"{h.programPath}\\{h.localFileName}", password, updateName);
                    }
                    else
                    {
                        WriteLine("Write like: update %NAME%");
                        goto START;
                    }
                }
                else if (cmd.StartsWith("generate"))
                {
                    var item = cmd.Split(' ');
                    try
                    {
                        int length = int.Parse(item[1]);
                        m.GeneratePwd(length);
                        goto START;
                    }
                    catch
                    {
                        WriteLine("Number length is not valid");
                    }
                }
                else if (cmd == "exit")
                {
                    Environment.Exit(0);
                }
                else if (cmd == "help")
                {
                    h.ShowHelp();
                }
                else WriteLine("Comand is not valid.");

                goto START;
            }
        }
    }
}
