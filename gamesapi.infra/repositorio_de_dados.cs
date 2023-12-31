﻿using gamesapi.infra.modelo;
using RestSharp;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using RestSharp.Serializers.NewtonsoftJson;
using ZstdSharp.Unsafe;

namespace gamesapi.infra
{
    public class repositorio_de_dados
    {
        public string conn { get; set; }
        public string url { get; set; }

        public int items { get; set; } = 10;

        public repositorio_de_dados(string connectionString)
        {
            
            conn = connectionString;
            url = "https://amiiboapi.com/";
            
        }

        public Amiibo[] GetFiltrado(filter filter)
        {
            var amiibo = new List<Amiibo>();
            var client = new RestClient(url);
            
            var request = new RestRequest("/api/amiibo/",Method.Get);
            request.AddQueryParameter("character",filter.charname);
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var data = JsonConvert.DeserializeObject<RootObject>(response.Content);
                amiibo.AddRange(data.amiibo);
            }

            return amiibo.ToArray();
        }

        /*
        AQUI TEM UM CONTAINER PRONTO COM O MYSQL

        # Pull da imagem:
        docker pull docker.io/library/mysql:5.7

        # Run da imagem
        docker run --name some-mysql -p 3366:3306 -e MYSQL_ROOT_PASSWORD=my-secret-pw -d mysql:5.7

        Dai só acessar e excutar o comando abaixo para criar o schemma e a tabela:

            create schema amiiboo collate utf8mb4_general_ci;

            create table amiibooData
            (
                amiiboSeries VARCHAR(255) null,
                thecharacter VARCHAR(255) null,
                gameSeries VARCHAR(255) null,
                head VARCHAR(255) null,
                image VARCHAR(4000) null,
                name VARCHAR(255) null,
                tail VARCHAR(255) null,
                type VARCHAR(255) null
            );
            create table amiibooLog
            (
                amiiboSeries VARCHAR(255) null,
                thecharacter VARCHAR(255) null,
                gameSeries VARCHAR(255) null,
                head VARCHAR(255) null,
                image VARCHAR(4000) null,
                name VARCHAR(255) null,
                tail VARCHAR(255) null,
                type VARCHAR(255) null,
                searchdata date null
            );

        */
        public bool Save(Amiibooo itens)
        {

            string sqlToInsert =
                $@"insert into amiibooData (amiiboSeries, thecharacter, gameSeries, head, image, name, tail, type) 
                    values ('{itens.amiiboSeries}','{itens.character}','{itens.gameSeries}','{itens.head}','{itens.image}','{itens.name}','{itens.tail}','{itens.type});";
                
            try
            {
                using (MySqlConnection connection = new MySqlConnection(conn))
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sqlToInsert, connection))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
            }
            
           

            return true;
        }

        public Amiibooo[] GetAll()
        {
            List<Amiibooo> retorno = new List<Amiibooo>();

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                connection.Open();

                string query = $"select * from amiibooData";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Amiibooo game = new Amiibooo()
                            {
                                amiiboSeries= reader.GetString("amiiboSeries"),
                                thecharacter= reader.GetString("thecharacter"),
                                gameSeries= reader.GetString("gameSeries"),
                                head= reader.GetString("head"),
                                image= reader.GetString("image"),
                                name= reader.GetString("name"),
                                tail= reader.GetString("tail"),
                                type= reader.GetString("type")
                            };
                            retorno.Add(game);
                        }
                    }
                }
            }
           
            return retorno.ToArray();
        }

        public void TranslateFromAmiiboooList(List<Amiibooo> item, out List<Amiibo> itemOut)
        {
            var retorno = new List<Amiibo>();

            item.ForEach((x) =>
            {
                Amiibo atualizado = new Amiibo();
                TranslateFromAmiibooo(x, out atualizado);
                retorno.Add(atualizado);
            });

            itemOut = retorno;
        }

        public void TranslateFromAmiibooo(Amiibooo item, out Amiibo itemOut)
        {
            var retorno = new Amiibo();

            retorno = item;
            retorno.character = item.thecharacter;

            itemOut = retorno;
        }
        
        public void TranslateToAmiiboooList(List<Amiibo> item, out List<Amiibooo> itemOut)
        {
            var retorno = new List<Amiibooo>();

            item.ForEach((x) =>
            {
                Amiibooo atualizado = new Amiibooo();
                TranslateToAmiibooo(x, out atualizado);
                retorno.Add(atualizado);
            });

            itemOut = retorno;
        }
        
        public void TranslateToAmiibooo(Amiibo item, out Amiibooo itemOut)
        {
            var retorno = new Amiibooo()
            {
                thecharacter  = item.character,
                head = item.head,
                image = item.image,
                gameSeries = item.gameSeries,
                tail = item.tail,
                type = item.type,
                name = item.name,
                amiiboSeries = item.amiiboSeries
            };

            itemOut = retorno;
        }
        
        public Amiibooo[] GetFiltered(string text)
        {
            
            List<Amiibooo> retorno = new List<Amiibooo>();

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                connection.Open();

                string query = $"select * from amiibooData where thecharacter like '%{text}%' or gameSeries like '%{text}%' or name like '%{text}%'";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Amiibooo game = new Amiibooo()
                            {
                                amiiboSeries= reader.GetString("amiiboSeries"),
                                thecharacter= reader.GetString("thecharacter"),
                                gameSeries= reader.GetString("gameSeries"),
                                head= reader.GetString("head"),
                                image= reader.GetString("image"),
                                name= reader.GetString("name"),
                                tail= reader.GetString("tail"),
                                type= reader.GetString("type")
                            };
                            retorno.Add(game);
                        }
                    }
                }
            }
           
            return retorno.ToArray();
        }
        
        
    }
}