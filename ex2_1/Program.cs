using System.Text.Json;
using System.Net;

namespace ex2_1
{
    public class Prog
    {
        public static void CreateResultFile(List<string> result)
        {
            string fileName = "result.json";
            string jsonString = JsonSerializer.Serialize(result);
            File.WriteAllText(fileName, jsonString);
        }
        public struct ItemsOfPermutation
        {
            public string source;
            public int permutationCounter;
            public int itemOfUsedPermutation;
        }
        public static ItemsOfPermutation HasReplacement(string message, string[,] replacement)
        {
            var itemOfPermutation = new ItemsOfPermutation();
            int i = replacement.Length / 2 - 1;
            while (i >= 0)
            {
                if (message.IndexOf(replacement[i, 0]) != -1)
                {
                    itemOfPermutation.source = replacement[i, 1];
                    itemOfPermutation.permutationCounter++;
                    itemOfPermutation.itemOfUsedPermutation = i;
                    i = -1;
                }
                i--;
            }
            return itemOfPermutation;
        }
        public static string MessageCorrection(string message, string[,] replacement)
        {
            bool flagPermutation = true;
            while (flagPermutation)
            {
                ItemsOfPermutation itemOfPermutation = HasReplacement(message, replacement);
                if (itemOfPermutation.permutationCounter == 0)
                    flagPermutation = false;
                else if (itemOfPermutation.source != null)
                    message = message.Replace(replacement[itemOfPermutation.itemOfUsedPermutation, 0],
                                              replacement[itemOfPermutation.itemOfUsedPermutation, 1]);
                else
                {
                    flagPermutation = false;
                    message = null;
                };
            }
            return message;
        }
        public static List<string> ListOfMessagesCorrection(List<string> messages, string[,] replacement)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < messages.Count; i++)
            {
                string message = MessageCorrection(messages[i], replacement);
                if (message != null)
                    result.Add(message);
            }
            return result;
        }
        public static string[,] GetReplacement()
        {
            return new string[,] {{ "Ha-haaa, hacked you", "I doubted if I should ever come back" },
                              { "sdshdjdskfm sfjsdif jfjfidjf", "Somewhere ages and ages hence:" },
                              { "1", "l" },
                              { "Emptry... or NOT!", null },
                              { "d12324344rgg6f5g6gdf2ddjf", "wood" },
                              { "Random text, yeeep", "took" },
                              { "Bla-bla-bla-blaaa, just some RANDOM tExT", null },
                              { "parentheses - that is a smart word", "the better claim" },
                              { "sdshdjdskfm sfjsdif jfjfidjf", "Somewhere ages and ages hence:" },
                              { "Emptry... or NOT!", "Had worn" },
                              { "Skooby-dooby-doooo", "knowing how way leads on" },
                              { "sdshdjdskfm sfjsdif jfjfidjf", "Somewhere ages and ages hence:" },
                              { "An other text", null },
                              { "Skooby-dooby-doooo", "knowing how way" }};
        }
        public static List<string>? GetListOfMessages(string json)
        {
            return JsonSerializer.Deserialize<List<string>>(json);
        }
        public static string GetData()
        {
            const string url = "https://raw.githubusercontent.com/thewhitesoft/student-2023-assignment/main/data.json";
            return new WebClient().DownloadString(url);
        }

        public static void Main()
        {
            string data = GetData();
            List<string>? messages = GetListOfMessages(data);
            string[,] replacement = GetReplacement();
            List<string> result = ListOfMessagesCorrection(messages, replacement);

            CreateResultFile(result);
        }
    }
}
