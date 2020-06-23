using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace TaskForTGWCSharp
{
    class Program
    {
        public static int layer { get; private set; }

        static void Main(string[] args)
        {
            Parameters parameters = new Parameters();
            layer = -1;

            ReadConfig("Base_Config.txt", parameters);

            int wrongCommand = 0;
            while (true)
            {
                Console.Write("Type the command: ");
                string command = Console.ReadLine();
                if(command.Equals("exit"))
                {
                    wrongCommand = 0;
                    Console.WriteLine("Program is closing");
                    break;
                }
                else if(command.Equals("help"))
                {
                    wrongCommand = 0;
                    Console.WriteLine("All commands list:");
                    Console.WriteLine("exit - for closing program");
                    Console.WriteLine("\"configId\" - for printing that \"configId\" current value");
                    Console.WriteLine("request all available config-values - for printing all available config-values");
                    Console.WriteLine("read second layer");
                    Console.WriteLine("results");
                }
                else if (IsItConfigId(command, parameters))
                {
                    wrongCommand = 0;
                    if (command.Equals("OrdersPerHour"))
                    {
                        if (parameters.IsOrdersPerHourAvailable())
                        {
                            Console.WriteLine("OrdersPerHour:" + parameters.OrdersPerHour);
                        }
                        else
                        {
                            Console.WriteLine("ConfigId:\"" + command + "\" is not available");
                        }
                    }
                    else if (command.Equals("OrderLinesPerOrder"))
                    {
                        if (parameters.IsOrderLinesPerOrderAvailable())
                        {
                            Console.WriteLine("OrderLinesPerOrder:" + parameters.OrderLinesPerOrder);
                        }
                        else
                        {
                            Console.WriteLine("ConfigId:\"" + command + "\" is not available");
                        }
                    }
                    else if (command.Equals("InboundStrategy"))
                    {
                        if (parameters.IsInboundStrategyAvailable())
                        {
                            Console.WriteLine("InboundStrategy:" + parameters.InboundStrategy);
                        }
                        else
                        {
                            Console.WriteLine("ConfigId:\"" + command + "\" is not available");
                        }
                    }
                    else if (command.Equals("NumberOfAisles"))
                    {
                        if (parameters.IsNumberOfAislesAvailable())
                        {
                            Console.WriteLine("NumberOfAisles:" + parameters.NumberOfAisles);
                        }
                        else
                        {
                            Console.WriteLine("ConfigId:\"" + command + "\" is not available");
                        }
                    }
                    else if (command.Equals("PowerSupply"))
                    {
                        if (parameters.IsPowerSupplyAvailable())
                        {
                            Console.WriteLine("PowerSupply:" + parameters.PowerSupply);
                        }
                        else
                        {
                            Console.WriteLine("ConfigId:\"" + command + "\" is not available");
                        }
                    }
                    else if (command.Equals("ResultStartTime"))
                    {
                        if (parameters.IsResultStartTimeAvailable())
                        {
                            Console.WriteLine("ResultStartTime:" + parameters.ResultStartTime);
                        }
                        else
                        {
                            Console.WriteLine("ConfigId:\"" + command + "\" is not available");
                        }
                    }
                    else if(command.Equals("ResultInterval"))
                    {
                        if (parameters.IsResultIntervalAvailable())
                        {
                            Console.WriteLine("ResultInterval:" + parameters.ResultInterval);
                        }
                        else
                        {
                            Console.WriteLine("ConfigId:\"" + command + "\" is not available");
                        }
                    }
                }
                else if (command.Equals("request all available config-values"))
                {
                    wrongCommand = 0;
                    PrintAllAvailableParameters(parameters);
                }
                else if (command.Equals("read second layer"))
                {
                    wrongCommand = 0;
                    ReadConfig("Project_Config.txt", parameters);
                }
                else if (command.Equals("results"))
                {
                    wrongCommand = 0;
                    PrintAllAvailableParameters(parameters);
                }
                else
                {
                    Console.WriteLine("No such command or config-id: " + command);
                    wrongCommand++;
                    if(wrongCommand >= 3)
                    {
                        Console.WriteLine("If you need help with commands, type \"help\"");
                    }
                }
            }
        }

        static void ReadConfig(string file, Parameters p)
        {
            layer++;
            if (layer == 0)
            {
                Console.WriteLine("- " + file + "//base-layer (0) containing the default config");
            }
            else
            {
                Console.WriteLine("- " + file + "//layer " + layer + " containing the project specific config which may overwrite the default config");
            }

            string line;
            StreamReader configReader = new StreamReader(file);
            while ((line = configReader.ReadLine()) != null)
            {
                int index = line.IndexOf(":\t");
                if (index > 0)
                {
                    string parameterId = line.Substring(0, index);
                    string parameterValue = line.Substring(index);
                    parameterValue = parameterValue.Replace(":\t", "");
                    parameterValue = parameterValue.Replace("\t", "");
                    int indexOfComments = parameterValue.IndexOf("//");
                    if(indexOfComments > 0)
                    {
                        parameterValue = parameterValue.Substring(0, indexOfComments);
                    }
                    Console.WriteLine(parameterId + ": " + parameterValue);

                    if(parameterId.Equals("ordersPerHour"))
                    {
                        p.OrdersPerHour = Int32.Parse(parameterValue);
                        p.OrdersPerHourLayer = layer;
                    }
                    else if (parameterId.Equals("orderLinesPerOrder"))
                    {
                        p.OrderLinesPerOrder = Int32.Parse(parameterValue);
                        p.OrderLinesPerOrderLayer = layer;
                    }
                    else if (parameterId.Equals("inboundStrategy"))
                    {
                        p.InboundStrategy = parameterValue;
                        p.InboundStrategyLayer = layer;
                    }
                    else if (parameterId.Equals("numberOfAisles"))
                    {
                        p.NumberOfAisles = Int32.Parse(parameterValue);
                        p.NumberOfAislesLayer = layer;
                    }
                    else if (parameterId.Equals("powerSupply"))
                    {
                        p.PowerSupply = parameterValue;
                        p.PowerSupplyLayer = layer;
                    }
                    else if (parameterId.Equals("resultStartTime"))
                    {
                        p.ResultStartTime = TimeSpan.Parse(parameterValue);
                        p.ResultStartTimeLayer = layer;
                    }
                    else if (parameterId.Equals("resultInterval"))
                    {
                        p.ResultInterval = Int32.Parse(parameterValue);
                        p.ResultIntervalLayer = layer;
                    }
                    else
                    {
                        Console.WriteLine("Config-id: \"" + parameterId + "\" is not defined with value:" + parameterValue);
                    }
                }
            }
        }

        static void PrintAllAvailableParameters(Parameters p)
        {
            Console.WriteLine("All available parameters values:");
            if(p.IsOrdersPerHourAvailable())
            {
                Console.WriteLine("OrdersPerHour: " + p.OrdersPerHour + "\t\t//taken from layer " + p.OrderLinesPerOrderLayer);
            }
            else
            {
                Console.Write("OrdersPerHour: Error" + "\t\t//could not be fount in layer " + layer);
                for(int i=layer-1; i>= 0; i--)
                {
                    Console.Write("," + i);
                }
                Console.WriteLine(". => No value available to be set. => Error");
            }

            if (p.IsOrderLinesPerOrderAvailable())
            {
                Console.WriteLine("OrderLinesPerOrder:" + p.OrderLinesPerOrder + "\t\t//taken from layer " + p.OrderLinesPerOrderLayer);
            }
            else
            {
                Console.Write("OrderLinesPerOrder: Error" + "\t\t//could not be fount in layer " + layer);
                for (int i = layer-1; i >= 0; i--)
                {
                    Console.Write("," + i);
                }
                Console.WriteLine(". => No value available to be set. => Error");
            }

            if (p.IsInboundStrategyAvailable())
            {
                Console.WriteLine("InboundStrategy:" + p.InboundStrategy + "\t\t//taken from layer " + p.InboundStrategyLayer);
            }
            else
            {
                Console.Write("InboundStrategy: Error" + "\t\t//could not be fount in layer " + layer);
                for (int i = layer-1; i >= 0; i--)
                {
                    Console.Write("," + i);
                }
                Console.WriteLine(". => No value available to be set. => Error");
            }

            if (p.IsNumberOfAislesAvailable())
            {
                Console.WriteLine("NumberOfAisles:" + p.NumberOfAisles + "\t\t//taken from layer " + p.NumberOfAislesLayer);
            }
            else
            {
                Console.Write("NumberOfAisles: Error" + "\t\t//could not be fount in layer " + layer);
                for (int i = layer-1; i >= 0; i--)
                {
                    Console.Write("," + i);
                }
                Console.WriteLine(". => No value available to be set. => Error");
            }

            if (p.IsPowerSupplyAvailable())
            {
                Console.WriteLine("PowerSupply:" + p.PowerSupply + "\t\t//taken from layer " + p.PowerSupplyLayer);
            }
            else
            {
                Console.Write("PowerSupply: Error" + "\t\t//could not be fount in layer " + layer);
                for (int i = layer-1; i >= 0; i--)
                {
                    Console.Write("," + i);
                }
                Console.WriteLine(". => No value available to be set. => Error");
            }

            if (p.IsResultStartTimeAvailable())
            {
                Console.WriteLine("ResultStartTime:" + p.ResultStartTime + "\t\t//taken from layer " + p.ResultStartTimeLayer);
            }
            else
            {
                Console.Write("ResultStartTime: Error" + "\t\t//could not be fount in layer " + layer);
                for (int i = layer-1; i >= 0; i--)
                {
                    Console.Write("," + i);
                }
                Console.WriteLine(". => No value available to be set. => Error");
            }

            if (p.IsResultIntervalAvailable())
            {
                Console.WriteLine("ResultInterval:" + p.ResultInterval + "\t\t//taken from layer " + p.ResultIntervalLayer);
            }
            else
            {
                Console.Write("ResultInterval: Error" + "\t\t//could not be fount in layer " + layer);
                for (int i = layer-1; i >= 0; i--)
                {
                    Console.Write("," + i);
                }
                Console.WriteLine(". => No value available to be set. => Error");
            }

            Console.WriteLine("All available parameters printed");
        }

        static bool IsItConfigId(string givenId, Parameters p)
        {
            if(p.ConfigIds.Contains(givenId))
            {
                return true;
            }
            return false;
        }
    }
}
