using System;
using GraphWebApp.Models.AccountViewModels;
using GraphWebApp.Models.GraphModels;
using Neo4j.AspNet.Identity.Core;
using Neo4jClient;

namespace GraphWebApp.Services
{
    public interface INeo4jService
    {
        void CreatePersonAndRelate(RegisterViewModel user);
    }

    public class Neo4jService:INeo4jService
    {
        private IGraphClient _client;
        public Neo4jService(IGraphClient client)
        {
            _client = client;
        }

        public void CreatePersonAndRelate(RegisterViewModel applicationUser)
        {
            var person = new Person();
            person.FullName = applicationUser.FullName;
            _client.Cypher.Match("(login:User)").Where((ApplicationUser login) => login.Email == applicationUser.Email)
                   .Create("(p:Person {newPerson})-[:LOGS_IN_WITH]->(login)").WithParam("newPerson", person).ExecuteWithoutResults();
        }
    }
}
