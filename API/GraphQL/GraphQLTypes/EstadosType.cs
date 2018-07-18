using API.Models;
using GraphQL.Types;
using static API.Models.EstadosRoot;

namespace API.GraphQL.GraphQLTypes
{
    public class EstadosType : ObjectGraphType<Estado>
    {
        public EstadosType()
        {
            Field(x => x.Nome).Description("Nome do Estado");
            Field(x => x.Sigla).Description("Sigla da Cidade");
            Field(x => x.Cidades).Description("Lista de Cidades");
        }
    }
}
