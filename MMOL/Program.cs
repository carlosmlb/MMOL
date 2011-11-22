// Need to add the following References if using VC# 2008:
// OpenMetaverse, OpenMetaverseTypes, System
// These can be found in your opensim\bin folder
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using OpenMetaverse;
using OpenMetaverse.Packets;
using System.Net;
using System.Xml.Linq;

namespace MMOL
{
    class MMOL
    {

        //REQUIERE log4net DEBUG NET/1.1
        private static HashSet<string> nearUsers = new HashSet<string>();

        public static void Main()
        {
            // Enter the region name where the bot will log in
            LanguageBot bot = new LanguageBot();
            /*bot.FirstName = "Mr";
            bot.LastName = "Bot";
            bot.Password = "bot";
            bot.Region = "SLROUTE";
            bot.ServerUrl = "http://localhost:9000";
            bot.Position = new Vector3(128, 128, 22);*/

            bot.LoadConfig("Resources/config.xml");

            bot.Initialize();

            bot.Connect();
        }

        /*
        static void Self_ChatFromSimulator(object sender, ChatEventArgs e)
        {
            if (e.SourceType == ChatSourceType.Agent && e.Type == ChatType.Normal && e.SourceID != client.Self.AgentID)
            {
                {
                    Console.WriteLine("Generando nombre random...");

                    string randomName = GetRandomNameDifferentFrom(e.FromName);

                    Console.WriteLine("Nombre random: " + randomName);

                    if (!"".Equals(randomName))
                        client.Self.Chat("Está cerca tu colega " + randomName, 0, ChatType.Whisper);
                }
            }
        }

        public static string GetRandomNameDifferentFrom(string name)
        {
            List<string> users = new List<string>(nearUsers);

            users.Remove(name);

            if (users.Count == 0) return "";

            Random random = new Random();

            return users[random.Next(users.Count)];
        }

        static void Objects_TerseObjectUpdate(object sender, TerseObjectUpdateEventArgs e)
        {
            if (!e.Update.Avatar) { return; }
            Avatar av;
            client.Network.CurrentSim.ObjectsAvatars.TryGetValue(e.Update.LocalID, out av);
            if (av == null) return;

            if (av.Name.Equals(full_name)) return;

            if (Vector3.Distance(av.Position, startLoc) < 6)
                nearUsers.Add(av.Name);
            else
                nearUsers.Remove(av.Name);

            //Console.WriteLine(av.Name + " esta " + (nearUsers[av.Name] ? "cerca" : "lejos"));
        }
         * 
         */

    }
}