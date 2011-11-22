using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using OpenMetaverse;
using System.Xml.Linq;
using MMOL.Bot;
using MMOL.Events;

namespace MMOL
{
    /// <summary>
    /// Bot that makes language-related operations with the user.
    /// </summary>
    class LanguageBot : BotBase
    {
        private Dictionary<string, int> knownUsers = new Dictionary<string, int>();

        public override void Initialize()
        {
            base.Initialize();

            //Add some actions
            RegisterChatAction("Hola", new EventHandler<ChatActionEventArgs>(GreetingHandler));
            RegisterChatAction("Analiza", new EventHandler<ChatActionEventArgs>(AnalyseHandler));
            RegisterChatAction("Invierte", new EventHandler<ChatActionEventArgs>(ReverseHandler));
            RegisterChatAction("Traduce", new EventHandler<ChatActionEventArgs>(TranslateHandler));
        }

        /// <summary>
        /// Handler for greeting message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GreetingHandler(object sender, ChatActionEventArgs e)
        {
            if (knownUsers.ContainsKey(e.FromName))
                knownUsers[e.FromName]++;
            else
                knownUsers[e.FromName] = 1;

            Client.Self.Chat("Hola por " + knownUsers[e.FromName] + "ª vez, " + e.FromName + "!", 0, ChatType.Whisper);
        }

        /// <summary>
        /// Handler for "reverse sentence" message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReverseHandler(object sender, ChatActionEventArgs e)
        {
            Client.Self.Chat("Voy a dar la vuelta a tu frase con una aplicación web. Conectando...", 0, ChatType.Whisper);

            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_ReverseDownloadStringCompleted);
            webClient.DownloadStringAsync(new Uri("http://www.ieru.org/projects/mmol/reverse.php?phrase=" + Uri.EscapeUriString(e.Message.Replace("Invierte ", ""))));
        }

        /// <summary>
        /// Handler for "analyse" message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnalyseHandler(object sender, ChatActionEventArgs e)
        {
            Client.Self.Chat("Voy a analizar tu frase. Conectando...", 0, ChatType.Whisper);

            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_OpenNLPDownloadStringCompleted);
            webClient.DownloadStringAsync(new Uri("http://localhost:8080/OpenSimNLP/OpenNLP?phrase=" + Uri.EscapeUriString(e.Message.Replace("Analiza ", ""))));
        }

        /// <summary>
        /// Handler for "translate" message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TranslateHandler(object sender, ChatActionEventArgs e)
        {
            Client.Self.Chat("Voy a traducir tu frase. Conectando...", 0, ChatType.Whisper);

            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_TranslationDownloadStringCompleted);
            webClient.DownloadStringAsync(new Uri("http://api.microsofttranslator.com/V2/Http.svc/Translate?"
                + "appId=5F1D586DEE19CCA530C52B5BA70F57800BAAC2F9"
                + "&text=" + Uri.EscapeUriString(e.Message.Replace("Traduce ", ""))
                + "&from=en"
                + "&to=es"));
        }

        /// <summary>
        /// Handler for reverse action completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webClient_ReverseDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Client.Self.Chat("Este es el resultado: \"" + e.Result + "\"", 0, ChatType.Whisper);
        }

        /// <summary>
        /// Handler for analyse action completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webClient_OpenNLPDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null) return;

            Client.Self.Chat("Este es el resultado:", 0, ChatType.Whisper);
            string trimmedResult = e.Result.Trim();
            string[] sentences = trimmedResult.Split('\n');
            foreach (string s in sentences)
                Client.Self.Chat(s, 0, ChatType.Whisper);

        }

        /// <summary>
        /// Handler for translate action completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webClient_TranslationDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null) return;

            Client.Self.Chat("Este es el resultado:", 0, ChatType.Whisper);
            XDocument doc = XDocument.Parse(e.Result);

            string t = doc.Root.Value;

            Client.Self.Chat(t, 0, ChatType.Whisper);
        }
    }
}
