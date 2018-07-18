using API.GraphQL.ModelQuery;
using API.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class EstadosController : Controller
    {
        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                var dados = getJson();
                return Json(dados);
            }
            catch (Exception ex)
            {
                return Json($"Erro: {ex.InnerException}");
            }
        }

        // POST api/values
        [HttpPost]
        public JsonResult GetEstados([FromBody] GraphQLQuery query)
        {
            try
            {
                // efetua a busca dos banners utilizado o filtro de dados
                var content = GetByGraphQLAsync(query);
                return Json(content);
            }
            catch (System.Exception ex)
            {
                return Json($"Erro: {ex.InnerException}");
            }

        }

        private async Task<ExecutionResult> GetByGraphQLAsync(GraphQLQuery query)
        {
            try
            {
                var json = getJson();
                var content = JsonConvert.DeserializeObject<EstadosRoot>(json);
                var estados = content.Estados.ToList();

                var schema = new Schema { Query = new EstadoQuery(estados) };

                return await new DocumentExecuter().ExecuteAsync(_ =>
                {
                    _.Schema = schema;
                    _.Query = query.Query;

                }).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string getJson()
        {
            var fullyQualifiedName = $"wwwroot/data/estados-cidades.json";
            var json = new StringBuilder();

            using (StreamReader sr = System.IO.File.OpenText(fullyQualifiedName))

            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    json.Append(s);
                }
            }

            return json.ToString();
        }

    }
}
