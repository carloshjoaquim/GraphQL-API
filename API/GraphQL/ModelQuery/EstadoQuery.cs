using API.GraphQL.GraphQLTypes;
using API.Models;
using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;
using static API.Models.EstadosRoot;

namespace API.GraphQL.ModelQuery
{
    public class EstadoQuery : ObjectGraphType
    {
        public EstadoQuery(List<Estado> estado)
        {
            Field<ListGraphType<EstadosType>>(
              "estado",
              arguments: new QueryArguments(
                  new QueryArgument<StringGraphType> { Name = "id" }),
              resolve: context =>
              {
                  var nomeQ = context.GetArgument<string>("nome");
                  var estadoQ = context.GetArgument<string>("estado");

                  if (nomeQ != null)
                      return estado.Where(x => x.Nome.Equals(nomeQ));
                  if (estadoQ != null)
                      return estado.Where(x => x.Sigla.Equals(estadoQ));
                  else
                      return estado;
              }

            );
        }

    }
}
