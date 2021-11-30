using DemoApp.Models;

namespace DemoApp.GraphQL
{
    public class Subscription
    {
        [Subscribe, Topic]
        public Author OnAuthorAdded([EventMessage] Author author) => author;
    }
}
