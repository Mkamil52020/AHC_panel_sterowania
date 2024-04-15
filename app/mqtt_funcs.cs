using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client.Options;
using MQTTnet.Client;
using MQTTnet.Server;
using Serilog;

namespace AHC.view
{
    public class mqtt
    {
        string temat_mqtt = "ahc_parametry";
        const int liczba_danych = 10; //chyba 10 przesyłanych liczb: 4 palce, 2x3osie
        //private static int MessageCounter = 0;
        private static int numer_portu = 2137;
        //static float[] posortowane_dane = new float[liczba_danych]; //tablica przechowująca dane z *surowe_dane* ale przekonwertowane do int
        //static string[] surowe_dane = new string[liczba_danych]; //tablica przechowując dane ze zmiennej odebrane dane jako string
        //static string odebrane_dane;// = "1;6;7;0;9;6;4;3;6;2";
       

        public static void Serwer()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            MqttServerOptionsBuilder options = new MqttServerOptionsBuilder()
                .WithDefaultEndpoint()
                .WithDefaultEndpointPort(numer_portu)
                .WithConnectionValidator(Nowe_polaczenie)
                .WithApplicationMessageInterceptor(Nowa_wiadomosc);


            IMqttServer mqttServer = new MqttFactory().CreateMqttServer();

            mqttServer.StartAsync(options.Build()).GetAwaiter().GetResult();

        }

        public static async Task Klient(string odebrane_dane)
        {
            var factory = new MqttFactory();
            var client = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("localhost", numer_portu) // ustaw adres i port brokera
                .Build();

            await client.ConnectAsync(options);
            Console.WriteLine("Połączono z serwerem!");

            // subskrybuj temat "ahc_parametry"

            while (true)
            {

                await client.SubscribeAsync("ahc_parametry");
                client.UseApplicationMessageReceivedHandler(e =>
                {
                    var odbior = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                    string ostatni_pakiet = odbior;
                    odebrane_dane = odbior;
                    Console.WriteLine($"Otrzymano wiadomość na temat {e.ApplicationMessage.Topic}: {odbior}");
                    //if (ostatni_pakiet == odbior) { Sort_danych(posortowane_dane, surowe_dane, odebrane_dane); }//jesli odebrnano nowe dane, automatycznie aktualizowane są tablice
                });



            }
        }

        // zakończ połączenie
        //await client.DisconnectAsync();//to się nigdy nie wykona, jest po pętli while(true)


        public static void Nowe_polaczenie(MqttConnectionValidatorContext context)
        {
            Log.Logger.Information(
                    "Nowe urządzenie: ID: {clientId}",
                    context.ClientId,
                    context.Endpoint,
                    context.CleanSession);
        }

        public static void Nowa_wiadomosc(MqttApplicationMessageInterceptorContext context)
        {
            var odebrane_dane = context.ApplicationMessage?.Payload == null ? null : Encoding.UTF8.GetString(context.ApplicationMessage?.Payload);

            //MessageCounter++;

            /* informacje o nowej wiadomości
            Log.Logger.Information(
                "",
                MessageCounter,
                DateTime.Now,
                context.ClientId,
                context.ApplicationMessage?.Topic, odebrane_dane,
                context.ApplicationMessage?.QualityOfServiceLevel,
                context.ApplicationMessage?.Retain);
            */
            //Console.WriteLine(odebrane_dane);



        }
        /*
        public static void Sort_danych(float[] posortowane_dane, string surowe_dane, string odebrane_dane, string dane_str)
        {
            /*
            ładne posortowanie danych do tablicy

            

            //string dane_temp = new string(odebrane_dane); // Konwertuj tablicę char na string
            
            dane_str = new string(odebrane_dane);

            Console.WriteLine(dane_str);

            for (int i = 0; i < liczba_danych; i++)
            {
                //posortowane_dane[i] = int.Parse(dane_str[i]);
            }

            // wyświetl wynik (opcjonalnie, tutaj dla testu czy dobrze sortuje)
            Console.WriteLine("Posortowane dane: ");
            foreach (int num in posortowane_dane)
            {
                Console.Write(num + " | ");
            }
            Console.WriteLine("");
        }
*/
    }
}
