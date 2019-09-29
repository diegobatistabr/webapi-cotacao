using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace seguradora.domain.ExternalServices
{
    public class Cidades : ICidades
    {
        private HttpClient _cidade;

        public Cidades(HttpClient cidade)
        {
            _cidade = cidade;
        }

        public CidadesAPI ObterTodas()
        {
            HttpResponseMessage response = _cidade.GetAsync("https://www.redesocialdecidades.org.br/cities").Result;

            CidadesAPI retorno = new CidadesAPI();

            if (response.StatusCode == HttpStatusCode.OK) 
                return  JsonConvert.DeserializeObject<CidadesAPI>(response.Content.ReadAsStringAsync().Result);           
            else
                return retorno;
        }
        
        public class CidadesAPI
        {
            public List<Cidades> cities { get; set; }
            public class Cidades
            {
                public string longitude { get; set; }
                public string name_uri { get; set; }
                public string name { get; set; }
                public string uf { get; set; }
                public string pais { get; set; }
                public object summary { get; set; }
                public string latitude { get; set; }
                public int id { get; set; }
            }
        }
    }
}
