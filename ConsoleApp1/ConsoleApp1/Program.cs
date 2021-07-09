using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TeleprompterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTeleprompter().Wait();
        }
        private static async Task ShowTeleprompter(TelePrompterConfig config)
        {
            var words = ReadFrom("sampleQuotes.txt");
            foreach (var word in words)
            {
                Console.Write(word);
                if (!string.IsNullOrWhiteSpace(word))
                {
                    await Task.Delay(config.DelayInMilliseconds);
                }
            }
            config.SetDone();
        }

        /// <summary>
        /// Reads from file and returns word by word
        /// </summary>
        /// <param name="file">File being read from</param>
        /// <returns>string for each word (or new line)</returns>
        static IEnumerable<string> ReadFrom(string file)
        {
            string line;
            using (var reader = File.OpenText(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var words = line.Split(' ');
                    var lineLength = 0;
                    foreach (var word in words)
                    {
                        yield return word + " ";
                        lineLength += word.Length + 1;
                        if (lineLength > 70)
                        {
                            yield return Environment.NewLine;
                            lineLength = 0;
                        }
                    }
                    yield return Environment.NewLine;
                }
            }
        }

        /// <summary>
        /// Getting the user input to adjust the speed of the teleprompter
        /// </summary>
        /// <param name="config">current configuration of the teleprompter as a TelePrompterConfig object</param>
        /// <returns>Task</returns>
        private static async Task GetInput(TelePrompterConfig config)
        {
            Action work = () =>
            {
                do
                {
                    var key = Console.ReadKey(true);
                    if (key.KeyChar == '>')
                    {
                        config.UpdateDelay(-10);
                    }
                    else if (key.KeyChar == '<')
                    {
                        config.UpdateDelay(10);
                    }
                    else if (key.KeyChar == 'X' || key.KeyChar == 'x')
                    {
                        config.SetDone();
                    }
                } while (!config.Done);
            };
            await Task.Run(work);
        }

        /// <summary>
        /// Overall control to run the telelprompter threads
        /// </summary>
        /// <returns>Task</returns>
        private static async Task RunTeleprompter()
        {
            var config = new TelePrompterConfig();
            var displayTask = ShowTeleprompter(config);
            var speedTask = GetInput(config);
            await Task.WhenAny(displayTask, speedTask);
        }
    }
}
